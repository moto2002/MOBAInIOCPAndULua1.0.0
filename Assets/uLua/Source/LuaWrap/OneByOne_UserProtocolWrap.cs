using System;
using LuaInterface;

public class OneByOne_UserProtocolWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateOneByOne_UserProtocol),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("CREATE_CREQ", get_CREATE_CREQ, null),
			new LuaField("CREATE_SRES", get_CREATE_SRES, null),
			new LuaField("GET_CREQ", get_GET_CREQ, null),
			new LuaField("GET_SRES", get_GET_SRES, null),
			new LuaField("ONLINE_CREQ", get_ONLINE_CREQ, null),
			new LuaField("ONELINE_SRES", get_ONELINE_SRES, null),
		};

		LuaScriptMgr.RegisterLib(L, "OneByOne.UserProtocol", typeof(OneByOne.UserProtocol), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOneByOne_UserProtocol(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OneByOne.UserProtocol obj = new OneByOne.UserProtocol();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OneByOne.UserProtocol.New");
		}

		return 0;
	}

	static Type classType = typeof(OneByOne.UserProtocol);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CREATE_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.UserProtocol.CREATE_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CREATE_SRES(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.UserProtocol.CREATE_SRES);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GET_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.UserProtocol.GET_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GET_SRES(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.UserProtocol.GET_SRES);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ONLINE_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.UserProtocol.ONLINE_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ONELINE_SRES(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.UserProtocol.ONELINE_SRES);
		return 1;
	}
}

