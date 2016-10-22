//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight.FightUnitFSM
// FileName : IdleState
//
// Created by : maxiao (398117200@qq.com) at 2016/7/30 4:14:04
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class IdleState : AbstractFUState
{
    public override int GetStateID()
    {
        return FightUnitStateIds.Idle;
    }

    public override void OnEnter(StateMachine fsm, IState previousState, object param1, object param2)
    {
        fsm.GameTransfrom.GetComponent<Animator>().SetInteger("state", 0);
    }

    public override void OnLeave(IState nextState, object param1, object param2)
    {
    }

    public override void OnUpdate()
    {
    }

    public override void OnLateUpdate()
    {
    }

    public override void OnFixedUpdate()
    {
    }
}
