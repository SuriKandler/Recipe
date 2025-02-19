create or alter procedure dbo.RecipeDirectionGet(
	@DirectionId int = 0,
	@RecipeId int = 0,
	@All bit = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @All = isnull(@All,0), @DirectionId = isnull(@DirectionId,0), @RecipeId = isnull(@RecipeId,0)

	select rd.DirectionId, rd.RecipeId,rd.DirectionDescription, rd.DirectionSequence
	from RecipeDirection rd
	where DirectionId = @DirectionId
	or rd.RecipeId = @RecipeId
	or @All = 1

	return @return
end
go
/*
exec RecipeDirectionGet @all = 1

exec RecipeDirectionGet @recipeid = 6
*/
--select * from recipeDirection