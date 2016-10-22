//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.InfoRecord
// FileName : InfoNode
//
// Created by : maxiao (398117200@qq.com) at 2016/7/22 23:09:12
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 这个类挂载在节点上，用于记录节点的hierachy信息，并用序列化来保存
/// </summary>
public class InfoNode : MonoBehaviour
{
    [SerializeField,HideInInspector]
    private List<string> indexNames = new List<string>();
    [SerializeField,HideInInspector]
    private List<int> nodeIds = new List<int>();
    [SerializeField,HideInInspector]
    private List<int> parentIds = new List<int>();
    [SerializeField,HideInInspector]
    private List<int> siblingIds = new List<int>();

    public void SetNodeOfName(string name, int nodeId, int parentId, int siblingId)
    {
        int index = -1;
        for (int i = 0; i < indexNames.Count; i++)
        {
            if (indexNames[i] == name)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            nodeIds[index] = nodeId;
            parentIds[index] = parentId;
            siblingIds[index] = siblingId;
        }
        else
        {
            indexNames.Add(name);
            nodeIds.Add(nodeId);
            parentIds.Add(parentId);
            siblingIds.Add(siblingId);
        }
    }

    public int GetNodeIdOfName(string name)
    {
        int index = -1;
        for (int i = 0; i < indexNames.Count; i++)
        {
            if (indexNames[i] == name)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            return nodeIds[index];
        }
        return -1;
    }

    public int GetParentIdOfName(string name)
    {
        int index = -1;
        for (int i = 0; i < indexNames.Count; i++)
        {
            if (indexNames[i] == name)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            return parentIds[index];
        }

        return -1;
    }

    public int GetSiblingIdOfName(string name)
    {
        int index = -1;
        for (int i = 0; i < indexNames.Count; i++)
        {
            if (indexNames[i] == name)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            return siblingIds[index];
        }

        return -1;
    }

    public void removeNodeInfoOfName(string name)
    {
        int index = -1;
        for (int i = 0; i < indexNames.Count; i++)
        {
            if (indexNames[i] == name)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            indexNames.RemoveAt(index);
            nodeIds.RemoveAt(index);
            parentIds.RemoveAt(index);
            siblingIds.RemoveAt(index);
        }
    }
}

