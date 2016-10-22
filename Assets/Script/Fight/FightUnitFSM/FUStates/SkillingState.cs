//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight.FightUnitFSM
// FileName : SkillingState
//
// Created by : maxiao (398117200@qq.com) at 2016/7/30 4:12:42
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class SkillingState:IState
{
    public int GetStateID()
    {
        return FightUnitStateIds.Skilling;
    }

    public void OnEnter(StateMachine fsm, IState previousState, object param1, object param2)
    {
    }

    public void OnLeave(IState nextState, object param1, object param2)
    {
    }

    public void OnUpdate()
    {
    }

    public void OnLateUpdate()
    {
    }

    public void OnFixedUpdate()
    {
    }
}
