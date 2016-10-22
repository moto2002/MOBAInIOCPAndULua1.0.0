using System;
using LuaInterface;

public class OneByOne_FightProtocolWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateOneByOne_FightProtocol),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("ENTER_CREQ", get_ENTER_CREQ, null),
			new LuaField("FIGHT_BRO", get_FIGHT_BRO, null),
			new LuaField("MOVE_CREQ", get_MOVE_CREQ, null),
			new LuaField("MOVE_BRO", get_MOVE_BRO, null),
			new LuaField("SKILL_UP_CREQ", get_SKILL_UP_CREQ, null),
			new LuaField("SKILL_UP_SRES", get_SKILL_UP_SRES, null),
			new LuaField("ATTACK_CREQ", get_ATTACK_CREQ, null),
			new LuaField("ATTACK_BRO", get_ATTACK_BRO, null),
			new LuaField("DAMAGE_CREQ", get_DAMAGE_CREQ, null),
			new LuaField("DAMAGE_BRO", get_DAMAGE_BRO, null),
		};

		LuaScriptMgr.RegisterLib(L, "OneByOne.FightProtocol", typeof(OneByOne.FightProtocol), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOneByOne_FightProtocol(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OneByOne.FightProtocol obj = new OneByOne.FightProtocol();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OneByOne.FightProtocol.New");
		}

		return 0;
	}

	static Type classType = typeof(OneByOne.FightProtocol);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ENTER_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.FightProtocol.ENTER_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FIGHT_BRO(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.FightProtocol.FIGHT_BRO);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MOVE_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.FightProtocol.MOVE_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MOVE_BRO(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.FightProtocol.MOVE_BRO);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SKILL_UP_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.FightProtocol.SKILL_UP_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SKILL_UP_SRES(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.FightProtocol.SKILL_UP_SRES);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ATTACK_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.FightProtocol.ATTACK_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ATTACK_BRO(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.FightProtocol.ATTACK_BRO);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DAMAGE_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.FightProtocol.DAMAGE_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DAMAGE_BRO(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.FightProtocol.DAMAGE_BRO);
		return 1;
	}
}

