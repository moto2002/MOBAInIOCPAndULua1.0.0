//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Graph
// FileName : DijkstraGraphSearch
//
// Created by : maxiao (398117200@qq.com) at 2016/10/10 0:20:41
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DijkstraGraphSearch
{
    private SparseGraph m_graph;
    //这个字典保存最短路径树的边
    //一个图的有向子树，该树包含了在SPT上的每一个节点到源节点的最优路径
    private Dictionary<int, GraphEdge> m_shortestPathTree;
    //这是一个以节点的索引为索引的，包含目前到给定节点最短路径的总开销的动态字典
    //例如，m_CostToThisNode[5]包含当前到达5的最短路径的所有边的开销总和
    //当然，节点5必须是当前节点并且已经被访问
    private Dictionary<int, float> m_CostToThisNode;
    //这是一个按节点来索引的，保存“父”边的动态数组
    //“父边”指向那些和SPT相连的但是还没有加入到SPT的节点
    private Dictionary<int, GraphEdge> m_searchFrontier;

    private int m_iSource;
    private int m_iTarget;

    private void Search()
    {
        //创建一个索引的优先队列，按照从前到后从最小到最大来排序
        //注意iPQ包含的最大节点数是NodeCount()
        //这是因为没有界定啊在队列中会重复表示
        SortedList<float, int> iPQ = new SortedList<float, int>();
        //把源节点入队
        iPQ.Add(0, m_iSource);
        m_CostToThisNode.Add(m_iSource, 0);
        while (iPQ.Count > 0)
        {
            //从队列中得到最小开销的节点。别忘了返回的是节点的索引而不是节点本身
            //这个节点是在SPT中没有，但是又是距离源节点最近的节点
            int NextClosestNode = iPQ.First().Value;
            iPQ.RemoveAt(0);
            //把这条边从搜索边界移动到最短路径树上,m_searchFrontier[NextClosestNode]是和NextClosestNode节点最近的一条边
            if(m_searchFrontier.ContainsKey(NextClosestNode))
                m_shortestPathTree.Add(NextClosestNode, m_searchFrontier[NextClosestNode]);
            //如果找到目标节点，则退出
            if (NextClosestNode == m_iTarget)
                return;
            //现在进行边放松，遍历每一条连接下一个最近节点的边
            foreach (GraphEdge e in m_graph.GetRelatedEdges(NextClosestNode))
            {
                //到这条边指向的节点的总开销是到当前节点的开销加上这条连接边的开销
                float NewCost = m_CostToThisNode[NextClosestNode] + e.Cost;
                //如果这条边还没有在搜索边界上，记录它所指向的点的开销，
                //接着把边加到搜索边界，
                //把指向的节点加到优先队列
                if (!m_searchFrontier.ContainsKey(e.To))
                {
                    m_CostToThisNode.Add(e.To, NewCost);
                    iPQ.Add(NewCost, e.To);
                    m_searchFrontier.Add(e.To, e);
                }
                //如果已经加入到搜索边界，测试是否从当前节点到达边指向的节点的开销是否小于当前找到的最小开销
                //如果这条路径更短的话，我们将新的开销记入边指向的节点，更新优先队列以反映变化
                //把边加入最短路径
                else if (NewCost < m_CostToThisNode[e.To] && !m_shortestPathTree.ContainsKey(e.To))
                {
                    m_CostToThisNode[e.To] = NewCost;
                    foreach (KeyValuePair<float, int> pair in iPQ)
                    {
                        if (pair.Value == e.To)
                        {
                            iPQ.Remove(pair.Key);
                            iPQ.Add(NewCost, e.To);
                        }
                    }
                    m_searchFrontier[e.To] = e;
                }
            }
        }
    }



    public DijkstraGraphSearch(SparseGraph mGraph, int mISource, int mITarget)
    {
        m_graph = mGraph;
        m_iSource = mISource;
        m_iTarget = mITarget;
    }
    /// <summary>
    /// 返回定义SPT的边的动态字典
    /// 如果调用构造函数时指定了目标节点，那么找到目标节点了就会返回
    /// 在找到目标节点之前已经访问过的所有节点的SPT
    /// 如果不是这样，SPT将包含图的所有节点
    /// </summary>
    /// <returns></returns>
    public Dictionary<int, GraphEdge> GetAllPaths()
    {

        return null;
    }
    /// <summary>
    /// 返回包含从源节点到目标节点的最短路径的节点的索引构成的数组
    /// 通过从目标节点回溯SPT计算路径
    /// </summary>
    /// <returns></returns>
    public List<int> GetPathToTarget()
    {
        return null;
    }

    public float GetCostToTarget()
    {
        return 0f;
    }
}
