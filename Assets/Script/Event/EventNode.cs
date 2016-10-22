//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script
// FileName : EventNode
//
// Created by : maxiao (398117200@qq.com) at 2016/6/18 18:53:22
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class EventNode : MonoBehaviour 
{
    /// <summary>
    /// 消息节点处理的优先级
    /// </summary>
    public int Priority{ get; private set; }
    /// <summary>
    /// 用于存放本节点上的监听器的字典（一个消息编号对应一个监听器列表）
    /// </summary>
    private Dictionary<int, List<IEventListener>> listeners;
    /// <summary>
    /// 用于存放本消息节点的子节点
    /// </summary>
    private List<EventNode> subNodes;

    void Awake()
    {
        subNodes = new List<EventNode>();
        listeners = new Dictionary<int, List<IEventListener>>();
    }


    /// <summary>
    /// 添加一个事件监听
    /// </summary>
    /// <param name="id">消息ID</param>
    /// <param name="listener">要添加的监听器</param>
    /// <returns>是否添加成功</returns>
    public bool AddEventListener(int id, IEventListener listener)
    {
        if (listener == null)
            return false;
        if (!listeners.ContainsKey(id))
        {
            listeners.Add(id, new List<IEventListener>() {listener});
            return true;
        }
        else
        {
            List<IEventListener> listenerList = listeners[id];
            if (listenerList.Contains(listener))
            {
                return false;
            }

            int insertPosition = 0;
            for (int i = 0; i < listenerList.Count; i++)
            {
                if (listenerList[i].HandlePriority() > listener.HandlePriority())
                {
                    break;
                }
                insertPosition++;
            }

            listenerList.Insert(insertPosition, listener);

            listeners[id] = listenerList;
            return true;
        }
    }
    /// <summary>
    /// 移除一个消息监听器
    /// </summary>
    /// <param name="id">消息ID</param>
    /// <param name="listener">要移除的监听器</param>
    /// <returns>是否移除成功</returns>
    public bool RemoveEventListener(int id, IEventListener listener)
    {
        if (listeners.ContainsKey(id) && listeners[id].Contains(listener))
        {
            listeners[id].Remove(listener);
            return true;
        }
        
        return false;
    }
    /// <summary>
    /// 添加一个消息子节点
    /// </summary>
    /// <param name="subNode">要添加的子节点</param>
    /// <returns>是否添加成功</returns>
    public bool AddSubEventNode(EventNode subNode)
    {
        if (subNode == null)
            return false;
        if (subNodes.Contains(subNode))
        {
            return false;
        }

        int insertPosition = 0;
        for (int i = 0; i < subNodes.Count; i++)
        {
            if (subNodes[i].Priority > subNode.Priority)
            {
                break;
            }
            insertPosition++;
        }

        subNodes.Insert(insertPosition,subNode);
        return true;
    }
    /// <summary>
    /// 移除消息子节点
    /// </summary>
    /// <param name="subNode">要移除的子节点</param>
    /// <returns>是否移除成功</returns>
    public bool RemoveSubEventNode(EventNode subNode)
    {
        if (subNodes.Contains(subNode))
        {
            subNodes.Remove(subNode);
            return true;
        }

        return false;
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="id">消息ID</param>
    /// <param name="args">发送的参数</param>
    public void SendEvent(int id, params object[] args)
    {
        DispatchEvent(id, args);
    }

    public bool DispatchEvent(int id, params object[] args)
    {
        if (subNodes.Count > 0)
        {
            foreach (EventNode item in subNodes)
            {
                if (item.DispatchEvent(id, args))
                    return true;
            }
        }

        return TrigggerEvent(id,args);
    }

    public bool TrigggerEvent(int id, params object[] args)
    {
        if (!listeners.ContainsKey(id))
        {
            Debug.Log("不存在对事件：" + id + "的监听器");
            return false;
        }

        List<IEventListener> listenerList = listeners[id];
        foreach (IEventListener item in listenerList)
        {
            if (item.HandleEvent(id, args))
                return true;
        }
        return false;
    }
}

