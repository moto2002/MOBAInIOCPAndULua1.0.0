
--输出日志--
function unity_log(str)
    Util.Log(str);
end

--打印字符串--
function unity_print(str) 
	Util.Log(str);
end

--错误日志--
function unity_error(str) 
	Util.LogError(str);
end

--警告日志--
function unity_warn(str) 
	Util.LogWarning(str);
end

--查找对象--
function findGO(str)
	return GameObject.Find(str);
end

--查找子对象
function findChild(obj, str)
	return TransformFinder.FindChild(obj, str)
end

--摧毁对象
function destroy(obj)
	if obj ~= nil then
		GameObject.Destroy(obj.gameObject);
	end	
end

--实例化新对象
function newobject(prefab)
	return GameObject.Instantiate(prefab);
end

--实例化新Lua对象
function newLuaObj(name)
	local obj
	print("newLuaObj:"..name)
	local class = _G[name]
	obj = class.new()
	return obj
end

--按名字返回子对象
function child(str)
	return transform:FindChild(str);
end

--按名字得到子对象上的组件
function subGet(childNode, typeName)		
	return child(childNode):GetComponent(typeName);
end

--得到对象实例ID
function get_instance_id(obj)
	if obj == nil then
		error(str.." is null");
	end
	return obj:GetInstanceID()
end
-------------------------------------------------------

--克隆新表--
function clone_class(t)
	local clzz = {}
	for k,v in pairs(t) do
		clzz[k] = v
	end
	return clzz
end

--激活对象
function setActive(go, state)
	if go ~= nil then
		go = go.gameObject
		go:SetActive(state)
	end
end

--设置父节点
function setParent(tf, parent)
	tf:SetParent(parent.transform, false)
end

--获取文件名
function GetFileName(path)
	return string.match(fullpath, ".*/(.*)")
end

--添加子对象
function add_child(prefab, parent)
	local obj = GameObject.Instantiate(prefab)
	local tf = obj.transform
	if tf ~= nil then
		setParent(tf, parent) --tf:SetParent(parent.transform, false)
	end
	return obj, tf
end

--添加LuaUnit脚本到对象上
function add_luaClass(obj, luaName)
	LuaUnit.luaClass = luaName
	local type = obj:GetComponent(m_luaUnitType)
	if type == nil then
		obj:AddComponent(m_luaUnitType)
	end
	local luaObj = findObjByTarget(obj)
	return luaObj
end

--按秒延迟
function delay_second(call, sec)
	local function delayCall()
		coroutine.wait(sec or 1)
		call()
	end
	coroutine.start(delayCall)
end

--按帧延迟
function delay_frame(call, frame)
	local function delayCall()
		coroutine.step(frame or 1)
		call()
	end
	coroutine.start(delayCall)
end

--清空表
function table_clear(t)
	for k,v in pairs(t) do
		t[k] = nil
	end
end

--清空表，并删除对象实例
--表项需要继承自base_behaviour
function table_dispose(t)
	for k,v in pairs(t) do
		v:dispose()
		t[k] = nil
	end
end

--字符串分割函数
--传入字符串和分隔符，返回分割后的数组
--Global里也有个方法实现字符串分割，没做过测试，这个先留着
function string.split(str, delimiter)
	if str==nil or str=='' or delimiter==nil then
		return nil
	end
	
    local arr = {}
    local i = 0
    for match in (str..delimiter):gmatch("(.-)"..delimiter) do
        i = i + 1
        arr[i] = match
    end
    return arr, i
end

--字符串是否为空
function string.IsNullOrEmpty(str)
	if str==nil or str=='' then
		return true
	end
	return false
end

--字符串是否包含字符串
function string.Contains(str, key)
	if string.IsNullOrEmpty(str) or string.IsNullOrEmpty(key) then
		return false
	end
	local x = string.find(str, key)
	if x == nil then
		return false
	else
		return true
	end
end

--没空值判断
function string.IsNotNull(str)
	if str==nil or str=='' then
		return false
	end
	return true
end

---获取对象的所有的一级子物体---GameObject数组
function get_object_child(parent)
	local objs = getObjectChild(parent)
	local objects = {}
	if objs == nil or objs.Length == 0 then
		return objects
	else
		local length = objs.Length - 1
		for i = 0, length do
			objects[objs[i].name] = objs[i]
		end
		return objects
	end
end

--- 获取传入的对象下的names数组中的所有对象
function get_names_child(parent, names)
	local objs = getNameTransforms(parent, names)
	local trans = {}
	if objs == nil or objs.Length == 0 then
		error(parent.name .. "查找对象失败！！！")
		return trans
	else
		local length = objs.Length - 1
		for i = 0, length do
			trans[objs[i].name] = objs[i]
		end
		return trans	
	end
end
