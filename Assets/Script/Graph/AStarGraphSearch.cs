//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Graph
// FileName : AStarGraphSearch
//
// Created by : maxiao (398117200@qq.com) at 2016/10/10 22:58:05
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AStarGraphSearch
{
    private SparseGraph m_graph;

    private int m_iSource;
    private int m_iTarget;

    private Dictionary<int, float> m_GCosts;
    private Dictionary<int, float> m_FCosts;
    private Dictionary<int, GraphEdge> m_shortestPathTree;
    //挨着搜索边界，但还未加入最短路径树的边
    private Dictionary<int, GraphEdge> m_searchFrontier;

    private void Search()
    {
        //创建一个索引的优先队列，按照从前到后从最小到最大来排序
        //注意iPQ包含的最大节点数是NodeCount()
        //这是因为没有界定啊在队列中会重复表示
        SortedList<float, int> iPQ = new SortedList<float, int>();
        //把源节点入队
        iPQ.Add(0, m_iSource);
        m_GCosts.Add(m_iSource, 0);
        m_FCosts.Add(m_iSource, 0);
        while (iPQ.Count > 0)
        {
            //从队列中得到最小开销的节点。别忘了返回的是节点的索引而不是节点本身
            //这个节点是在SPT中没有，但是又是距离源节点最近的节点
            int NextClosestNode = iPQ.First().Value;
            iPQ.RemoveAt(0);
            //把这条边从搜索边界移动到最短路径树上,m_searchFrontier[NextClosestNode]是和NextClosestNode节点最近的一条边
            if (m_searchFrontier.ContainsKey(NextClosestNode))
                m_shortestPathTree.Add(NextClosestNode, m_searchFrontier[NextClosestNode]);
            //如果找到目标节点，则退出
            if (NextClosestNode == m_iTarget)
                return;
            //现在进行边放松，遍历每一条连接下一个最近节点的边
            foreach (GraphEdge e in m_graph.GetRelatedEdges(NextClosestNode))
            {
                //到这条边指向的节点的总开销是到当前节点的开销加上这条连接边的开销
                float NewGCost = m_GCosts[NextClosestNode] + e.Cost;
                float NewFCost = NewGCost + CalculateHCost(NextClosestNode, e.To);
                //如果这条边还没有在搜索边界上，记录它所指向的点的开销，
                //接着把边加到搜索边界，
                //把指向的节点加到优先队列
                //FCost越小，越先被处理
                if (!m_searchFrontier.ContainsKey(e.To))
                {
                    m_GCosts.Add(e.To, NewGCost);
                    m_FCosts.Add(e.To, NewFCost);
                    iPQ.Add(NewFCost, e.To);
                    m_searchFrontier.Add(e.To, e);
                }
                //如果已经加入到搜索边界，测试是否从当前节点到达边指向的节点的开销是否小于当前找到的最小开销
                //如果这条路径更短的话，我们将新的开销记入边指向的节点，更新优先队列以反映变化
                //把边加入最短路径
                //最短路径树还是最短实际花费距离路径树
                else if (NewGCost < m_GCosts[e.To] && !m_shortestPathTree.ContainsKey(e.To))
                {
                    m_GCosts[e.To] = NewGCost;
                    m_FCosts[e.To] = NewFCost;
                    foreach (KeyValuePair<float, int> pair in iPQ)
                    {
                        if (pair.Value == e.To)
                        {
                            iPQ.Remove(pair.Key);
                            iPQ.Add(NewFCost, e.To);
                        }
                    }
                    m_searchFrontier[e.To] = e;
                }
            }
        }
    }

    private static float CalculateHCost(int nd1, int nd2)
    {
        return -1;
    }
}
