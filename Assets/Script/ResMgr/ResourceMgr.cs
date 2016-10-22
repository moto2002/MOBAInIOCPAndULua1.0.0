//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets
// FileName : ResourceMgr
//
// Created by : maxiao (398117200@qq.com) at 2016/6/19 9:39:16
//
// Function : 
//
//======================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using FileMode = System.IO.FileMode;


public class ResourceMgr : EventNode, IEventListener
{
    private Dictionary<string, string> assetPathDic =
        new Dictionary<string, string>();

    private Dictionary<string, AssetInfo> assetCache = new Dictionary<string, AssetInfo>();

    private List<ResRequestInfo> mLoadingRequest = new List<ResRequestInfo>();
    private Queue<ResRequestInfo> mWaiting = new Queue<ResRequestInfo>();

    private static GameObject requestInfoContainer;

    #region 单例Instance

    private static ResourceMgr _instance;
    private static object syncObj = new object();

    public static ResourceMgr Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    _instance = GameObject.FindObjectOfType<ResourceMgr>();
                    if (_instance == null)
                    {
                        GameObject container = GameObject.Find("SingletonContainer");
                        if (container == null)
                        {
                            container = new GameObject("SingletonContainer");
                        }
                        _instance = container.AddComponent<ResourceMgr>();
                        requestInfoContainer = new GameObject("requestInfoContainer");
                        _instance.BuildeAssetRefDic();
                        Debug.Log("ResourceMgr Loaded");
                    }
                }
            }
            return _instance;
        }
    }

    #endregion



    #region 资源全名

    /// <summary>
    /// 获取资源的存放路径
    /// </summary>
    /// <param name="assetName">资源名</param>
    /// <param name="r">返回的字符串</param>
    /// <returns>是否得到</returns>
    public bool GetABName(string assetName, ref string refBundleName)
    {
        if (assetPathDic.ContainsKey(assetName))
        {
            refBundleName = assetPathDic[assetName];
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// 建立assets和assetBundles之间的对应关系字典
    /// </summary>
    /// <param name="assetBundleName"></param>
    /// <returns></returns>
    private void BuildeAssetRefDic()
    {
        string path = AppConst.fileSavePathPlatform + '/' + AppConst.assetBundleListFileName;
        FileStream fs = new FileStream(path, FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        string l;
        while ((l = sr.ReadLine()) != null)
        {
            string[] assetRef = l.Split('|');
            if (assetRef.Length == 2)
            {
                assetPathDic.Add(assetRef[0], assetRef[1]);
            }
            else
            {
                SendEvent(EventDef.LoadAssetReferenceError, l);
            }
        }

        sr.Close();
        fs.Close();
    }

    #endregion
    #region 加载资源
    /// <summary>
    /// 异步加载资源
    /// </summary>
    /// <param name="assetName"></param>
    /// <param name="listener"></param>
    /// <param name="type"></param>
    /// <param name="isKeepInMemory"></param>
    public void LoadAsync(string assetName, IEventListener listener = null, Type type = null, bool isKeepInMemory = false)
    {
        if (assetCache.ContainsKey(assetName))
        {
            if (listener != null)
                listener.HandleEvent(EventDef.LoadAssetFinished, assetCache[assetName]);


            return;
        }

        _loadAsync(assetName, listener, type, isKeepInMemory);
    }
    /// <summary>
    /// 异步加载
    /// </summary>
    /// <param name="assetName"></param>
    /// <param name="listener"></param>
    /// <param name="type"></param>
    /// <param name="isKeepInmemory"></param>
    private void _loadAsync(string assetName, IEventListener listener = null, Type type = null,
        bool isKeepInmemory = false)
    {
        foreach (ResRequestInfo info in mLoadingRequest)
        {
            if (info.assetName == assetName)
            {
                info.AddEventListener(EventDef.LoadAssetFinished, listener);
                return;
            }
        }

        foreach (ResRequestInfo i in mWaiting)
        {
            if (i.assetName == assetName)
            {
                i.AddEventListener(EventDef.LoadAssetFinished, listener);
                return;
            }
        }

        ResRequestInfo requestInfo = requestInfoContainer.AddComponent<ResRequestInfo>();
        requestInfo.assetName = assetName;
        requestInfo.AddEventListener(EventDef.LoadAssetFinished, listener);
        requestInfo.AddEventListener(EventDef.LoadAssetFinished, this);
        requestInfo.IsKeepInMemory = isKeepInmemory;
        requestInfo.type = type;
        if (assetPathDic.ContainsKey(assetName))
        {
            requestInfo.loadType = LoadType.assetBundleLoad;
        }
        else
        {
            requestInfo.loadType = LoadType.resourceLoad;
        }
        mWaiting.Enqueue(requestInfo);
    }
    /// <summary>
    /// 同步加载资源
    /// </summary>
    /// <param name="assetName"></param>
    /// <param name="listener"></param>
    /// <param name="type"></param>
    /// <param name="isKeepInMemory"></param>
    public UnityEngine.Object LoadSync(string assetName, Type type = null, bool isKeepInMemory = false)
    {
        if (assetCache.ContainsKey(assetName))
        {
            assetCache[assetName].referenceCount++;

            return assetCache[assetName].asset;
        }

        return _loadSync(assetName, type, isKeepInMemory);
    }
    /// <summary>
    /// 同步加载
    /// </summary>
    /// <param name="assetName"></param>
    /// <param name="listener"></param>
    /// <param name="type"></param>
    /// <param name="isKeepInmemory"></param>
    private UnityEngine.Object _loadSync(string assetName, Type type = null, bool isKeepInmemory = false)
    {

        UnityEngine.Object asset = null;
        if (assetPathDic.ContainsKey(assetName))
        {
            string path = AppConst.fileSavePathPlatform + '/' + assetPathDic[assetName];
            AssetBundle ab = null;
            if (!AssetBundleMgr.Instance.GetLoadedAssetbundle(assetPathDic[assetName], out ab))
            {
                ab = AssetBundle.LoadFromFile(path);
            }
            if (type == null)
            {
                asset = ab.LoadAsset(assetName);
            }
            else
            {
                asset = ab.LoadAsset(assetName, type);
            }
            ab.Unload(false);
        }
        else
        {
            if (type != null)
            {
                asset = Resources.Load(assetName, type);
            }
            else
            {
                asset = Resources.Load(assetName);
            }
        }
        AssetInfo info = new AssetInfo();
        info.IsKeepInMemory = isKeepInmemory;
        info.referenceCount = 1;
        info.asset = asset;
        info.name = assetName;

        assetCache.Add(assetName, info);
        return asset;
    }
    #endregion

    #region 资源处理
    /// <summary>
    /// 从资源字典中取得一个资源
    /// </summary>
    /// <param name="assetName">资源名</param>
    /// <returns></returns>
    public AssetInfo GetAsset(string assetName)
    {
        AssetInfo info = null;
        assetCache.TryGetValue(assetName, out info);
        return info;
    }
    /// <summary>
    /// 直接释放一个资源
    /// </summary>
    /// <param name="assetName">资源名</param>
    public void ReleaseAsset(string assetName)
    {
        AssetInfo info = null;
        assetCache.TryGetValue(assetName, out info);

        if (info != null && !info.IsKeepInMemory)
        {
            assetCache.Remove(assetName);
        }
    }
    /// <summary>
    /// 释放一个对资源的引用,引用计数减一
    /// </summary>
    /// <param name="assetName">资源名</param>
    public void ReleaseAssetReference(string assetName)
    {
        AssetInfo info = null;
        assetCache.TryGetValue(assetName, out info);

        if (info != null)
        {
            info.referenceCount--;
        }
    }

    /// <summary>
    /// 修改资源是否常驻内存
    /// </summary>
    /// <param name="assetName"></param>
    /// <param name="isKeepInMemory"></param>
    public void IsKeepInMemory(string assetName, bool isKeepInMemory)
    {
        AssetInfo info = null;
        assetCache.TryGetValue(assetName, out info);

        if (info != null)
        {
            info.IsKeepInMemory = isKeepInMemory;
        }
    }

    #endregion




    /// <summary>
    /// 一次清理所有缓存池，这里在默认所有缓存都不需要时调用
    /// </summary>
    public void ReleaseAssetCache()
    {
        if (assetCache.Count == 0)
            return;

        foreach (KeyValuePair<string, AssetInfo> aInfo in assetCache)
        {
            if (aInfo.Value.referenceCount < 1)
            {
                assetCache.Remove(aInfo.Key);
            }
        }

        GC();
    }
    /// <summary>
    /// 垃圾回收
    /// </summary>
    public void GC()
    {
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }

    /// <summary>
    /// 更新主逻辑，用于执行Load队列
    /// </summary>
    void Update()
    {
        if (mLoadingRequest.Count > 0)
        {
            for (int i = mLoadingRequest.Count - 1; i >= 0; i--)
            {
                if (mLoadingRequest[i].IsDone)
                {
                    Debug.Log(mLoadingRequest[i].assetName + " is done");
                    ResRequestInfo info = mLoadingRequest[i];
                    AssetInfo aInfo = new AssetInfo();
                    aInfo.asset = info.Asset;
                    aInfo.IsKeepInMemory = info.IsKeepInMemory;
                    aInfo.name = info.assetName;

                    info.SendEvent(EventDef.LoadAssetFinished, aInfo);
                    mLoadingRequest.RemoveAt(i);
                    Destroy(info);
                }
            }
        }

        if (mLoadingRequest.Count < SystemInfo.processorCount && mWaiting.Count > 0)
        {
            ResRequestInfo info = mWaiting.Dequeue();
            mLoadingRequest.Add(info);
            Debug.Log("mWaiting dequeue :" + info.assetName);
            info.LoadAsync();
        }
    }
    /// <summary>
    /// 处理优先级
    /// </summary>
    /// <returns></returns>
    public int HandlePriority()
    {
        return 0;
    }
    /// <summary>
    /// 加载完成的处理方法，处理资源缓存池
    /// </summary>
    /// <param name="id"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public bool HandleEvent(int id, params object[] args)
    {
        switch (id)
        {
            case EventDef.LoadAssetFinished:
                AssetInfo info = args[0] as AssetInfo;
                if (info.asset != null)
                {
                    if (!assetCache.ContainsKey(info.name))
                    {
                        assetCache.Add(info.name, info);
                    }
                }

                return false;
        }

        return false;
    }

    public Sprite GetSprite(string name)
    {
        Sprite tempSp = new Sprite();
        Sprite sprite = LoadSync(name,tempSp.GetType()) as Sprite;
        return sprite;
    }
}

