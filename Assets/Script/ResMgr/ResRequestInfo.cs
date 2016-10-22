//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.ResMgr
// FileName : ResRequestInfo
//
// Created by : maxiao (398117200@qq.com) at 2016/6/19 20:53:35
//
// Function : 
//
//======================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public enum LoadType
{
    resourceLoad,
    assetBundleLoad
}

/// <summary>
/// 资源请求
/// </summary>
public class ResRequestInfo : EventNode
{
    /// <summary>
    /// 请求的资源名
    /// </summary>
    public string assetName;
    /// <summary>
    /// 请求的资源类型
    /// </summary>
    public Type type;
    /// <summary>
    /// 是否常驻内存
    /// </summary>
    public bool IsKeepInMemory;
    /// <summary>
    /// Resources资源加载请求
    /// </summary>
    public ResourceRequest resReq = null;
    /// <summary>
    /// AssetBundle资源加载请求
    /// </summary>
    private AssetBundleRequest abReq = null;
    /// <summary>
    /// 是否加载完成
    /// </summary>
    private bool isDone = false;
    /// <summary>
    /// 加载到的资源
    /// </summary>
    private UnityEngine.Object asset;
    /// <summary>
    /// 加载类型（Resources加载还是AssetBundle加载）
    /// </summary>
    public LoadType loadType = LoadType.resourceLoad;
    /// <summary>
    /// 要加载的AB名字
    /// </summary>
    private List<string> toLoadAbNames = new List<string>();


    private string mainAbName;
    AssetBundle mainAb = null;
    /// <summary>
    /// 异步加载
    /// </summary>
    public void LoadAsync()
    {
        string abName = null;

        Debug.Log("load async:" + assetName);
        if (ResourceMgr.Instance.GetABName(assetName, ref abName))
        {
            Debug.Log("resource: " + assetName + " exists");
            if (loadType == LoadType.assetBundleLoad)
            {
                Debug.Log("load from assetbundle: " + assetName);
                LoadAssetFromBundle(abName);
            }
            else if (loadType == LoadType.resourceLoad)
            {
                if (type == null)
                {
                    resReq = Resources.LoadAsync(abName);
                }
                else
                {
                    resReq = Resources.LoadAsync(abName, type);
                }
                Debug.Log("Load from resource async: " + assetName);
            }
        }
        else
        {
            Debug.Log("resource: " + assetName + " not exists");
        }
    }
    /// <summary>
    /// assetBundle加载
    /// </summary>
    /// <param name="abName"></param>
    /// <returns></returns>
    void LoadAssetFromBundle(string abName)
    {
            Debug.Log("Enter load asset from bundle :" + abName);
            mainAbName = abName;
            AssetBundleMgr.Instance.GetLoadedAssetbundle(abName, out mainAb);
            toLoadAbNames = AssetBundleMgr.Instance.GetAssetBundleDependencies(abName);
            toLoadAbNames.Add(abName);


            List<string> loadedAbNames = new List<string>();
            for (int i = 0; i < toLoadAbNames.Count; i++)
            {
                AssetBundle temp;
                if (AssetBundleMgr.Instance.GetLoadedAssetbundle(toLoadAbNames[i], out temp))
                {
                    Debug.Log("remove toLoadAbName :" + toLoadAbNames[i]);
                    loadedAbNames.Add(toLoadAbNames[i]);
                }
            }

            for (int i = 0; i < loadedAbNames.Count; i++)
            {
                if (toLoadAbNames.Contains(loadedAbNames[i]))
                {
                    toLoadAbNames.Remove(loadedAbNames[i]);
                }
            }

            foreach (string s in toLoadAbNames)
            {
                AssetBundleMgr.Instance.LoadAssetBundle(s);
            }

            StartCoroutine("checkIfAssetBundleLoaded");
    }

    IEnumerator checkIfAssetBundleLoaded()
    {
        while (true)
        {
            if (toLoadAbNames.Count > 0)
            {
                Debug.Log("要加载的AB大于0个");
                for (int i = 0; i < toLoadAbNames.Count; i++)
                {
                    AssetBundleCreateRequest abCreateReq = null;
                    AssetBundle tempAb;
                    if (!AssetBundleMgr.Instance.GetLoadedAssetbundle(toLoadAbNames[i], out tempAb))
                    {
                        if (AssetBundleMgr.Instance.GetLoadingAssetBundle(toLoadAbNames[i], out abCreateReq))
                        {
                            Debug.Log(toLoadAbNames[i] + " loaded");
                            if (abCreateReq.isDone)
                            {
                                if (toLoadAbNames[i] == mainAbName)
                                {
                                    mainAb = abCreateReq.assetBundle;
                                }
                                AssetBundleMgr.Instance.RemoveLoadingAssetBundle(toLoadAbNames[i], IsKeepInMemory);
                                toLoadAbNames.RemoveAt(i);
                            }
                        }
                    }
                    else
                    {
                        if (toLoadAbNames[i] == mainAbName)
                        {
                            mainAb = tempAb;
                        }
                        toLoadAbNames.RemoveAt(i);
                    }
                }
            }
            else
            {
                if (mainAb != null)
                {
                    Debug.Log("main ab : " + mainAbName + " is not null");
                    ABLoadAsset();
                    StopCoroutine("checkIfAssetBundleLoaded");
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }

    void ABLoadAsset()
    {
        Debug.Log("load asset: " + assetName);
        if (type != null)
        {
            abReq = mainAb.LoadAssetAsync(assetName, type);
        }
        else
        {
            abReq = mainAb.LoadAssetAsync(assetName);
        }
    }

    /// <summary>
    /// 加载到的资源
    /// </summary>
    public UnityEngine.Object Asset
    {
        get
        {
            if (loadType == LoadType.assetBundleLoad)
            {
                return abReq.asset;
            }
            else
            {
                return resReq.asset;
            }
        }
    }
    /// <summary>
    /// 是否加载完成
    /// </summary>
    public bool IsDone
    {
        get
        {
            if (loadType == LoadType.assetBundleLoad)
            {
                return abReq != null && abReq.isDone;
            }
            else
            {
                return resReq != null && resReq.isDone;
            }
        }
    }
}

