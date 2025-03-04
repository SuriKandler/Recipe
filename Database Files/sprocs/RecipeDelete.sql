create or alter procedure dbo.RecipeDelete(
	@RecipeId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0

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

       return @return
end
go

/*
select * from Recipe

exec RecipeDelete @recipeid = 2
*/