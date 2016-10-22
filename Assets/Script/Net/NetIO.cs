//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script
// FileName : NetIO
//
// Created by : maxiao (398117200@qq.com) at 2016/6/18 22:37:34
//
// Function : 
//
//======================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

/// <summary>
/// 这个单例类用来收发网络消息
/// </summary>
public class NetIO :EventNode
{
    /// <summary>
    /// 套接字
    /// </summary>
    private Socket socket;
    /// <summary>
    /// 读取缓存区大小
    /// </summary>
    private int readBuffSize = AppConst.READ_BUFF_COUNT;
    /// <summary>
    /// 读取缓存
    /// </summary>
    private byte[] readBuff;
    /// <summary>
    /// 接收到的字节缓存区
    /// </summary>
    private List<byte> cache = new List<byte>();
    /// <summary>
    /// 是否正在读取
    /// </summary>
    private bool isRead = false;
    /// <summary>
    /// 接收到的消息队列
    /// </summary>
    private Queue<SocketModel> receivedMessages = new Queue<SocketModel>();

    #region 单例Instance

    private static NetIO _instance;
    private static object syncObj = new object();

    public static NetIO Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    _instance = GameObject.FindObjectOfType<NetIO>();
                    if (_instance == null)
                    {
                        GameObject container = GameObject.Find("SingletonContainer");
                        if (container == null)
                        {
                            container = new GameObject("SingletonContainer");
                        }
                        _instance = container.AddComponent<NetIO>();
                    }
                }
            }
            return _instance;
        }
    }

    #endregion

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// 初始化读取缓存及套接字
    /// </summary>
    private void Init()
    {
        readBuff = new byte[readBuffSize];

        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Connect();
    }
    /// <summary>
    /// 连接服务器并开始接收
    /// </summary>
    public void Connect()
    {
        try
        {
            if (socket.Connected)
            {
                socket.Disconnect(true);
            }

            socket.Connect(AppConst.GAME_SERVER_IP, AppConst.GAME_SERVER_PORT);
            socket.BeginReceive(readBuff, 0, readBuffSize, SocketFlags.None, ReceiveCallBack, readBuff);
            onConnected();
            Debug.Log("连接服务器成功");
        }
        catch (Exception e)
        {
            onConnectFailed();
            Debug.Log("连接服务器失败" + e.Message);
        }
    }

    private void onConnectFailed()
    {
    }

    private void onConnected()
    {
    }

    /// <summary>
    /// 提供给外部的发送消息方法，这里就直接写了
    /// </summary>
    /// <param name="type">消息类型</param>
    /// <param name="area">区域码</param>
    /// <param name="command">命令码</param>
    /// <param name="message">附带的消息，可以为空</param>
    public void Write(int type, int area, int command, object message = null)
    {
        ByteArray temp = new ByteArray();
        temp.write(type);
        temp.write(area);
        temp.write(command);
        if (message != null)
        {
            temp.write(SerializeUtil.encode(message));
        }

        ByteArray arr = new ByteArray();
        arr.write(temp.Length);
        arr.write(temp.getBuff());
        try
        {
            socket.Send(arr.getBuff());
            onSend();
        }
        catch (Exception e)
        {
            Debug.Log("网络错误，请检查：" + e.Message);
            onWriteError();
        }
    }

    private void onSend()
    {
    }

    private void onWriteError()
    {
    }
    /// <summary>
    /// 接收到数据的回调函数
    /// </summary>
    /// <param name="asr">异步接收结果</param>
    private void ReceiveCallBack(IAsyncResult asr)
    {
        try
        {
            //结束消息读取，并得到消息长度
            int readCount = socket.EndReceive(asr);
            byte[] bytes = new byte[readCount];
            Debug.Log(readCount + "KB");
            //将此消息复制到临时存储数组
            Buffer.BlockCopy(readBuff, 0, bytes, 0, readCount);

            cache.AddRange(bytes);
            onReceive();

            //因为这里是异步回调，所以要防止多个回调同时操作cache
            if (!isRead)
            {
                isRead = true;
                OnData();
            }
        }
        catch (Exception e)
        {
            Debug.Log("服务器主动断开连接" + e.Message);
            onClose();
            return;
        }

        if(socket.Connected)
            socket.BeginReceive(readBuff,0,readBuffSize,SocketFlags.None,ReceiveCallBack,readBuff);
    }

    private void onClose()
    {
        //TODO 套接字关闭处理逻辑
        socket.Close();
    }
    /// <summary>
    /// 对缓存的数据进行解码，并尾递归
    /// </summary>
    private void OnData()
    {
        byte[] result = lengthDecode(ref cache);

        if (result == null)
        {
            isRead = false;
            return;
        }

        SocketModel model = modelDecode(result);
        //将收到的消息放到队列中
        receivedMessages.Enqueue(model);
        onRead();

        //尾递归
        OnData();
    }

    private void onRead()
    {
    }

    private void onReceive()
    {
    }

    /// <summary>
    /// 长度解码
    /// </summary>
    /// <param name="cache">缓冲区</param>
    /// <returns>经过长度解码得到的字节消息体</returns>
    private byte[] lengthDecode(ref List<byte> cache)
    {
        if (cache.Count < 4)
        {
            return null;
        }
        //用cache转数组，用数组创建内存流对象
        MemoryStream ms = new MemoryStream(cache.ToArray());
        //用二进制读取器读取这个流对象
        BinaryReader br = new BinaryReader(ms);
        //读出定义在头部的长度
        int length = br.ReadInt32();
        if (length > ms.Length - ms.Position)
        {
            return null;
        }
        
        //执行到这里，说明消息体完全了,将其放入结果
        byte[] result = br.ReadBytes(length);
        //接下来将cache中剩余的数据放回cache
        cache.Clear();
        cache.AddRange(br.ReadBytes((int)(ms.Length - ms.Position)));
        br.Close();
        ms.Close();

        return result;
    }

    /// <summary>
    /// 传输模型的解码
    /// </summary>
    /// <param name="data">字节数据</param>
    /// <returns>模型数据</returns>
    private SocketModel modelDecode(byte[] data)
    {
        ByteArray ba = new ByteArray(data);
        int type;
        int area;
        int command;
        ba.read(out type);
        ba.read(out area);
        ba.read(out command);

        SocketModel sm = new SocketModel();
        sm.type = type;
        sm.area = area;
        sm.command = command;
        //如果剩下还有数据，将剩下的数据读到一个数组，并对此数组解码成object
        if (ba.Readnable)
        {
            byte[] message;
            ba.read(out message, ba.Length - ba.Position);
            sm.message = SerializeUtil.decoder(message);
        }

        return sm;
    }

    /// <summary>
    /// 从接收到的消息队列中取出一个消息
    /// </summary>
    /// <returns></returns>
    public SocketModel getOneMessage()
    {
        if (receivedMessages.Count > 0)
        {
            return receivedMessages.Dequeue();
        }
        else
        {
            return null;
        }
    }
}

