using System;
using LuaInterface;

public class ErrorModelWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("CallFunction", CallFunction),
			new LuaMethod("New", _CreateErrorModel),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("text", get_text, set_text),
			new LuaField("function", get_function, set_function),
		};

		LuaScriptMgr.RegisterLib(L, "ErrorModel", typeof(ErrorModel), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateErrorModel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			ErrorModel obj = new ErrorModel(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 2);
			ErrorModel obj = new ErrorModel(arg0,arg1);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ErrorModel.New");
		}

		return 0;
	}

	static Type classType = typeof(ErrorModel);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_text(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ErrorModel obj = (ErrorModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name text");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index text on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.text);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_function(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ErrorModel obj = (ErrorModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name function");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index function on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.function);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_text(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ErrorModel obj = (ErrorModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name text");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index text on a nil value");
			}
		}

		obj.text = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_function(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ErrorModel obj = (ErrorModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name function");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index function on a nil value");
			}
		}

		obj.function = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CallFunction(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ErrorModel obj = (ErrorModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "ErrorModel");
		obj.CallFunction();
		return 0;
	}
}

