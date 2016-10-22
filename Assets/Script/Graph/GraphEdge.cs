//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Graph
// FileName : GraphEdge
//
// Created by : maxiao (398117200@qq.com) at 2016/10/6 23:22:05
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GraphEdge
{
    protected int m_iFrom;
    protected int m_iTo;

    protected float m_dCost;

    public GraphEdge(int mIFrom, int mITo, float mDCost)
    {
        m_iFrom = mIFrom;
        m_iTo = mITo;
        m_dCost = mDCost;
    }

    public GraphEdge(int mIFrom, int mITo)
    {
        m_iFrom = mIFrom;
        m_iTo = mITo;
    }

    public int From
    {
        get { return m_iFrom; }
        set { m_iFrom = value; }
    }

    public int To
    {
        get { return m_iTo; }
        set { m_iTo = value; }
    }

    public float Cost
    {
        get { return m_dCost; }
        set { m_dCost = value; }
    }
}