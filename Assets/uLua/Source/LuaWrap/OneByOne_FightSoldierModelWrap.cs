using System;
using LuaInterface;

public class OneByOne_FightSoldierModelWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateOneByOne_FightSoldierModel),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("code", get_code, set_code),
			new LuaField("speed", get_speed, set_speed),
		};

		LuaScriptMgr.RegisterLib(L, "OneByOne.FightSoldierModel", typeof(OneByOne.FightSoldierModel), regs, fields, typeof(OneByOne.AbsFightModel));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOneByOne_FightSoldierModel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OneByOne.FightSoldierModel obj = new OneByOne.FightSoldierModel();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OneByOne.FightSoldierModel.New");
		}

		return 0;
	}

	static Type classType = typeof(OneByOne.FightSoldierModel);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_code(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightSoldierModel obj = (OneByOne.FightSoldierModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name code");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index code on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.code);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_speed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightSoldierModel obj = (OneByOne.FightSoldierModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name speed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index speed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.speed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_code(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightSoldierModel obj = (OneByOne.FightSoldierModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name code");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index code on a nil value");
			}
		}

		obj.code = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_speed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightSoldierModel obj = (OneByOne.FightSoldierModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name speed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index speed on a nil value");
			}
		}

		obj.speed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

