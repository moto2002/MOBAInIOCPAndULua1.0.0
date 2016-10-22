using System;
using System.Collections.Generic;
using LuaInterface;

public class OneByOne_UserDTOWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateOneByOne_UserDTO),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("name", get_name, set_name),
			new LuaField("id", get_id, set_id),
			new LuaField("level", get_level, set_level),
			new LuaField("winCount", get_winCount, set_winCount),
			new LuaField("loseCount", get_loseCount, set_loseCount),
			new LuaField("ranCount", get_ranCount, set_ranCount),
			new LuaField("heroList", get_heroList, set_heroList),
			new LuaField("isAI", get_isAI, set_isAI),
			new LuaField("isAIHost", get_isAIHost, set_isAIHost),
		};

		LuaScriptMgr.RegisterLib(L, "OneByOne.UserDTO", typeof(OneByOne.UserDTO), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOneByOne_UserDTO(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OneByOne.UserDTO obj = new OneByOne.UserDTO();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 9)
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			List<int> arg6 = (List<int>)LuaScriptMgr.GetNetObject(L, 7, typeof(List<int>));
			bool arg7 = LuaScriptMgr.GetBoolean(L, 8);
			bool arg8 = LuaScriptMgr.GetBoolean(L, 9);
			OneByOne.UserDTO obj = new OneByOne.UserDTO(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7,arg8);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OneByOne.UserDTO.New");
		}

		return 0;
	}

	static Type classType = typeof(OneByOne.UserDTO);

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
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

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
	static int get_id(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name id");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index id on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.id);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

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
	static int get_winCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name winCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index winCount on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.winCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_loseCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name loseCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index loseCount on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.loseCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ranCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ranCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ranCount on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.ranCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_heroList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name heroList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index heroList on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.heroList);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isAI(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

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
	static int get_isAIHost(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isAIHost");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isAIHost on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isAIHost);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

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
	static int set_id(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name id");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index id on a nil value");
			}
		}

		obj.id = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

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
	static int set_winCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name winCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index winCount on a nil value");
			}
		}

		obj.winCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_loseCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name loseCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index loseCount on a nil value");
			}
		}

		obj.loseCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ranCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ranCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ranCount on a nil value");
			}
		}

		obj.ranCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_heroList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name heroList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index heroList on a nil value");
			}
		}

		obj.heroList = (List<int>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<int>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isAI(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isAIHost(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.UserDTO obj = (OneByOne.UserDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isAIHost");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isAIHost on a nil value");
			}
		}

		obj.isAIHost = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}

