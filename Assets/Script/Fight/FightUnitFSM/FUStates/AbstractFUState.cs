//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight.FightUnitFSM.FUStates
// FileName : FUState
//
// Created by : maxiao (398117200@qq.com) at 2016/8/23 15:11:45
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

public abstract class AbstractFUState:IState
{
    protected Animator anim;
    protected FightUnit fUnit;
    protected float originAminSpeed = 0f;
    protected StateMachine fuFSM = null;
    protected Transform gameTransform = null;

    public abstract int GetStateID();

    public abstract void OnEnter(StateMachine fsm, IState previousState, object param1, object param2);

    public abstract void OnLeave(IState nextState, object param1, object param2);

    public abstract void OnUpdate();

    public abstract void OnLateUpdate();

    public abstract void OnFixedUpdate();

    protected void SetAminSpeedToOrigin()
    {
        anim.speed = originAminSpeed;
    }

    protected void RecordAnimSpeed()
    {
        originAminSpeed = anim.speed;
    }

    protected void SetAminSpeedToCharCurSpeed(float speed)
    {
        anim.speed = anim.GetCurrentAnimatorStateInfo(0).length/speed;
    }
}
