
exec RecipeGet

exec RecipeGet @RecipeName = '' --no results

exec RecipeGet @RecipeName = 'i' 

exec RecipeGet @All = 1

declare @RecipeId int
select top 1 @RecipeId = r.RecipeId from Recipe r
exec RecipeGet @RecipeId = @RecipeId