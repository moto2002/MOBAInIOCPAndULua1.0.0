//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.ResMgr
// FileName : ResourceLoader
//
// Created by : maxiao (398117200@qq.com) at 2016/9/20 18:35:12
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ResourceLoader
{
    public static Sprite GetSprite(string name)
    {
        return ResourceMgr.Instance.GetSprite(name);
    }

    public static UnityEngine.Object LoadSync(string assetName, Type type = null, bool isKeepInMemory = false)
    {
        return ResourceMgr.Instance.LoadSync(assetName, type, isKeepInMemory);
    }

    public static AssetInfo GetAsset(string assetName)
    {
        return ResourceMgr.Instance.GetAsset(assetName);
    }

    public static void ReleaseAsset(string assetName)
    {
        ResourceMgr.Instance.ReleaseAsset(assetName);
    }

    public static void ReleaseAssetReference(string assetName)
    {
        ResourceMgr.Instance.ReleaseAssetReference(assetName);
    }

    public static void IsKeepInMemory(string assetName, bool isKeepInMemory)
    {
        ResourceMgr.Instance.IsKeepInMemory(assetName, isKeepInMemory);
    }

    public static void ReleaseAssetCache()
    {
        ResourceMgr.Instance.ReleaseAssetCache();
    }
}
