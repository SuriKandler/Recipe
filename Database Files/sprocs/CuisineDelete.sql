create or alter procedure dbo.CuisineDelete(
	@CuisineId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
	select @CuisineId = isnull(@CuisineId,0)

	begin try
		begin tran
	delete cr from CookBookRecipe cr join Recipe r on cr.RecipeId = r.RecipeId where r.CuisineId = @CuisineId
	delete mcr from MealCourseRecipe mcr join Recipe r on mcr.RecipeId = r.RecipeId where r.CuisineId = @CuisineId
	delete rd from RecipeDirection rd left join Recipe r on rd.RecipeId = r.RecipeId where r.CuisineId = @CuisineId
	delete ri from RecipeIngredient ri left join Recipe r on ri.RecipeId = r.RecipeId where r.CuisineId = @CuisineId
	delete r from recipe r where r.CuisineId = @CuisineId
	delete c from Cuisine c where c.CuisineId = @CuisineId
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

select * from Recipedirection ri left join Recipe r on ri.RecipeId = r.RecipeId
--exec dbo.CuisineDelete @cuisineid = 3
*/