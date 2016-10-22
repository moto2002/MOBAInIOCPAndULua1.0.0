//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script
// FileName : Main
//
// Created by : maxiao (398117200@qq.com) at 2016/6/29 9:23:41
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Main : MonoBehaviour
{
    void Awake()
    {
        LuaScriptMgr.Instance.Start();
    }
}

