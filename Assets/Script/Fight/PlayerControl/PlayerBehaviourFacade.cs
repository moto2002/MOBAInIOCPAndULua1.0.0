//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight
// FileName : FightInput
//
// Created by : maxiao (398117200@qq.com) at 2016/7/27 1:00:38
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
using UnityStandardAssets.CrossPlatformInput;


public class PlayerBehaviourFacade : MonoBehaviour
{

    #region 单例Instance

    private static PlayerBehaviourFacade _instance;
    private static object syncObj = new object();

    public static PlayerBehaviourFacade Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    _instance = GameObject.FindObjectOfType<PlayerBehaviourFacade>();
                    if (_instance == null)
                    {
                        GameObject container = GameObject.Find("SingletonContainer");
                        if (container == null)
                        {
                            container = new GameObject("SingletonContainer");
                        }
                        _instance = container.AddComponent<PlayerBehaviourFacade>();
                    }
                }
            }
            return _instance;
        }
    }
    #endregion

    /// <summary>
    /// 玩家当前控制的战斗单位
    /// </summary>
    private FightUnit fightUnit;
    /// <summary>
    /// 玩家数据
    /// </summary>
    private FightPlayerModel player;
    /// <summary>
    /// 玩家数据属性
    /// </summary>
    public FightPlayerModel Player
    {
        get { return player; }
        set { player = value; }
    }



    /// <summary>
    /// 更新玩家当前控制的单位
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="iFight"></param>
    public void UpdateControlUnit(FightUnit fu)
    {
        if (fightUnit != null)
        {
            fightUnit.gameObject.GetComponent<UnitPosUpdater>().StopUpdateUnitPos();
        }

        fightUnit = fu;
        if (fu.gameObject.GetComponent<UnitPosUpdater>() == null)
        {
            fu.gameObject.AddComponent<UnitPosUpdater>();
        }
        fu.gameObject.GetComponent<UnitPosUpdater>().StartUpdateUnitPos();
    }
    /// <summary>
    /// 根据摇杆的输入来更新控制单位的移动
    /// </summary>
    void Update()
    {
        float x = CrossPlatformInputManager.GetAxis(Joystick.horizontalAxisName);
        float y = CrossPlatformInputManager.GetAxis(Joystick.verticalAxisName);
        if (x != 0 || y != 0)
        {
            Debug.Log(x + "," + y);
            if (fightUnit != null)
            {
                Debug.Log("move by control");
                fightUnit.MoveByControl();
            }
        }
    }
    /// <summary>
    /// 攻击键按下
    /// </summary>
    public void AttackPressed()
    {
        if (fightUnit != null)
        {
            fightUnit.StartAttack();
        }
    }
    /// <summary>
    /// 技能键按下
    /// </summary>
    /// <param name="arg">技能的Id</param>
    public void SkillPressed(object arg)
    {
        if (arg == null)
        {
            Debug.Log("未传入技能按钮对应的技能id");
        }

        int id = Convert.ToInt32(arg);
        if (fightUnit != null)
        {
            fightUnit.skill(id);
        }
    }
}