using System;
using UnityEngine.UI;
using UnityEngine;
using LuaInterface;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

public class RectMask2DWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("IsRaycastLocationValid", IsRaycastLocationValid),
			new LuaMethod("PerformClipping", PerformClipping),
			new LuaMethod("AddClippable", AddClippable),
			new LuaMethod("RemoveClippable", RemoveClippable),
			new LuaMethod("New", _CreateRectMask2D),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("canvasRect", get_canvasRect, null),
			new LuaField("rectTransform", get_rectTransform, null),
		};

		LuaScriptMgr.RegisterLib(L, "UnityEngine.UI.RectMask2D", typeof(RectMask2D), regs, fields, typeof(UIBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateRectMask2D(IntPtr L)
	{
		LuaDLL.luaL_error(L, "RectMask2D class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(RectMask2D);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_canvasRect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		RectMask2D obj = (RectMask2D)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canvasRect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canvasRect on a nil value");
			}
		}

		LuaScriptMgr.PushValue(L, obj.canvasRect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rectTransform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		RectMask2D obj = (RectMask2D)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rectTransform");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rectTransform on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.rectTransform);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsRaycastLocationValid(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		RectMask2D obj = (RectMask2D)LuaScriptMgr.GetUnityObjectSelf(L, 1, "RectMask2D");
		Vector2 arg0 = LuaScriptMgr.GetVector2(L, 2);
		Camera arg1 = (Camera)LuaScriptMgr.GetUnityObject(L, 3, typeof(Camera));
		bool o = obj.IsRaycastLocationValid(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PerformClipping(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RectMask2D obj = (RectMask2D)LuaScriptMgr.GetUnityObjectSelf(L, 1, "RectMask2D");
		obj.PerformClipping();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddClippable(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		RectMask2D obj = (RectMask2D)LuaScriptMgr.GetUnityObjectSelf(L, 1, "RectMask2D");
		IClippable arg0 = (IClippable)LuaScriptMgr.GetNetObject(L, 2, typeof(IClippable));
		obj.AddClippable(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveClippable(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		RectMask2D obj = (RectMask2D)LuaScriptMgr.GetUnityObjectSelf(L, 1, "RectMask2D");
		IClippable arg0 = (IClippable)LuaScriptMgr.GetNetObject(L, 2, typeof(IClippable));
		obj.RemoveClippable(arg0);
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

