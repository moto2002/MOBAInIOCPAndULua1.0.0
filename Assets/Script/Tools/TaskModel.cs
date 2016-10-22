//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Tools
// FileName : TaskModel
//
// Created by : maxiao (398117200@qq.com) at 2016/6/24 13:24:57
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class TaskModel
{
    /// <summary>
    /// 任务ID
    /// </summary>
    private int id;
    /// <summary>
    /// 要执行的任务
    /// </summary>
    private Action execute;
    /// <summary>
    /// 多久执行
    /// </summary>
    private long runtime;


    public TaskModel(int id, Action execute, long runtime)
    {
        this.id = id;
        this.execute = execute;
        this.runtime = runtime;
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public Action Execute
    {
        get { return execute; }
        set { execute = value; }
    }

    public long Runtime
    {
        get { return runtime; }
        set { runtime = value; }
    }

    public void Run()
    {
        execute();
    }
}

