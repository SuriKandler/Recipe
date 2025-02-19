create or alter function dbo.NumCaloriesPerMeal(@MealId int)
returns int
as
begin
    declare @value int

    select @value = sum(r.Calories)
    from MealCourse mc
    join MealCourseRecipe mcr
    on mcr.MealCourseId = mc.MealCourseId
    join Recipe r
    on mcr.RecipeId = r.RecipeId
    where mc.MealId = @MealId   

    return @value
end
go

select TotalCaloriesPerMeal = dbo.CaloriesPerMeal(m.MealId),*
from Meal m
