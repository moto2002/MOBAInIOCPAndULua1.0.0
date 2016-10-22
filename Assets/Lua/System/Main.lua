UpdateBeat = Event("Update", true)
LateUpdateBeat = Event("LateUpdate", true)
CoUpdateBeat = Event("CoUpdate", true)
FixedUpdateBeat = Event("FixedUpdate", true)

require "Common/define"
require "Common/functions"
require "Game/common/luaLoadCenter"
require "Game/common/config"
require "Game/common/singleton"
--入口函数，调用Game/common/controller中的controllerInit()
function Main()
	Time:Init()
	controllerInit()
end

function Update(deltatime, unscaledDeltaTime)
	Time:SetDeltaTime(deltatime, unscaledDeltaTime)
	UpdateBeat()
end

function LateUpdate()
	LateUpdateBeat()
	CoUpdateBeat()
end

function FixedUpdate(fixedTime)
	Time:SetFixedDelta(fixedTime)
	FixedUpdateBeat()
end

function OnLevelWasLoaded(level)
	Time.timeSinceLevelLoad = 0
end