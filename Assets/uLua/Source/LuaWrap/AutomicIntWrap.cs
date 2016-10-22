using System;
using LuaInterface;

public class AutomicIntWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetIncrease", GetIncrease),
			new LuaMethod("GetReduce", GetReduce),
			new LuaMethod("Get", Get),
			new LuaMethod("New", _CreateAutomicInt),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "AutomicInt", typeof(AutomicInt), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAutomicInt(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AutomicInt obj = new AutomicInt();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			AutomicInt obj = new AutomicInt(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AutomicInt.New");
		}

		return 0;
	}

	static Type classType = typeof(AutomicInt);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetIncrease(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AutomicInt obj = (AutomicInt)LuaScriptMgr.GetNetObjectSelf(L, 1, "AutomicInt");
		int o = obj.GetIncrease();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetReduce(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AutomicInt obj = (AutomicInt)LuaScriptMgr.GetNetObjectSelf(L, 1, "AutomicInt");
		int o = obj.GetReduce();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Get(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AutomicInt obj = (AutomicInt)LuaScriptMgr.GetNetObjectSelf(L, 1, "AutomicInt");
		int o = obj.Get();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

