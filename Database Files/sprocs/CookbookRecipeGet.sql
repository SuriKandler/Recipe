create or alter procedure dbo.CookbookRecipeGet(
	@CookbookRecipeId int = 0,
	@CookbookId int = 0,
	@All bit = 0,
	@UserId int = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @All = isnull(@All,0), @CookbookRecipeId = isnull(@CookbookRecipeId,0), @CookbookId = isnull(@CookbookId,0)

	select cr.CookBookRecipeId, cr.CookbookId, cr.RecipeId, cr.CookbookRecipeSequence
    from CookbookRecipe cr
	join Recipe r
	on r.RecipeId = cr.RecipeId
	join users u
	on r.UserId = u.UserId
	where cr.CookbookRecipeId = @CookbookRecipeId
	or @All = 1
    or cr.CookbookId = @CookbookId
	or @UserId = r.UserId
	order by cr.CookbookRecipeSequence
	

	return @return
end
go

--select * from CookbookRecipe
--exec CookbookRecipeGet @all = 1
--exec CookbookRecipeGet @cookbookid = 1