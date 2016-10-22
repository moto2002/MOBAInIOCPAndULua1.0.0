using System;
using UnityEngine.UI;
using LuaInterface;

public class InputManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("RegisterBtn", RegisterBtn),
			new LuaMethod("SetBtnFunction", SetBtnFunction),
			new LuaMethod("New", _CreateInputManager),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
		};

		LuaScriptMgr.RegisterLib(L, "InputManager", typeof(InputManager), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateInputManager(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			InputManager obj = new InputManager();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: InputManager.New");
		}

		return 0;
	}

	static Type classType = typeof(InputManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, InputManager.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RegisterBtn(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		InputManager obj = (InputManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "InputManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Action<object> arg1 = null;
		LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

		if (funcType3 != LuaTypes.LUA_TFUNCTION)
		{
			 arg1 = (Action<object>)LuaScriptMgr.GetNetObject(L, 3, typeof(Action<object>));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
			arg1 = (param0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.PushVarObject(L, param0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}

		obj.RegisterBtn(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetBtnFunction(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		InputManager obj = (InputManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "InputManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Button arg1 = (Button)LuaScriptMgr.GetUnityObject(L, 3, typeof(Button));
		object arg2 = LuaScriptMgr.GetVarObject(L, 4);
		obj.SetBtnFunction(arg0,arg1,arg2);
		return 0;
	}
}

