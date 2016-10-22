using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class SceneLoaderWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("LoadScene", LoadScene),
			new LuaMethod("New", _CreateSceneLoader),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
		};

		LuaScriptMgr.RegisterLib(L, "SceneLoader", typeof(SceneLoader), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSceneLoader(IntPtr L)
	{
		LuaDLL.luaL_error(L, "SceneLoader class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(SceneLoader);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, SceneLoader.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadScene(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SceneLoader obj = (SceneLoader)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SceneLoader");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.LoadScene(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

