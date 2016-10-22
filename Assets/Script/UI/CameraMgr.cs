//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.UI
// FileName : CameraMgr
//
// Created by : maxiao (398117200@qq.com) at 2016/9/19 16:16:38
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CameraMgr
{
    #region 单例Instance

    private static CameraMgr _instance;
    private static object syncObj = new object();

    public static CameraMgr Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    if (_instance == null)
                    {
                        
                        _instance = new CameraMgr();
                    }
                }
            }
            return _instance;
        }
    }

    #endregion

    private CameraMgr()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
            if (mainCamera == null)
            {
                Debug.Log("场景中不存在主摄影机！");
            }
        }
    }

    private Camera mainCamera;

    public void FocusMainCameraToPlayer(Transform player)
    {
        if (mainCamera != null)
        {
            CameraFollow cFollow = mainCamera.GetComponent<CameraFollow>();
            if (cFollow == null)
            {
                cFollow = mainCamera.gameObject.AddComponent<CameraFollow>();
            }

            cFollow.FocusTransform = player;
        }
        else
        {
            Debug.Log("CameraMgr中的主摄影机为null！");
        }
    }
}
