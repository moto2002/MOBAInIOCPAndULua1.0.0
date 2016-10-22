using System;
using LuaInterface;

public class Constans_SkillTypeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("SELF", GetSELF),
		new LuaMethod("TARGET", GetTARGET),
		new LuaMethod("POSITION", GetPOSITION),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Constans.SkillType", typeof(Constans.SkillType), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSELF(IntPtr L)
	{
		LuaScriptMgr.Push(L, Constans.SkillType.SELF);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTARGET(IntPtr L)
	{
		LuaScriptMgr.Push(L, Constans.SkillType.TARGET);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPOSITION(IntPtr L)
	{
		LuaScriptMgr.Push(L, Constans.SkillType.POSITION);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		Constans.SkillType o = (Constans.SkillType)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

