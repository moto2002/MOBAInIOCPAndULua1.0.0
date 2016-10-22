//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Editor.Scripts
// FileName : RecTransformInfo
//
// Created by : maxiao (398117200@qq.com) at 2016/7/4 17:03:28
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class RecTransformInfo : MonoBehaviour
{
    [SerializeField]
    private string indexName = string.Empty;
    [SerializeField]
    private int siblingIndex = -1;
    [SerializeField]
    private Vector2 anchoredPosition;
    [SerializeField]
    private Vector3 anchoredPosition3D;
    [SerializeField]
    private Vector2 anchorMax;
    [SerializeField]
    private Vector2 anchorMin;
    [SerializeField]
    private Vector3 localEulerAngles;
    [SerializeField]
    private Vector3 localPosition;
    [SerializeField]
    private Vector3 localScale;
    [SerializeField]
    private Vector2 offsetMax;
    [SerializeField]
    private Vector2 offsetMin;
    [SerializeField]
    private Vector2 pivot;
    [SerializeField]
    private Vector2 sizeDelta;



    public void SetRecTransform()
    {
        if(siblingIndex < transform.parent.childCount)
            transform.SetSiblingIndex(siblingIndex);
  
        RectTransform rec = transform.GetComponent<RectTransform>();
        rec.anchoredPosition = anchoredPosition;
        rec.anchoredPosition3D = anchoredPosition3D;
        rec.anchorMax = anchorMax;
        rec.anchorMin = anchorMin;
        rec.localEulerAngles = localEulerAngles;
        rec.localPosition = localPosition;
        rec.localScale = localScale;
        rec.offsetMax = offsetMax;
        rec.offsetMin = offsetMin;
        rec.pivot = pivot;
        rec.sizeDelta = sizeDelta;
    }

    public int SiblingIndex
    {
        set { siblingIndex = value; }
    }

    public Vector2 AnchoredPosition
    {
        set { anchoredPosition = value; }
    }

    public Vector3 AnchoredPosition3D
    {
        set { anchoredPosition3D = value; }
    }

    public Vector2 AnchorMax
    {
        set { anchorMax = value; }
    }

    public Vector2 AnchorMin
    {
        set { anchorMin = value; }
    }

    public Vector3 LocalEulerAngles
    {
        set { localEulerAngles = value; }
    }

    public Vector3 LocalPosition
    {
        set { localPosition = value; }
    }

    public Vector3 LocalScale
    {
        set { localScale = value; }
    }

    public Vector2 OffsetMax
    {
        set { offsetMax = value; }
    }

    public Vector2 OffsetMin
    {
        set { offsetMin = value; }
    }

    public Vector2 Pivot
    {
        set { pivot = value; }
    }

    public Vector2 SizeDelta
    {
        set { sizeDelta = value; }
    }

    public string IndexName
    {
        get { return indexName; }
        set { indexName = value; }
    }
}

