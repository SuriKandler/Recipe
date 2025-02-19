create or alter procedure dbo.UserDelete(
	@UserId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0

		select @UserId = isnull(@UserId,0)

	/*delete Users where UserId = @UserId

	delete Recipe from Recipe r where r.userid = @UserId

	delete Meal from Meal m where m.UserId = @UserId

	delete MealCourseRecipe from MealCourseRecipe mr join MealCourse m on m.MealCourseId = mr.MealCourseId where mr.*/

	
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

	return @return

	/*    if exists(select * from User r where r.UserId = @UserId and (r.UserStatus = 'Archived' and getdate() - r.DateArchived < 30) or r.UserStatus = 'Published')
    begin
        select @return = 1, @Message = 'Cannot delete User, either it has been archived for less than 30 days, or its a published User.'
        goto finished
    end

	begin try
		begin tran
        delete UserDirection where UserId = @UserId
		delete UserIngredient where UserId = @UserId
		delete User where UserId = @UserId
		commit
	end try
	begin catch
		rollback;
		throw
	end catch

    finished: 
    return @return*/
end
go