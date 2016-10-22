using System;
using LuaInterface;

public class OneByOne_MatchProtocolWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateOneByOne_MatchProtocol),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("ENTER_CREQ", get_ENTER_CREQ, null),
			new LuaField("ENTER_SRES", get_ENTER_SRES, null),
			new LuaField("LEAVE_CREQ", get_LEAVE_CREQ, null),
			new LuaField("LEAVE_SRES", get_LEAVE_SRES, null),
			new LuaField("TALK_CREQ", get_TALK_CREQ, null),
			new LuaField("TALK_BRO", get_TALK_BRO, null),
			new LuaField("ENTER_SELECT_BRO", get_ENTER_SELECT_BRO, null),
			new LuaField("ACCEPT_AI_CREQ", get_ACCEPT_AI_CREQ, null),
			new LuaField("ACCEPT_AI_SRES", get_ACCEPT_AI_SRES, null),
			new LuaField("ACCEPT_PLAYER_CREQ", get_ACCEPT_PLAYER_CREQ, null),
			new LuaField("ACCEPT_PLAYER_SRES", get_ACCEPT_PLAYER_SRES, null),
		};

		LuaScriptMgr.RegisterLib(L, "OneByOne.MatchProtocol", typeof(OneByOne.MatchProtocol), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOneByOne_MatchProtocol(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OneByOne.MatchProtocol obj = new OneByOne.MatchProtocol();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OneByOne.MatchProtocol.New");
		}

		return 0;
	}

	static Type classType = typeof(OneByOne.MatchProtocol);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ENTER_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.MatchProtocol.ENTER_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ENTER_SRES(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.MatchProtocol.ENTER_SRES);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LEAVE_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.MatchProtocol.LEAVE_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LEAVE_SRES(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.MatchProtocol.LEAVE_SRES);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TALK_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.MatchProtocol.TALK_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TALK_BRO(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.MatchProtocol.TALK_BRO);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ENTER_SELECT_BRO(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.MatchProtocol.ENTER_SELECT_BRO);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ACCEPT_AI_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.MatchProtocol.ACCEPT_AI_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ACCEPT_AI_SRES(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.MatchProtocol.ACCEPT_AI_SRES);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ACCEPT_PLAYER_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.MatchProtocol.ACCEPT_PLAYER_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ACCEPT_PLAYER_SRES(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.MatchProtocol.ACCEPT_PLAYER_SRES);
		return 1;
	}
}

