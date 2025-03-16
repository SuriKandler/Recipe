create or alter procedure dbo.UserDelete(
	@UserId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0
	select @UserId = isnull(@UserId,0)
begin try
		begin tran	
--LB: Formatting tip: The code below should be indented.
--LB: The Users table join is unnecessary in cases where UserId is already available in the Recipe, Meal, or other related tables.
		delete cr
		from CookBookRecipe cr
		join Recipe r
		on cr.RecipeId = r.RecipeId
		where r.userid = @UserId
		
		delete cr
		from CookBookRecipe cr
		join Cookbook cb
		on cb.CookbookId = cr.CookbookId
		where cb.userid = @UserId
		
		delete c
		from CookBook c
		where c.userid = @UserId

		delete r
		from MealCourseRecipe r 
		join recipe p
		on p.RecipeId = r.RecipeId
		where p.userid = @UserId

		delete mcr
		from MealCourseRecipe mcr
		join MealCourse mc
		on mc.MealCourseId = mcr.MealCourseId
		join meal m
		on mc.MealId = m.MealId
		where m.userid = @UserId

		delete mc
		from MealCourse mc
		join meal m
		on mc.MealId = m.MealId
		where m.userid = @UserId

		delete m
		from Meal m
		where m.userid = @UserId

		delete d
		from RecipeDirection d
		join Recipe r
		on r.RecipeId = d.RecipeId
		where r.userid = @UserId

		delete ri
		from RecipeIngredient ri
		join Recipe r
		on r.RecipeId = ri.RecipeId
		where r.userid = @UserId

		delete r
		from Recipe r
		where r.userid = @UserId

		delete u
		from Users u
		where u.userid = @UserId

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