create or alter procedure dbo.RecipeList(
    @Message varchar (1000) = '' output
)
as
begin
    declare @return int = 0

	select 
	r.RecipeId, r.RecipeName, r.RecipeStatus,  UserName = concat(u.FirstName, ' ', u.Lastname), r.Calories, NumIngredients = count(i.IngredientId)	
	from Recipe r
    join users u
    on r.userid = u.userid
    left join RecipeIngredient ri
    on ri.RecipeId = r.RecipeId
    left join Ingredient i
    on i.IngredientId = ri.IngredientId    
	group by r.RecipeId, r.RecipeName, r.RecipeStatus, u.FirstName,u.Lastname,r.Calories
	order by r.RecipeStatus desc

return @return
end
/*

exec RecipeList

exec RecipeList @RecipeName = '' --no results

exec RecipeList @RecipeName = 'i' 

exec RecipeList @All = 1

declare @RecipeId int
select top 1 @RecipeId = r.RecipeId from Recipe r
exec RecipeList @RecipeId = @RecipeId

*/