using System;
using UnityEngine.UI;
using UnityEngine;
using LuaInterface;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

public class MaskWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("IsRaycastLocationValid", IsRaycastLocationValid),
			new LuaMethod("GetModifiedMaterial", GetModifiedMaterial),
			new LuaMethod("New", _CreateMask),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("rectTransform", get_rectTransform, null),
			new LuaField("showMaskGraphic", get_showMaskGraphic, set_showMaskGraphic),
			new LuaField("graphic", get_graphic, null),
		};

		LuaScriptMgr.RegisterLib(L, "UnityEngine.UI.Mask", typeof(Mask), regs, fields, typeof(UIBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMask(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Mask class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(Mask);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rectTransform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Mask obj = (Mask)o;

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
	static int get_showMaskGraphic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Mask obj = (Mask)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name showMaskGraphic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index showMaskGraphic on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.showMaskGraphic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Mask obj = (Mask)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name graphic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index graphic on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.graphic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_showMaskGraphic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Mask obj = (Mask)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name showMaskGraphic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index showMaskGraphic on a nil value");
			}
		}

		obj.showMaskGraphic = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsRaycastLocationValid(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Mask obj = (Mask)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Mask");
		Vector2 arg0 = LuaScriptMgr.GetVector2(L, 2);
		Camera arg1 = (Camera)LuaScriptMgr.GetUnityObject(L, 3, typeof(Camera));
		bool o = obj.IsRaycastLocationValid(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetModifiedMaterial(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Mask obj = (Mask)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Mask");
		Material arg0 = (Material)LuaScriptMgr.GetUnityObject(L, 2, typeof(Material));
		Material o = obj.GetModifiedMaterial(arg0);
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

