//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.MiniMap
// FileName : MapHead
//
// Created by : maxiao (398117200@qq.com) at 2016/7/25 6:09:51
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class MapHead:MonoBehaviour
{
    /// <summary>
    /// 头像的sprite
    /// </summary>
    private Image img;
    /// <summary>
    /// 头像的recTrans
    /// </summary>
    private RectTransform trans;

    void Start()
    {
        img = transform.GetComponent<Image>();
        trans = transform.GetComponent<RectTransform>();
    }

    /// <summary>
    /// 设置小地图头像的位置
    /// </summary>
    /// <param name="pos"></param>
    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }
    /// <summary>
    /// 设置小地图头像的sprite
    /// </summary>
    /// <param name="sp"></param>
    public void SetHeadSprite(HeadType type)
    {
        Sprite sp = ResourceMgr.Instance.GetSprite(GetHeadSpriteName(type));
        img.sprite = sp;
        trans.sizeDelta = sp.rect.size;
    }

    private string GetHeadSpriteName(HeadType type)
    {
        switch (type)
        {
            case HeadType.batman:
                return "head_batMan";
            case HeadType.bigDead:
                return "head_dead";
            case HeadType.bigEnemy:
                return "head_bigEnemy";
            case HeadType.bigFriend:
                return "head_bigFriend";
            case HeadType.boss:
                return "head_boss";
            case HeadType.sheild:
                return "head_sheild";
            case HeadType.shop:
                return "head_shop";
            case HeadType.smallDead:
                return "head_smallDead";
            case HeadType.smallEnemy:
                return "head_smallEnemy";
            case HeadType.smallFriend:
                return "head_smallFriend";
            case HeadType.squareFriend:
                return "head_squareFriend";
            default:
                return "";
        }
    }
}

