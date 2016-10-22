//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Graph
// FileName : DFSGrapgSearch
//
// Created by : maxiao (398117200@qq.com) at 2016/10/9 16:40:35
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum NodeVisitType
{
    visited,
    unvisited,
    noParentAssigned,
}

public class GraphSearch
{
    //一个被搜索的图的引用
    private SparseGraph m_graph;
    //记录在搜索过程中访问过的所有节点
    private Dictionary<int, NodeVisitType> m_visitedNodes;
    //保存到达目标节点的路径
    private Dictionary<int, int> m_route;

    private int sourceNodeIndex;
    private int targetNodeIndex;
    private bool isFound = false;

    public GraphSearch(SparseGraph mGraph, Dictionary<int, NodeVisitType> mVisitedNodes, Dictionary<int, int> mRoute, int sourceNodeIndex, int targetNodeIndex)
    {
        m_graph = mGraph;
        m_visitedNodes = mVisitedNodes;
        m_route = mRoute;
        this.sourceNodeIndex = sourceNodeIndex;
        this.targetNodeIndex = targetNodeIndex;
        this.isFound = DFSSearch();
    }
    /// <summary>
    /// 深度优先搜索
    /// </summary>
    /// <returns></returns>
    private bool DFSSearch()
    {
        m_visitedNodes.Clear();
        m_route.Clear();
        //创建堆栈用来保存边的指针
        Stack<GraphEdge> edgeStack = new Stack<GraphEdge>();
        //创建一个哑边并入栈
        GraphEdge dummyEdge = new GraphEdge(sourceNodeIndex, sourceNodeIndex, 0);
        edgeStack.Push(dummyEdge);
        while (edgeStack.Count > 0)
        {
            //取下一条边
            GraphEdge next = edgeStack.Pop();
            //记录这条边指向的节点的父节点
            m_route.Add(next.To, next.From);
            //并标记指向的节点为已访问
            m_visitedNodes.Add(next.To, NodeVisitType.visited);
            if (next.To == targetNodeIndex)
            {
                return true;
            }
            //将这条边指向的节点的所有关联的边入栈
            //只要关联的边指向的节点没有被访问过
            foreach (GraphEdge e in m_graph.GetRelatedEdges(next.To))
            {
                if (!m_visitedNodes.ContainsKey(e.To))
                {
                    edgeStack.Push(e);
                }
            }
        }

        //没有路径到达目标节点
        return false;
    }
    /// <summary>
    /// 广度优先搜索
    /// </summary>
    /// <returns></returns>
    private bool BFSSearch()
    {
        m_visitedNodes.Clear();
        m_route.Clear();
        //创建堆栈用来保存边的指针
        Queue<GraphEdge> edgeQueue = new Queue<GraphEdge>();
        //创建一个哑边并入栈
        GraphEdge dummyEdge = new GraphEdge(sourceNodeIndex, sourceNodeIndex, 0);
        edgeQueue.Enqueue(dummyEdge);
        while (edgeQueue.Count > 0)
        {
            //取下一条边
            GraphEdge next = edgeQueue.Dequeue();
            //记录这条边指向的节点的父节点
            m_route.Add(next.To, next.From);
            //并标记指向的节点为已访问
            m_visitedNodes.Add(next.To, NodeVisitType.visited);
            if (next.To == targetNodeIndex)
            {
                return true;
            }
            //将这条边指向的节点的所有关联的边入栈
            //只要关联的边指向的节点没有被访问过
            foreach (GraphEdge e in m_graph.GetRelatedEdges(next.To))
            {
                if (!m_visitedNodes.ContainsKey(e.To))
                {
                    edgeQueue.Enqueue(e);
                }
            }
        }

        //没有路径到达目标节点
        return false;
    }

    public Stack<int> GetPathToTarget()
    {
        Stack<int> path = new Stack<int>();
        //在没有路径或者没有指定目标节点时返回空路径
        if (!isFound || targetNodeIndex < 0)
        {
            return null;
        }

        int nd = targetNodeIndex;
        path.Push(nd);
        while (nd != sourceNodeIndex)
        {
            nd = m_route[nd];
            path.Push(nd);
        }

        return path;
    }

    public bool IsFound
    {
        get { return isFound; }
    }

}
