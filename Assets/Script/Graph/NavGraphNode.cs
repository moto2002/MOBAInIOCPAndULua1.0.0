//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Graph
// FileName : NavGraphNode
//
// Created by : maxiao (398117200@qq.com) at 2016/10/6 23:15:17
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class NavGraphNode:GraphNode
{
    public NavGraphNode(int index) : base(index)
    {
    }

    protected Vector3 m_position;

}
