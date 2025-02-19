create or alter procedure dbo.CookbookRecipeUpdate(
	@CookbookRecipeId int  output,
    @CookbookId int ,
	@RecipeId int ,
	@CookbookRecipeSequence int,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @CookbookRecipeId = isnull(@CookbookRecipeId,0)

	if @CookbookRecipeId = 0
	begin
		insert CookbookRecipe(CookbookId, RecipeId, CookbookRecipeSequence)
		values(@CookbookId, @RecipeId, @CookbookRecipeSequence)

		select @CookbookRecipeId = scope_identity()
	end
	else
	begin
		update CookBookRecipe
		set
            CookbookId = @CookbookId,
			RecipeId = @RecipeId,
            CookbookRecipeSequence = @CookbookRecipeSequence
		where CookbookRecipeId = @CookbookRecipeId
	end

	return @return
end
go

--select * from CookbookRecipe

