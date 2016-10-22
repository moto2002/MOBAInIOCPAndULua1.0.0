using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class TransformFinderWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetTransform", GetTransform),
			new LuaMethod("FindChild", FindChild),
			new LuaMethod("New", _CreateTransformFinder),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
		};

		LuaScriptMgr.RegisterLib(L, "TransformFinder", typeof(TransformFinder), regs, fields, typeof(EventNode));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTransformFinder(IntPtr L)
	{
		LuaDLL.luaL_error(L, "TransformFinder class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(TransformFinder);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, TransformFinder.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTransform(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		TransformFinder obj = (TransformFinder)LuaScriptMgr.GetUnityObjectSelf(L, 1, "TransformFinder");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Transform o = obj.GetTransform(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindChild(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		GameObject o = TransformFinder.FindChild(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
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

