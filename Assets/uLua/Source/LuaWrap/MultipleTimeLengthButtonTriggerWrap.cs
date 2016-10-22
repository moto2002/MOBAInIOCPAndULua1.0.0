using System;
using UnityEngine.EventSystems;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class MultipleTimeLengthButtonTriggerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("OnPointerDown", OnPointerDown),
			new LuaMethod("OnPointerUp", OnPointerUp),
			new LuaMethod("OnPointerExit", OnPointerExit),
			new LuaMethod("New", _CreateMultipleTimeLengthButtonTrigger),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("longPressTrigger", get_longPressTrigger, set_longPressTrigger),
			new LuaField("cancelLongPressTrigger", get_cancelLongPressTrigger, set_cancelLongPressTrigger),
		};

		LuaScriptMgr.RegisterLib(L, "MultipleTimeLengthButtonTrigger", typeof(MultipleTimeLengthButtonTrigger), regs, fields, typeof(UIBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMultipleTimeLengthButtonTrigger(IntPtr L)
	{
		LuaDLL.luaL_error(L, "MultipleTimeLengthButtonTrigger class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(MultipleTimeLengthButtonTrigger);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_longPressTrigger(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MultipleTimeLengthButtonTrigger obj = (MultipleTimeLengthButtonTrigger)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name longPressTrigger");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index longPressTrigger on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.longPressTrigger);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cancelLongPressTrigger(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MultipleTimeLengthButtonTrigger obj = (MultipleTimeLengthButtonTrigger)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cancelLongPressTrigger");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cancelLongPressTrigger on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.cancelLongPressTrigger);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_longPressTrigger(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MultipleTimeLengthButtonTrigger obj = (MultipleTimeLengthButtonTrigger)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name longPressTrigger");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index longPressTrigger on a nil value");
			}
		}

		obj.longPressTrigger = (UnityEngine.Events.UnityEvent)LuaScriptMgr.GetNetObject(L, 3, typeof(UnityEngine.Events.UnityEvent));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cancelLongPressTrigger(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MultipleTimeLengthButtonTrigger obj = (MultipleTimeLengthButtonTrigger)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cancelLongPressTrigger");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cancelLongPressTrigger on a nil value");
			}
		}

		obj.cancelLongPressTrigger = (UnityEngine.Events.UnityEvent)LuaScriptMgr.GetNetObject(L, 3, typeof(UnityEngine.Events.UnityEvent));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MultipleTimeLengthButtonTrigger obj = (MultipleTimeLengthButtonTrigger)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MultipleTimeLengthButtonTrigger");
		PointerEventData arg0 = (PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(PointerEventData));
		obj.OnPointerDown(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerUp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MultipleTimeLengthButtonTrigger obj = (MultipleTimeLengthButtonTrigger)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MultipleTimeLengthButtonTrigger");
		PointerEventData arg0 = (PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(PointerEventData));
		obj.OnPointerUp(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerExit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MultipleTimeLengthButtonTrigger obj = (MultipleTimeLengthButtonTrigger)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MultipleTimeLengthButtonTrigger");
		PointerEventData arg0 = (PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(PointerEventData));
		obj.OnPointerExit(arg0);
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

