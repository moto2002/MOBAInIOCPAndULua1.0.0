//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Graph
// FileName : GraphNode
//
// Created by : maxiao (398117200@qq.com) at 2016/10/6 23:09:50
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GraphNode
{
    public NodeVisitType m_visitType = NodeVisitType.unvisited;

    protected int m_index;

    public GraphNode()
    {
    }

    public GraphNode(int index)
    {
        this.m_index = index;
    }

    public int Index
    {
        get { return m_index; }
        set { m_index = value; }
    }
}