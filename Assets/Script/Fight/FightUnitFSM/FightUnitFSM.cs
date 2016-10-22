//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight
// FileName : FightUnitFSM
//
// Created by : maxiao (398117200@qq.com) at 2016/7/29 12:28:52
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FightUnitFSM:StateMachine
{
    public FightUnitFSM(Transform goTransform):base(goTransform)
    {
        this.RegisterState(new BroadcastRunState());
        this.RegisterState(new ChaseState());
        this.RegisterState(new AttackState());
        this.RegisterState(new IdleState());
        this.RegisterState(new SkillingState());
        this.RegisterState(new JoystickRunState());
    }
}
