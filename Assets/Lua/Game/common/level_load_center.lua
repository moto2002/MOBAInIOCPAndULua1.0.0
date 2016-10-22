--本脚本控制所有元素的加载
currentUIElements = {}
currentUIElementNames = {}

currentUICtrl = {}
currentUIName  = nil
-------------------------加载方法-------------------------------
function loadLevelUI(levelName)
	currentUIName = get_ui_name_by_scene_name(levelName)
	currentUIElements = {}
	currentUIElementNames = {}
	local cacheElements = get_ui_cfg(levelName)
	local uiElements = {}
	for k,v in pairs(cacheElements) do
		print("cacheElement:"..v["name"])
		table.insert(uiElements, v)
	end
	for k,v in pairs(uiElements) do
		local elementName = string.gsub(v["name"], "用于占位的逗号", ",")
		print(elementName)
		table.insert(currentUIElementNames, elementName)
		load_ui_element(elementName)
	end
end

--当C#里面异步加载界面元素完成后调用此函数，此函数检查是否所有的元素都已加载
--如果所有的元素都已加载，则查找对应的界面控制器，将界面控制器初始化
function ui_loaded(element, elementAssetName)
	if element ~=nil and currentUIElements[elementAssetName] == nil then
		currentUIElements[elementAssetName] = element
		print("UI loaded:"..elementAssetName)
	else
		error("UI加载的结果为空！")
	end
	--如果UI全都已经加载了，那么将当前界面控制器初始化
	if checkIfAllUILoaded() then
		print("all UI loaded")
		currentUICtrl = find_controller_by_name(currentUIName)
		if currentUICtrl == nil then
			local ctrlGO = TransformFinder.Instance:GetTransform(currentUIName).gameObject
			awake(ctrlGO, currentUIName, ctrlGO:GetInstanceID(), nil, nil, nil, nil)
		end
		currentUICtrl = find_controller_by_name(currentUIName)
		currentUICtrl:initItems()
	end
end

--检查是否所有UI元素都已经加载了
function checkIfAllUILoaded()
	for sid,name in pairs(currentUIElementNames) do
		print(name)
		if currentUIElements[name] == nil then
			print(name.."not yet loaded")
			return false
		end
	end
	
	return true
end

--对UI元素表排序的函数
function sortByParentIdAndSiblingId(tableName)
	if a.parentid == b.parentid then
		return a.siblingid < b.siblingid
	else
		return a.parentid < b.parentid
	end
end

