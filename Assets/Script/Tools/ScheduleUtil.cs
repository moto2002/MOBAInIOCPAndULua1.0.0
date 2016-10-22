//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// NameSpace : Assets.Script.Tools
// FileName : ScheduleUtil
//
// Created by : maxiao (398117200@qq.com) at 2016/6/24 13:29:39
//
// Function : 
//
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;


public class ScheduleUtil
{
    private Dictionary<int, TaskModel> mission = new Dictionary<int, TaskModel>();
    /// <summary>
    /// 唯一的计时器
    /// </summary>
    private Timer timer;
    /// <summary>
    /// 自增任务ID
    /// </summary>
    private AutomicInt mId = new AutomicInt();
    /// <summary>
    /// 任务移除列表
    /// </summary>
    private List<int> removeList = new List<int>();
    #region 单例Instance

    private static ScheduleUtil _instance;
    private static object syncObj = new object();

    public static ScheduleUtil Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncObj)
                {
                    if (_instance == null)
                    {
                        _instance = new ScheduleUtil();
                    }
                }
            }
            return _instance;
        }
    }

    #endregion

    private ScheduleUtil()
    {
        timer = new Timer(200);
        timer.Elapsed += loopTask;
        timer.Start();
    }
    /// <summary>
    /// 主循环，检查任务列表，如超过时限，则执行
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void loopTask(object sender, ElapsedEventArgs e)
    {
        lock (mission)
        {
            lock (removeList)
            {
                foreach (int l in removeList)
                {
                    mission.Remove(l);
                }
                removeList.Clear();
                foreach (TaskModel model in mission.Values)
                {
                    if (model.Runtime <= DateTime.Now.Ticks)
                    {
                        model.Run();
                        removeList.Add(model.Id);
                    }
                }
            }
        }
    }



    /// <summary>
    /// 添加一个定时执行的任务
    /// </summary>
    /// <param name="task"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public int AddScheduledTask(Action task, DateTime time)
    {
        long t = time.Ticks - DateTime.Now.Ticks;
        t = Math.Abs(t);

        return scheduleMMS(task, t);
    }


    /// <summary>
    /// 添加一个任务，返回ID，以秒为延迟时间单位
    /// </summary>
    /// <param name="task"></param>
    /// <param name="delay"></param>
    /// <returns></returns>
    public int AddScheduledTask(Action task, long delay)
    {
        return scheduleMMS(task, delay * 1000 * 1000);
    }
    /// <summary>
    /// 添加一个任务，并返回ID,以微秒为延迟时间单位
    /// </summary>
    /// <param name="task"></param>
    /// <param name="delay"></param>
    /// <returns></returns>
    private int scheduleMMS(Action task, long delay)
    {
        lock (mission)
        {
            int id = mId.GetIncrease();
            TaskModel model = new TaskModel(id,task,DateTime.Now.Ticks +delay);
            mission.Add(id, model);
            return id;
        }
    }
    /// <summary>
    /// 将要移除的任务ID放入移除列表，在主循环中，它将被移除
    /// </summary>
    /// <param name="id"></param>
    public void RemoveTask(int id)
    {
        lock (removeList)
        {
            removeList.Add(id);
        }
    }
}

