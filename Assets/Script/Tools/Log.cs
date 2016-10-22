//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets
// FileName : Log
//
// Created by : maxiao (398117200@qq.com) at 2016/6/18 19:43:28
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Log
{
    /// <summary>
    /// log委托定义
    /// </summary>
    /// <param name="arg"></param>
    public delegate void LogFunc(object arg);

    public static LogFunc Error = UnityEngine.Debug.LogError;
#if UNITY_EDITOR
    public static LogFunc log = UnityEngine.Debug.Log;
    public static LogFunc Warning = UnityEngine.Debug.LogWarning;
#else
    public static void log(){

    }

    public static void Warning(){

    }
#endif
}

