create or alter procedure dbo.RecipeDelete(
	@RecipeId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0

	--bc i want the message to be different i made 2 seperate statements, is that ok, or is there a way, and is it necessary, to combine them?
		
	if exists(select * from Recipe r where r.RecipeId = @RecipeId and r.RecipeStatus = 'Published')-- or(r.RecipeStatus = 'Archived' and getdate() - r.DateArchived < 30) )
	begin
		select @return = 1, @Message = 'Cannot delete published recipes'
		goto finished
	end

	if exists(select * from Recipe r where r.RecipeId = @RecipeId and r.RecipeStatus = 'Archived' and getdate() - r.DateArchived < 30 )
		begin
		select @return = 1, @Message = 'Cannot delete recipes archived less than 30 days'
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