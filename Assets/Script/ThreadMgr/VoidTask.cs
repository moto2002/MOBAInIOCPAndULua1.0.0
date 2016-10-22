//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.ThreadMgr
// FileName : VoidTask
//
// Created by : maxiao (398117200@qq.com) at 2016/6/21 11:26:29
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class VoidTask
{
    public Action<object> task;
    public object arg;
}

