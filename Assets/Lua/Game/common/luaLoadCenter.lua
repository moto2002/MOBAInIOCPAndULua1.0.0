local CONTROL_RELATED_SCRIPTS = {
-----------所有类型加载-------------------------------------
	"Game/types/ui_types",
-----------实用工具加载-------------------------------------
	"Game/module/view/ui_utils",
	"Game/module/net/net_utils",
-----------基类加载-----------------------------------------
	"Game/core/base_behaviour",
	"Game/core/base_model",
	"Game/core/lua_mvc_controller",
	"Game/core/lua_obj_center",
	"Game/common/level_load_center",
-----------？？界面类加载----------------------------------------

-----------？？model类加载---------------------------------------
}

function controllerInit()
	for i,v in ipairs(CONTROL_RELATED_SCRIPTS) do
		require(v)
	end

	loadLevelUI("1_mobile")
end