//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.GameObjectMgr
// FileName : ParentMgr
//
// Created by : maxiao (398117200@qq.com) at 2016/9/18 10:44:23
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TransformFinder:EventNode
{
    #region 单例Instance
    private static TransformFinder _instance;
    private static object syncObj = new object();

    public static TransformFinder Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    _instance = GameObject.FindObjectOfType<TransformFinder>();
                    if (_instance == null)
                    {
                        GameObject container = GameObject.Find("SingletonContainer");
                        if (container == null)
                        {
                            container = new GameObject("SingletonContainer");
                        }
                        _instance = container.AddComponent<TransformFinder>();
                    }
                }
            }
            return _instance;
        }
    }

    #endregion

    private Dictionary<string, Transform> transformDic = new Dictionary<string, Transform>();

    public Transform GetTransform(string name)
    {
        Transform p = null;
        transformDic.TryGetValue(name, out p);

        if (p == null)
        {
            GameObject o = GameObject.Find(name);
            if (o == null)
            {
                SendEvent(EventDef.NeededGameObjectDontExist, name);
                return null;
            }
            else
            {
                p = o.transform;
            }
        }

        return p;
    }

    public static GameObject FindChild(GameObject o, string childName)
    {
        if (o != null)
        {
            Transform t = o.transform;
            GameObject toFindChild = null;
            for (int i = 0; i < t.childCount; i++)
            {
                Transform child = t.GetChild(i);
                if (child.name == childName)
                {
                    return child.gameObject;
                }
                else
                {
                    toFindChild = FindChild(child.gameObject, childName);
                    if (toFindChild != null)
                    {
                        return toFindChild;
                    }
                }
            }

            return toFindChild;
        }
        else
        {
            Debug.Log("寻找子物体失败，传入的父物体为空");
            return null;
        }
    }
}
