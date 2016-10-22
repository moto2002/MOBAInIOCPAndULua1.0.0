select_grid = newclass(base_model)

function select_grid:init(headImg, txt_name, image)
	self.headImg = headImg
	self.txt_name = txt_name
	self.img = image
end

--设置select grid的数据
function select_grid:setData(selectModel)
	self.txt_name.text = selectModel.name
	if selectModel.entered and selectModel.heroId ~= -1 then
		print("assets/dynamicresources/heroicon/"..selectModel.heroId..".png")
		self.headImg.sprite = resource_loader.GetSprite("assets/dynamicresources/heroicon/"..selectModel.heroId..".png")
	else
		self.headImg.sprite = resource_loader.GetSprite("assets/dynamicresources/heroicon/nil.png")
	end

	if selectModel.ready then
		self:selected()
	else
		self:unselected()
	end
end
--选择
function select_grid:selected()
	--self.img.color = Color.New(1, 0, 0, 1)
end
--不选择
function select_grid:unselected()
	--self.img.color = Color.New(1, 1, 1, 1)
end