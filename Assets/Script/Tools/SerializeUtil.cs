using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

/// <summary>
/// 字节数组编码解码工具
/// </summary>
public class SerializeUtil
{
    /// <summary>
    /// 将一个object编码成一个字节数组
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static byte[] encode(object value)
    {
        MemoryStream ms = new MemoryStream();
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(ms, value);
        byte[] result = new byte[ms.Length];
        Buffer.BlockCopy(ms.GetBuffer(), 0, result, 0, (int)ms.Length);
        return result;
    }

    /// <summary>
    /// 将字节数组还原成一个object
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static object decoder(byte[] value)
    {
        MemoryStream ms = new MemoryStream(value);
        BinaryFormatter bf = new BinaryFormatter();
        return bf.Deserialize(ms);
    }



}
