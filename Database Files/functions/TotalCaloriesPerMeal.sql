create or alter function dbo.CaloriesPerMeal(@MealId int)
returns varchar(100)
as
begin
    declare @value varchar(100)

    select @value = concat(m.MealName,' TotalCalories = ', sum(r.Calories))
    from meal m
    join MealCourse mc
    on m.MealId = mc.MealId
    join MealCourseRecipe mcr
    on mcr.MealCourseId = mc.MealCourseId
    join Recipe r
    on mcr.RecipeId = r.RecipeId
    where m.MealId = @MealId
    group by m.MealName

    return @value
end
go

select TotalCaloriesPerMeal = dbo.CaloriesPerMeal(m.MealId),*
from Meal m


