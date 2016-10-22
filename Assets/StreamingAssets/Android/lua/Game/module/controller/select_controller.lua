select_controller = newclass(lua_mvc_controller)
heroSelected = false

local heroGrids = {}
local room
local LeftHeroList = {}
local RightHeroList = {}
local selectInitialMask
local selectHerosPanel
local btn_selectEnsure
local HeroGirdBox
local SelectLeftList
local SelectRightList
local btn_SelectHero

local selectUILoaded = "unloaded"


function select_controller:awake()
end

function select_controller:initItems()
	selectUILoaded = "unloaded"
	heroSelected = false
	selectInitialMask = currentUIElements["assets/dynamicresources/uiprefabs/ui/select_ui/initialmask.prefab"]
	selectHerosPanel = currentUIElements["assets/dynamicresources/uiprefabs/ui/select_ui/selectherospanel.prefab"]
	btn_selectEnsure = findChild(selectHerosPanel, "btn_selectEnsure")
	enableEnsureBtn()
	HeroGridBox = findChild(selectHerosPanel, "HeroGirdBox")
	SelectLeftList = currentUIElements["assets/dynamicresources/uiprefabs/ui/select_ui/leftlist.prefab"]
	SelectRightList = currentUIElements["assets/dynamicresources/uiprefabs/ui/select_ui/rightlist.prefab"]
	--TODO 
	btn_SelectHero = load_ui_element_sync("assets/dynamicresources/uiprefabs/uidynamicprefabs/selectherobtn.prefab")
	initialSelectHeroList(btn_SelectHero)

	LeftHeroList = {
		findChild(SelectLeftList, "LeftHeroGrid 1"),
		findChild(SelectLeftList, "LeftHeroGrid 2"),
		findChild(SelectLeftList, "LeftHeroGrid 3"),
		findChild(SelectLeftList, "LeftHeroGrid 4"),
		findChild(SelectLeftList, "LeftHeroGrid 5"),
	}
	LeftHeroList = buildSelectGrids(LeftHeroList)

	RightHeroList = {
		findChild(SelectRightList, "RightHeroGrid 1"),
		findChild(SelectRightList, "RightHeroGrid 2"),
		findChild(SelectRightList, "RightHeroGrid 3"),
		findChild(SelectRightList, "RightHeroGrid 4"),
		findChild(SelectRightList, "RightHeroGrid 5"),
	}
	RightHeroList = buildSelectGrids(RightHeroList)

	ui_set_click(btn_selectEnsure, selectEnsure_bt_clicked)
	selectUILoaded = "loaded"
	net_write(Protocol.TYPE_SELECT, 0, SelectProtocol.ENTER_CREQ, nil)
end
--建立两侧列表的元素索引
function buildSelectGrids(list)
	local cacheList = {}
	
	for i,v in ipairs(list) do
		require("Game/module/model/select_grid")
		local s_grid = newLuaObj("select_grid")
		local headImg = ui_get_image( findChild(v, "HeroImage") )
		local txt_name = ui_get_text( findChild(v, "NameText") )
		local img = ui_get_image(v)

		s_grid:init(headImg, txt_name, img)
		
		cacheList[i] = s_grid
	end
	return cacheList
end
--选择确定按钮按下后的功能,
function selectEnsure_bt_clicked()
	local teamId = room:inTeam(GameData.user.id)
	print(GameData.user.id)
	local selectModel
	if teamId == 1 then
		selectModel = room.teamOne
	else
		selectModel = room.teamTwo
	end
	local last = {}
	local mySelected = false
	for i=0,selectModel.Length - 1 do
		if selectModel[i].heroId ~= -1 then
			if selectModel[i].userId == GameData.user.id then
				mySelected = true
				break
			end
			last[selectModel[i].heroId] = selectModel[i].heroId
		end
	end

	--如果没有选择，则从可选择的列表中随机选择一个
	if not mySelected then
		local temp = {}
		local count = 0
		for i=0,GameData.user.heroList.Count - 1 do
			local unselectedHeroId = GameData.user.heroList[i]
			if last[unselectedHeroId] == nil then
				temp[i + 1] = unselectedHeroId
				count = count + 1
			end
		end
		net_write_int_message(Protocol.TYPE_SELECT, 0, SelectProtocol.SELECT_CREQ, temp[math.ceil(math.Random(1, count))])
	end
	net_write(Protocol.TYPE_SELECT, 0, SelectProtocol.READY_CREQ, nil)
end
--初始化英雄选择列表
function initialSelectHeroList(obj)
	if GameData.user == nil then
		return
	end
	for i=0, GameData.user.heroList.Count - 1 do
		local id = GameData.user.heroList[i]
		local go = newobject(obj)
		local rec = ui_get_rectTransform(go)
		rec:SetParent(HeroGridBox.transform)
		rec.localScale = Vector3.New(1, 1, 1)
		rec.localPosition = Vector3.New(i % 10 * 44 + 25, -(math.ceil((i + 1) / 10) - 1) * 44 + 3)
		require("Game/module/model/hero_grid")
		local h_grid = newLuaObj("hero_grid")
		local sp = resource_loader.GetSprite("assets/dynamicresources/heroicon/"..id..".png")
		h_grid:init(go, id, sp)

		heroGrids[id] = h_grid
	end
end
--刷新可选择的英雄列表
function refreshHeroSelectList(selectRoomDTO)
	room = selectRoomDTO
	local teamId = room:inTeam(GameData.user.id)
	local selected = {}
	if teamId == 1 then
		for i=0,room.teamOne.Length - 1 do
			if room.teamOne[i].heroId ~= -1 then
				selected[room.teamOne[i].heroId] = room.teamOne[i].heroId
			end
		end
	else
		for i=0,room.teamTwo.Length - 1 do
			if room.teamTwo[i].heroId ~= -1 then
				selected[room.teamTwo[i].heroId] = room.teamTwo[i].heroId
			end
		end
	end

	for k,v in pairs(heroGrids) do
		if selected[k] ~= nil or heroSelected then
			heroGrids[k]:deactive()
		else
			heroGrids[k]:active()
		end
 	end

end

--刷新选择界面
function refreshTeamView(selectRoomDTO)
	local teamId = selectRoomDTO:inTeam(GameData.user.id)
	if teamId == 1 then
		for i=0,selectRoomDTO.teamOne.Length - 1 do
			LeftHeroList[i+1]:setData(selectRoomDTO.teamOne[i])
		end
		for j=0,selectRoomDTO.teamTwo.Length - 1 do
			RightHeroList[j+1]:setData(selectRoomDTO.teamTwo[j])
		end	
	elseif teamId == 2 then
		for i=0,selectRoomDTO.teamOne.Length - 1 do
			RightHeroList[i+1]:setData(selectRoomDTO.teamOne[i])
		end
		for j=0,selectRoomDTO.teamTwo.Length - 1 do
			LeftHeroList[j+1]:setData(selectRoomDTO.teamTwo[j])
		end
	end

	refreshHeroSelectList(selectRoomDTO)
end
--打开初始化mask
function activeSelectInitialMask()
	selectInitialMask:SetActive(true)
end
--关闭初始化mask
function closeSelectInitialMask()
	selectInitialMask:SetActive(false)
end
--自身进入匹配房间
function selfEnter(selectRoomDTO)
	closeSelectInitialMask()
	refreshTeamView(selectRoomDTO)
	print("selfEnter")
end
--其他人进入匹配房间
function otherEnter(id)
	if room == nil then
		return
	end

	for i=0,room.teamOne.Length - 1 do
		if room.teamOne[i].userId == id then
			room.teamOne[i].entered = true
			refreshTeamView(room)
			return
		end
	end

	for j=0,room.teamTwo.Length - 1 do
		if room.teamTwo[j].userId == id then
			room.teamTwo[j].entered = true
			refreshTeamView(room)
			return
		end
	end
	print("otherEnter, id:" + id)
end
--一个玩家准备游戏完成
function readyForGame(selectModel)
	if selectModel.userId == GameData.user.id then
		disableEnsureBtn()
	end
	if room:inTeam(selectModel.userId) == 1 then
		for i=0,room.teamOne.Length - 1 do
			if room.teamOne[i].userId == selectModel.userId then
				room.teamOne[i].heroId = selectModel.heroId
				room.teamOne[i].ready = selectModel.ready
			end
		end
	else
		for i=0,room.teamTwo.Length - 1 do
			if room.teamTwo[i].userId == selectModel.userId then
				room.teamTwo[i].heroId = selectModel.heroId
				room.teamTwo[i].ready = selectModel.ready
			end
		end
	end

	refreshTeamView(room)
end
--回到匹配界面
function backToMatch()
	SceneManager.LoadScene(2)
end
--选择英雄失败
function selectHeroFailure()
	ErrorManager.Instance:AddError(ErrorModel.New("选择角色失败，请重新选择"))
end
--英雄选择之后刷新界面
function selectHeroRefresh(selectModel)
	if room:inTeam(selectModel.userId) == 1 then

		for i=0,room.teamOne.Length - 1 do
			if room.teamOne[i].userId == selectModel.userId then
				room.teamOne[i].heroId = selectModel.heroId
			end
		end
	else
		for i=0,room.teamTwo.Length - 1 do
			if room.teamTwo[i].userId == selectModel.userId then
				room.teamTwo[i].heroId = selectModel.heroId
			end
		end
	end

	refreshTeamView(room)
end
--加载战斗场景
function loadFightLevel()
	activeSelectInitialMask()
	SceneLoader.Instance:LoadScene("fightScene4")
end
--选择英雄
function selectHero(id)
	if not heroSelected then
		print("select hero : "..id)
		net_write_int_message(Protocol.TYPE_SELECT, 0, SelectProtocol.SELECT_CREQ, id)
	end
end
--禁用选择确定按钮
function disableEnsureBtn()
	btn_selectEnsure:SetActive(false)
	heroSelected = true
end
--启用选择确定按钮
function enableEnsureBtn()
	btn_selectEnsure:SetActive(true)
	heroSelected = false
end
function isSelectUILoaded()
 	return selectUILoaded
end 