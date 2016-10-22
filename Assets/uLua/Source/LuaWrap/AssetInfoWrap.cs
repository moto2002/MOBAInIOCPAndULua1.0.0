using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class AssetInfoWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateAssetInfo),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("name", get_name, set_name),
			new LuaField("asset", get_asset, set_asset),
			new LuaField("IsKeepInMemory", get_IsKeepInMemory, set_IsKeepInMemory),
			new LuaField("referenceCount", get_referenceCount, set_referenceCount),
		};

		LuaScriptMgr.RegisterLib(L, "AssetInfo", typeof(AssetInfo), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAssetInfo(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AssetInfo obj = new AssetInfo();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AssetInfo.New");
		}

		return 0;
	}

	static Type classType = typeof(AssetInfo);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		AssetInfo obj = (AssetInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index name on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_asset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		AssetInfo obj = (AssetInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name asset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index asset on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.asset);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsKeepInMemory(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		AssetInfo obj = (AssetInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsKeepInMemory");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsKeepInMemory on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.IsKeepInMemory);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_referenceCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		AssetInfo obj = (AssetInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name referenceCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index referenceCount on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.referenceCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		AssetInfo obj = (AssetInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index name on a nil value");
			}
		}

		obj.name = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_asset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		AssetInfo obj = (AssetInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name asset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index asset on a nil value");
			}
		}

		obj.asset = (Object)LuaScriptMgr.GetUnityObject(L, 3, typeof(Object));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_IsKeepInMemory(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		AssetInfo obj = (AssetInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsKeepInMemory");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsKeepInMemory on a nil value");
			}
		}

		obj.IsKeepInMemory = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_referenceCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		AssetInfo obj = (AssetInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name referenceCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index referenceCount on a nil value");
			}
		}

		obj.referenceCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

