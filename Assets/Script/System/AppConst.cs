//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets
// FileName : AppConst
//
// Created by : maxiao (398117200@qq.com) at 2016/6/19 0:10:23
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class AppConst
{
    public static string DOWNLOAD_SERVER_IP = "127.0.2.1";
    public static int DOWNLOAD_SERVER_PORT = 8080;

    public static string GAME_SERVER_IP = "127.0.0.1";
    public static int GAME_SERVER_PORT = 6650;
    public const int READ_BUFF_COUNT = 1024;
    public const bool IsLuaEncode = false;
    public const string AppName = "LOL";
    public const bool DebugMode = false;
    public const bool UpdateMode = false;
    public const string AssetDirName = "StreamingAssets";
    public const string fileListTxtName = "/files.txt";
    public const string versionFileName = "/Version.txt";
    public const string assetBundleListFileName = "/Assets.txt";
    public const string assetBundleDependenciesFileName = "/AbDependencies.txt";
    
    //资源更新地址
    public static string WebUrl
    {
        get
        {
            return "http://" + DOWNLOAD_SERVER_IP + ":" + DOWNLOAD_SERVER_PORT + "/LOLFile/";
        }
    }

    /// <summary>
    /// lua文件源地址
    /// </summary>
    public static string luaSourcePath
    {
        get {
            return Application.dataPath + "/lua/".ToLower();
        }
    }



    /// <summary>
    /// StreamingAsset路径名
    /// </summary>
    public static string StreamingAssetPath
    {
        get { return Application.streamingAssetsPath; }
    }

    /// <summary>
    /// 平台文件夹名
    /// </summary>
    public static string platformFolderName
    {
        get
        {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            return "Android";
#elif UNITY_ANDROID
            return "Android";
#elif UNITY_WEB_PLAYER
        return "WebPlayer";
#elif UNITY_IPHONE
        return "IOS";
#elif UNITY_STANDALONE_OSX
        return "OSX";
#endif
        }
    }

    public static string fileSavePathPlatform
    {
        get
        {
            string path = "";
#if UNITY_ANDROID && !UNITY_EDITOR
            path = Application.persistentDataPath + '/' + platformFolderName + '/';
#elif UNITY_IPHONE && !UNITY_EDITOR
            path = Application.dataPath + "/Raw/";  
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
            path = Application.persistentDataPath + "/" + platformFolderName + "/";
#else
            path = string.Empty;
#endif
            return path;
        }
    }
#region ULua常数
    public const bool UsePbc = true;                           //PBC
    public const bool UseLpeg = true;                          //LPEG
    public const bool UsePbLua = true;                         //Protobuff-lua-gen
    public const bool UseCJson = true;                         //CJson
    public const bool UseSproto = true;                        //Sproto
    public const bool AutoWrapMode = true;                     //自动Wrap模式 
    /// <summary>
    /// 这个路径是用来生成静态注册类的
    /// </summary>
    public static string uLuaPath
    {
        get
        {
            return Application.dataPath + "/uLua/";
        }
    }

#endregion
}

