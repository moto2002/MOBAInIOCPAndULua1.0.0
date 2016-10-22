//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Graph
// FileName : DependencyGraphNode
//
// Created by : maxiao (398117200@qq.com) at 2016/10/9 15:45:16
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DependencyGraphNode: GraphNode
{
    public DependencyGraphNode()
    {
    }

    public DependencyGraphNode(int index) : base(index)
    {
    }

    protected object assets;
}
