--lua中对应unity的behaviours,由于是全局的，因此哪里都可以使用
UNITY_LUA_BEHAVIOUR = {
	Awake = "awake",
	OnEnable = "onEnable",
	Start = "start",
	OnDisable = "onDisable",
	OnDestroy = "onDestroy",
}

UI_LOCATION_INDEX = {
	TopLeft = 1,
	TopCenter = 2,
	TopRight = 3,
	MiddleLeft = 4,
	MiddleCenter = 5,
	MiddleRight = 6,
	BottomLeft = 7,
	BottomCenter = 8,
	BottomRight = 9,
}

CtrlName = {
	Prompt = "PromptCtrl",
	Message = "MessageCtrl"
}

--协议类型--
ProtocalType = {
	BINARY = 0,
	PB_LUA = 1,
	PBC = 2,
	SPROTO = 3,
}
--当前使用的协议类型--
TestProtoType = ProtocalType.BINARY;

Util = Util;
AppConst = AppConst;

AccountDTO = OneByOne.AccountDTO
Protocol = OneByOne.Protocol
UserProtocol = OneByOne.UserProtocol
UserDTO = OneByOne.UserDTO
SelectProtocol = OneByOne.SelectProtocol
SelectModel = OneByOne.SelectModel
LoginProtocol = OneByOne.LoginProtocol
MatchProtocol = OneByOne.MatchProtocol
MoveDTO = OneByOne.MoveDTO
FightSkill = OneByOne.FightSkill
DamageDTO = OneByOne.DamageDTO
FightProtocol = OneByOne.FightProtocol
FightPlayerModel = OneByOne.FightPlayerModel
SelectRoomDTO = OneByOne.SelectRoomDTO
FightSoldierModel = OneByOne.FightSoldierModel
FightRoomModel = OneByOne.FightRoomModel
AttackDTO = OneByOne.AttackDTO
FightBuildModel = OneByOne.FightBuildModel
SceneManager = UnityEngine.SceneManagement.SceneManager
SkillTarget = Constans.SkillTarget
SkillType = Constans.SkillType