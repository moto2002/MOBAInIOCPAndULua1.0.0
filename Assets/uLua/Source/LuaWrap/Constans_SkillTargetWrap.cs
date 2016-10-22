using System;
using LuaInterface;

public class Constans_SkillTargetWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("SELF", GetSELF),
		new LuaMethod("F_H", GetF_H),
		new LuaMethod("F_N_N", GetF_N_N),
		new LuaMethod("F_ALL", GetF_ALL),
		new LuaMethod("E_H", GetE_H),
		new LuaMethod("E_N_N", GetE_N_N),
		new LuaMethod("E_S_N", GetE_S_N),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Constans.SkillTarget", typeof(Constans.SkillTarget), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSELF(IntPtr L)
	{
		LuaScriptMgr.Push(L, Constans.SkillTarget.SELF);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF_H(IntPtr L)
	{
		LuaScriptMgr.Push(L, Constans.SkillTarget.F_H);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF_N_N(IntPtr L)
	{
		LuaScriptMgr.Push(L, Constans.SkillTarget.F_N_N);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetF_ALL(IntPtr L)
	{
		LuaScriptMgr.Push(L, Constans.SkillTarget.F_ALL);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetE_H(IntPtr L)
	{
		LuaScriptMgr.Push(L, Constans.SkillTarget.E_H);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetE_N_N(IntPtr L)
	{
		LuaScriptMgr.Push(L, Constans.SkillTarget.E_N_N);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetE_S_N(IntPtr L)
	{
		LuaScriptMgr.Push(L, Constans.SkillTarget.E_S_N);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		Constans.SkillTarget o = (Constans.SkillTarget)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

