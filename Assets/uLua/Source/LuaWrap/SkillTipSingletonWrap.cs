using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class SkillTipSingletonWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("ActiveTip", ActiveTip),
			new LuaMethod("DisactiveTip", DisactiveTip),
			new LuaMethod("New", _CreateSkillTipSingleton),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
		};

		LuaScriptMgr.RegisterLib(L, "SkillTipSingleton", typeof(SkillTipSingleton), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSkillTipSingleton(IntPtr L)
	{
		LuaDLL.luaL_error(L, "SkillTipSingleton class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(SkillTipSingleton);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, SkillTipSingleton.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ActiveTip(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		SkillTipSingleton obj = (SkillTipSingleton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SkillTipSingleton");
		OneByOne.FightSkill arg0 = (OneByOne.FightSkill)LuaScriptMgr.GetNetObject(L, 2, typeof(OneByOne.FightSkill));
		Vector3 arg1 = LuaScriptMgr.GetVector3(L, 3);
		obj.ActiveTip(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DisactiveTip(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SkillTipSingleton obj = (SkillTipSingleton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SkillTipSingleton");
		obj.DisactiveTip();
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

