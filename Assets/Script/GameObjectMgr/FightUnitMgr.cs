//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.GameObjectMgr
// FileName : FightUnitMgr
//
// Created by : maxiao (398117200@qq.com) at 2016/9/7 0:16:42
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FightUnitMgr:GameObjectMgr
{
    #region 单例Instance

    private static FightUnitMgr _instance;
    private static object syncObj = new object();

    public static FightUnitMgr Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    if (_instance == null)
                    {
                        _instance = new FightUnitMgr();
                    }
                }
            }
            return _instance;
        }
    }

    #endregion
}
