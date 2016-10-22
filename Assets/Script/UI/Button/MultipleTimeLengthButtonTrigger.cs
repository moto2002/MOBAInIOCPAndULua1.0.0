//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.UI.Button
// FileName : MultipleTimeLengthButtonTrigger
//
// Created by : maxiao (398117200@qq.com) at 2016/9/17 14:15:56
//
// Function : 
//
//======================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MultipleTimeLengthButtonTrigger : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    /// <summary>
    /// 长按和短按之间的分界线
    /// </summary>
    private float longPressDurationThreshold = 0.7f;
    /// <summary>
    /// 按下的时间
    /// </summary>
    private float pointerDownTimestamp;
    /// <summary>
    /// 长按是否已经触发
    /// </summary>
    private bool isLongPressTriggered = false;
    /// <summary>
    /// 长按事件
    /// </summary>
    public UnityEvent longPressTrigger;
    /// <summary>
    /// 退出长按事件
    /// </summary>
    public UnityEvent cancelLongPressTrigger;



    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(onPressed());
    }
    /// <summary>
    /// 进入长按之后的协程判断
    /// </summary>
    /// <returns></returns>
    IEnumerator onPressed()
    {
        pointerDownTimestamp = Time.time;
        while (true)
        {
            if (!isLongPressTriggered)
            {
                if (Time.time - pointerDownTimestamp > longPressDurationThreshold)
                {
                    isLongPressTriggered = true;
                    longPressTrigger.Invoke();
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CancelLongPress();
    }
    /// <summary>
    /// 取消长按
    /// </summary>
    void CancelLongPress()
    {
        StopCoroutine(onPressed());
        isLongPressTriggered = false;
        cancelLongPressTrigger.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CancelLongPress();
    }
}
