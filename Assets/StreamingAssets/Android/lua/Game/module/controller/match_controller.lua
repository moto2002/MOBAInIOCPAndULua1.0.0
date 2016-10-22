match_controller = newclass(lua_mvc_controller)
local infoPanel
local mask
local createUserPanel
local matchHintPanel
local btn_match
local tog_acceptAI
local tog_acceptPlayer
local txt_matchBtn
local txt_playerName
local inp_name
local btn_create

function match_controller:awake()
end

function match_controller:initItems()
	infoPanel = currentUIElements["assets/dynamicresources/uiprefabs/ui/match_ui/infopanel.prefab"]
	mask = currentUIElements["assets/dynamicresources/uiprefabs/ui/match_ui/mask.prefab"]
	createUserPanel = currentUIElements["assets/dynamicresources/uiprefabs/ui/match_ui/createuserpanel.prefab"]

	matchHintPanel = findChild(infoPanel, "matchHintPanel")
	btn_match = findChild(infoPanel, "btn_match")
	txt_matchBtn = ui_get_text( findChild(btn_match, "txt_matchBtn") )

	txt_playerName = ui_get_text( findChild(infoPanel, "txt_playerName") )

	--tog_acceptAI = findChild(infoPanel, "tog_acceptAI")
	--tog_acceptPlayer = findChild(infoPanel, "tog_acceptPlayer")
	--ui_set_toggle(tog_acceptAI, acceptAIClicked)
	--ui_set_toggle(tog_acceptPlayer, acceptPlayerClicked)

	inp_name = ui_get_inputField(findChild(createUserPanel, "inp_name"))
	btn_create = findChild(createUserPanel, "btn_create")

	closeCreatePanel()
	ui_set_click(btn_match, match_bt_clicked)
	ui_set_click(btn_create, match_create_bt_clicked)

	getAvaliableUser()
end
--進入match或創建角色完畢后，請求可用的角色
function getAvaliableUser()
	if GameData.user == nil then
		mask:SetActive(true)
		net_write(Protocol.TYPE_USER, 0, UserProtocol.GET_CREQ, nil)
	end
end
--刷新角色信息
function refreshInfoPanel()
	if GameData.user ~= nil then
		txt_playerName.text = GameData.user.name.."  等级:"..GameData.user.level
	end
end
--顯示創建角色面板
function showCreateUserPanel()
	mask:SetActive(false)
	createUserPanel:SetActive(true)
	btn_create:SetActive(true)
end
--角色在線，隱藏mask，刷新角色信息
function uiOnUserOnline( ... )
	mask:SetActive(false)
	refreshInfoPanel()
end
--按下匹配按鈕后的功能
function match_bt_clicked()
	if txt_matchBtn.text == "开始排队" then
		txt_matchBtn.text = "取消排队"
		matchHintPanel:SetActive(true)
		net_write(Protocol.TYPE_MATCH, 0, MatchProtocol.ENTER_CREQ, nil)
	else
		txt_matchBtn.text = "开始排队"
		matchHintPanel:SetActive(false)
		net_write(Protocol.TYPE_MATCH, 0, MatchProtocol.LEAVE_CREQ, nil)
	end
end
--創建角色按鈕的功能
function match_create_bt_clicked()
	if string.len(inp_name.text) > 6 or string.IsNullOrEmpty(inp_name.text) then
		local errorModel = ErrorModel.New("名称不合法")
		ErrorManager.Instance:AddError(errorModel)

		return
	end

	btn_create:SetActive(false)
	net_write(Protocol.TYPE_USER, 0, UserProtocol.CREATE_CREQ, inp_name.text)
end
--關閉創建角色面板
function closeCreatePanel()
	createUserPanel:SetActive(false)
end
--打開創建角色面板
function openCreatePanel()
	createUserPanel:SetActive(true)
	btn_create:SetActive(true)
end

--TODO 不用
function acceptAIClicked(isOn)
	if isOn == true then
		net_write(Protocol.TYPE_MATCH, 0, MatchProtocol.ACCEPT_AI_CREQ, nil)
	end
end

--TODO 不用
function acceptPlayerClicked(isOn)
	if isOn == true then
		net_write(Protocol.TYPE_MATCH, 0, MatchProtocol.ACCEPT_PLAYER_CREQ, nil)
	end
end



