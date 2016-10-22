using System;
using LuaInterface;

public class AppConstWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateAppConst),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("READ_BUFF_COUNT", get_READ_BUFF_COUNT, null),
			new LuaField("IsLuaEncode", get_IsLuaEncode, null),
			new LuaField("AppName", get_AppName, null),
			new LuaField("DebugMode", get_DebugMode, null),
			new LuaField("UpdateMode", get_UpdateMode, null),
			new LuaField("AssetDirName", get_AssetDirName, null),
			new LuaField("fileListTxtName", get_fileListTxtName, null),
			new LuaField("versionFileName", get_versionFileName, null),
			new LuaField("assetBundleListFileName", get_assetBundleListFileName, null),
			new LuaField("assetBundleDependenciesFileName", get_assetBundleDependenciesFileName, null),
			new LuaField("UsePbc", get_UsePbc, null),
			new LuaField("UseLpeg", get_UseLpeg, null),
			new LuaField("UsePbLua", get_UsePbLua, null),
			new LuaField("UseCJson", get_UseCJson, null),
			new LuaField("UseSproto", get_UseSproto, null),
			new LuaField("AutoWrapMode", get_AutoWrapMode, null),
			new LuaField("DOWNLOAD_SERVER_IP", get_DOWNLOAD_SERVER_IP, set_DOWNLOAD_SERVER_IP),
			new LuaField("DOWNLOAD_SERVER_PORT", get_DOWNLOAD_SERVER_PORT, set_DOWNLOAD_SERVER_PORT),
			new LuaField("GAME_SERVER_IP", get_GAME_SERVER_IP, set_GAME_SERVER_IP),
			new LuaField("GAME_SERVER_PORT", get_GAME_SERVER_PORT, set_GAME_SERVER_PORT),
			new LuaField("WebUrl", get_WebUrl, null),
			new LuaField("luaSourcePath", get_luaSourcePath, null),
			new LuaField("StreamingAssetPath", get_StreamingAssetPath, null),
			new LuaField("platformFolderName", get_platformFolderName, null),
			new LuaField("fileSavePathPlatform", get_fileSavePathPlatform, null),
			new LuaField("uLuaPath", get_uLuaPath, null),
		};

		LuaScriptMgr.RegisterLib(L, "AppConst", typeof(AppConst), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAppConst(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AppConst obj = new AppConst();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AppConst.New");
		}

		return 0;
	}

	static Type classType = typeof(AppConst);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_READ_BUFF_COUNT(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.READ_BUFF_COUNT);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsLuaEncode(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.IsLuaEncode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppName(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.AppName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DebugMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.DebugMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UpdateMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.UpdateMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AssetDirName(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.AssetDirName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fileListTxtName(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.fileListTxtName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_versionFileName(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.versionFileName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_assetBundleListFileName(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.assetBundleListFileName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_assetBundleDependenciesFileName(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.assetBundleDependenciesFileName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UsePbc(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.UsePbc);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UseLpeg(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.UseLpeg);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UsePbLua(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.UsePbLua);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UseCJson(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.UseCJson);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UseSproto(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.UseSproto);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AutoWrapMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.AutoWrapMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DOWNLOAD_SERVER_IP(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.DOWNLOAD_SERVER_IP);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DOWNLOAD_SERVER_PORT(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.DOWNLOAD_SERVER_PORT);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GAME_SERVER_IP(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.GAME_SERVER_IP);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GAME_SERVER_PORT(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.GAME_SERVER_PORT);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WebUrl(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.WebUrl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_luaSourcePath(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.luaSourcePath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StreamingAssetPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.StreamingAssetPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_platformFolderName(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.platformFolderName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fileSavePathPlatform(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.fileSavePathPlatform);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uLuaPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.uLuaPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_DOWNLOAD_SERVER_IP(IntPtr L)
	{
		AppConst.DOWNLOAD_SERVER_IP = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_DOWNLOAD_SERVER_PORT(IntPtr L)
	{
		AppConst.DOWNLOAD_SERVER_PORT = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_GAME_SERVER_IP(IntPtr L)
	{
		AppConst.GAME_SERVER_IP = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_GAME_SERVER_PORT(IntPtr L)
	{
		AppConst.GAME_SERVER_PORT = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

