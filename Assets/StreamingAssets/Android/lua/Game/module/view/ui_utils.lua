
--向按钮设置单个事件
function ui_set_click(go, func, param)
	print("####"..go.name.."set Click")
	if param == nil then
		UIutils.Instance:setButtonClick(go, func)
	else
		local function callback()
			func(param) 
		end
		UIutils.Instance:setButtonClick(go, callback)
	end
end

function ui_set_toggle(go, func, params)
	print("####"..go.name.."set Toggle")
	if params == nil then
		UIutils.Instance:setToogleAction(go, func)
	else
		UIutils.Instance:setToogleAction(go, func, params)
	end
end

--向按钮添加一个事件
function ui_add_normal_click(go, action)
	UIutils.Instance:addButtonNormalClick(go, action)
end

function load_ui_element(name)
	UIutils.Instance:LoadUiElement(name)
end

function load_ui_element_sync(name)
	return UIutils.Instance:LoadUiElementSync(name)
end

function get_sprite(name)
	return UIutils.Instance:LoadSprite(name)
end