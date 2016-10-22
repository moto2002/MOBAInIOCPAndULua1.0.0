using System;
using UnityEngine.UI;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class SkillButtonWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("ColdDown", ColdDown),
			new LuaMethod("SetBtnSprite", SetBtnSprite),
			new LuaMethod("SetSkill", SetSkill),
			new LuaMethod("ForbidSkillBtn", ForbidSkillBtn),
			new LuaMethod("ActiveSkillBtn", ActiveSkillBtn),
			new LuaMethod("New", _CreateSkillButton),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("skillImg", get_skillImg, set_skillImg),
			new LuaField("cdMask", get_cdMask, set_cdMask),
			new LuaField("cdText", get_cdText, set_cdText),
			new LuaField("skillBtn", get_skillBtn, set_skillBtn),
			new LuaField("skillLevelUpBtn", get_skillLevelUpBtn, set_skillLevelUpBtn),
			new LuaField("goSkillLevelUp", get_goSkillLevelUp, set_goSkillLevelUp),
			new LuaField("illution", get_illution, set_illution),
			new LuaField("CdSecondCount", get_CdSecondCount, set_CdSecondCount),
		};

		LuaScriptMgr.RegisterLib(L, "SkillButton", typeof(SkillButton), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSkillButton(IntPtr L)
	{
		LuaDLL.luaL_error(L, "SkillButton class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(SkillButton);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillImg(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillImg");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillImg on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.skillImg);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cdMask(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cdMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cdMask on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.cdMask);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cdText(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cdText");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cdText on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.cdText);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillBtn(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillBtn");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillBtn on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.skillBtn);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillLevelUpBtn(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillLevelUpBtn");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillLevelUpBtn on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.skillLevelUpBtn);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_goSkillLevelUp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name goSkillLevelUp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index goSkillLevelUp on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.goSkillLevelUp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_illution(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name illution");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index illution on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.illution);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CdSecondCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name CdSecondCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index CdSecondCount on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.CdSecondCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillImg(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillImg");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillImg on a nil value");
			}
		}

		obj.skillImg = (Image)LuaScriptMgr.GetUnityObject(L, 3, typeof(Image));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cdMask(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cdMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cdMask on a nil value");
			}
		}

		obj.cdMask = (Image)LuaScriptMgr.GetUnityObject(L, 3, typeof(Image));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cdText(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cdText");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cdText on a nil value");
			}
		}

		obj.cdText = (Text)LuaScriptMgr.GetUnityObject(L, 3, typeof(Text));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillBtn(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillBtn");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillBtn on a nil value");
			}
		}

		obj.skillBtn = (Button)LuaScriptMgr.GetUnityObject(L, 3, typeof(Button));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillLevelUpBtn(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillLevelUpBtn");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillLevelUpBtn on a nil value");
			}
		}

		obj.skillLevelUpBtn = (Button)LuaScriptMgr.GetUnityObject(L, 3, typeof(Button));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_goSkillLevelUp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name goSkillLevelUp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index goSkillLevelUp on a nil value");
			}
		}

		obj.goSkillLevelUp = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_illution(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name illution");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index illution on a nil value");
			}
		}

		obj.illution = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CdSecondCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SkillButton obj = (SkillButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name CdSecondCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index CdSecondCount on a nil value");
			}
		}

		obj.CdSecondCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ColdDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SkillButton obj = (SkillButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SkillButton");
		obj.ColdDown();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetBtnSprite(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SkillButton obj = (SkillButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SkillButton");
		Sprite arg0 = (Sprite)LuaScriptMgr.GetUnityObject(L, 2, typeof(Sprite));
		obj.SetBtnSprite(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetSkill(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SkillButton obj = (SkillButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SkillButton");
		OneByOne.FightSkill arg0 = (OneByOne.FightSkill)LuaScriptMgr.GetNetObject(L, 2, typeof(OneByOne.FightSkill));
		obj.SetSkill(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ForbidSkillBtn(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SkillButton obj = (SkillButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SkillButton");
		obj.ForbidSkillBtn();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ActiveSkillBtn(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SkillButton obj = (SkillButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SkillButton");
		obj.ActiveSkillBtn();
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

