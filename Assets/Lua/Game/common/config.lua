--配置表管理器
config_list = {}

--读取config_map,找到对应的CSV表和解析方法，解析后放入缓存配置表
function config_analysis(tableName)
	require("Game/configs/"..tableName.."_csv")
	local cfg = CSV_TABLES[tableName]
	if cfg ~= nil then
		cfg = cfg_data_by_name(cfg)
	else
		error("配置表为nil，配置表名为："..tableName)
	end
	config_list[tableName] = cfg

	return cfg
end

--ui表的解析方法
function cfg_data_by_name(cfg)
	local cfgs = {}
	for k,v in pairs(cfg) do
		print("#######get ui element form CSV:"..v.name)
		cfgs[v.name] = v
	end
	return cfgs
end
--得到一个配置表
function get_cfg(tableName)
	local cfg = config_list[tableName]
	if cfg == nil then
		cfg = config_analysis(tableName)
	end
	return cfg
end

function get_ui_cfg(sceneName)
	local ui_name = get_ui_name_by_scene_name(sceneName)
	local cfg = config_list[ui_name]
	if cfg == nil then
		cfg = config_analysis(ui_name)
	end
	return cfg
end

function  get_ui_name_by_scene_name(sceneName)
	require("Game/configs/UIcatalog_csv")
	local ui_name = CSV_TABLES["UIcatalog"][sceneName]["name"]

	return ui_name
end