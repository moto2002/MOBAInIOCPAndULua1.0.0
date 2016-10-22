//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.System
// FileName : SceneLoader
//
// Created by : maxiao (398117200@qq.com) at 2016/9/30 2:48:05
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader:MonoBehaviour
{
    private List<string> buildingSceneNames;

    #region 单例Instance

    private static SceneLoader _instance;
    private static object syncObj = new object();

    public static SceneLoader Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    _instance = GameObject.FindObjectOfType<SceneLoader>();
                    if (_instance == null)
                    {
                        GameObject container = GameObject.Find("SingletonContainer");
                        if (container == null)
                        {
                            container = new GameObject("SingletonContainer");
                        }
                        _instance = container.AddComponent<SceneLoader>();
                        _instance.BuildSceneNames();
                    }
                }
            }
            return _instance;
        }
    }
    #endregion


    private void BuildSceneNames()
    {
        buildingSceneNames = new List<string>();
        Scene[] scenes = SceneManager.GetAllScenes();
        for (int i = 0; i < scenes.Length; i++)
        {
            buildingSceneNames.Add(scenes[i].name);
        }
    }

    public void LoadScene(string sceneName)
    {
        if (buildingSceneNames.Contains(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            AssetBundleMgr.Instance.LoadAssetBundleSync(sceneName + ".assetbundle");
            SceneManager.LoadScene(sceneName);
        }
    }
}
