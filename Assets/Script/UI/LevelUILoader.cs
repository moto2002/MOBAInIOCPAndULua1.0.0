using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LevelUILoader: MonoBehaviour
{
    void OnLevelWasLoaded()
    {
        LuaScriptMgr.Instance.CallLuaFunction("loadLevelUI", Application.loadedLevelName);
    }
}
