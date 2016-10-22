//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.ResMgr
// FileName : ResDownloader
//
// Created by : maxiao (398117200@qq.com) at 2016/6/21 2:26:12
//
// Function : 
//
//======================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 管理游戏初始化时的版本检查及更新
/// </summary>
[RequireComponent(typeof(DownloadScreen))]
public class ResDownloader : EventNode, IEventListener
{
    /// <summary>
    /// 辅助锁对象
    /// </summary>
    private readonly object m_syncRoot = new object();
    /// <summary>
    /// 版本号，存放在PlayerPrefs里
    /// </summary>
    private string versionString = null;
    /// <summary>
    /// 下载得到的最新版本号
    /// </summary>
    private string newVersionString = null;
    /// <summary>
    /// 正在执行的下载任务
    /// </summary>
    private Dictionary<string, DownloadTask> downloadingTasks = new Dictionary<string, DownloadTask>();
    /// <summary>
    /// 等待执行的下载任务
    /// </summary>
    private Queue<DownloadTask> waitingTasks = new Queue<DownloadTask>();
    /// <summary>
    /// 下载界面
    /// </summary>
    private DownloadScreen dScreen;

    private GameObject downloadTaskContainer;
    private Dictionary<string, string> existedFileNameAndMd5s;

    private string localFileListTxtName;
    /// <summary>
    /// 开始更新
    /// </summary>
    void Start()
    {
#if UNITY_EDITOR
        versionString = "1.0.0.0";
#elif UNITY_ANDROID
        versionString = PlayerPrefs.GetString("version", "0.0.0.0");
#endif
        dScreen = gameObject.GetComponent<DownloadScreen>();
        existedFileNameAndMd5s = new Dictionary<string, string>();
        downloadTaskContainer = new GameObject("downloadTaskContainer");
    }

    public void StartUpdate()
    {
        Debug.Log("start update");
        StopCoroutine("CheckUpdate");
        StartCoroutine("CheckUpdate");
    }

    /// <summary>
    /// 下载版本信息，检查是否需要更新文件列表
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckUpdate()
    {
        WWW www = new WWW(AppConst.WebUrl + AppConst.versionFileName);
        Debug.Log(AppConst.WebUrl + AppConst.versionFileName);
        yield return www;
        if (www.error != null)
        {
            Debug.Log("Check version error:" + www.error);
            SendEvent(EventDef.DownloadVersionError, www.error);
            yield break;
        }
        Debug.Log(www.text);
        string[] versionStrs = www.text.Split('\n');

        string newVersionStr = versionStrs[0];

        if (CheckVersionIfNeedUpdate(versionString, newVersionStr))
        {
            newVersionString = newVersionStr;
            StartCoroutine("DownloadFileListAndCheck");
        }
        else
        {
            ActionAfterUpdateCompleted();
        }
    }
    /// <summary>
    /// 根据新、旧版本号字符串，检查是否需要更新
    /// </summary>
    /// <param name="oldVersionStr"></param>
    /// <param name="newVersionStr"></param>
    /// <returns></returns>
    private bool CheckVersionIfNeedUpdate(string oldVersionStr, string newVersionStr)
    {
        string[] oldVersions = oldVersionStr.Split('.');
        string[] newVersions = newVersionStr.Split('.');
        if (oldVersions.Length != newVersions.Length || oldVersions.Length != 4)
        {
            Debug.Log("版本号格式有误");
            SendEvent(EventDef.VersionNumberFormatError, null);
            return false;
        }

        for (int i = 0; i < oldVersions.Length; i++)
        {
            int a = Convert.ToInt32(oldVersions[i]);
            int b = Convert.ToInt32(newVersions[i]);
            if (a < b)
            {
                return true;
            }
        }

        return false;
    }


    /// <summary>
    /// 下载相应的文件列表文档，检查其中对应的文件，更新这些文件
    /// </summary>
    /// <param name="fileListTxtName"></param>
    /// <returns></returns>
    IEnumerator DownloadFileListAndCheck()
    {
        SendEvent(EventDef.DownloadFileList, AppConst.fileListTxtName);

        string listFilePath = AppConst.WebUrl + AppConst.platformFolderName  + AppConst.fileListTxtName;
        Debug.Log(listFilePath);
        WWW www = new WWW(listFilePath);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            SendEvent(EventDef.DownloadFileListError, www.error);
            yield break;
        }

        localFileListTxtName = AppConst.fileSavePathPlatform + AppConst.fileListTxtName;
        Dictionary<string, string> oldFileInfos = new Dictionary<string, string>();
        FileInfo fInfo = new FileInfo(localFileListTxtName);
        if (fInfo.Exists)
        {
            FileStream fs = File.Open(localFileListTxtName, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string[] strBlock = sr.ReadToEnd().Split('\n');

            for (int i = 0; i < strBlock.Length; i++)
            {
                string s = strBlock[i].Replace("\r", string.Empty);
                string[] pair = strBlock[i].Split('|');
                if (pair.Length == 2)
                {
                    oldFileInfos.Add(pair[0].TrimStart().TrimEnd(), pair[1].TrimStart().TrimEnd());
                }
            }

            sr.Close();
            fs.Close();
        }

        existedFileNameAndMd5s.Clear();
        string fileNames = www.text;
        string[] files = fileNames.Split('\n');
        Dictionary<string, string> latestFileInfos = new Dictionary<string, string>();
        for (int i = 0; i < files.Length; i++)
        {
            string newInfo = files[i].Replace("\r", string.Empty);
            string[] info = newInfo.Split('|');
            if (info.Length == 2)
            {
                latestFileInfos.Add(info[0].TrimStart().TrimEnd(), info[1].TrimStart().TrimEnd());
            }
        }
        Debug.Log("读取最新文件列表完成");
        Dictionary<string, string> wantedFileInfos = new Dictionary<string, string>();

        foreach (KeyValuePair<string, string> p in latestFileInfos)
        {
            if (oldFileInfos.ContainsKey(p.Key))
            {
                if (oldFileInfos[p.Key] != p.Value)
                {
                    wantedFileInfos.Add(p.Key, p.Value);
                    Debug.Log("需要更新的文件:" + p.Key);
                }
                else
                {
                    existedFileNameAndMd5s.Add(p.Key, p.Value);
                    Debug.Log("不需要更新的文件:" + p.Key);
                }
            }
            else
            {
                wantedFileInfos.Add(p.Key, p.Value);
                Debug.Log("需要更新的文件:" + p.Key);
            }
        }

        foreach (KeyValuePair<string, string> info in wantedFileInfos)
        {
            string url = AppConst.WebUrl + AppConst.platformFolderName + '/' + info.Key;
            string localSaveName = info.Key;
            string md5 = info.Value;

            DownloadTask dTask = downloadTaskContainer.AddComponent<DownloadTask>();
            string localSavePath = AppConst.fileSavePathPlatform + localSaveName;
            string saveDirectory = Path.GetDirectoryName(localSavePath);
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }
            dTask.SetDownloadTask(url, localSaveName, localSavePath, md5);
            //TODO 一些下载事件的设置
            dTask.AddEventListener(EventDef.DownloadFileCompleted, this);
            dTask.AddEventListener(EventDef.DownloadFileProgressChanged, this);

            waitingTasks.Enqueue(dTask);
        }

        StartCoroutine(DownloadFiles());
    }

    /// <summary>
    /// 检查等待下载队列，开始下载，并行下载数应不大于平台CPU线程数
    /// </summary>
    /// <returns></returns>
    IEnumerator DownloadFiles()
    {
        while (true)
        {
            if (waitingTasks.Count != 0)
            {
                if (downloadingTasks.Count < SystemInfo.processorCount)
                {
                    DownloadTask dTask = waitingTasks.Dequeue();
                    dTask.ExecuteTask();
                    Debug.Log("start download file:" + dTask.LocalSaveName);
                    downloadingTasks.Add(dTask.LocalSaveName, dTask);
                }
            }
            else
            {
                if (downloadingTasks.Count == 0)
                {
                    if(newVersionString != null)
                        PlayerPrefs.SetString("version", newVersionString);

                    UpdateFileListFile();
                    ActionAfterUpdateCompleted();

                    StopCoroutine(DownloadFiles());
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }

    void UpdateFileListFile()
    {
        if (File.Exists(localFileListTxtName))
        {
            File.Delete(localFileListTxtName);
        }
        FileStream fs = new FileStream(localFileListTxtName, FileMode.CreateNew);
        StreamWriter sw = new StreamWriter(fs);
        foreach (KeyValuePair<string, string> pair in existedFileNameAndMd5s)
        {
            sw.WriteLine(pair.Key + '|' + pair.Value);
        }

        sw.Close();
        fs.Close();
    }

    void ActionAfterUpdateCompleted()
    {
        dScreen.SetProgressBarAndText("全部下载完成！", 100);
        transform.GetComponent<DownloadScreen>().ScreenOnDownloadCompleted();
    }

 
    /// <summary>
    /// 下载事件处理的优先级
    /// </summary>
    /// <returns></returns>
    public int HandlePriority()
    {
        return 0;
    }
    /// <summary>
    /// 当有一个异步下载事件通知时进行的处理，需要加锁
    /// </summary>
    /// <param name="id"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public bool HandleEvent(int id, params object[] args)
    {
        lock (m_syncRoot)
        {
            switch (id)
            {
                case EventDef.DownloadFileCompleted:
                    string localSaveName = args[0] as string;
                    string md5ToCheck = args[1] as string;
                    string localSavePath = args[2] as string;
                    Debug.Log("handle event downloadFileCompleted");
                    string checkedMd5 = Util.md5file(localSavePath);
                    if (checkedMd5 != md5ToCheck)
                    {
                        //TODO md5码校验不一致，进行处理和通知
                        waitingTasks.Enqueue(downloadingTasks[localSaveName]);
                        downloadingTasks.Remove(localSaveName);
                    }
                    else
                    {
                        //md5校验正确，说明下载成功
                        //TODO 下载成功后的一些通知
                        Debug.Log("下载成功：" + localSavePath);
                        dScreen.SetProgressBarAndText(localSavePath + "更新完成！", 100);
                        existedFileNameAndMd5s.Add(localSaveName, md5ToCheck);
                        //移除下载完成的任务
                        downloadingTasks.Remove(localSaveName);
                    }

                    return true;
                case EventDef.DownloadFileProgressChanged:
                    //TODO 下载进度变化的一些通知
                    string savePath = args[0] as string;
                    DownloadProgressChangedEventArgs e = args[1] as DownloadProgressChangedEventArgs;
                    dScreen.SetProgressBarAndText(savePath, e.ProgressPercentage);

                    return true;
            }
            return false;
        }
    }
}

