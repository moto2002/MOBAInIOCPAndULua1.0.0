using System;
using LuaInterface;

public class OneByOne_FightRoomModelWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateOneByOne_FightRoomModel),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("teamOne", get_teamOne, set_teamOne),
			new LuaField("teamTwo", get_teamTwo, set_teamTwo),
			new LuaField("teamOneBuildMap", get_teamOneBuildMap, set_teamOneBuildMap),
			new LuaField("teamTwoBuildMap", get_teamTwoBuildMap, set_teamTwoBuildMap),
		};

		LuaScriptMgr.RegisterLib(L, "OneByOne.FightRoomModel", typeof(OneByOne.FightRoomModel), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOneByOne_FightRoomModel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OneByOne.FightRoomModel obj = new OneByOne.FightRoomModel();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OneByOne.FightRoomModel.New");
		}

		return 0;
	}

	static Type classType = typeof(OneByOne.FightRoomModel);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_teamOne(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightRoomModel obj = (OneByOne.FightRoomModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name teamOne");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index teamOne on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.teamOne);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_teamTwo(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightRoomModel obj = (OneByOne.FightRoomModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name teamTwo");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index teamTwo on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.teamTwo);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_teamOneBuildMap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightRoomModel obj = (OneByOne.FightRoomModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name teamOneBuildMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index teamOneBuildMap on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.teamOneBuildMap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_teamTwoBuildMap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightRoomModel obj = (OneByOne.FightRoomModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name teamTwoBuildMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index teamTwoBuildMap on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.teamTwoBuildMap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_teamOne(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightRoomModel obj = (OneByOne.FightRoomModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name teamOne");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index teamOne on a nil value");
			}
		}

		obj.teamOne = LuaScriptMgr.GetArrayObject<OneByOne.FightPlayerModel>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_teamTwo(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightRoomModel obj = (OneByOne.FightRoomModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name teamTwo");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index teamTwo on a nil value");
			}
		}

		obj.teamTwo = LuaScriptMgr.GetArrayObject<OneByOne.FightPlayerModel>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_teamOneBuildMap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightRoomModel obj = (OneByOne.FightRoomModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name teamOneBuildMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index teamOneBuildMap on a nil value");
			}
		}

		obj.teamOneBuildMap = LuaScriptMgr.GetArrayObject<OneByOne.FightBuildModel>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_teamTwoBuildMap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.FightRoomModel obj = (OneByOne.FightRoomModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name teamTwoBuildMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index teamTwoBuildMap on a nil value");
			}
		}

		obj.teamTwoBuildMap = LuaScriptMgr.GetArrayObject<OneByOne.FightBuildModel>(L, 3);
		return 0;
	}
}

