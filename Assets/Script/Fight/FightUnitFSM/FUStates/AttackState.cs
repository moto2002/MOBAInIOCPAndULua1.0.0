//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight.FightUnitFSM.FUStates
// FileName : AttackState
//
// Created by : maxiao (398117200@qq.com) at 2016/7/30 6:08:08
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

public class AttackState : AbstractFUState
{
    private Transform attackTarget = null;

    public override int GetStateID()
    {
        return FightUnitStateIds.Attack;
    }

    public override void OnEnter(StateMachine fsm, IState previousState, object param1, object param2)
    {
        fuFSM = fsm;
        if (gameTransform == null)
        {
            gameTransform = fsm.GameTransfrom;
        }

        fUnit = gameTransform.GetComponent<FightUnit>();

        anim = fsm.GameTransfrom.GetComponent<FightUnit>().Anim;
        anim.SetInteger("state", 2);
        RecordAnimSpeed();
        attackTarget = fsm.GameTransfrom.GetComponent<FightUnit>().MoveTarget;
    }

    public override void OnLeave(IState nextState, object param1, object param2)
    {
        SetAminSpeedToOrigin();
    }

    public override void OnUpdate()
    {
        if (attackTarget != null)
        {
            gameTransform.LookAt(attackTarget);
            SetAminSpeedToCharCurSpeed(fUnit.getData().aspeed);

            if (Vector3.Distance(gameTransform.position, attackTarget.position) > fUnit.getData().range)
            {
                fuFSM.SwitchState(FightUnitStateIds.Chase, null, null);
            }
        }
    }

    public override void OnLateUpdate()
    {
    }

    public override void OnFixedUpdate()
    {
    }
}
