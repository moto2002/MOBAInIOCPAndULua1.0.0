using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneByOne;
using UnityEngine;

public class StateMachine
{
    /// <summary>
    /// 状态机控制的游戏单位transform
    /// </summary>
    protected Transform gameTransfrom;
    /// <summary>
    /// 用于存储当前状态机的字典
    /// </summary>
    private Dictionary<int, IState> m_stateMap = new Dictionary<int, IState>();
    /// <summary>
    /// 当前的状态
    /// </summary>
    private IState curState = null;
    /// <summary>
    /// 返回当前状态
    /// </summary>
    public IState CurState
    {
        get { return curState; }
    }

    public int CurStateID
    {
        get { return curState == null ? -1 : curState.GetStateID(); }
    }

    public Transform GameTransfrom
    {
        get
        {
            return gameTransfrom;
        }
    }

    protected StateMachine(Transform goTransform)
    {
        this.gameTransfrom = goTransform;
    }
    /// <summary>
    /// 注册一个状态
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    public bool RegisterState(IState state)
    {
        if (state == null)
        {
            
            Debug.LogWarning("状态机注册状态时传入的状态为空");
            return false;
        }
        if (m_stateMap.ContainsKey(state.GetStateID()))
        {
            Debug.LogWarning("状态机中已经有这个状态，注册失败，状态ID:" + state.GetStateID());
            return false;
        }
        m_stateMap.Add(state.GetStateID(), state);
        return true;
    }
    /// <summary>
    /// 移除一个状态
    /// </summary>
    /// <param name="stateId">状态Id</param>
    /// <returns>当状态不存在或者状态正在运行那么返回失败</returns>
    public bool RemoveState(int stateId)
    {
        if (!m_stateMap.ContainsKey(stateId))
        {
            return false;
        }
        if (curState != null && curState.GetStateID() == stateId)
        {
            return false;
        }
        m_stateMap.Remove(stateId);
        return true;
    }
    /// <summary>
    /// 根据Id得到一个状态
    /// </summary>
    /// <param name="stateId">状态Id</param>
    /// <returns></returns>
    public IState GetState(int stateId)
    {
        IState state = null;
        m_stateMap.TryGetValue(stateId, out state);
        return state;
    }
    /// <summary>
    /// 停止一个状态
    /// </summary>
    /// <param name="param1"></param>
    /// <param name="param2"></param>
    public void StopState(object param1, object param2)
    {
        if (curState == null)
        {
            return;
        }
        curState.OnLeave(null, param1, param2);
        curState = null;
    }
    /// <summary>
    /// 状态间切换的委托
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="param1"></param>
    /// <param name="param2"></param>
    public delegate void BetweenStateSwitch(IState from, IState to, object param1, object param2);
    /// <summary>
    /// 中间功能可注册在这里
    /// </summary>
    public BetweenStateSwitch m_funcBetweenStateSwitch;
    /// <summary>
    /// 状态切换
    /// </summary>
    /// <param name="newStateId">新状态Id</param>
    /// <param name="param1"></param>
    /// <param name="param2"></param>
    /// <returns></returns>
    public bool SwitchState(int newStateId, object param1, object param2)
    {
        if (curState != null && curState.GetStateID() == newStateId)
        {
            return false;
        }
        IState newState = null;
        m_stateMap.TryGetValue(newStateId, out newState);
        if (newState == null)
        {
            return false;
        }
        if (curState != null)
        {
            curState.OnLeave(newState, param1, param2);
        }
        IState oldState = curState;
        curState = newState;
        if (m_funcBetweenStateSwitch != null)
        {
            m_funcBetweenStateSwitch(oldState, newState, param1, param2);
        }
        newState.OnEnter(this, oldState, param1, param2);
        return true;
    }
    /// <summary>
    /// 判断状态机是否在stateId代表的状态
    /// </summary>
    /// <param name="stateId">状态Id</param>
    /// <returns></returns>
    public bool IsInState(int stateId)
    {
        return curState == null ? false : curState.GetStateID() == stateId;
    }

    public void OnUpdate()
    {
        curState.OnUpdate();
    }

    public void OnLateUpdate()
    {
        curState.OnLateUpdate();
    }

    public void OnFixedUpdate()
    {
        curState.OnFixedUpdate();
    }
}
