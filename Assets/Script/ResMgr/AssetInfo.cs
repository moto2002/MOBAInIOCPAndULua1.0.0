//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.ResMgr
// FileName : AssetInfo
//
// Created by : maxiao (398117200@qq.com) at 2016/6/19 20:50:05
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class AssetInfo
{
    /// <summary>
    /// 资源名
    /// </summary>
    public string name;
    /// <summary>
    /// 资源对象
    /// </summary>
    public UnityEngine.Object asset;
    /// <summary>
    /// 是否常驻内存
    /// </summary>
    public bool IsKeepInMemory = false;
    /// <summary>
    /// 引用数
    /// </summary>
    public int referenceCount = 0;
}

