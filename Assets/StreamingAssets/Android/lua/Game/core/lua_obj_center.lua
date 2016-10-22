--在unity里通过C#脚本LuaInitial.cs传入的对象被集中存储在这里(分为控制器类、数据类、非控制器类)
--可以在这里操作这些对象

--非控制器脚本对象类
local luaObjs = {}
--控制器脚本对象类
local luaControllers = {}
--数据对象类
local luaModels = {}
-----------------------------------------------------------------------

--将视图注册到控制器中，多对一
local VIEW_CONTROL_ENROLL = {
	LOGIN_UI = "login_controller",
	ERROR_PANEL = "error_controller",
	MATCH_UI = "match_controller",
	SELECT_UI = "select_controller",
	FIGHT_UI = "fight_controller",
}

--将数据类注册到控制器中，一对一
local CONTROL_MODEL_ENROLL = {

}

-----------------------------------------------------------------------
--LuaInitial.cs可调用下面这些方法
function awake(gameObject, className, insID, objs, len, prefabs, prefabLen)
---------------缓存传入的objs及prefabs----------------------------------
	local cacheObjs = {}
	if objs ~= nil then
		for i = 0,len - 1 do
			local  obj = objs[i]
			if obj == nil then
				error(gameObject.name.."脚本传入obj为空："..i)
			end
			local objName = string.gsub(obj.name, "%(Clone%)", "")
			print(objName)
			cacheObjs[objName] = obj
		end
	end

	local cachePrefabs = {}
	if prefabs ~= nil then
		for i = 0, prefabLen - 1 do
			local obj = prefabs[i]
			if obj == nil then
				error(gameObject.name.."脚本传入prefab为空："..i)
			end
			cachePrefabs[obj.name] = obj
		end
	end
----------------------------------------------------------------------
	--根据view名查找控制器，并实例化该控制器
	local m_ctrl = VIEW_CONTROL_ENROLL[className]

	--如不存在注册表中，则说明它是一个非控制器类
	if m_ctrl == nil then
		local Obj = newLuaObj(className)
		Obj:init(gameObject, insID, cacheObjs, cachePrefabs)
		luaObjs[insID] = Obj
		Obj:awake()
	else
	    --如存在，说明是控制器类。先到缓存中找该控制器
		local Obj = luaControllers[m_ctrl]
		--缓存中没有，说明需要实例化
		if Obj == nil then
			--先找到或实例化数据类
			local modelName = CONTROL_MODEL_ENROLL[m_ctrl]
			local modelObj = nil
			if modelName ~= nil then
				modelObj = luaModels[modelName]
				if modelObj == nil then
					require("Game/module/model/"..modelName)
					modelObj = newLuaObj(modelName)
					modelObj:init()
					luaModels[modelName] = modelObj
				end
			end
			--实例化控制器类
				require("Game/module/controller/"..m_ctrl)
				Obj = newLuaObj(m_ctrl)
			--将控制器类放入缓存
				luaControllers[m_ctrl] = Obj
			--将model传入控制器并初始化
			if modelObj ~= nil then
				Obj:InitModel(modelObj)
			end
		end
		--初始化控制器
		Obj:NewCtrl(m_ctrl, gameObject, insID, cacheObjs, cachePrefabs)
		--调用控制器的初始化
		Obj:UnityToLuaBehaviour(insID, UNITY_LUA_BEHAVIOUR.Awake)
	end
end

function onEnable(insID, className)
	local luaObj = luaObjs[insID]
	if luaObj ~= nil then
		luaObj:onEnable()
	else
		local name = VIEW_CONTROL_ENROLL[className]
		if name ~= nil and luaControllers[name] ~= nil then
			luaControllers[name]:UnityToLuaBehaviour(insID, UNITY_LUA_BEHAVIOUR.OnEnable)
		else
			error(insID.."  onEnable View "..className.."--------->  没有找到该脚本对象")
		end
	end
end

function start(insID, className)
	local luaObj = luaObjs[insID]
	if luaObj ~= nil then
		luaObj:start()
	else
		local name = VIEW_CONTROL_ENROLL[className]
		if name ~= nil and luaControllers[name] ~= nil then
			luaControllers[name]:UnityToLuaBehaviour(insID, UNITY_LUA_BEHAVIOUR.Start)
		else
			error(insID.."  start View "..className.."--------->  没有找到该脚本对象")
		end
	end
end

function onDisable(insID, className)
	local luaObj = luaObjs[insID]
	if luaObj ~= nil then
		luaObj:onDisable()
	else
		local name = VIEW_CONTROL_ENROLL[className]
		if name ~= nil and luaControllers[name] ~= nil then
			luaControllers[name]:UnityToLuaBehaviour(insID, UNITY_LUA_BEHAVIOUR.OnDisable)
		else
			error(insID.."  onDisable View "..className.."--------->  没有找到该脚本对象")
		end
	end
end

function onDestroy(insID, className)
	local luaObj = luaObjs[insID]
	if luaObj ~= nil then
		luaObj:onDestroy()
	else
		local name = VIEW_CONTROL_ENROLL[className]
		if name ~= nil and luaControllers[name] ~= nil then
			luaControllers[name]:UnityToLuaBehaviour(insID, UNITY_LUA_BEHAVIOUR.OnDestroy)
		else
			error(insID.."  onDestroy View "..className.."--------->  没有找到该脚本对象")
		end
	end
end

function find_controller_by_name(name)
	local ctrl_name = VIEW_CONTROL_ENROLL[name]
	if ctrl_name ~= nil then
		local ctrl = luaControllers[ctrl_name]
		if ctrl ~= nil then
			return ctrl
		else
			print("UI:"..name.."的controller:"..ctrl_name.."还未实例化！")
			return nil
		end	
	else
		print(name.."对应的controller不存在")
		return nil
	end
end



