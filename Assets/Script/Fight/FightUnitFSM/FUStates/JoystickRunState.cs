//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight.FightUnitFSM
// FileName : FightUnitRunState
//
// Created by : maxiao (398117200@qq.com) at 2016/7/29 12:30:47
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
using UnityStandardAssets.CrossPlatformInput;


public class JoystickRunState : AbstractFUState
{
    public override int GetStateID()
    {
        return FightUnitStateIds.JoystickRun;
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
        if (fuFSM == null)
        {
            fuFSM = fsm;
        }

        anim = gameTransform.GetComponent<Animator>();
        anim.SetInteger("state", 1);
        SetAminSpeedToCharCurSpeed(fUnit.getData().speed);
    }

    public override void OnLeave(IState nextState, object param1, object param2)
    {
        SetAminSpeedToOrigin();
    }

    public override void OnUpdate()
    {
        float x = CrossPlatformInputManager.GetAxis(Joystick.horizontalAxisName);
        float y = CrossPlatformInputManager.GetAxis(Joystick.verticalAxisName);
        if (x != 0 || y != 0)
        {
            Debug.Log(x + "," + y);
            gameTransform.eulerAngles = new Vector3(0, (Mathf.Atan2(x, y) / Mathf.PI) * 180, 0);
            gameTransform.Translate(0f, 0f, fUnit.getData().speed*Time.deltaTime, Space.Self);
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