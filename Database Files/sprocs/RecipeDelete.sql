create or alter procedure dbo.RecipeDelete(
	@RecipeId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
	declare @deleteallowed varchar(60) = ''

	select @deleteallowed= isnull(dbo.IsRecipeDeleteAllowed(@RecipeId),'')

	if @deleteallowed <> ''
	begin
		select @return = 1, @Message = @deleteallowed
		goto finished
	end

	begin try
		begin tran
		delete CookBookRecipe where RecipeId = @RecipeId
		delete MealCourseRecipe where RecipeId = @RecipeId
        delete RecipeDirection where RecipeId = @RecipeId
		delete RecipeIngredient where RecipeId = @RecipeId
		delete Recipe where RecipeId = @RecipeId
		commit
	end try
	begin catch
		rollback;
		throw
	end catch

	finished:
	return @return
	
end
go

/*
select * from Recipe

exec RecipeDelete @recipeid = 29
*/