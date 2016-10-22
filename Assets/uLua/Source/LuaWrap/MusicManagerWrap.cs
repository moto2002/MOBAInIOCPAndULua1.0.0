﻿using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class MusicManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("LoadAudioClip", LoadAudioClip),
			new LuaMethod("HandlePriority", HandlePriority),
			new LuaMethod("HandleEvent", HandleEvent),
			new LuaMethod("CanPlayBackSound", CanPlayBackSound),
			new LuaMethod("CanPlaySoundEffect", CanPlaySoundEffect),
			new LuaMethod("Play", Play),
			new LuaMethod("PlayBacksound", PlayBacksound),
			new LuaMethod("New", _CreateMusicManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "MusicManager", typeof(MusicManager), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMusicManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "MusicManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(MusicManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAudioClip(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MusicManager obj = (MusicManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MusicManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.LoadAudioClip(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HandlePriority(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MusicManager obj = (MusicManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MusicManager");
		int o = obj.HandlePriority();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HandleEvent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		MusicManager obj = (MusicManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MusicManager");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		object[] objs1 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
		bool o = obj.HandleEvent(arg0,objs1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CanPlayBackSound(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MusicManager obj = (MusicManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MusicManager");
		bool o = obj.CanPlayBackSound();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CanPlaySoundEffect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MusicManager obj = (MusicManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MusicManager");
		bool o = obj.CanPlaySoundEffect();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Play(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MusicManager obj = (MusicManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MusicManager");
		AudioClip arg0 = (AudioClip)LuaScriptMgr.GetUnityObject(L, 2, typeof(AudioClip));
		Vector3 arg1 = LuaScriptMgr.GetVector3(L, 3);
		obj.Play(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayBacksound(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MusicManager obj = (MusicManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MusicManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
		obj.PlayBacksound(arg0,arg1);
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

