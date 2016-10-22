--控制器的基类
lua_mvc_controller = newclass(base_behaviour)

luaObjs = {}

function lua_mvc_controller:InitModel(luaModel)
	--同时还存储着对应本控制器类的数据类
	self.luaModel = luaModel
end

function lua_mvc_controller:NewCtrl(className, gameObject, insID, cacheObjs, cachePrefabs)
	local Obj = newLuaObj(className)
	Obj:init(gameObject, insID, cacheObjs, cachePrefabs)
	luaObjs[insID] = Obj
	self:init(gameObject, insID, cacheObjs, cachePrefabs)
end

function lua_mvc_controller:UnityToLuaBehaviour(insID, behaviour)
	local luaObj = luaObjs[insID]
	if luaObj ~= nil then
		if behaviour == UNITY_LUA_BEHAVIOUR.OnEnable then
			luaObj:onEnable()
		elseif behaviour == UNITY_LUA_BEHAVIOUR.OnDisable then
			luaObj:onDisable()
		elseif behaviour == UNITY_LUA_BEHAVIOUR.Awake then
			luaObj:awake()
		elseif behaviour == UNITY_LUA_BEHAVIOUR.Start then
			luaObj:start()
		elseif behaviour == UNITY_LUA_BEHAVIOUR.OnDestroy then
			luaObj:onDestroy()
		end
	else
		error("错误："..insID.."方法名："..behaviour)
	end
end

function lua_mvc_controller:initItems()

end

function lua_mvc_controller:GetLuaObjByInsID(insID)
	local luaObj = luaObjs[insID]
	if luaObj ~= nil then
		return luaObj
	end
	return nil
end

function lua_mvc_controller:GetLuaObjByObj(gameObject)
	for k,v in pairs(luaObjs) do
		if v.gameObject == gameObject then
			return v
		end
	end
	return nil
end