using System;
using UnityEngine;
using LuaInterface;

public class CameraMgrWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("FocusMainCameraToPlayer", FocusMainCameraToPlayer),
			new LuaMethod("New", _CreateCameraMgr),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
		};

		LuaScriptMgr.RegisterLib(L, "CameraMgr", typeof(CameraMgr), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCameraMgr(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CameraMgr class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CameraMgr);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CameraMgr.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FocusMainCameraToPlayer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CameraMgr obj = (CameraMgr)LuaScriptMgr.GetNetObjectSelf(L, 1, "CameraMgr");
		Transform arg0 = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		obj.FocusMainCameraToPlayer(arg0);
		return 0;
	}
}

