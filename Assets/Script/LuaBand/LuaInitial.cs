//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Lua
// FileName : LuaInitial
//
// Created by : maxiao (398117200@qq.com) at 2016/6/30 15:26:52
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 这个类用于挂载在用Lua脚本控制实例化的Prefab上；
/// 在Prefab被实例化之后，可通过此脚本来调用Lua方法，由于是Prefab，因此在热更的时候可以直接在Prefab上设置一些参数
/// </summary>
public class LuaInitial :MonoBehaviour
{
    /// <summary>
    /// 调用的lua脚本名
    /// </summary>
    [SerializeField]
    public string luaClassName = "";
    /// <summary>
    /// call方法需要的objs参数
    /// </summary>
    [SerializeField]
    public GameObject[] objs;
    /// <summary>
    /// call方法需要的prefabs参数
    /// </summary>
    [SerializeField]
    public GameObject[] prefabs;
    /// <summary>
    /// 本gameObject的实例序号，用于在lua中查找
    /// </summary>
    protected int insID;
    /// <summary>
    /// toLua虚拟机，这里是单例引用
    /// </summary>
    private LuaScriptMgr toLua;

    /// <summary>
    /// 唤醒后调用
    /// </summary>
    void Awake()
    {
        toLua = LuaScriptMgr.Instance;
        insID = gameObject.GetInstanceID();

        if (string.IsNullOrEmpty(luaClassName))
        {
            Debug.Log(gameObject.name + "-----lua脚本名为空-------", transform);
            return;
        }

        int len = objs == null ? 0 : objs.Length;
        int prefabLen = prefabs == null ? 0 : prefabs.Length;

        //注意这些参数传入lua后，这些参数名也是可以被lua识别的,因为是awake，这里就可以将此prefab需要的参数一次都传入lua
        CallMethod("awake", gameObject, luaClassName, insID, objs, len, prefabs, prefabLen);
    }
    /// <summary>
    /// 调用lua的start方法，需要在lua中定义
    /// </summary>
    void Start()
    {
        CallMethod("start", insID, luaClassName);
    }
    /// <summary>
    /// 调用lua的onDestroy方法，需要在lua中定义
    /// </summary>
    void OnDestroy()
    {
        CallMethod("onDestroy", insID, luaClassName);
    }
    /// <summary>
    /// 这个方法通过LuaScriptMgr来调用Lua方法
    /// </summary>
    /// <param name="funcName"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    protected object[] CallMethod(string funcName, params object[] args)
    {
        if (toLua == null)
            return null;
        return toLua.CallLuaFunction(funcName, args);
    }
}

