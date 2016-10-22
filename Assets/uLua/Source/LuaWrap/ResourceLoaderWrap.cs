using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class ResourceLoaderWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetSprite", GetSprite),
			new LuaMethod("LoadSync", LoadSync),
			new LuaMethod("GetAsset", GetAsset),
			new LuaMethod("ReleaseAsset", ReleaseAsset),
			new LuaMethod("ReleaseAssetReference", ReleaseAssetReference),
			new LuaMethod("IsKeepInMemory", IsKeepInMemory),
			new LuaMethod("ReleaseAssetCache", ReleaseAssetCache),
			new LuaMethod("New", _CreateResourceLoader),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "ResourceLoader", typeof(ResourceLoader), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateResourceLoader(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ResourceLoader obj = new ResourceLoader();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ResourceLoader.New");
		}

		return 0;
	}

	static Type classType = typeof(ResourceLoader);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSprite(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Sprite o = ResourceLoader.GetSprite(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadSync(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Type arg1 = LuaScriptMgr.GetTypeObject(L, 2);
		bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
		Object o = ResourceLoader.LoadSync(arg0,arg1,arg2);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		AssetInfo o = ResourceLoader.GetAsset(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReleaseAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		ResourceLoader.ReleaseAsset(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReleaseAssetReference(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		ResourceLoader.ReleaseAssetReference(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsKeepInMemory(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
		ResourceLoader.IsKeepInMemory(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReleaseAssetCache(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		ResourceLoader.ReleaseAssetCache();
		return 0;
	}
}

