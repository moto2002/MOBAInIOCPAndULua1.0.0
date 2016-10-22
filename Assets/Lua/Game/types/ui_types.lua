----------------------------------------------------------
--获取脚本解析类型
local m_Canvas 			= UnityEngine.Canvas.GetClassType()
local m_RectTransform 	= UnityEngine.RectTransform.GetClassType()
local m_InputField 		= UnityEngine.UI.InputField.GetClassType()
local m_Button 			= UnityEngine.UI.Button.GetClassType()
local m_Text 			= UnityEngine.UI.Text.GetClassType()
local m_Image 			= UnityEngine.UI.Image.GetClassType()
local m_RawImage 		= UnityEngine.UI.RawImage.GetClassType()
local m_Mask 			= UnityEngine.UI.Mask.GetClassType()
local m_RectMask2D 		= UnityEngine.UI.RectMask2D.GetClassType()
local m_Toggle 			= UnityEngine.UI.Toggle.GetClassType()
local m_ToggleGroup 	= UnityEngine.UI.ToggleGroup.GetClassType()
local m_Slider 	   		= UnityEngine.UI.Slider.GetClassType()
local m_Scrollbar 	   	= UnityEngine.UI.Scrollbar.GetClassType()
local m_Dropdown 	   	= UnityEngine.UI.Dropdown.GetClassType()
local m_ScrollRect 	   	= UnityEngine.UI.ScrollRect.GetClassType()
local m_Selectable 	   	= UnityEngine.UI.Selectable.GetClassType()
local m_SkillButton     = SkillButton.GetClassType()


-------------获取ui组件
function ui_get_canvas(go)
	local comp = go:GetComponent(m_Canvas)
	return comp
end

function ui_get_rectTransform(go)
	local comp = go:GetComponent(m_RectTransform)
	return comp
end

function ui_get_inputField(go)
	local comp = go:GetComponent(m_InputField)
	return comp
end

function ui_get_btn(go)
	local comp = go:GetComponent(m_Button)
	return comp
end

function ui_get_text(go)
	local comp = go:GetComponent(m_Text)
	return comp
end

function ui_get_image(go)
	local comp = go:GetComponent(m_Image)
	return comp
end

function ui_get_rawImage(go)
	local comp = go:GetComponent(m_RawImage)
	return comp
end

function ui_get_mask(go)
	local comp = go:GetComponent(m_Mask)
	return comp
end

function ui_get_rectMask2D(go)
	local comp = go:GetComponent(m_RectMask2D)
	return comp
end

function ui_get_toggle(go)
	local comp = go:GetComponent(m_Toggle)
	return comp
end

function ui_get_toggleGroup(go)
	local comp = go:GetComponent(m_ToggleGroup)
	return comp
end

function ui_get_slider(go)
	local comp = go:GetComponent(m_Slider)
	return comp
end

function ui_get_scrollbar(go)
	local comp = go:GetComponent(m_Scrollbar)
	return comp
end

function ui_get_dropdown(go)
	local comp = go:GetComponent(m_Dropdown)
	return comp
end

function ui_get_scrollRect(go)
	local comp = go:GetComponent(m_ScrollRect)
	return comp
end

function ui_get_selectable(go)
	local comp = go:GetComponent(m_Selectable)
	return comp
end

function ui_get_transform(go)
	return go.transform
end

function ui_get_skillButton(go)
	local comp = go:GetComponent(m_SkillButton)
	return comp
end

local UI_FUNC_MAP = {
 	cav = ui_get_canvas,
	rec = ui_get_rectTransform,
	inp = ui_get_inputField,
	btn = ui_get_btn,
	txt = ui_get_text,
	img = ui_get_image,
	rim = ui_get_rawImage,
	msk = ui_get_mask,
	r2d = ui_get_rectMask2D,
	tog = ui_get_toggle,
	tgg = ui_get_toggleGroup,
	sli = ui_get_slider,
	scb = ui_get_scrollbar,
	drp = ui_get_dropdown,
	scr = ui_get_scrollRect,
	slc = ui_get_selectable,
	tra = ui_get_transform,
	sbt = ui_get_skillButton,
}

--------------------------------------------------
--obj的前綴代表其掛載的主要腳本的類型
local function getComponent(obj)
	local typeKey = string.sub(obj.name, 1,3)
	typeKey = string.lower(typeKey)
	print("为GO:"..obj.name.."获取组件:"..typeKey)
	--funcMap在all_types里，由於在此之前已經在controlCenter加載進來了
	--所以可以直接使用
	local luaGetComponent = UI_FUNC_MAP[typeKey]
	local component = nil
	if luaGetComponent then
		component = luaGetComponent(obj)
	else
		component = obj.gameObject
		print(component.name)
	end
	return component
end

function GetAllComponents(base_behaviour, objs)
	local cacheComponents = {}
	for name,obj in pairs(objs) do
		cacheComponents[name] = getComponent(obj)
	end

	base_behaviour["cacheComponents"] = cacheComponents
end


