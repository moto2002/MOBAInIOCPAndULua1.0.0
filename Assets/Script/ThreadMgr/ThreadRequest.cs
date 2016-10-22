//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.ThreadMgr
// FileName : ThreadRequest
//
// Created by : maxiao (398117200@qq.com) at 2016/6/21 10:19:51
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


public class ThreadRequest
{
    private Thread thread = null;

    private Action<object> m_task = null;
    private object m_arg = null;

    public void StartThread(Action<object> task, object arg = null)
    {
        m_task = task;
        m_arg = arg;
        if (thread != null)
        {
            thread.Abort();
            thread = new Thread(ExecuteTask);
            thread.Start();
        }
    }

    public void StopThread()
    {
        thread.Abort();
    }

    private void ExecuteTask()
    {
        m_task(m_arg);
    }
}

