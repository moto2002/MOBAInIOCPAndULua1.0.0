using System;
using LuaInterface;

public class OneByOne_MoveDTOWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateOneByOne_MoveDTO),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("userId", get_userId, set_userId),
			new LuaField("posX", get_posX, set_posX),
			new LuaField("posY", get_posY, set_posY),
			new LuaField("posZ", get_posZ, set_posZ),
			new LuaField("dirX", get_dirX, set_dirX),
			new LuaField("dirY", get_dirY, set_dirY),
			new LuaField("dirZ", get_dirZ, set_dirZ),
		};

		LuaScriptMgr.RegisterLib(L, "OneByOne.MoveDTO", typeof(OneByOne.MoveDTO), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOneByOne_MoveDTO(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OneByOne.MoveDTO obj = new OneByOne.MoveDTO();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OneByOne.MoveDTO.New");
		}

		return 0;
	}

	static Type classType = typeof(OneByOne.MoveDTO);

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
		OneByOne.MoveDTO obj = (OneByOne.MoveDTO)o;

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
	static int get_posX(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.MoveDTO obj = (OneByOne.MoveDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name posX");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index posX on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.posX);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_posY(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.MoveDTO obj = (OneByOne.MoveDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name posY");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index posY on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.posY);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_posZ(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.MoveDTO obj = (OneByOne.MoveDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name posZ");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index posZ on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.posZ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dirX(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.MoveDTO obj = (OneByOne.MoveDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dirX");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dirX on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.dirX);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dirY(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.MoveDTO obj = (OneByOne.MoveDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dirY");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dirY on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.dirY);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dirZ(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.MoveDTO obj = (OneByOne.MoveDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dirZ");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dirZ on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.dirZ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_userId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.MoveDTO obj = (OneByOne.MoveDTO)o;

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
	static int set_posX(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.MoveDTO obj = (OneByOne.MoveDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name posX");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index posX on a nil value");
			}
		}

		obj.posX = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_posY(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.MoveDTO obj = (OneByOne.MoveDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name posY");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index posY on a nil value");
			}
		}

		obj.posY = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_posZ(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.MoveDTO obj = (OneByOne.MoveDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name posZ");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index posZ on a nil value");
			}
		}

		obj.posZ = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dirX(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.MoveDTO obj = (OneByOne.MoveDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dirX");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dirX on a nil value");
			}
		}

		obj.dirX = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dirY(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.MoveDTO obj = (OneByOne.MoveDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dirY");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dirY on a nil value");
			}
		}

		obj.dirY = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dirZ(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		OneByOne.MoveDTO obj = (OneByOne.MoveDTO)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dirZ");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dirZ on a nil value");
			}
		}

		obj.dirZ = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

