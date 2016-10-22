//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight
// FileName : FightUnitManager
//
// Created by : maxiao (398117200@qq.com) at 2016/7/28 4:51:08
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;


public class GameObjectMgr
{
    protected Dictionary<string, GameObject> m_prototypeMap = new Dictionary<string, GameObject>();
    protected Dictionary<int, GameObjectInfo> m_gameObjectMap = new Dictionary<int, GameObjectInfo>();
    protected Dictionary<string, Stack<GameObject>> m_gameObjectPool = new Dictionary<string, Stack<GameObject>>();
    /// <summary>
    /// 返回一个GameObject,如果不存在则创建一个新的
    /// </summary>
    /// <param name="id"></param>
    /// <param name="prototypeName"></param>
    /// <param name="name"></param>
    /// <param name="isReuse"></param>
    /// <returns></returns>
    public GameObject GetGameObject(int id, string prototypeName, string name, bool isReuse)
    {
        GameObject obj = GetGameObjectById(id);
        if (obj == null)
        {
            obj = NewGameObject(id, prototypeName, name, isReuse);
        }

        return obj;
    }

    /// <summary>
    /// 得到已实例化的一个GameObject,如果不存在则返回null
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public GameObject GetGameObjectById(int id)
    {
        GameObjectInfo obj = null;
        m_gameObjectMap.TryGetValue(id, out obj);

        return obj == null ? null : obj.gameObj;
    }
    /// <summary>
    /// 新建一个GameObject并返回
    /// </summary>
    /// <param name="id"></param>
    /// <param name="prototypeName"></param>
    /// <param name="name"></param>
    /// <param name="isReuse"></param>
    /// <returns></returns>
    public GameObject NewGameObject(int id, string prototypeName, string name, bool isReuse)
    {
        GameObject gu = null;
        if (m_gameObjectMap.ContainsKey(id))
        {
            Debug.LogWarning(this.GetType().Name + " Warning : 新建GameObject失败，已存在相同id的GameObject:" + id);
            return null;
        }
        Stack<GameObject> goPool = null;
        if (m_gameObjectPool.TryGetValue(prototypeName, out goPool) && goPool.Count > 0)
        {
            gu = goPool.Pop();
            PutGOIntoMap(id, prototypeName, name, isReuse, gu);
        }
        else
        {
            if (m_prototypeMap.ContainsKey(prototypeName))
            {
                gu = GameObject.Instantiate(m_prototypeMap[prototypeName]);
            }
            else
            {
                gu = (GameObject)GameObject.Instantiate(ResourceMgr.Instance.LoadSync(prototypeName, null, isReuse));
                if (isReuse)
                {
                    m_prototypeMap.Add(prototypeName, gu);
                }
            }
            PutGOIntoMap(id, prototypeName, name, isReuse, gu);
        }
        return gu;
    }
    /// <summary>
    /// 将一个GO放入单位缓存列表
    /// </summary>
    /// <param name="id"></param>
    /// <param name="prototypeName"></param>
    /// <param name="name"></param>
    /// <param name="isReuse"></param>
    /// <param name="go"></param>
    private void PutGOIntoMap(int id, string prototypeName, string name, bool isReuse, GameObject go)
    {
        go.SetActive(true);
        go.name = name;
        GameObjectInfo goInfo = new GameObjectInfo(id, name, prototypeName, go, isReuse);
        m_gameObjectMap.Add(id, goInfo);
    }
    /// <summary>
    /// 释放一个战斗单位
    /// </summary>
    /// <param name="id"></param>
    public void ReleaseGameObject(int id)
    {
        if (m_gameObjectMap.ContainsKey(id))
        {
            Debug.LogWarning(this.GetType().Name + " Warning : 释放GameObject失败，缓存字典里并不存在这个GameObject, id:" + id);
            return;
        }
        GameObjectInfo info = m_gameObjectMap[id];
        if (info.IsReuse)
        {
            if (!m_gameObjectPool.ContainsKey(info.prototypeName))
            {
                Stack<GameObject> stack = new Stack<GameObject>();
                stack.Push(info.gameObj);
                m_gameObjectPool[info.prototypeName] = stack;
            }
            else
            {
                m_gameObjectPool[info.prototypeName].Push(info.gameObj);
            }
        }
        else
        {
            GameObject.Destroy(info.gameObj);
        }
        m_gameObjectMap.Remove(id);
    }
}

