using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class ErrorManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("AddError", AddError),
			new LuaMethod("AddNoLuaError", AddNoLuaError),
			new LuaMethod("CurrentErrorHandled", CurrentErrorHandled),
			new LuaMethod("ShowErrorPanel", ShowErrorPanel),
			new LuaMethod("HideErrorPanel", HideErrorPanel),
			new LuaMethod("SetErrorPanelText", SetErrorPanelText),
			new LuaMethod("SetErrorPanel", SetErrorPanel),
			new LuaMethod("SetEnsureBtnFunction", SetEnsureBtnFunction),
			new LuaMethod("New", _CreateErrorManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
		};

		LuaScriptMgr.RegisterLib(L, "ErrorManager", typeof(ErrorManager), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateErrorManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "ErrorManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(ErrorManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, ErrorManager.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddError(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ErrorManager obj = (ErrorManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ErrorManager");
		ErrorModel arg0 = (ErrorModel)LuaScriptMgr.GetNetObject(L, 2, typeof(ErrorModel));
		obj.AddError(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddNoLuaError(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ErrorManager obj = (ErrorManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ErrorManager");
		NoLuaErroModel arg0 = (NoLuaErroModel)LuaScriptMgr.GetNetObject(L, 2, typeof(NoLuaErroModel));
		obj.AddNoLuaError(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CurrentErrorHandled(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ErrorManager obj = (ErrorManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ErrorManager");
		obj.CurrentErrorHandled();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ShowErrorPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ErrorManager obj = (ErrorManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ErrorManager");
		obj.ShowErrorPanel();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HideErrorPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ErrorManager obj = (ErrorManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ErrorManager");
		obj.HideErrorPanel();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetErrorPanelText(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ErrorManager obj = (ErrorManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ErrorManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.SetErrorPanelText(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetErrorPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ErrorManager obj = (ErrorManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ErrorManager");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		obj.SetErrorPanel(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetEnsureBtnFunction(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ErrorManager obj = (ErrorManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ErrorManager");
		Action<object[]> arg0 = null;
		LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

		if (funcType2 != LuaTypes.LUA_TFUNCTION)
		{
			 arg0 = (Action<object[]>)LuaScriptMgr.GetNetObject(L, 2, typeof(Action<object[]>));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
			arg0 = (param0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.PushArray(L, param0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}

		object[] objs1 = LuaScriptMgr.GetArrayObject<object>(L, 3);
		obj.SetEnsureBtnFunction(arg0,objs1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

