error_controller = newclass(lua_mvc_controller)

local errorPanel
local txt_error
local btn_ensure

function error_controller:awake()
	errorPanel = self.cacheObjs["errorPanel"]
	txt_error = self.cacheComponents["txt_errorInfo"]
	btn_ensure = self.cacheObjs["btn_errorEnsure"]
	errorPanel:SetActive(false)
	ErrorManager.Instance:SetErrorPanel(errorPanel)
end

function errorTrigger(text, func)
	txt_error.text = text
	errorPanel:SetActive(true)
	local function callback()
		errorPanel:SetActive(false)
		ErrorManager.Instance:CurrentErrorHandled()
		if func ~= nil then
			func()
		end
	end
	ui_set_click(btn_ensure, callback)
end