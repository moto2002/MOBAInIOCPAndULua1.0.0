//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight
// FileName : FightUnitView
//
// Created by : maxiao (398117200@qq.com) at 2016/8/1 2:28:01
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FightUnitView:MonoBehaviour
{


    private Transform unitInfoView;
    private UnitInfoView unitInfoViewScript;

    private Transform mapHead;
    private MapHead mapHeadScript;
    private bool isHeadShow;

    public void Init()
    {
        unitInfoView = ((GameObject)Instantiate(ResourceMgr.Instance.LoadSync("assets/dynamicresources/uiprefabs/uidynamicprefabs/unitinfoview.prefab", null, true))).transform;
        unitInfoView.name = "unitInfoView";
        unitInfoView.parent = TransformFinder.Instance.GetTransform("UnitInfoContainer");
        unitInfoViewScript = unitInfoView.GetComponent<UnitInfoView>();

        mapHead = ((GameObject)Instantiate(ResourceMgr.Instance.LoadSync("assets/dynamicresources/uiprefabs/uidynamicprefabs/maphead.prefab", null, true))).transform;
        mapHead.name = "MapHead";
        mapHead.parent = TransformFinder.Instance.GetTransform("MiniMapContainer");

        mapHeadScript = unitInfoView.GetComponent<MapHead>();
    }

    public void SetName(string name)
    {
        unitInfoViewScript.SetName(name);
    }


    public void SetHpBarColor(Color col)
    {
        unitInfoViewScript.SetHpBarColor(col);
    }

    public void SetHpView(float percent)
    {
        unitInfoViewScript.SetValue(percent);
    }

    public void HideMiniMapHead()
    {
        isHeadShow = false;
        mapHead.gameObject.SetActive(false);
    }

    public void ShowMiniMapHead()
    {
        isHeadShow = true;
        mapHead.gameObject.SetActive(true);
    }

    public void ViewAsFriend()
    {
        unitInfoViewScript.SetFriendColor();
        ShowMiniMapHead();
    }

    public void ViewAsEnemy()
    {
        unitInfoViewScript.SetEnemyColor();
        HideMiniMapHead();
    }

    public void SetViewByData(HeadType headType)
    {

    }

    void Update()
    {
        Vector2 unit2DPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (isHeadShow)
        {
            Vector3 originalPos = transform.position*GameData.mapToMiniMapScale;
            mapHead.localPosition = new Vector3(originalPos.x,originalPos.y,0f);
        }

        if (unit2DPosition.x > Screen.width || unit2DPosition.x < 0 || unit2DPosition.y > Screen.height ||
            unit2DPosition.y < 0)
        {
            unitInfoView.gameObject.SetActive(false);
        }
        else
        {
            unitInfoView.gameObject.SetActive(true);
            unitInfoViewScript.SetInfoViewPos(unit2DPosition);
        }
    }
}