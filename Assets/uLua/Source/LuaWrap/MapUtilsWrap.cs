using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class MapUtilsWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("BuildMapHierachyOfMapName", BuildMapHierachyOfMapName),
			new LuaMethod("LoadMapElement", LoadMapElement),
			new LuaMethod("LoadMapElementSync", LoadMapElementSync),
			new LuaMethod("NewMapElement", NewMapElement),
			new LuaMethod("HandlePriority", HandlePriority),
			new LuaMethod("HandleEvent", HandleEvent),
			new LuaMethod("New", _CreateMapUtils),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "MapUtils", typeof(MapUtils), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMapUtils(IntPtr L)
	{
		LuaDLL.luaL_error(L, "MapUtils class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(MapUtils);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BuildMapHierachyOfMapName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MapUtils obj = (MapUtils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MapUtils");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.BuildMapHierachyOfMapName(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadMapElement(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MapUtils obj = (MapUtils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MapUtils");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.LoadMapElement(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadMapElementSync(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MapUtils obj = (MapUtils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MapUtils");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		Object o = obj.LoadMapElementSync(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int NewMapElement(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MapUtils obj = (MapUtils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MapUtils");
		Object arg0 = (Object)LuaScriptMgr.GetUnityObject(L, 2, typeof(Object));
		GameObject o = obj.NewMapElement(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HandlePriority(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MapUtils obj = (MapUtils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MapUtils");
		int o = obj.HandlePriority();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HandleEvent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		MapUtils obj = (MapUtils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MapUtils");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		object[] objs1 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
		bool o = obj.HandleEvent(arg0,objs1);
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

