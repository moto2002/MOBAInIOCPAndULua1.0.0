using System;
using LuaInterface;

public class OneByOne_ProtocolWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateOneByOne_Protocol),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("TYPE_USER", get_TYPE_USER, null),
			new LuaField("TYPE_TEAM", get_TYPE_TEAM, null),
			new LuaField("TYPE_MATCH", get_TYPE_MATCH, null),
			new LuaField("TYPE_FIGHT", get_TYPE_FIGHT, null),
			new LuaField("TYPE_LOGIN", get_TYPE_LOGIN, null),
			new LuaField("TYPE_SELECT", get_TYPE_SELECT, null),
		};

		LuaScriptMgr.RegisterLib(L, "OneByOne.Protocol", typeof(OneByOne.Protocol), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOneByOne_Protocol(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OneByOne.Protocol obj = new OneByOne.Protocol();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OneByOne.Protocol.New");
		}

		return 0;
	}

	static Type classType = typeof(OneByOne.Protocol);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TYPE_USER(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.Protocol.TYPE_USER);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TYPE_TEAM(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.Protocol.TYPE_TEAM);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TYPE_MATCH(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.Protocol.TYPE_MATCH);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TYPE_FIGHT(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.Protocol.TYPE_FIGHT);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TYPE_LOGIN(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.Protocol.TYPE_LOGIN);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TYPE_SELECT(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.Protocol.TYPE_SELECT);
		return 1;
	}
}

