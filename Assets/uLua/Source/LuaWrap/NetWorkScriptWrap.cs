using System;
using System.Collections.Generic;
using LuaInterface;

public class NetWorkScriptWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Connect", Connect),
			new LuaMethod("ConnectTest", ConnectTest),
			new LuaMethod("BeginReceive", BeginReceive),
			new LuaMethod("write", write),
			new LuaMethod("writeIntMessage", writeIntMessage),
			new LuaMethod("New", _CreateNetWorkScript),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("messageList", get_messageList, set_messageList),
			new LuaField("Instance", get_Instance, null),
		};

		LuaScriptMgr.RegisterLib(L, "NetWorkScript", typeof(NetWorkScript), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateNetWorkScript(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			NetWorkScript obj = new NetWorkScript();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: NetWorkScript.New");
		}

		return 0;
	}

	static Type classType = typeof(NetWorkScript);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_messageList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		NetWorkScript obj = (NetWorkScript)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name messageList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index messageList on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.messageList);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, NetWorkScript.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_messageList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		NetWorkScript obj = (NetWorkScript)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name messageList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index messageList on a nil value");
			}
		}

		obj.messageList = (List<SocketModel>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<SocketModel>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Connect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		NetWorkScript obj = (NetWorkScript)LuaScriptMgr.GetNetObjectSelf(L, 1, "NetWorkScript");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		bool o = obj.Connect(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ConnectTest(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		NetWorkScript obj = (NetWorkScript)LuaScriptMgr.GetNetObjectSelf(L, 1, "NetWorkScript");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		bool o = obj.ConnectTest(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BeginReceive(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		NetWorkScript obj = (NetWorkScript)LuaScriptMgr.GetNetObjectSelf(L, 1, "NetWorkScript");
		obj.BeginReceive();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int write(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		NetWorkScript obj = (NetWorkScript)LuaScriptMgr.GetNetObjectSelf(L, 1, "NetWorkScript");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		object arg3 = LuaScriptMgr.GetVarObject(L, 5);
		obj.write(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int writeIntMessage(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		NetWorkScript obj = (NetWorkScript)LuaScriptMgr.GetNetObjectSelf(L, 1, "NetWorkScript");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		object arg3 = LuaScriptMgr.GetVarObject(L, 5);
		obj.writeIntMessage(arg0,arg1,arg2,arg3);
		return 0;
	}
}

