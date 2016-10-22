//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.UI
// FileName : UIutils
//
// Created by : maxiao (398117200@qq.com) at 2016/7/5 0:12:42
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;


public class UIutils : MonoBehaviour, IEventListener
{
    private Canvas UI;
    /// <summary>
    /// 用来存放所有UI元素节点的字典
    /// </summary>
    private Dictionary<int, Transform> uiNodes = new Dictionary<int, Transform>();

    private string currentUIName;
    #region 单例Instance

    private static UIutils _instance;
    private static object syncObj = new object();

    public static UIutils Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    _instance = GameObject.FindObjectOfType<UIutils>();
                    if (_instance == null)
                    {
                        GameObject container = GameObject.Find("SingletonContainer");
                        if (container == null)
                        {
                            container = new GameObject("SingletonContainer");
                        }
                        _instance = container.AddComponent<UIutils>();
                        Debug.Log("UIutils loaded");
                    }
                }
            }
            return _instance;
        }
    }

    #endregion


    private void Start()
    {
        if (UI == null)
        {
            UI = GameObject.FindGameObjectWithTag("MainUI").GetComponent<Canvas>();
            if (UI == null)
            {
                Debug.Log("场景中的Main UI Canvas设置不正确！");
            }
        }
        currentUIName = LuaScriptMgr.Instance.CallLuaFunction("get_ui_name_by_scene_name", SceneManager.GetActiveScene().name)[0] as string;
        RecurseAllUIElements(UI.transform);

    }

    /// <summary>
    /// 递归遍历所有初始UI节点，将其加入uiNodes字典，以便后面查找父节点
    /// </summary>
    /// <param name="trans"></param>
    private void RecurseAllUIElements(Transform trans)
    {
        int childCount = trans.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = trans.GetChild(i);
            if (child.GetComponent<InfoNode>() == null)
            {
                Debug.Log("UI元素:" + child.name + "没有挂载InfoNode脚本！");
            }
            else
            {
                InfoNode node = child.GetComponent<InfoNode>();
                if (!uiNodes.ContainsKey(node.GetNodeIdOfName(currentUIName)))
                {
                    uiNodes.Add(node.GetNodeIdOfName(currentUIName), child);
                }
                else
                {
                    Debug.Log("存在重复的UiNode,重复序号为：" + node.GetNodeIdOfName(currentUIName) + ",名字为：" + child.name);
                }
            }
            RecurseAllUIElements(child);
        }
    }
    /// <summary>
    /// 异步加载一个UI元素
    /// </summary>
    /// <param name="name"></param>
    public void LoadUiElement(string name)
    {
        Debug.Log("load ui element: " + name);
        ResourceMgr.Instance.LoadAsync(name, this, null, true);
    }
    /// <summary>
    /// 同步加载一个UI元素
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Object LoadUiElementSync(string name)
    {
        return ResourceMgr.Instance.LoadSync(name, null, false);
    }


    /// <summary>
    /// 利用传入的ui元素信息新建一个UI元素，并根据信息对其初始化，再加入节点字典
    /// </summary>
    /// <param name="info"></param>
    public GameObject NewUIElement(Object obj)
    {
        GameObject go = (GameObject)Instantiate(obj);
        InfoNode node = go.GetComponent<InfoNode>();
        if (node == null)
        {
            Debug.Log("UI元素预设未挂载InfoNode脚本,实例化失败！");
            Destroy(go);
            return null;
        }


        int parentId = node.GetParentIdOfName(currentUIName);
        if (parentId == 0)
        {
            go.transform.SetParent(UI.transform);
        }
        else
        {
            if (uiNodes.ContainsKey(parentId))
            {
                go.transform.SetParent(uiNodes[parentId]);
            }
            else
            {
                Debug.Log("没有找到UI元素:" + go.name + "的父节点:" + parentId);
                Destroy(go);
                return null;
            }
        }

        if (!uiNodes.ContainsKey(node.GetNodeIdOfName(currentUIName)))
        {
            uiNodes.Add(node.GetNodeIdOfName(currentUIName), go.transform);
        }
        else
        {
            Debug.Log("UI界面中已存在相同的元素：" + go.name + "，请检查重复调用！");
            Destroy(go);
            return null;
        }

        RecurseAllUIElements(go.transform);

        foreach (RecTransformInfo info in go.GetComponents<RecTransformInfo>())
        {
            if (info.IndexName == currentUIName)
            {
                info.SetRecTransform();
                break;
            }
        }
        return go;
    }

    public int HandlePriority()
    {
        return 0;
    }

    public bool HandleEvent(int id, params object[] args)
    {
        switch (id)
        {
            case EventDef.LoadAssetFinished:
                AssetInfo info = args[0] as AssetInfo;
                Debug.Log(info.name);

                GameObject element = NewUIElement(info.asset);
                if (element != null)
                {
                    element.name = element.name.Replace("(Clone)", string.Empty);
                    string elementAssetName = info.name;
                    LuaScriptMgr.Instance.CallLuaFunction("ui_loaded", element, elementAssetName);
                }
                else
                {
                    Debug.Log("element " + info.name + " is null");
                }
                return false;
        }
        return false;
    }


    /// <summary>
    /// 添加单个按钮事件
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="click"></param>
    public void setButtonClick(GameObject obj, LuaFunction click, params object[] args)
    {
        Button btn = obj.GetComponent<Button>();
        if (btn == null)
        {
            Log.Error("setButtonClick 没有按钮组件 添加按钮事件失败！！！");
            return;
        }
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(delegate
        {
            click.Call(args);
        });
    }

    /// <summary>
    /// 设置按钮普通点击事件
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="click"></param>
    public void setButtonNormalClick(GameObject obj, Action click)
    {
        Button btn = obj.GetComponent<Button>();
        if (btn == null)
        {
            Log.Error("setButtonClick 没有按钮组件 添加按钮事件失败！！！");
            return;
        }
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(delegate
        {
            click();
        });
    }
    /// <summary>
    /// 添加按钮事件
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="click"></param>
    public void addButtonClick(GameObject obj, LuaFunction click, params object[] args)
    {
        Button btn = obj.GetComponent<Button>();
        if (btn == null)
        {
            Log.Error("addButtonClick 没有按钮组件 添加按钮事件失败！！！");
            return;
        }

        btn.onClick.AddListener(delegate
        {
            click.Call(args);
        });
    }

    /// <summary>
    /// 添加按钮普通点击事件
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="click"></param>
    public void addButtonNormalClick(GameObject obj, Action click)
    {
        Button btn = obj.GetComponent<Button>();
        if (btn == null)
        {
            Log.Error("addButtonClick 没有按钮组件 添加按钮事件失败！！！");
            return;
        }

        btn.onClick.AddListener(delegate
        {
            click();
        });
    }

    /// <summary>
    /// 添加按钮长按事件
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="click"></param>
    public void addButtonLongPressed(GameObject obj, LuaFunction click, params object[] args)
    {
        MultipleTimeLengthButtonTrigger longPressBtn = obj.GetComponent<MultipleTimeLengthButtonTrigger>();
        if (longPressBtn == null)
        {
            Log.Error("addButtonClick 没有长按组件 添加长按事件失败！！！");
            return;
        }

        longPressBtn.longPressTrigger.AddListener(delegate
        {
            click.Call(args);
        });
    }
    /// <summary>
    /// 添加按钮长按取消事件
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="click"></param>
    public void addButtonLongPressCancel(GameObject obj, LuaFunction click, params object[] args)
    {
        MultipleTimeLengthButtonTrigger longPressBtn = obj.GetComponent<MultipleTimeLengthButtonTrigger>();
        if (longPressBtn == null)
        {
            Log.Error("addButtonClick 没有长按组件 添加长按取消事件失败！！！");
            return;
        }

        longPressBtn.cancelLongPressTrigger.AddListener(delegate
        {
            click.Call(args);
        });
    }

    public void setToogleAction(GameObject go, LuaFunction tAction, params object[] args)
    {
        Toggle tg = go.GetComponent<Toggle>();
        if (tg == null)
        {
            Log.Error("setToggleClick 没有toggle组件 添加事件失败！！！");
            return;
        }
        tg.onValueChanged.AddListener(delegate { tAction.Call(tg.isOn, args); });
    }
}

