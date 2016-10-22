//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight.FightUnit
// FileName : CloseBodyFightUnit
//
// Created by : maxiao (398117200@qq.com) at 2016/8/1 16:10:45
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneByOne;

public class CloseBodyFightUnit:FightUnit
{
    public override void attacked()
    {
        this.WriteMessage(Protocol.TYPE_FIGHT, 0, FightProtocol.ATTACK_CREQ,
                new int[] { moveTarget.GetComponent<FightUnit>().getData().id });
    }
}