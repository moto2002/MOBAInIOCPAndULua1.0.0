using UnityEngine;
using System.Collections;
using OneByOne;

public class LoginHandler : MonoBehaviour,IHandler {

    public void MessageReceive(SocketModel model)
    {
        switch (model.command) { 
            case LoginProtocol.CREATE_SRES:
                register(model.getMessage<int>());
                break;
            case LoginProtocol.LOGIN_SRES:
                login(model.getMessage<int>());
                break;
        }
    }

    void register(int result)
    {
        LuaScriptMgr.Instance.CallLuaFunction("registerByResult", result);
    }

    void login(int result)
    {
        LuaScriptMgr.Instance.CallLuaFunction("loginByResult", result);
    }
}
