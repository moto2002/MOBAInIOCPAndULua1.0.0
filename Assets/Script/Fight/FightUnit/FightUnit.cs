//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight
// FileName : FightUnit
//
// Created by : maxiao (398117200@qq.com) at 2016/7/27 5:55:03
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

/// <summary>
/// 战斗单位的基类，Hero继承这个类
/// </summary>
[RequireComponent(typeof(EnemyEye), typeof(FightUnitView))]
public class FightUnit : MonoBehaviour, IFight
{
    /// <summary>
    /// 战斗单位的视觉内容
    /// </summary>
    protected FightUnitView fuView;
    /// <summary>
    /// 视野
    /// </summary>
    protected EnemyEye enemyEye;
    /// <summary>
    /// 战斗单位的数据
    /// </summary>
    protected FightPlayerModel fightModel;
    /// <summary>
    /// 状态机
    /// </summary>
    protected FightUnitFSM fuFSM;
    /// <summary>
    /// 要移动的目标
    /// </summary>
    protected Transform moveTarget;
    /// <summary>
    /// 攻击目标的Id
    /// </summary>
    protected int[] attackTargets;
    /// <summary>
    /// 角色的anim
    /// </summary>
    protected Animator anim;
    /// <summary>
    /// 当收到广播移动数据后，将移动数据传入这里，然后广播移动状态取出这个数据进行更新
    /// </summary>
    public Vector3 toSetPos;
    /// <summary>
    /// 当收到广播移动数据后，将移动数据传入这里，然后广播移动状态取出这个数据进行更新
    /// </summary>
    public Vector3 toSetEulerAngles;
    /// <summary>
    /// 攻击的特效
    /// </summary>
    public GameObject attackedEffect;


    void Start()
    {

    }

    public Transform MoveTarget
    {
        get
        {
            return moveTarget;
        }

        set
        {
            moveTarget = value;
        }
    }

    public Animator Anim
    {
        get
        {
            return anim;
        }

        set
        {
            anim = value;
        }
    }

    public void Initial(int teamId, FightPlayerModel model, bool isMyTeam)
    {
        fuFSM = new FightUnitFSM(this.transform);
        anim = transform.GetComponent<Animator>();
        fuFSM.SwitchState(FightUnitStateIds.Idle, null, null);
        fuView = GetComponent<FightUnitView>();
        enemyEye = GetComponent<EnemyEye>();
        setData(model);
        fuView.Init();
        fuView.SetHpView(1f);

        if (teamId == 1)
        {
            transform.position = GameData.teamOneStart;
            transform.rotation = Quaternion.identity;
        }
        else
        {
            transform.position = GameData.teamTwoStart;
            transform.rotation = Quaternion.identity;
        }

        if (isMyTeam)
        {
            gameObject.layer = LayerMask.NameToLayer("visible");
            fuView.ViewAsFriend();
            fuView.SetName(model.name);
            setTag("friendHero");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("invisible");
            fuView.ViewAsEnemy();
            fuView.SetName(model.name);
            setTag("enemyHero");
        }
    }
    /// <summary>
    /// 完成攻击，造成伤害
    /// </summary>
    public virtual void attacked()
    {
    }
    /// <summary>
    /// 接到攻击广播，开始攻击
    /// </summary>
    /// <param name="targets"></param>
    public void attack(int[] targets)
    {
        attackTargets = targets;
        fuFSM.SwitchState(FightUnitStateIds.Attack, null, null);
    }

    public void skill(int id, GameObject[] targets)
    {
    }

    public void skill(int id, Transform target)
    {
    }

    public void skill(int id)
    {
    }

    public void skilled()
    {
    }
    /// <summary>
    /// 对一个单位造成伤害
    /// </summary>
    /// <param name="value"></param>
    public void damage(int value)
    {
        fightModel.hp -= value;
        if (fightModel.hp < 0)
        {
            fightModel.hp = 0;
            //TODO dead
        }
        if (fightModel.hp > fightModel.maxHp)
        {
            fightModel.hp = fightModel.maxHp;
        }
        fuView.SetHpView((float)fightModel.hp / fightModel.maxHp);
    }
    /// <summary>
    /// 通过摇杆来移动
    /// </summary>
    public void MoveByControl()
    {
        fuFSM.SwitchState(FightUnitStateIds.JoystickRun, null, null);
    }
    /// <summary>
    /// 通过广播数据来移动
    /// </summary>
    /// <param name="dto"></param>
    public void MoveByBroadcast(MoveDTO dto)
    {
        SetMoveVectors(dto);
    }

    /// <summary>
    /// 当收到移动广播时按收到的数据进行移动
    /// </summary>
    /// <param name="dto"></param>
    public void SetMoveVectors(MoveDTO dto)
    {
        toSetPos = new Vector3(dto.posX, dto.posY, dto.posZ);
        toSetEulerAngles = new Vector3(dto.dirX, dto.dirY, dto.dirZ);
        fuFSM.SwitchState(FightUnitStateIds.BroadcastRun, null, null);
    }
    /// <summary>
    /// 设置战斗单位的tag
    /// </summary>
    /// <param name="tag"></param>
    public void setTag(string tag)
    {
        transform.tag = tag;
    }
    /// <summary>
    /// 得到战斗单位的数据
    /// </summary>
    /// <returns></returns>
    public FightPlayerModel getData()
    {
        return fightModel;
    }
    /// <summary>
    /// 设置战斗单位的数据
    /// </summary>
    /// <param name="model"></param>
    public void setData(FightPlayerModel model)
    {
        this.fightModel = model;
    }
    /// <summary>
    /// 得到当前的状态
    /// </summary>
    /// <returns></returns>
    public IState getCurState()
    {
        return fuFSM.CurState;
    }
    /// <summary>
    /// 得到攻击目标
    /// </summary>
    /// <returns></returns>
    public GameObject[] getAttackTargets()
    {
        List<GameObject> targets = new List<GameObject>();
        for (int i = 0; i < attackTargets.Length; i++)
        {
            targets.Add(FightUnitMgr.Instance.GetGameObjectById(attackTargets[i]));
        }

        return targets.Count == 0 ? null : targets.ToArray();
    }
    /// <summary>
    /// 释放攻击目标
    /// </summary>
    public void ReleaseAttackTargets()
    {
        moveTarget = null;
        attackTargets = null;
    }
    /// <summary>
    /// 开始攻击
    /// </summary>
    public void StartAttack()
    {
        fuFSM.SwitchState(FightUnitStateIds.Chase, null, null);
    }

    /// <summary>
    /// 更新方法
    /// </summary>
    void Update()
    {
        fuFSM.OnUpdate();
    }
}

