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
join Users u
on u.UserId = r.UserId 
where u.userid = @UserId

delete cr
from CookBookRecipe cr
join Cookbook cb
on cb.CookbookId = cr.CookbookId
join Users u
on u.UserId = cb.UserId
where u.userid = @UserId

delete c
from CookBook c
join Users u
on u.UserId = c.UserId 
where u.userid = @UserId

delete r
from MealCourseRecipe r 
join recipe p
on p.RecipeId = r.RecipeId
join Users u
on u.UserId = p.UserId
where u.userid = @UserId

delete mcr
from MealCourseRecipe mcr
join MealCourse mc
on mc.MealCourseId = mcr.MealCourseId
join meal m
on mc.MealId = m.MealId
join Users u
on u.UserId = m.UserId 
where u.userid = @UserId

delete mc
from MealCourse mc
join meal m
on mc.MealId = m.MealId
join Users u
on u.UserId = m.UserId 
where u.userid = @UserId

delete m
from Meal m
join Users u
on u.UserId = m.UserId 
where u.userid = @UserId

delete d
from RecipeDirection d
join Recipe r
on r.RecipeId = d.RecipeId
join Users u
on u.UserId = r.UserId 
where u.userid = @UserId

delete ri
from RecipeIngredient ri
join Recipe r
on r.RecipeId = ri.RecipeId
join Users u
on u.UserId = r.UserId 
where u.userid = @UserId

delete r
from Recipe r
join Users u
on u.UserId = r.UserId 
where u.userid = @UserId

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