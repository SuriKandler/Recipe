create or alter function dbo.NumRecipesPerMeal(@MealId int)
returns int
as
begin
    declare @value int   
    
    select @value = Count(r.RecipeName)
    from recipe r
    join MealCourseRecipe mcr
    on mcr.RecipeId = r.recipeid
    join mealcourse mc
    on mcr.mealcourseid = mc.mealcourseid 
    join meal m
    on m.mealid = mc.mealid
    where m.MealId = @MealId  
    
    return @value
end
go
/*
select NumRecipesPerMeal = dbo.NumRecipesPerMeal(m.mealid), m.*
from meal m
*/