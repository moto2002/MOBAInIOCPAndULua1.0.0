using System;
using LuaInterface;

public class OneByOne_AccountDTOWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateOneByOne_AccountDTO),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("account", get_account, set_account),
			new LuaField("password", get_password, set_password),
		};

		LuaScriptMgr.RegisterLib(L, "OneByOne.AccountDTO", typeof(OneByOne.AccountDTO), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOneByOne_AccountDTO(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OneByOne.AccountDTO obj = new OneByOne.AccountDTO();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OneByOne.AccountDTO.New");
		}

		return 0;
	}

	static Type classType = typeof(OneByOne.AccountDTO);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_account(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.AccountDTO obj = (OneByOne.AccountDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name account");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index account on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.account);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_password(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.AccountDTO obj = (OneByOne.AccountDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name password");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index password on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.password);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_account(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.AccountDTO obj = (OneByOne.AccountDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name account");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index account on a nil value");
			}
		}

		obj.account = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_password(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.AccountDTO obj = (OneByOne.AccountDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name password");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index password on a nil value");
			}
		}

		obj.password = LuaScriptMgr.GetString(L, 3);
		return 0;
	}
}

