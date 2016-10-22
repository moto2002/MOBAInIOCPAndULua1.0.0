using System;
using LuaInterface;

public class OneByOne_SelectModelWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateOneByOne_SelectModel),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("userId", get_userId, set_userId),
			new LuaField("name", get_name, set_name),
			new LuaField("heroId", get_heroId, set_heroId),
			new LuaField("entered", get_entered, set_entered),
			new LuaField("ready", get_ready, set_ready),
			new LuaField("isAI", get_isAI, set_isAI),
		};

		LuaScriptMgr.RegisterLib(L, "OneByOne.SelectModel", typeof(OneByOne.SelectModel), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOneByOne_SelectModel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OneByOne.SelectModel obj = new OneByOne.SelectModel();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OneByOne.SelectModel.New");
		}

		return 0;
	}

	static Type classType = typeof(OneByOne.SelectModel);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_userId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.SelectModel obj = (OneByOne.SelectModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name userId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index userId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.userId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.SelectModel obj = (OneByOne.SelectModel)o;

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
		OneByOne.SelectModel obj = (OneByOne.SelectModel)o;

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
	static int get_entered(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.SelectModel obj = (OneByOne.SelectModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name entered");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index entered on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.entered);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ready(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.SelectModel obj = (OneByOne.SelectModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ready");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ready on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.ready);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isAI(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.SelectModel obj = (OneByOne.SelectModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isAI");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isAI on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isAI);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_userId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.SelectModel obj = (OneByOne.SelectModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name userId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index userId on a nil value");
			}
		}

		obj.userId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.SelectModel obj = (OneByOne.SelectModel)o;

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
		OneByOne.SelectModel obj = (OneByOne.SelectModel)o;

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
	static int set_entered(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.SelectModel obj = (OneByOne.SelectModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name entered");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index entered on a nil value");
			}
		}

		obj.entered = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ready(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.SelectModel obj = (OneByOne.SelectModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ready");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ready on a nil value");
			}
		}

		obj.ready = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isAI(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.SelectModel obj = (OneByOne.SelectModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isAI");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isAI on a nil value");
			}
		}

		obj.isAI = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}

