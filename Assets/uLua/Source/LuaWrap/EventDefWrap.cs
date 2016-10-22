using System;
using LuaInterface;

public class EventDefWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateEventDef),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("VersionNumberFormatError", get_VersionNumberFormatError, null),
			new LuaField("DownloadVersionError", get_DownloadVersionError, null),
			new LuaField("DownloadFileList", get_DownloadFileList, null),
			new LuaField("DownloadFileListError", get_DownloadFileListError, null),
			new LuaField("DownloadFileProgressChanged", get_DownloadFileProgressChanged, null),
			new LuaField("DownloadFileCompleted", get_DownloadFileCompleted, null),
			new LuaField("LoadAssetBundleMainManifestError", get_LoadAssetBundleMainManifestError, null),
			new LuaField("LoadAssetBundleError", get_LoadAssetBundleError, null),
			new LuaField("LoadAssetReferenceError", get_LoadAssetReferenceError, null),
			new LuaField("LoadAssetFinished", get_LoadAssetFinished, null),
			new LuaField("AssetBundleRefFileDontExist", get_AssetBundleRefFileDontExist, null),
			new LuaField("NeededGameObjectDontExist", get_NeededGameObjectDontExist, null),
			new LuaField("LoadAbDependenciesError", get_LoadAbDependenciesError, null),
			new LuaField("FileListNotExistError", get_FileListNotExistError, null),
			new LuaField("TableDataFinish", get_TableDataFinish, null),
			new LuaField("StateEndEvent", get_StateEndEvent, null),
			new LuaField("CreateRoleFinsh", get_CreateRoleFinsh, null),
		};

		LuaScriptMgr.RegisterLib(L, "EventDef", typeof(EventDef), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateEventDef(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			EventDef obj = new EventDef();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: EventDef.New");
		}

		return 0;
	}

	static Type classType = typeof(EventDef);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_VersionNumberFormatError(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.VersionNumberFormatError);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DownloadVersionError(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.DownloadVersionError);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DownloadFileList(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.DownloadFileList);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DownloadFileListError(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.DownloadFileListError);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DownloadFileProgressChanged(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.DownloadFileProgressChanged);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DownloadFileCompleted(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.DownloadFileCompleted);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LoadAssetBundleMainManifestError(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.LoadAssetBundleMainManifestError);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LoadAssetBundleError(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.LoadAssetBundleError);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LoadAssetReferenceError(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.LoadAssetReferenceError);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LoadAssetFinished(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.LoadAssetFinished);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AssetBundleRefFileDontExist(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.AssetBundleRefFileDontExist);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NeededGameObjectDontExist(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.NeededGameObjectDontExist);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LoadAbDependenciesError(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.LoadAbDependenciesError);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FileListNotExistError(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.FileListNotExistError);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TableDataFinish(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.TableDataFinish);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StateEndEvent(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.StateEndEvent);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CreateRoleFinsh(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDef.CreateRoleFinsh);
		return 1;
	}
}

