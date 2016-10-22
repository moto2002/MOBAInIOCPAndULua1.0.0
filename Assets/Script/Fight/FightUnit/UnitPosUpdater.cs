//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight
// FileName : UpdateUnitPos
//
// Created by : maxiao (398117200@qq.com) at 2016/7/28 4:21:21
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


public class UnitPosUpdater : MonoBehaviour
{
    public bool isUpdating = false;
    private float sendMoveInterval;
    private int unitId;

    private Vector3 lastPosition;

    void OnEnable()
    {
        sendMoveInterval = 1 / GameData.posUpdateRate;
        lastPosition = transform.position;
    }

    void OnDisable()
    {
        StopUpdateUnitPos();
    }

    public void StartUpdateUnitPos()
    {
        unitId = GetComponent<FightUnit>().getData().id;
        StartCoroutine("UpdatePosition");
    }

    IEnumerator UpdatePosition()
    {
        while (true)
        {
            if (isUpdating && Vector3.Distance(lastPosition, transform.position) > 0.001f)
            {
                MoveDTO dto = new MoveDTO();
                dto.userId = unitId;
                dto.dirX = transform.eulerAngles.x;
                dto.dirY = transform.eulerAngles.y;
                dto.dirZ = transform.eulerAngles.z;
                dto.posX = transform.position.x;
                dto.posY = transform.position.y;
                dto.posZ = transform.position.z;
                NetWorkScript.Instance.write(Protocol.TYPE_FIGHT, 0, FightProtocol.MOVE_CREQ, dto);
            }

            lastPosition = transform.position;
            yield return new WaitForSeconds(sendMoveInterval);
        }
    }

    public void StopUpdateUnitPos()
    {
        StopCoroutine("UpdatePosition");
    }
}

