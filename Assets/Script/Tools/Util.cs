//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets
// FileName : Util
//
// Created by : maxiao (398117200@qq.com) at 2016/6/20 18:56:42
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;


public class Util
{
    /// <summary>
    /// 计算文件的MD5值
    /// </summary>
    public static string md5file(string file)
    {
        try
        {
            if (File.Exists(file))
            {
                FileStream fs = new FileStream(file, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(fs);
                fs.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            else
            {
                Debug.Log("md5 校验失败！ file : " + file + " 不存在");
                return "";
            }
        }
        catch (Exception ex)
        {
            throw new Exception("md5file() fail, error:" + ex.Message);
        }
    }



    /// <summary>
    /// 取得Lua路径
    /// </summary>
    public static string LuaPath(string name)
    {
        string path = null;
        path = AppConst.fileSavePathPlatform;


        string lowerName = name.ToLower();
        if (lowerName.EndsWith(".lua"))
        {
            int index = name.LastIndexOf('.');
            name = name.Substring(0, index);
        }
        name = name.Replace('.', '/');
		path = path + "/lua/" + name + ".lua";
		if (File.Exists (path))
			return path;
		else {
			Debug.Log ("path do not exited! path name:" + path);
			return null;
		}
    }

    public static void Log(string str)
    {
        Debug.Log(str);
    }

    public static void LogWarning(string str)
    {
        Debug.LogWarning(str);
    }

    public static void LogError(string str)
    {
        Debug.LogError(str);
    }

    /// <summary>
    /// 清理内存
    /// </summary>
    public static void ClearMemory()
    {
        GC.Collect();
        Resources.UnloadUnusedAssets();
        LuaScriptMgr mgr = LuaScriptMgr.Instance;
        if (mgr != null && mgr.lua != null) mgr.LuaGC();
    }

    /// <summary>
    /// 防止初学者不按步骤来操作
    /// </summary>
    /// <returns></returns>
    static int CheckRuntimeFile()
    {
        if (!Application.isEditor) return 0;
        string sourceDir = AppConst.uLuaPath + "/Source/LuaWrap/";
        if (!Directory.Exists(sourceDir))
        {
            return -2;
        }
        else
        {
            string[] files = Directory.GetFiles(sourceDir);
            if (files.Length == 0) return -2;
        }
        return 0;
    }

    /// <summary>
    /// 检查运行环境
    /// </summary>
    public static bool CheckEnvironment()
    {
#if UNITY_EDITOR
        int resultId = Util.CheckRuntimeFile();
        if (resultId == -1)
        {
            Debug.LogError("没有找到框架所需要的资源，单击Game菜单下Build xxx Resource生成！！");
            //EditorApplication.isPlaying = false;
            return false;
        }
        else if (resultId == -2)
        {
            Debug.LogError("没有找到Wrap脚本缓存，单击Lua菜单下Gen Lua Wrap Files生成脚本！！");
            //EditorApplication.isPlaying = false;
            return false;
        }
#endif
        return true;
    }
    /// <summary>
    /// 是不是苹果平台
    /// </summary>
    /// <returns></returns>
    public static bool isApplePlatform
    {
        get
        {
            return Application.platform == RuntimePlatform.IPhonePlayer ||
                   Application.platform == RuntimePlatform.OSXEditor ||
                   Application.platform == RuntimePlatform.OSXPlayer;
        }
    }

   
}

