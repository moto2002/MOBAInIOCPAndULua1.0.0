local register_results = {
	succeed = 0,
	alreadyExisted = -1,
	invalidInfo = -2,
}

local login_results = {
	succeed = 0,
	noAccount = -1,
	alreadyLogin = -2,
	wrongPwd = -3,
	invalidInfo = -4,
}

login_controller = newclass(lua_mvc_controller)

local loginPanel
local registerPanel

local inp_loginAccount
local inp_loginPwd
local btn_enter
local btn_registerPanel

local inp_registerAccount
local inp_registerPwd
local inp_registerPwdAgain
local btn_register                                                                                                                
local btn_registerClose

function login_controller:awake()

end

function login_controller:initItems()
	loginPanel = currentUIElements["assets/dynamicresources/uiprefabs/ui/login_ui/loginpanel.prefab"]
	registerPanel = currentUIElements["assets/dynamicresources/uiprefabs/ui/login_ui/registerpanel.prefab"]

	inp_loginAccount = ui_get_inputField( findChild(loginPanel, "inp_loginAccount") )
	inp_loginPwd = ui_get_inputField( findChild(loginPanel, "inp_loginPwd") )
	btn_enter = findChild(loginPanel, "btn_enter")
	btn_registerPanel = findChild(loginPanel, "btn_registerPanel")

	inp_registerAccount = ui_get_inputField( findChild(registerPanel, "inp_registerAccount") )
	inp_registerPwd = ui_get_inputField(findChild(registerPanel, "inp_registerPwd"))
	inp_registerPwdAgain = ui_get_inputField( findChild(registerPanel, "inp_registerPwdAgain") )
	btn_register = findChild(registerPanel, "btn_register")                                                                                                                    
	btn_registerClose = findChild(registerPanel, "btn_registerClose")

	ui_set_click(btn_enter, login_bt_clicked)
	ui_set_click(btn_registerPanel, register_panel_bt_clicked)
	ui_set_click(btn_registerClose, register_close_bt_clicked)
	ui_set_click(btn_register, register_bt_clicked)
end

function login_bt_clicked()
	local accountStr = inp_loginAccount.text
	local pwdStr = inp_loginPwd.text

	if string.IsNullOrEmpty(accountStr) or string.IsNullOrEmpty(pwdStr) then
		local errorModel = ErrorModel.New("輸入的賬號密碼信息為空")
		ErrorManager.Instance:AddError(errorModel)
		return
	else
		local dto = AccountDTO.New()
		dto.account = accountStr
		dto.password = pwdStr
		net_write(Protocol.TYPE_LOGIN, -1, LoginProtocol.LOGIN_CREQ, dto)
	end
end

function register_bt_clicked()
	local accStr = inp_registerAccount.text
	local pwdStr = inp_registerPwd.text
	local pwdAgainStr = inp_registerPwdAgain.text

	if string.IsNullOrEmpty(accStr) or string.IsNullOrEmpty(pwdStr) then
		local errorModel = ErrorModel.New("輸入的賬號密碼信息為空")
		ErrorManager.Instance:AddError(errorModel)
		return
	end

	if pwdStr ~= pwdAgainStr then
		local errorModel = ErrorModel.New("兩次輸入的密碼不一致")
		ErrorManager.Instance:AddError(errorModel)
		return
	end

	local dto = AccountDTO.New()
	dto.account = accStr
	dto.password = pwdStr
	net_write(Protocol.TYPE_LOGIN, -1, LoginProtocol.CREATE_CREQ, dto)
end

function reset_register_panel()
	inp_registerAccount.text = string.Empty
	inp_registerPwd.text = string.Empty
	inp_registerPwdAgain.text = string.Empty
	btn_register:SetActive(true)
	btn_registerClose:SetActive(true)
end

function register_panel_bt_clicked()
	btn_register:SetActive(true)
	btn_registerClose:SetActive(true)
	registerPanel:SetActive(true)
end

function register_close_bt_clicked()
	registerPanel:SetActive(false)
end

function registerByResult(result)
	local errorModel

	if result == register_results.succeed then
		errorModel = ErrorModel.New("注册成功", register_close_bt_clicked)
	elseif result == register_results.alreadyExisted then
		errorModel = ErrorModel.New("账号已存在", reset_register_panel)
	elseif result == register_results.invalidInfo then
		errorModel = ErrorModel.New("注册信息不合法", reset_register_panel)
	else
		errorModel = ErrorModel.New("未知错误", reset_register_panel)
	end
	ErrorManager.Instance:AddError(errorModel)
end

function loginByResult(result)
	local errorModel = nil

	if result == login_results.succeed then
		SceneManager.LoadScene(2)
	elseif result == login_results.noAccount then
		errorModel = ErrorModel.New("账号不存在")
	elseif result == login_results.alreadyLogin then
		errorModel = ErrorModel.New("账号已登录")
	elseif result == login_results.wrongPwd then
		errorModel = ErrorModel.New("密码错误")
	elseif result == login_results.invalidInfo then
		errorModel = ErrorModel.New("输入不合法")
	else
		errorModel = ErrorModel.New("未知错误")
	end

	if errorModel ~= nil then
		ErrorManager.Instance:AddError(errorModel)
	end
end

