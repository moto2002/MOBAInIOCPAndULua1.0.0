using System;
using LuaInterface;

public class OneByOne_FightBuildModelWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateOneByOne_FightBuildModel),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("code", get_code, set_code),
			new LuaField("reBorn", get_reBorn, set_reBorn),
			new LuaField("rebornTime", get_rebornTime, set_rebornTime),
			new LuaField("initiative", get_initiative, set_initiative),
			new LuaField("infrared", get_infrared, set_infrared),
			new LuaField("name", get_name, set_name),
		};

		LuaScriptMgr.RegisterLib(L, "OneByOne.FightBuildModel", typeof(OneByOne.FightBuildModel), regs, fields, typeof(OneByOne.AbsFightModel));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOneByOne_FightBuildModel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OneByOne.FightBuildModel obj = new OneByOne.FightBuildModel();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 11)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			bool arg6 = LuaScriptMgr.GetBoolean(L, 7);
			int arg7 = (int)LuaScriptMgr.GetNumber(L, 8);
			bool arg8 = LuaScriptMgr.GetBoolean(L, 9);
			bool arg9 = LuaScriptMgr.GetBoolean(L, 10);
			string arg10 = LuaScriptMgr.GetString(L, 11);
			OneByOne.FightBuildModel obj = new OneByOne.FightBuildModel(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7,arg8,arg9,arg10);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OneByOne.FightBuildModel.New");
		}

		return 0;
	}

	static Type classType = typeof(OneByOne.FightBuildModel);

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
		OneByOne.FightBuildModel obj = (OneByOne.FightBuildModel)o;

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
	static int get_reBorn(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightBuildModel obj = (OneByOne.FightBuildModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reBorn");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reBorn on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.reBorn);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rebornTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightBuildModel obj = (OneByOne.FightBuildModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rebornTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rebornTime on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.rebornTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_initiative(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightBuildModel obj = (OneByOne.FightBuildModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name initiative");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index initiative on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.initiative);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_infrared(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightBuildModel obj = (OneByOne.FightBuildModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name infrared");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index infrared on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.infrared);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightBuildModel obj = (OneByOne.FightBuildModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index name on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_code(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightBuildModel obj = (OneByOne.FightBuildModel)o;

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
	static int set_reBorn(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightBuildModel obj = (OneByOne.FightBuildModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reBorn");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reBorn on a nil value");
			}
		}

		obj.reBorn = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rebornTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightBuildModel obj = (OneByOne.FightBuildModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rebornTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rebornTime on a nil value");
			}
		}

		obj.rebornTime = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_initiative(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightBuildModel obj = (OneByOne.FightBuildModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name initiative");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index initiative on a nil value");
			}
		}

		obj.initiative = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_infrared(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightBuildModel obj = (OneByOne.FightBuildModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name infrared");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index infrared on a nil value");
			}
		}

		obj.infrared = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightBuildModel obj = (OneByOne.FightBuildModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index name on a nil value");
			}
		}

		obj.name = LuaScriptMgr.GetString(L, 3);
		return 0;
	}
}

