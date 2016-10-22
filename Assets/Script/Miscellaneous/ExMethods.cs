//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script
// FileName : ExMethods
//
// Created by : maxiao (398117200@qq.com) at 2016/8/1 16:44:46
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class ExMethods
{
    /// <summary>
    /// 扩展write方法，使在所有MonoBehaviour中都可以直接调用这个方法
    /// </summary>
    /// <param name="mono"></param>
    /// <param name="type"></param>
    /// <param name="area"></param>
    /// <param name="command"></param>
    /// <param name="message"></param>
    public static void WriteMessage(this MonoBehaviour mono, int type,int area,int command,object message)
    {
        NetWorkScript.Instance.write(type, area, command, message);
    }
}