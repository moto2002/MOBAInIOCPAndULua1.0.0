//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.ResMgr
// FileName : DownloadTask
//
// Created by : maxiao (398117200@qq.com) at 2016/6/22 1:51:10
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.ComponentModel;
using UnityEngine;

/// <summary>
/// 每一个下载对应这样一个类
/// </summary>
public class DownloadTask : EventNode
{
    /// <summary>
    /// 下载链接
    /// </summary>
    private string url;
    /// <summary>
    /// 本地存放名字
    /// </summary>
    private string localSaveName;
    /// <summary>
    /// 本地存放地址
    /// </summary>
    private string localSavePath;
    /// <summary>
    /// 待比对的md5校验码
    /// </summary>
    private string md5ToCheck;

    private WebClient client;

    public string LocalSaveName
    {
        get { return localSaveName; }
    }

    public string Md5ToCheck
    {
        get { return md5ToCheck; }
    }

    /// <summary>
    /// 构造器
    /// </summary>
    /// <param name="url"></param>
    /// <param name="localSaveName"></param>
    /// <param name="md5"></param>
    public void SetDownloadTask(string url, string localSaveName, string localSavePath,string md5)
    {
        this.url = url;
        this.localSaveName = localSaveName;
        this.localSavePath = localSavePath;
        this.md5ToCheck = md5;
        client = new WebClient();
        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
        client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
    }
    /// <summary>
    /// 执行下载任务
    /// </summary>
    public void ExecuteTask()
    {
        client.DownloadFileAsync(new System.Uri(url), localSavePath);
        Debug.Log("开始一个下载任务:" + url);
    }

    /// <summary>
    /// 下载完成的回调
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
    {
        object[] args = new object[4];
        args[0] = localSaveName;
        args[1] = md5ToCheck;
        args[2] = localSavePath;
        args[3] = e;

        Debug.Log("download completed:" + localSavePath);
        SendEvent(EventDef.DownloadFileCompleted, args);
    }

    /// <summary>
    /// 下载进度变化的回调
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        object[] args = new object[2];
        args[0] = localSavePath;
        args[1] = e;

        SendEvent(EventDef.DownloadFileProgressChanged, args);
    }

    

    public void StopTask()
    {

    }
}

