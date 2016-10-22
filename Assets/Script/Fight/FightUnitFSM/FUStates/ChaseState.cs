//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight.FightUnitFSM
// FileName : ChaseNAttackState
//
// Created by : maxiao (398117200@qq.com) at 2016/7/30 4:11:23
//
// Function : 
//
//======================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneByOne;
using UnityEngine;

public class ChaseState : AbstractFUState
{
    private Transform target = null;
    private bool isAttacking = false;

    public override int GetStateID()
    {
        return FightUnitStateIds.Chase;
    }

    public override void OnEnter(StateMachine fsm, IState previousState, object param1, object param2)
    {
        if (fuFSM == null)
        {
            fuFSM = fsm;
        }
        if (gameTransform == null)
        {
            gameTransform = fsm.GameTransfrom;

        }
        fUnit = gameTransform.GetComponent<FightUnit>();

        anim = gameTransform.GetComponent<Animator>();
        anim.SetInteger("state", 1);
        RecordAnimSpeed();

        target = gameTransform.GetComponent<EnemyEye>().GetNearestFrontTarget();
        fUnit.MoveTarget = target;
    }

    public override void OnLeave(IState nextState, object param1, object param2)
    {
        SetAminSpeedToOrigin();
    }

    public override void OnUpdate()
    {
        if (target != null)
        {
            gameTransform.LookAt(target);
            if (Vector3.Distance(gameTransform.position, target.position) <= fUnit.getData().range)
            {
                if (!isAttacking)
                {
                    NetWorkScript.Instance.write(Protocol.TYPE_FIGHT, 0, FightProtocol.ATTACK_CREQ,
                        target.GetComponent<FightUnit>().getData().id);
                    isAttacking = true;
                }
            }
            else
            {
                isAttacking = false;
                SetAminSpeedToCharCurSpeed(fUnit.getData().speed);
                gameTransform.Translate(0f, 0f, fUnit.getData().speed*Time.deltaTime, Space.Self);
            }
        }
        else
        {
            fuFSM.SwitchState(FightUnitStateIds.Idle, null, null);
        }
    }

    public override void OnLateUpdate()
    {
    }

    public override void OnFixedUpdate()
    {
    }
}
