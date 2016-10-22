using System;
using LuaInterface;

public class OneByOne_FightPlayerModelWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("skillLevel", skillLevel),
			new LuaMethod("New", _CreateOneByOne_FightPlayerModel),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("name", get_name, set_name),
			new LuaField("heroId", get_heroId, set_heroId),
			new LuaField("free", get_free, set_free),
			new LuaField("level", get_level, set_level),
			new LuaField("exp", get_exp, set_exp),
			new LuaField("speed", get_speed, set_speed),
			new LuaField("aspeed", get_aspeed, set_aspeed),
			new LuaField("isLongRange", get_isLongRange, set_isLongRange),
			new LuaField("range", get_range, set_range),
			new LuaField("money", get_money, set_money),
			new LuaField("equs", get_equs, set_equs),
			new LuaField("skills", get_skills, set_skills),
		};

		LuaScriptMgr.RegisterLib(L, "OneByOne.FightPlayerModel", typeof(OneByOne.FightPlayerModel), regs, fields, typeof(OneByOne.AbsFightModel));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOneByOne_FightPlayerModel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OneByOne.FightPlayerModel obj = new OneByOne.FightPlayerModel();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OneByOne.FightPlayerModel.New");
		}

		return 0;
	}

	static Type classType = typeof(OneByOne.FightPlayerModel);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

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
	static int get_heroId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name heroId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index heroId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.heroId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_free(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name free");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index free on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.free);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name level");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index level on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.level);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_exp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name exp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index exp on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.exp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_speed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

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
	static int get_aspeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aspeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aspeed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.aspeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isLongRange(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isLongRange");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isLongRange on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isLongRange);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_range(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name range");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index range on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.range);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_money(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name money");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index money on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.money);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_equs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name equs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index equs on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.equs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skills(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skills");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skills on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.skills);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_heroId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name heroId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index heroId on a nil value");
			}
		}

		obj.heroId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_free(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name free");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index free on a nil value");
			}
		}

		obj.free = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name level");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index level on a nil value");
			}
		}

		obj.level = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_exp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name exp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index exp on a nil value");
			}
		}

		obj.exp = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_speed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_aspeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aspeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aspeed on a nil value");
			}
		}

		obj.aspeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isLongRange(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isLongRange");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isLongRange on a nil value");
			}
		}

		obj.isLongRange = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_range(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name range");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index range on a nil value");
			}
		}

		obj.range = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_money(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name money");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index money on a nil value");
			}
		}

		obj.money = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_equs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name equs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index equs on a nil value");
			}
		}

		obj.equs = LuaScriptMgr.GetArrayNumber<int>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skills(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skills");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skills on a nil value");
			}
		}

		obj.skills = LuaScriptMgr.GetArrayObject<OneByOne.FightSkill>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int skillLevel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		OneByOne.FightPlayerModel obj = (OneByOne.FightPlayerModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "OneByOne.FightPlayerModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int o = obj.skillLevel(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

