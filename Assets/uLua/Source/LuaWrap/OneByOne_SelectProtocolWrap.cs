using System;
using LuaInterface;

public class OneByOne_SelectProtocolWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateOneByOne_SelectProtocol),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("ENTER_CREQ", get_ENTER_CREQ, null),
			new LuaField("ENTER_SRES", get_ENTER_SRES, null),
			new LuaField("SELECT_CREQ", get_SELECT_CREQ, null),
			new LuaField("SELECT_SRES", get_SELECT_SRES, null),
			new LuaField("SELECT_BRO", get_SELECT_BRO, null),
			new LuaField("TALK_CREQ", get_TALK_CREQ, null),
			new LuaField("TALK_BRO", get_TALK_BRO, null),
			new LuaField("ROOM_DESTORY_BRO", get_ROOM_DESTORY_BRO, null),
			new LuaField("START_FIGHT_BRO", get_START_FIGHT_BRO, null),
			new LuaField("READY_CREQ", get_READY_CREQ, null),
			new LuaField("READY_BRO", get_READY_BRO, null),
			new LuaField("ENTER_BRO", get_ENTER_BRO, null),
		};

		LuaScriptMgr.RegisterLib(L, "OneByOne.SelectProtocol", typeof(OneByOne.SelectProtocol), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOneByOne_SelectProtocol(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OneByOne.SelectProtocol obj = new OneByOne.SelectProtocol();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OneByOne.SelectProtocol.New");
		}

		return 0;
	}

	static Type classType = typeof(OneByOne.SelectProtocol);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ENTER_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.SelectProtocol.ENTER_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ENTER_SRES(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.SelectProtocol.ENTER_SRES);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SELECT_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.SelectProtocol.SELECT_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SELECT_SRES(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.SelectProtocol.SELECT_SRES);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SELECT_BRO(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.SelectProtocol.SELECT_BRO);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TALK_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.SelectProtocol.TALK_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TALK_BRO(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.SelectProtocol.TALK_BRO);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ROOM_DESTORY_BRO(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.SelectProtocol.ROOM_DESTORY_BRO);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_START_FIGHT_BRO(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.SelectProtocol.START_FIGHT_BRO);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_READY_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.SelectProtocol.READY_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_READY_BRO(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.SelectProtocol.READY_BRO);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ENTER_BRO(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.SelectProtocol.ENTER_BRO);
		return 1;
	}
}

