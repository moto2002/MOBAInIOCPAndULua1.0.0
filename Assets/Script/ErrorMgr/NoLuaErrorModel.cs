//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.ErrorMgr
// FileName : NoLuaErrorModel
//
// Created by : maxiao (398117200@qq.com) at 2016/10/3 3:42:18
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NoLuaErroModel:IError
{
    public string text;
    /// <summary>
    /// 这个方法在玩家确认之后调用
    /// </summary>
    public Action<object[]> function;

    public NoLuaErroModel(string s, Action<object[]> action)
    {
        text = s;
        function = action;
    }

    public NoLuaErroModel(string s)
    {
        text = s;
    }

    public void CallFunction()
    {
        ErrorManager.Instance.ShowErrorPanel();
        ErrorManager.Instance.SetErrorPanelText(text);
        ErrorManager.Instance.SetEnsureBtnFunction(function);
    }
}