using OneByOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public interface IFight
{
    /// <summary>
    /// 开始攻击
    /// </summary>
    void StartAttack();

    /// <summary>
    /// 对一组目标进行攻击
    /// </summary>
    /// <param name="targets"></param>
    void attack(int[] targetIds);
    /// <summary>
    /// 攻击动画播放结束触发的攻击成功
    /// </summary>
    void attacked();
    /// <summary>
    /// 群体技能
    /// </summary>
    /// <param name="code"></param>
    /// <param name="targets"></param>
    void skill(int code, GameObject[] targets);
    /// <summary>
    /// 单体技能
    /// </summary>
    /// <param name="code"></param>
    /// <param name="target"></param>
    void skill(int code, Transform target);
    /// <summary>
    /// 技能释放成功
    /// </summary>
    void skilled();
    /// <summary>
    /// 减血
    /// </summary>
    /// <param name="value"></param>
    void damage(int value);
    /// <summary>
    /// 按照玩家的控制移动
    /// </summary>
    void MoveByControl();
    /// <summary>
    /// 按照网络广播的数据来移动
    /// </summary>
    /// <param name="dto"></param>
    void MoveByBroadcast(MoveDTO dto);
    /// <summary>
    /// 对FightUnit进行初始化
    /// </summary>
    /// <param name="teamId"></param>
    /// <param name="model"></param>
    /// <param name="isMyTeam"></param>
    void Initial(int teamId, FightPlayerModel model, bool isMyTeam);
    /// <summary>
    /// 设置FightUnit的tag
    /// </summary>
    /// <param name="tag"></param>
    void setTag(string tag);
    /// <summary>
    /// 得到FightUnit的model
    /// </summary>
    /// <returns></returns>
    FightPlayerModel getData();
    /// <summary>
    /// 设置FightUnit的model
    /// </summary>
    /// <param name="model"></param>
    void setData(FightPlayerModel model);
    /// <summary>
    /// 得到fightUnit的当前状态
    /// </summary>
    /// <returns></returns>
    IState getCurState();
    /// <summary>
    /// 得到当前的攻击目标
    /// </summary>
    /// <returns></returns>
    GameObject[] getAttackTargets();
    /// <summary>
    /// 释放当前的攻击目标
    /// </summary>
    void ReleaseAttackTargets();
}

