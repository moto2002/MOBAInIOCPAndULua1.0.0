//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight.FightUnitFSM
// FileName : BroadcastRunState
//
// Created by : maxiao (398117200@qq.com) at 2016/7/30 4:08:22
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


public class BroadcastRunState:AbstractFUState
{

    public override int GetStateID()
    {
        return FightUnitStateIds.BroadcastRun;
    }

    public override void OnEnter(StateMachine fsm, IState previousState, object param1, object param2)
    {
        if (gameTransform == null)
        {
            gameTransform = fsm.GameTransfrom;
        }
        if (fUnit == null)
        {
            fUnit = gameTransform.GetComponent<FightUnit>();
        }

        anim = gameTransform.GetComponent<Animator>();
        anim.SetInteger("state", 1);
        RecordAnimSpeed();
    }

    public override void OnLeave(IState nextState, object param1, object param2)
    {
        SetAminSpeedToOrigin();
    }

    public override void OnUpdate()
    {
        SetAminSpeedToCharCurSpeed(fUnit.getData().speed);
        gameTransform.position = fUnit.toSetPos;
        gameTransform.eulerAngles = fUnit.toSetEulerAngles;
    }

    public override void OnLateUpdate()
    {
    }

    public override void OnFixedUpdate()
    {
    }
}
