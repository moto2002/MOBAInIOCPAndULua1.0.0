using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LuaInterface;
/// <summary>
/// 界面提示类，包含提示信息和回调方法
/// </summary>
public class ErrorModel:IError
{
    public string text;
    /// <summary>
    /// 这个方法在玩家确认之后调用
    /// </summary>
    public LuaFunction function;

    public ErrorModel(string s, LuaFunction e)
    {
        text = s;
        function = e;
    }

    public ErrorModel(string s)
    {
        text = s;
    }


    public void CallFunction()
    {
        ErrorManager.Instance.ShowErrorPanel();
        LuaScriptMgr.Instance.CallLuaFunction("errorTrigger", text, function);
    }
}

