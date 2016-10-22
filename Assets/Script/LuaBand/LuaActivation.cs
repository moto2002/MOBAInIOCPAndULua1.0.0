//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.LuaBand
// FileName : LuaActivation
//
// Created by : maxiao (398117200@qq.com) at 2016/6/30 15:47:03
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 这个类包括了两个不常用的方法
/// </summary>
public class LuaActivation : LuaInitial
{
    /// <summary>
    /// 脚本启用
    /// </summary>
    void OnEnable()
    {
        CallMethod("onEnable", insID, luaClassName);
    }
    /// <summary>
    /// 脚本禁用
    /// </summary>
    void OnDisable()
    {
        CallMethod("onDisable", insID, luaClassName);
    }
}

