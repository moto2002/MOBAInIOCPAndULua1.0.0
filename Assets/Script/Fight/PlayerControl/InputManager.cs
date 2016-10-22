//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight
// FileName : InputManager
//
// Created by : maxiao (398117200@qq.com) at 2016/7/28 19:21:14
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class InputManager
{
    #region 单例Instance

    private static InputManager _instance;
    private static object syncObj = new object();

    public static InputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    if (_instance == null)
                    {
                        _instance = new InputManager();
                    }
                }
            }
            return _instance;
        }
    }

    #endregion


    private Dictionary<string, Action<object>> inputActionMap = new Dictionary<string, Action<object>>();

    public void RegisterBtn(string inputName, Action<object> action)
    {
        if (!inputActionMap.ContainsKey(inputName))
        {
            inputActionMap.Add(inputName, action);
        }
        else
        {
            inputActionMap[inputName] = action;
        }
    }

    public void SetBtnFunction(string inputName, Button btn, object arg = null)
    {
        Action<object> action = inputActionMap[inputName];
        if (action != null && btn != null)
        {
            btn.onClick.AddListener(delegate
            {
                action(arg);
            });
        }
    }
}

