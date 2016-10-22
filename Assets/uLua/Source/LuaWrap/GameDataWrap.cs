using System;
using LuaInterface;

public class GameDataWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateGameData),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("user", get_user, set_user),
			new LuaField("posUpdateRate", get_posUpdateRate, set_posUpdateRate),
			new LuaField("teamOneStart", get_teamOneStart, set_teamOneStart),
			new LuaField("teamTwoStart", get_teamTwoStart, set_teamTwoStart),
			new LuaField("cameraFollowOffset", get_cameraFollowOffset, set_cameraFollowOffset),
			new LuaField("mapToMiniMapScale", get_mapToMiniMapScale, set_mapToMiniMapScale),
		};

		LuaScriptMgr.RegisterLib(L, "GameData", typeof(GameData), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGameData(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			GameData obj = new GameData();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GameData.New");
		}

		return 0;
	}

	static Type classType = typeof(GameData);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_user(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, GameData.user);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_posUpdateRate(IntPtr L)
	{
		LuaScriptMgr.Push(L, GameData.posUpdateRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_teamOneStart(IntPtr L)
	{
		LuaScriptMgr.Push(L, GameData.teamOneStart);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_teamTwoStart(IntPtr L)
	{
		LuaScriptMgr.Push(L, GameData.teamTwoStart);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cameraFollowOffset(IntPtr L)
	{
		LuaScriptMgr.Push(L, GameData.cameraFollowOffset);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mapToMiniMapScale(IntPtr L)
	{
		LuaScriptMgr.Push(L, GameData.mapToMiniMapScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_user(IntPtr L)
	{
		GameData.user = (OneByOne.UserDTO)LuaScriptMgr.GetNetObject(L, 3, typeof(OneByOne.UserDTO));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_posUpdateRate(IntPtr L)
	{
		GameData.posUpdateRate = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_teamOneStart(IntPtr L)
	{
		GameData.teamOneStart = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_teamTwoStart(IntPtr L)
	{
		GameData.teamTwoStart = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cameraFollowOffset(IntPtr L)
	{
		GameData.cameraFollowOffset = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mapToMiniMapScale(IntPtr L)
	{
		GameData.mapToMiniMapScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

