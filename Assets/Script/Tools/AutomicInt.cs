//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Tools
// FileName : ConcurrentInteger
//
// Created by : maxiao (398117200@qq.com) at 2016/6/24 13:45:50
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


public class AutomicInt
{
    private int value;
    private Mutex tex = new Mutex();

    public AutomicInt()
    {
        value = 0;
    }

    public AutomicInt(int value)
    {
        this.value = value;
    }

    public int GetIncrease()
    {
        lock (this)
        {
            tex.WaitOne();
            this.value ++;
            tex.ReleaseMutex();
            return value;
        }
    }

    public int GetReduce()
    {
        lock (this)
        {
            tex.WaitOne();
            value--;
            tex.ReleaseMutex();
            return value;
        }
    }

    public int Get()
    {
        return value;
    }
}

