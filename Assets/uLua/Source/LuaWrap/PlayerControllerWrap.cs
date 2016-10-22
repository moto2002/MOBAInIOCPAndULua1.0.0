using System;
using LuaInterface;

public class PlayerControllerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreatePlayerController),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
			new LuaField("Player", get_Player, set_Player),
			new LuaField("MyTeamId", get_MyTeamId, set_MyTeamId),
		};

		LuaScriptMgr.RegisterLib(L, "PlayerController", typeof(PlayerController), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreatePlayerController(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			PlayerController obj = new PlayerController();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: PlayerController.New");
		}

		return 0;
	}

	static Type classType = typeof(PlayerController);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, PlayerController.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Player(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PlayerController obj = (PlayerController)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Player");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Player on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.Player);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MyTeamId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PlayerController obj = (PlayerController)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name MyTeamId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index MyTeamId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.MyTeamId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Player(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PlayerController obj = (PlayerController)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Player");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Player on a nil value");
			}
		}

		obj.Player = (OneByOne.FightPlayerModel)LuaScriptMgr.GetNetObject(L, 3, typeof(OneByOne.FightPlayerModel));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MyTeamId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PlayerController obj = (PlayerController)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name MyTeamId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index MyTeamId on a nil value");
			}
		}

		obj.MyTeamId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

