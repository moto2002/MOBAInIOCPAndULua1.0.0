using System;
using LuaInterface;

public class OneByOne_LoginProtocolWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateOneByOne_LoginProtocol),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("LOGIN_CREQ", get_LOGIN_CREQ, null),
			new LuaField("LOGIN_SRES", get_LOGIN_SRES, null),
			new LuaField("CREATE_CREQ", get_CREATE_CREQ, null),
			new LuaField("CREATE_SRES", get_CREATE_SRES, null),
		};

		LuaScriptMgr.RegisterLib(L, "OneByOne.LoginProtocol", typeof(OneByOne.LoginProtocol), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOneByOne_LoginProtocol(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OneByOne.LoginProtocol obj = new OneByOne.LoginProtocol();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OneByOne.LoginProtocol.New");
		}

		return 0;
	}

	static Type classType = typeof(OneByOne.LoginProtocol);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LOGIN_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.LoginProtocol.LOGIN_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LOGIN_SRES(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.LoginProtocol.LOGIN_SRES);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CREATE_CREQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.LoginProtocol.CREATE_CREQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CREATE_SRES(IntPtr L)
	{
		LuaScriptMgr.Push(L, OneByOne.LoginProtocol.CREATE_SRES);
		return 1;
	}
}

