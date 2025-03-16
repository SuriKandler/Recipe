create or alter procedure dbo.MealGet(
	@MealId int = 0, 
	@All bit = 0,
	@Message varchar(500) = '' output
)
as
begin	
	
	select m.MealName, Users = concat(u.FirstName, ' ', u.Lastname), 
	NumCalories = dbo.CaloriesPerMeal(m.MealId), 
	NumCourses = dbo.NumCoursesPerMeal(m.mealid),
	NumRecipes = dbo.NumRecipesPerMeal(m.mealid)
	from meal m
	join Users u 
	on m.UserId = u.UserId
	where m.MealId = @MealId
	or @all = 1

end
go

exec dbo.MealList @all = 1