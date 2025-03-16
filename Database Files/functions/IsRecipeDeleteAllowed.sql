create or alter function dbo.IsRecipeDeleteAllowed(@RecipeId int)
returns varchar(60)
as
begin
	declare @value varchar(60) = ''
	if exists(select * from Recipe r where r.RecipeStatus = 'Published'and r.RecipeId = @RecipeId)
	begin
		select @value = 'Cannot delete published recipes'
	end
	return @value
end 
go
