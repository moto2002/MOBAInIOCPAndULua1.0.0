//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.UI.SkillUI
// FileName : SkillSingleton
//
// Created by : maxiao (398117200@qq.com) at 2016/9/18 9:06:34
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneByOne;
using UnityEngine;

public class SkillTipSingleton:MonoBehaviour
{
    #region 单例Instance

    private static SkillTipSingleton _instance;
    private static object syncObj = new object();

    public static SkillTipSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    if (_instance == null)
                    {
                        _instance = new SkillTipSingleton();
                    }
                }
            }
            return _instance;
        }
    }

    #endregion

    private SkillTip skillTip;

    private SkillTipSingleton()
    {
        GameObject tip = Instantiate(ResourceMgr.Instance.LoadSync("skillTip", null, true) as GameObject);
        tip.transform.parent = TransformFinder.Instance.GetTransform("skillTipContainer");
        skillTip = tip.GetComponent<SkillTip>();
        if (skillTip == null)
        {
            skillTip = tip.AddComponent<SkillTip>();
        }
    }

    public void ActiveTip(FightSkill skill, Vector3 position)
    {
        skillTip.Active(skill, position);
    }

    public void DisactiveTip()
    {
        skillTip.Disactive();
    }
}
