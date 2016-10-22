using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneByOne;


public interface IState
{
    /// <summary>
    /// 得到该state的ID
    /// </summary>
    /// <returns></returns>
    int GetStateID();
    /// <summary>
    /// 进入一个新状态
    /// </summary>
    /// <param name="fsm"></param>
    /// <param name="previousState">前一个状态</param>
    /// <param name="param1">参数1</param>
    /// <param name="param2">参数2</param>
    void OnEnter(StateMachine fsm, IState previousState, object param1, object param2);
    /// <summary>
    /// 离开当前状态
    /// </summary>
    /// <param name="nextState">下一个状态</param>
    /// <param name="param1">参数1</param>
    /// <param name="param2">参数2</param>
    void OnLeave(IState nextState, object param1, object param2);

    void OnUpdate();
    void OnLateUpdate();
    void OnFixedUpdate();
}
