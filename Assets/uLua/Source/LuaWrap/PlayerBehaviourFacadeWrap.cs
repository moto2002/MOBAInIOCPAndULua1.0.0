using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class PlayerBehaviourFacadeWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("UpdateControlUnit", UpdateControlUnit),
			new LuaMethod("AttackPressed", AttackPressed),
			new LuaMethod("SkillPressed", SkillPressed),
			new LuaMethod("New", _CreatePlayerBehaviourFacade),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
			new LuaField("Player", get_Player, set_Player),
		};

		LuaScriptMgr.RegisterLib(L, "PlayerBehaviourFacade", typeof(PlayerBehaviourFacade), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreatePlayerBehaviourFacade(IntPtr L)
	{
		LuaDLL.luaL_error(L, "PlayerBehaviourFacade class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(PlayerBehaviourFacade);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, PlayerBehaviourFacade.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Player(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PlayerBehaviourFacade obj = (PlayerBehaviourFacade)o;

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
	static int set_Player(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PlayerBehaviourFacade obj = (PlayerBehaviourFacade)o;

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
	static int UpdateControlUnit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		PlayerBehaviourFacade obj = (PlayerBehaviourFacade)LuaScriptMgr.GetUnityObjectSelf(L, 1, "PlayerBehaviourFacade");
		FightUnit arg0 = (FightUnit)LuaScriptMgr.GetUnityObject(L, 2, typeof(FightUnit));
		obj.UpdateControlUnit(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AttackPressed(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		PlayerBehaviourFacade obj = (PlayerBehaviourFacade)LuaScriptMgr.GetUnityObjectSelf(L, 1, "PlayerBehaviourFacade");
		obj.AttackPressed();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SkillPressed(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		PlayerBehaviourFacade obj = (PlayerBehaviourFacade)LuaScriptMgr.GetUnityObjectSelf(L, 1, "PlayerBehaviourFacade");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.SkillPressed(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

