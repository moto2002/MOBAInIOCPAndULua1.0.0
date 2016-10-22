//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight.skill
// FileName : BaseSkill
//
// Created by : maxiao (398117200@qq.com) at 2016/7/31 0:41:25
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
/// 所有技能的基类
/// </summary>
public class BaseSkill:MonoBehaviour
{
    public virtual void Init()
    {
    }

    /// <summary>
    /// 释放技能
    /// </summary>
    public virtual void ReleaseSkill()
    {
    }
    /// <summary>
    /// 停止技能
    /// </summary>
    public virtual void StopSkill()
    {
    }
}
