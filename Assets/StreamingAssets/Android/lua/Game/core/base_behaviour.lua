--lua行为基类
base_behaviour = newclass();

function base_behaviour:init(gameObject, insID, cacheObjs, cachePrefabs)
	self.gameObject = gameObject
	self.transform = gameObject.transform
	self.name = gameObject.name
	print(self.name)
	self.insID = insID
	self.cachePrefabs = cachePrefabs
	self.cacheObjs = cacheObjs
	self.cacheComponents = {}
	GetAllComponents(self, cacheObjs)
end

function base_behaviour:awake()
end

function base_behaviour:onEnable()
end

function base_behaviour:start()
end

function base_behaviour:onDisable()
end

function base_behaviour:getInsID()
	return self.insID
end

function base_behaviour:getName()
	return self.name
end

function base_behaviour:onDestroy()
end