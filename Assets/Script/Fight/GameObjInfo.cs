//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.UI
// FileName : GameObjInfo
//
// Created by : maxiao (398117200@qq.com) at 2016/7/5 18:11:35
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameObjInfo : MonoBehaviour
{
    [SerializeField]
    private string indexName = string.Empty;
    [SerializeField,HideInInspector]
    private Vector3 localPosition;
    [SerializeField,HideInInspector]
    private Vector3 localEulerAngles;
    [SerializeField,HideInInspector]
    private Vector3 localScale;
    [SerializeField,HideInInspector]
    private int siblingId;

    public void SetGameObj()
    {
        if (siblingId < transform.parent.childCount)
            transform.SetSiblingIndex(siblingId);

        transform.localPosition = localPosition;
        transform.localEulerAngles = localEulerAngles;
        transform.localScale = localScale;
    }

    public string IndexName
    {
        get { return indexName; }
        set { indexName = value; }
    }

    public Vector3 LocalPosition
    {
        get { return localPosition; }
        set { localPosition = value; }
    }

    public Vector3 LocalEulerAngles
    {
        get { return localEulerAngles; }
        set { localEulerAngles = value; }
    }

    public Vector3 LocalScale
    {
        get { return localScale; }
        set { localScale = value; }
    }

    public int SiblingId
    {
        get { return siblingId; }
        set { siblingId = value; }
    }
}

