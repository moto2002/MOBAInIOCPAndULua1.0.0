using System;
using LuaInterface;

public class OneByOne_SelectRoomDTOWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("inTeam", inTeam),
			new LuaMethod("New", _CreateOneByOne_SelectRoomDTO),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("teamOne", get_teamOne, set_teamOne),
			new LuaField("teamTwo", get_teamTwo, set_teamTwo),
		};

		LuaScriptMgr.RegisterLib(L, "OneByOne.SelectRoomDTO", typeof(OneByOne.SelectRoomDTO), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOneByOne_SelectRoomDTO(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OneByOne.SelectRoomDTO obj = new OneByOne.SelectRoomDTO();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OneByOne.SelectRoomDTO.New");
		}

		return 0;
	}

	static Type classType = typeof(OneByOne.SelectRoomDTO);

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
		OneByOne.SelectRoomDTO obj = (OneByOne.SelectRoomDTO)o;

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
		OneByOne.SelectRoomDTO obj = (OneByOne.SelectRoomDTO)o;

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
	static int set_teamOne(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.SelectRoomDTO obj = (OneByOne.SelectRoomDTO)o;

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

		obj.teamOne = LuaScriptMgr.GetArrayObject<OneByOne.SelectModel>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_teamTwo(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.SelectRoomDTO obj = (OneByOne.SelectRoomDTO)o;

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

		obj.teamTwo = LuaScriptMgr.GetArrayObject<OneByOne.SelectModel>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int inTeam(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		OneByOne.SelectRoomDTO obj = (OneByOne.SelectRoomDTO)LuaScriptMgr.GetNetObjectSelf(L, 1, "OneByOne.SelectRoomDTO");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int o = obj.inTeam(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

