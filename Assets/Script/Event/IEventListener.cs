using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public interface IEventListener
{
    /// <summary>
    /// 得到监听器的优先级
    /// </summary>
    /// <returns></returns>
    int HandlePriority();

    /// <summary>
    /// 处理消息
    /// </summary>
    /// <param name="id">消息ID</param>
    /// <param name="args">传入的参数</param>
    /// <returns>是否停止派发</returns>
    bool HandleEvent(int id, params object[] args);
}

