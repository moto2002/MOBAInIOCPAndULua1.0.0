using System.Collections;
using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NetWorkScript {


    private byte[] readBuff = new byte[1024];
    private bool isRead = false;
    public List<SocketModel> messageList = new List<SocketModel>();
    private Socket socket;

    private List<byte> cache = new List<byte>();

    #region 单例Instance

    private static NetWorkScript _instance;
    private static object syncObj = new object();

    public static NetWorkScript Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    if (_instance == null)
                    {
                        _instance = new NetWorkScript();
                    }
                }
            }
            return _instance;
        }
    }

    #endregion

    public NetWorkScript()
    {
    }

    public bool Connect(string ip, int port)
    {
        try
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, port);
            Debug.Log("连接服务器成功");
            return true;
        }
        catch (Exception e)
        {
            Debug.Log("连接服务器失败" + e.Message);
            return false;
        }
    }

    public bool ConnectTest(string ip, int port)
    {
        try
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, port);
            Debug.Log("连接服务器成功");
            socket.Shutdown(SocketShutdown.Both);
            socket.Disconnect(false);
            return true;
        }
        catch (Exception e)
        {
            Debug.Log("连接服务器失败" + e.Message);
            return false;
        }
    }

    public void BeginReceive()
    {
        socket.BeginReceive(readBuff, 0, 1024, SocketFlags.None, ReceiveCallBack, readBuff);
    }

    public void write(int type,int area,int command,object message) {
        ByteArray arr = new ByteArray();
        arr.write(type);
        arr.write(area);
        arr.write(command);
        if (message != null) { 
        byte[] bs = SerializeUtil.encode(message);
        arr.write(bs);}
        ByteArray arr1 = new ByteArray();
        arr1.write(arr.Length);
        arr1.write(arr.getBuff());
        try
        {
            socket.Send(arr1.getBuff());
        }
        catch (Exception e) {
            Debug.Log("网络错误，请重新登录"+e.Message);
        }
    }

    public void writeIntMessage(int type, int area, int command, object message)
    {
        Debug.Log(message);
        int intMessage = Convert.ToInt32(message);
        write(type, area, command, intMessage);
    }

    private void ReceiveCallBack(IAsyncResult ar) {
        try
        {
            //结束异步消息读取 并获取消息长度
            int readCount = socket.EndReceive(ar);
            if (readCount > 0)
            {
                Debug.Log(readCount);
                byte[] bytes = new byte[readCount];
                //将接收缓冲池的内容复制到临时消息存储数组
                Buffer.BlockCopy(readBuff, 0, bytes, 0, readCount);
                cache.AddRange(bytes);

                if (!isRead)
                {
                    isRead = true;
                    onData();
                }
            }
        }
        catch (Exception e) {
            Debug.Log("远程服务器主动断开连接"+e.Message);
            socket.Close();
            return;
        }

        socket.BeginReceive(readBuff, 0, 1024, SocketFlags.None, ReceiveCallBack, readBuff);
    }

    private void onData() {
        //消息体长度为一个4字节数值 长度不足的时候 说明消息未接收完成 或者是废弃消息
        if (cache.Count < 4)
        {
            isRead = false;
            return;
        }

        byte[] result = GameSocketModelUtil.ldecode(ref cache);

        if (result == null)
        {
            isRead = false;
            return;
        }
            //转换为传输模型用于使用
            SocketModel model = GameSocketModelUtil.mDecode(result);
            //将消息存储进消息列表 等待Unity来读取
            messageList.Add(model);
        
        onData();
    }
}
