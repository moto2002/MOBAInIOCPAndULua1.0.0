//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Fight.PlayerControl
// FileName : PlayerController
//
// Created by : maxiao (398117200@qq.com) at 2016/9/19 9:26:23
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneByOne;

public class PlayerController
{
    #region 单例Instance

    private static PlayerController _instance;
    private static object syncObj = new object();

    public static PlayerController Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    if (_instance == null)
                    {
                        _instance = new PlayerController();
                    }
                }
            }
            return _instance;
        }
    }



    #endregion

    private FightPlayerModel player;

    private int myTeamId = 0;

    public FightPlayerModel Player
    {
        get { return player; }
        set { player = value; }
    }

    public int MyTeamId
    {
        get { return myTeamId; }
        set { myTeamId = value; }
    }
}
