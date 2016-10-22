fight_controller = newclass(lua_mvc_controller)

local topLeft
local topRight
local settings_panel
local mini_map
local m_player_behaviour = PlayerBehaviourFacade.Instance
local m_player_ctrl = PlayerController.Instance
local img_player_head

local button_skills = {
	btn_skill_1,
	btn_skill_2,
	btn_skill_3,
}

local ui_skills = {
	ui_skill_1,
	ui_skill_2,
	ui_skill_3,
}

local button_skillLevelUps = {
	btn_skillLevelUp_1,
	btn_skillLevelUp_2,
	btn_skillLevelUp_3,
}

local skill_button_comps = {
	skill_button_comp1,
	skill_button_comp2,
	skill_button_comp3,
}

function fight_controller:awake()
end

function fight_controller:initItems()
	topLeft = findChild(self.gameObject, "TopLeft")
	topRight = currentUIElements["assets/dynamicresources/uiprefabs/ui/fight_ui/topright.prefab"]
	mini_map = currentUIElements["assets/dynamicresources/uiprefabs/ui/fight_ui/minimapframe.prefab"]
	--TODO 修正
	img_player_head = ui_get_image(findChild(topLeft, "sp_head"))
	self.bottomRight = currentUIElements["assets/dynamicresources/uiprefabs/ui/fight_ui/bottomright.prefab"]

	ui_skills.ui_skill_1 = findChild(self.bottomRight, "btn_skill1")
	ui_skills.ui_skill_2 = findChild(self.bottomRight, "btn_skill2")
	ui_skills.ui_skill_3 = findChild(self.bottomRight, "btn_skill3")

	skill_button_comps[1] = ui_get_skillButton(ui_skills.ui_skill_1)
	skill_button_comps[2] = ui_get_skillButton(ui_skills.ui_skill_2)
	skill_button_comps[3] = ui_get_skillButton(ui_skills.ui_skill_3)

	button_skills.btn_skill_1 = findChild(ui_skills.ui_skill_1, "btn_skill")
	button_skills.btn_skill_2 = findChild(ui_skills.ui_skill_2, "btn_skill")
	button_skills.btn_skill_3 = findChild(ui_skills.ui_skill_3, "btn_skill")

	button_skillLevelUps.btn_skillLevelUp_1 = findChild(ui_skills.ui_skill_1, "btn_update")
	button_skillLevelUps.btn_skillLevelUp_2 = findChild(ui_skills.ui_skill_2, "btn_update")
	button_skillLevelUps.btn_skillLevelUp_3 = findChild(ui_skills.ui_skill_3, "btn_update")

	self.btn_attack = findChild(self.bottomRight, "btn_attack")
	--设置技能和攻击按钮点击事件
	ui_add_normal_click(self.btn_attack, attackBtnPressed)
	ui_set_click(button_skills.btn_skill_1, skill_btn_pressed, 1)
	ui_set_click(button_skills.btn_skill_2, skill_btn_pressed, 2)
	ui_set_click(button_skills.btn_skill_3, skill_btn_pressed, 3)
	--设置 设置界面的按钮点击事件
	settings_panel = currentUIElements["assets/dynamicresources/uiprefabs/ui/fight_ui/settingspanel.prefab"]
	self.btn_settings = findChild(topRight, "settingBtn")
	ui_set_click(self.btn_settings, setting_btn_pressed)
	self.btn_resume = findChild(settings_panel, "btn_resume")
	ui_set_click(self.btn_resume, resume_btn_pressed)
	self.btn_quitGame = findChild(settings_panel, "btn_quitGame")
	ui_set_click(self.btn_quitGame, quit_game_btn_pressed)
	
	--TODO 界面设置完毕后，开始游戏
	net_write(Protocol.TYPE_FIGHT, 0, FightProtocol.ENTER_CREQ, nil)
end

function skill_btn_pressed(index)
	m_player_behaviour:SkillPressed(index)
	skill_button_comps[index]:ColdDown()
end

function setting_btn_pressed()
	settings_panel:SetActive(true)
end

function resume_btn_pressed()
	settings_panel:SetActive(false)
end

function quit_game_btn_pressed()
	Application.Quit()
end

function initPlayerFightUI(model)
	for i,skillBtn in ipairs(skill_button_comps) do
		skillBtn:SetSkill(model.skills[i - 1])
	end
	setPlayerHeadById(model.heroId)
end

function setPlayerHeadById(id)
	img_player_head.sprite = resource_loader.GetSprite("assets/dynamicresources/heroicon/"..id.."_round.png")
end

function refreshSkillUI()
	local playerSkills = m_player_ctrl.Player.skills
	for i=0,playerSkills.Length - 1 do
		skill_button_comps[i + 1]:SetSkill(playerSkills[i])

		if m_player_ctrl.Player.free > 0 and playerSkills[i].nextLevel <=  m_player_ctrl.Player.level then
			skill_button_comps[i + 1]:ShowSkillLevelUpBtn()
		else
			skill_button_comps[i + 1]:HideSkillLevelUpBtn()
		end
	end
end

function attackBtnPressed()
	m_player_behaviour:AttackPressed()
end