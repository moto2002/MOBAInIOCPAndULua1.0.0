using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class UIutilsWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("LoadUiElement", LoadUiElement),
			new LuaMethod("LoadUiElementSync", LoadUiElementSync),
			new LuaMethod("NewUIElement", NewUIElement),
			new LuaMethod("HandlePriority", HandlePriority),
			new LuaMethod("HandleEvent", HandleEvent),
			new LuaMethod("setButtonClick", setButtonClick),
			new LuaMethod("setButtonNormalClick", setButtonNormalClick),
			new LuaMethod("addButtonClick", addButtonClick),
			new LuaMethod("addButtonNormalClick", addButtonNormalClick),
			new LuaMethod("addButtonLongPressed", addButtonLongPressed),
			new LuaMethod("addButtonLongPressCancel", addButtonLongPressCancel),
			new LuaMethod("setToogleAction", setToogleAction),
			new LuaMethod("New", _CreateUIutils),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
		};

		LuaScriptMgr.RegisterLib(L, "UIutils", typeof(UIutils), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUIutils(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIutils class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(UIutils);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIutils.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadUiElement(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIutils obj = (UIutils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIutils");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.LoadUiElement(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadUiElementSync(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIutils obj = (UIutils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIutils");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Object o = obj.LoadUiElementSync(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int NewUIElement(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIutils obj = (UIutils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIutils");
		Object arg0 = (Object)LuaScriptMgr.GetUnityObject(L, 2, typeof(Object));
		GameObject o = obj.NewUIElement(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HandlePriority(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIutils obj = (UIutils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIutils");
		int o = obj.HandlePriority();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HandleEvent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		UIutils obj = (UIutils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIutils");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		object[] objs1 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
		bool o = obj.HandleEvent(arg0,objs1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setButtonClick(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		UIutils obj = (UIutils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIutils");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		object[] objs2 = LuaScriptMgr.GetParamsObject(L, 4, count - 3);
		obj.setButtonClick(arg0,arg1,objs2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setButtonNormalClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UIutils obj = (UIutils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIutils");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		Action arg1 = null;
		LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

		if (funcType3 != LuaTypes.LUA_TFUNCTION)
		{
			 arg1 = (Action)LuaScriptMgr.GetNetObject(L, 3, typeof(Action));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
			arg1 = () =>
			{
				func.Call();
			};
		}

		obj.setButtonNormalClick(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int addButtonClick(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		UIutils obj = (UIutils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIutils");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		object[] objs2 = LuaScriptMgr.GetParamsObject(L, 4, count - 3);
		obj.addButtonClick(arg0,arg1,objs2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int addButtonNormalClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UIutils obj = (UIutils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIutils");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		Action arg1 = null;
		LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

		if (funcType3 != LuaTypes.LUA_TFUNCTION)
		{
			 arg1 = (Action)LuaScriptMgr.GetNetObject(L, 3, typeof(Action));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
			arg1 = () =>
			{
				func.Call();
			};
		}

		obj.addButtonNormalClick(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int addButtonLongPressed(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		UIutils obj = (UIutils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIutils");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		object[] objs2 = LuaScriptMgr.GetParamsObject(L, 4, count - 3);
		obj.addButtonLongPressed(arg0,arg1,objs2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int addButtonLongPressCancel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		UIutils obj = (UIutils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIutils");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		object[] objs2 = LuaScriptMgr.GetParamsObject(L, 4, count - 3);
		obj.addButtonLongPressCancel(arg0,arg1,objs2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setToogleAction(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		UIutils obj = (UIutils)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIutils");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		object[] objs2 = LuaScriptMgr.GetParamsObject(L, 4, count - 3);
		obj.setToogleAction(arg0,arg1,objs2);
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

