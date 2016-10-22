hero_grid = newclass(base_model)

function hero_grid_clicked(id)
	if id ~= -1 then
		selectHero(id)
	end
end

function hero_grid:active()
	self.selectGrid:SetActive(true)
end

function hero_grid:deactive()
	self.selectGrid:SetActive(false)
end

function hero_grid:init(grid, id, sprite)
	self.selectGrid = grid
	self.id = id
	self.championIcon = findChild(self.selectGrid, "ChampionGrid")
	self.sp = ui_get_image(self.championIcon)
	self.sp.sprite = sprite
	ui_set_click(self.championIcon, hero_grid_clicked, self.id)
end