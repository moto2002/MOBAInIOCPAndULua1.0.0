//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight.FightUnit
// FileName : LongRangeFightUnit
//
// Created by : maxiao (398117200@qq.com) at 2016/8/1 16:08:01
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LongRangeFightUnit : FightUnit
{
    public override void attacked()
    {
        foreach (int targetId in attackTargets)
        {
            GameObject target = FightUnitMgr.Instance.GetGameObjectById(targetId);
            GameObject go = (GameObject)Instantiate(attackedEffect, transform.position + new Vector3(0, 1), transform.rotation);
            go.GetComponent<TargetSkill>().Init(target, -1, 0);
            go.GetComponent<TargetSkill>().ReleaseSkill();
        }
    }
}