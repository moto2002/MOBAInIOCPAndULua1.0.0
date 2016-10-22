using UnityEngine;
using System.Collections;
using OneByOne;
using UnityEngine.SceneManagement;

public class SelectHandler : MonoBehaviour, IHandler
{
    private string ifUILoaded = string.Empty;
    public void MessageReceive(SocketModel model)
    {
        switch (model.command)
        {
            case SelectProtocol.ENTER_SRES:
                LuaScriptMgr.Instance.CallLuaFunction("selfEnter", model.getMessage<SelectRoomDTO>());
                break;
            case SelectProtocol.ENTER_BRO:
                ifUILoaded = LuaScriptMgr.Instance.CallLuaFunction("isSelectUILoaded")[0] as string;
                Debug.Log(ifUILoaded);
                if (ifUILoaded == "loaded")
                {
                    LuaScriptMgr.Instance.CallLuaFunction("otherEnter", model.getMessage<int>());
                }
                else
                {
                    NetWorkScript.Instance.messageList.Add(model);
                }
                break;
            case SelectProtocol.READY_BRO:
                LuaScriptMgr.Instance.CallLuaFunction("readyForGame", model.getMessage<SelectModel>());
                break;
            case SelectProtocol.ROOM_DESTORY_BRO:
                LuaScriptMgr.Instance.CallLuaFunction("backToMatch");
                break;
            case SelectProtocol.SELECT_SRES:
                LuaScriptMgr.Instance.CallLuaFunction("selectHeroFailure");
                break;
            case SelectProtocol.SELECT_BRO:
                LuaScriptMgr.Instance.CallLuaFunction("selectHeroRefresh", model.getMessage<SelectModel>());
                break;
            case SelectProtocol.START_FIGHT_BRO:
                LuaScriptMgr.Instance.CallLuaFunction("loadFightLevel");
                break;
        }
    }

}
