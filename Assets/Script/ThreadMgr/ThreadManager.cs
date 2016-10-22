//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets
// FileName : ThreadManager
//
// Created by : maxiao (398117200@qq.com) at 2016/6/21 9:37:55
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class ThreadManager
{
    private int processorCount = SystemInfo.processorCount;
    private List<ThreadRequest> threadPool = new List<ThreadRequest>();
    private Stack<ThreadRequest> unusedThreadStack = new Stack<ThreadRequest>();
    private Queue<VoidTask> waitingVoidTasks = new Queue<VoidTask>();
    private Action<object> actionWithArg;

    #region 单例Instance

    private static ThreadManager _instance;
    private static object syncObj = new object();

    public static ThreadManager Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    if (_instance == null)
                    {
                        
                        _instance = new ThreadManager();
                    }
                }
            }
            return _instance;
        }
    }

    #endregion

    /// <summary>
    /// 私有构造器
    /// </summary>
    private ThreadManager()
    {
    }

    /// <summary>
    /// 得到一个闲置的线程，执行传入的任务，如果没有可用的线程则将其加入一个等待队列
    /// </summary>
    /// <param name="action"></param>
    /// <param name="arg"></param>
    /// <returns></returns>
    public void StartTask(Action<object> action, object arg)
    {
        if (threadPool.Count < processorCount)
        {
            ThreadRequest request = new ThreadRequest();
            request.StartThread(action, arg);
            threadPool.Add(request);
        }
        else
        {
            if (unusedThreadStack.Count > 0)
            {
                ThreadRequest request = unusedThreadStack.Pop();
                request.StartThread(action, arg);
            }
            else
            {
                VoidTask voidTask = new VoidTask();
                voidTask.task = action;
                voidTask.arg = arg;
                waitingVoidTasks.Enqueue(voidTask);
            }
        }
    }
}

