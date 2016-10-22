//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Graph
// FileName : SparseGraph
//
// Created by : maxiao (398117200@qq.com) at 2016/10/9 15:47:03
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class SparseGraph
{
    //组成这个图的节点
    private List<GraphNode> m_Nodes;
    //一个边(EdgeList)的动态数组。（在边中，通过节点的索引号和节点相关联）
    private Dictionary<int, List<GraphEdge>> m_Edges;
    private bool isDigraph;

    //将要被添加的下一个节点的索引号
    private int m_NextNodeIndex;

    public SparseGraph(bool isDigraph, int mNextNodeIndex)
    {
        this.isDigraph = isDigraph;
        m_NextNodeIndex = 0;
    }
    //TODO
    public GraphNode GetNode(int index)
    {
        return null;
    }
    //TODO
    public GraphEdge GetEdge(int from, int to)
    {
        return null;
    }

    public List<GraphEdge> GetRelatedEdges(int nodeIndex)
    {
        return null;
    }

    //TODO 取得下一个可用的节点索引
    public int GetNextFreeNodeIndex()
    {
        return -1;
    }
    //TODO 添加一个节点到图中并返回其索引
    public int AddNode(GraphNode node)
    {
        return -1;
    }
    //TODO 通过设置一个节点的索引为invalid_node_index来删除一个节点
    public void RemoveNode(int node)
    {
    }

    public void AddEdge(GraphEdge edge)
    {
    }

    public void RemoveEdge(int from, int to)
    {

    }

    //返回当前图中所有节点数
    public int NodeCount()
    {
        return m_Nodes.Count;
    }
    //TODO 得到图中活动的节点数
    public int ActiveNodeCount()
    {
        return 0;
    }
    //TODO 得到图中的边数
    public int EdgeCount()
    {
        return 0;
    }

    public bool IsDigraph
    {
        get { return isDigraph; }
    }
    //图是否为空
    public bool IsEmpty()
    {
        return m_Nodes.Count == 0;
    }
    //TODO 节点是否存在
    public bool IsNodeExisted(int index)
    {
        return false;
    }
    //TODO 通过一个打开的文件流或者文件名来装入或存储图
    public bool Save(string fileName)
    {
        return false;
    }

    public bool Save(Stream stream)
    {
        return false;
    }

    public bool Load(string fileName)
    {
        return false;
    }

    public bool Load(Stream stream)
    {
        return false;
    }
    //TODO 清空图
    public void Clear()
    {
    }

    //TODO 客户可能使用的用来存取边和节点的迭代器（iterator）
    //TODO EdgeIterator
    //TODO NodeIterator
}
