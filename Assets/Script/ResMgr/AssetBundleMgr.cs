//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.ResMgr
// FileName : AssetBundleMgr
//
// Created by : maxiao (398117200@qq.com) at 2016/9/25 13:51:28
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AssetBundleMgr
{

    private Dictionary<string, AssetBundle> assetbundleCache = new Dictionary<string, AssetBundle>();
    private AssetBundleManifest m_manifest;
    private Dictionary<string, AssetBundleCreateRequest> abLoadingRequest = new Dictionary<string, AssetBundleCreateRequest>();
    #region 单例Instance

    private static AssetBundleMgr _instance;
    private static object syncObj = new object();

    public static AssetBundleMgr Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    if (_instance == null)
                    {

                        _instance = new AssetBundleMgr();
                    }
                }
            }
            return _instance;
        }
    }
    #endregion

    private AssetBundleMgr()
    {
        LoadAssetBundleManifest();
    }

    #region AssetBundle的manifest
    /// <summary>
    /// 加载主manifest
    /// </summary>
    /// <returns></returns>
    private void LoadAssetBundleManifest()
    {
        string mUrl = AppConst.fileSavePathPlatform + AppConst.platformFolderName;
        AssetBundle mab = AssetBundle.LoadFromFile(mUrl);
        m_manifest = mab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

        mab.Unload(false);
    }
    #endregion

    /// <summary>
    /// 获取资源的存放路径
    /// </summary>
    /// <param name="assetName">资源名</param>
    /// <param name="r">返回的字符串</param>
    /// <returns>是否得到</returns>
    public bool GetLoadedAssetbundle(string abName, out AssetBundle ab)
    {
        lock (syncObj)
        {
            if (assetbundleCache.ContainsKey(abName))
            {
                ab = assetbundleCache[abName];
                if (ab == null)
                {
                    Debug.Log("remove null asset bundle :" + abName);
                    assetbundleCache.Remove(abName);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                ab = null;
                return false;
            }
        }
    }
    /// <summary>
    /// 得到AssetBundle的依赖AssetBundle名列表
    /// </summary>
    /// <param name="abName"></param>
    /// <returns></returns>
    public List<string> GetAssetBundleDependencies(string abName)
    {
        LoadAssetBundleManifest();

        string[] dependencies = m_manifest.GetAllDependencies(abName);

        List<string> abDependencies = new List<string>();
        foreach (string s in dependencies)
        {
            abDependencies.Add(s);
        }

        return abDependencies;
    }

    public bool PutAssetBundleToCache(string abName, AssetBundle ab)
    {
        if (assetbundleCache.ContainsKey(abName) || ab == null)
        {
            return false;
        }
        else
        {
            assetbundleCache.Add(abName, ab);
            return true;
        }
    }

    public void LoadAssetBundle(string abName)
    {
        lock (syncObj)
        {
            if (!assetbundleCache.ContainsKey(abName))
            {
                if (!abLoadingRequest.ContainsKey(abName))
                {
                    abLoadingRequest.Add(abName,
                        AssetBundle.LoadFromFileAsync(AppConst.fileSavePathPlatform + abName));
                }
                else
                {
                    Debug.Log("abLoadingRequest 中已经存在AB :" + abName);
                }
            }
            else
            {
                Debug.Log("assetbundleCache 中已经存在AB :" + abName);
            }
        }
    }

    public AssetBundle LoadAssetBundleSync(string abName)
    {
        lock (syncObj)
        {
            if (!assetbundleCache.ContainsKey(abName))
            {
                AssetBundle ab = AssetBundle.LoadFromFile(AppConst.fileSavePathPlatform + abName);
                assetbundleCache.Add(abName, ab);
                return ab;
            }
            else
            {
                return assetbundleCache[abName];
            }
        }
    }

    public bool GetLoadingAssetBundle(string name,out AssetBundleCreateRequest abcReq)
    {
        return abLoadingRequest.TryGetValue(name, out abcReq);
    }

    public void RemoveLoadedAssetBundle(string name)
    {
        lock (syncObj)
        {
            if (assetbundleCache.ContainsKey(name))
            {
                AssetBundle ab = assetbundleCache[name];
                assetbundleCache.Remove(name);
                ab.Unload(false);
            }
            else
            {
                Debug.Log("卸载AssetBundle失败：" + name + "未被加载");
            }
        }
    }

    public bool RemoveLoadingAssetBundle(string name, bool isKeepInMemory)
    {
        lock (syncObj)
        {
            if (abLoadingRequest.ContainsKey(name))
            {
                if (abLoadingRequest[name].isDone)
                {
                    if (isKeepInMemory)
                    {
                        if (!assetbundleCache.ContainsKey(name))
                        {
                            Debug.Log("assetbundle added to cache: " + name);
                            assetbundleCache.Add(name, abLoadingRequest[name].assetBundle);
                        }
                    }
                    else
                    {
                        abLoadingRequest[name].assetBundle.Unload(false);
                    }

                    Debug.Log("remove loading ab : " + name);
                    abLoadingRequest.Remove(name);
                    return true;
                }
            }

            return false;
        }
    }
}
