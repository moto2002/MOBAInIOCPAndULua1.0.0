//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Tools
// FileName : NetUtils
//
// Created by : maxiao (398117200@qq.com) at 2016/9/20 10:56:53
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using Ping = System.Net.NetworkInformation.Ping;

public class NetUtils
{
    /// <summary>
    /// TODO 因为协议族的问题，这个方法没有正常工作
    /// </summary>
    /// <param name="ipOrDomain"></param>
    /// <returns></returns>
    public static bool PingIpOrDomainName(string ipOrDomain)
    {
        Debug.Log("Start ping");
        Ping objPingSender = new Ping();
        Debug.Log("New ping");
        PingReply objPingReply = objPingSender.Send(ipOrDomain);
        Debug.Log("pinged");
        Debug.Log(objPingReply.Status);
        if (objPingReply.Status == IPStatus.Success)
        {
            Debugger.Log("连接测试成功");
            return true;
        }
        else
        {
            return false;
        }
    }
}
