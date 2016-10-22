//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets
// FileName : EventDef
//
// Created by : maxiao (398117200@qq.com) at 2016/6/21 3:03:33
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class EventDef
{
    #region 系统消息 1-1000

    public const int VersionNumberFormatError = 1;
    public const int DownloadVersionError = 2;
    public const int DownloadFileList = 3;
    public const int DownloadFileListError = 4;
    public const int DownloadFileProgressChanged = 5;
    public const int DownloadFileCompleted = 6;
    public const int LoadAssetBundleMainManifestError = 7;
    public const int LoadAssetBundleError = 8;
    public const int LoadAssetReferenceError = 9;
    public const int LoadAssetFinished = 10;
    public const int AssetBundleRefFileDontExist = 12;
    public const int NeededGameObjectDontExist = 13;
    public const int LoadAbDependenciesError = 14;
    public const int FileListNotExistError = 15;
    #endregion

    #region 界面相关消息 2000 - 4000

    /// <summary>
    /// 配置表加载完成
    /// </summary>
    public const int TableDataFinish = 2000;

    #endregion

    #region 战斗相关事件 5000 - 6000

    /// <summary>
    /// 状态结束消息
    /// </summary>
    public const int StateEndEvent = 5000;

    /// <summary>
    /// 所有角色创建完成
    /// </summary>
    public const int CreateRoleFinsh = StateEndEvent + 1;

    #endregion
}

