using System;
using LuaInterface;

public class SocketModelWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateSocketModel),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("type", get_type, set_type),
			new LuaField("area", get_area, set_area),
			new LuaField("command", get_command, set_command),
			new LuaField("message", get_message, set_message),
		};

		LuaScriptMgr.RegisterLib(L, "SocketModel", typeof(SocketModel), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSocketModel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			SocketModel obj = new SocketModel();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 4)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			object arg3 = LuaScriptMgr.GetVarObject(L, 4);
			SocketModel obj = new SocketModel(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SocketModel.New");
		}

		return 0;
	}

	static Type classType = typeof(SocketModel);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SocketModel obj = (SocketModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name type");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index type on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.type);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_area(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SocketModel obj = (SocketModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name area");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index area on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.area);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_command(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SocketModel obj = (SocketModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name command");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index command on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.command);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_message(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SocketModel obj = (SocketModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name message");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index message on a nil value");
			}
		}

		LuaScriptMgr.PushVarObject(L, obj.message);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SocketModel obj = (SocketModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name type");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index type on a nil value");
			}
		}

		obj.type = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_area(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SocketModel obj = (SocketModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name area");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index area on a nil value");
			}
		}

		obj.area = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_command(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SocketModel obj = (SocketModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name command");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index command on a nil value");
			}
		}

		obj.command = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_message(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SocketModel obj = (SocketModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name message");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index message on a nil value");
			}
		}

		obj.message = LuaScriptMgr.GetVarObject(L, 3);
		return 0;
	}
}

