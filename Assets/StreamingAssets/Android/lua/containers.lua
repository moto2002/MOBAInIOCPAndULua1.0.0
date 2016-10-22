--===========加载类===========================
local LOAD_LUA_SCRIPT = {
--==============基类加载======================
    "Game/Core/base_behaviour",
    "Game/Core/lua_base_model",
    "Game/Core/lua_view_controller",
    "Game/Core/lua_behaviour",
--==============UI界面相关脚本加载=============
	"Game/Core/view",
--==============UI控制器类加载=================
	"Game/modular/controller/test_controller",
	"Game/modular/controller/main_controller",
--==============资源类加载=================

}




function ContainersInit()
	LoadLuas(LOAD_LUA_SCRIPT)
end
--所有Lua脚本加载
function LoadLuas(LuaList)
	if LuaList ~= nil then
		for k,v in pairs(LuaList) do
				require(v)
			end	
end
