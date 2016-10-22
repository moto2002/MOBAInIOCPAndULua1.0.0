//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Tools
// FileName : GameSocketModelUtil
//
// Created by : maxiao (398117200@qq.com) at 2016/8/25 16:51:52
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class GameSocketModelUtil
{
    /// <summary>
    /// 对SocketModel进行长度解码
    /// </summary>
    /// <param name="cache"></param>
    /// <returns></returns>
    public static byte[] ldecode(ref List<byte> cache)
    {
        if (cache.Count < 4) return null;
        MemoryStream ms = new MemoryStream(cache.ToArray());
        BinaryReader br = new BinaryReader(ms);
        int length = br.ReadInt32();
        if (length > ms.Length - ms.Position)
        {
            return null;
        }

        byte[] result = br.ReadBytes(length);
        cache.Clear();
        cache.AddRange(br.ReadBytes((int)(ms.Length - ms.Position)));
        br.Close();
        ms.Close();
        return result;
    }
    /// <summary>
    /// 进行SocketModel解码
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static SocketModel mDecode(byte[] value)
    {
        ByteArray ba = new ByteArray(value);
        SocketModel sm = new SocketModel();
        int type;
        int area;
        int command;
        ba.read(out type);
        ba.read(out area);
        ba.read(out command);
        sm.type = type;
        sm.area = area;
        sm.command = command;
        if (ba.Readnable)
        {
            byte[] message;
            ba.read(out message, ba.Length - ba.Position);
            sm.message = SerializeUtil.decoder(message);
        }
        ba.Close();
        return sm;
    }
}
