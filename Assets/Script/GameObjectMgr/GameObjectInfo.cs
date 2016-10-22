//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.GameUnitMgr
// FileName : GameUnitInfo
//
// Created by : maxiao (398117200@qq.com) at 2016/7/31 11:56:28
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameObjectInfo
{
    public GameObjectInfo()
    {
    }

    public GameObjectInfo(int id, string name, string prototypeName, GameObject gameUnit, bool isReuse)
    {
        this.id = id;
        this.name = name;
        this.prototypeName = prototypeName;
        this.gameObj = gameUnit;
        IsReuse = isReuse;
    }

    /// <summary>
    /// 单位的Id
    /// </summary>
    public int id;
    /// <summary>
    /// 单位名
    /// </summary>
    public string name;
    /// <summary>
    /// 原型的名字
    /// </summary>
    public string prototypeName;
    /// <summary>
    /// 单位对象
    /// </summary>
    public GameObject gameObj;
    /// <summary>
    /// 是否循环使用
    /// </summary>
    public bool IsReuse = false;
}
