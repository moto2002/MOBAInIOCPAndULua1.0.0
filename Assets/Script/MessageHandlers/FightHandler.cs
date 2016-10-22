using UnityEngine;
using System.Collections;
using OneByOne;
using System.Collections.Generic;
using UnityEngine.UI;

public class FightHandler : MonoBehaviour,IHandler {

    public void MessageReceive(SocketModel model)
    {
        switch (model.command) { 
            case FightProtocol.FIGHT_BRO:
                fightStart(model.getMessage<FightRoomModel>());
                break;
            case FightProtocol.MOVE_BRO:
                move(model.getMessage<MoveDTO>());
                break;
            case FightProtocol.SKILL_UP_SRES:
                skillLevelUp(model.getMessage<FightSkill>());
                break;
            case FightProtocol.ATTACK_BRO:
                attack(model.getMessage<AttackDTO>());
                break;
            case FightProtocol.DAMAGE_BRO:
                damage(model.getMessage<DamageDTO>());
                break;
        }
    }

    private void damage(DamageDTO dto) {
        foreach (int[] item in dto.targetDamage)
        {
            GameObject target= FightUnitMgr.Instance.GetGameObjectById(item[0]);
            if (target != null)
            {
                target.GetComponent<FightUnit>().damage(item[1]);
            }
        }
    }

    private void attack(AttackDTO atk)
    {
        GameObject attackUnit = FightUnitMgr.Instance.GetGameObjectById(atk.id);
        if (attackUnit != null)
        {
            attackUnit.GetComponent<FightUnit>().attack(atk.target);
        }
    }

    private void skillLevelUp(FightSkill skill)
    {
        for (int i = 0; i < PlayerController.Instance.Player.skills.Length; i++)
        {
            if (PlayerController.Instance.Player.skills[i].id == skill.id)
            {
                PlayerController.Instance.Player.free -= 1;
                PlayerController.Instance.Player.skills[i] = skill;
                LuaScriptMgr.Instance.CallLuaFunction("refreshSkillUI", null);
                return;
            }
        }
    }
    /// <summary>
    /// 向一个战斗单位发送移动广播
    /// </summary>
    /// <param name="dto"></param>
    private void move(MoveDTO dto)
    {
        GameObject unit = FightUnitMgr.Instance.GetGameObjectById(dto.userId);
        if (unit != null)
        {
            unit.GetComponent<FightUnit>().MoveByBroadcast(dto);
        }
    }
    /// <summary>
    /// 战斗开始前进行的加载
    /// </summary>
    /// <param name="model">游戏房间的数据</param>
    private void fightStart(FightRoomModel model) {
        //1.判断队伍1中有没有当前玩家，有的话属于队伍1
        foreach (FightPlayerModel item in model.teamOne)
        {
            if (item.id == GameData.user.id) {
                PlayerController.Instance.MyTeamId = 1;
                break;
            }
        }
        //2.没有的话，当前玩家属于队伍2
        if (PlayerController.Instance.MyTeamId == 0)
        {
            PlayerController.Instance.MyTeamId = 2;
        }
        //3.为两支队伍添加英雄
        foreach (FightPlayerModel item in model.teamOne)
        {
            addHero(1, item);
        }

        foreach (FightPlayerModel item in model.teamTwo)
        {
            addHero(2, item);
        }
    }
    /// <summary>
    /// 向当前战斗场景中添加一个英雄
    /// </summary>
    /// <param name="teamId">英雄所属的队伍ID</param>
    /// <param name="model">英雄的数据</param>
    private void addHero(int teamId,FightPlayerModel model)
    {
        string assetName = "assets/dynamicresources/characters/hero" + model.heroId + ".prefab";
        Debug.Log(assetName);
        GameObject o = FightUnitMgr.Instance.NewGameObject(model.id, assetName, model.name + model.id,false);
        FightUnit fu = o.GetComponent<FightUnit>();
        bool isMyTeam = (PlayerController.Instance.MyTeamId == teamId);
        fu.Initial(teamId, model, isMyTeam);

        if (model.id == GameData.user.id)
        {
            PlayerController.Instance.Player = model;

            LuaScriptMgr.Instance.CallLuaFunction("initPlayerFightUI",model);//设置玩家界面

            CameraMgr.Instance.FocusMainCameraToPlayer(o.transform);//摄像机对准角色
            PlayerBehaviourFacade.Instance.UpdateControlUnit(fu);
        }
    }
}
