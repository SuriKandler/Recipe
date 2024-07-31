create or alter procedure dbo.RecipeGet(
	@RecipeId int = 0, 
	@All bit = 0, 
	@RecipeName varchar(100) = '')
as
begin

	select @RecipeName = nullif(@RecipeName,'')

	select 
	RecipeDesc = dbo.RecipeDesc(r.RecipeId),
	r.RecipeId, r.RecipeName, r.UserId, r.CuisineId, r.RecipeStatus, r.Calories, r.DateDraft, r.DatePublished, r.DateArchived		
	from Recipe r
	where r.RecipeId = @RecipeId
	or @All = 1
	or r.RecipeName like '%' + @RecipeName + '%'
	order by r.RecipeName, r.RecipeStatus
end
go


/*
exec RecipeGet

exec RecipeGet @RecipeName = '' --no results

exec RecipeGet @RecipeName = 'i' 

exec RecipeGet @All = 1

declare @RecipeId int
select top 1 @RecipeId = r.RecipeId from Recipe r
exec RecipeGet @RecipeId = @RecipeId

*/