use HeartyHearthDB
go
--select concat('grant execute on ', r.ROUTINE_NAME,' to approle')
--from INFORMATION_SCHEMA.ROUTINES R

grant execute on NumCoursesPerMeal to approle
grant execute on NumCaloriesPerMeal to approle
grant execute on NumRecipesPerCookbook to approle
grant execute on NumRecipesPerMeal to approle
grant execute on NumRecipesPerUser to approle
grant execute on RecipeDesc to approle
grant execute on UserUpdate to approle
grant execute on UserGet to approle
grant execute on UserDelete to approle
grant execute on RecipeUpdate to approle
grant execute on RecipeIngredientUpdate to approle
grant execute on RecipeIngredientGet to approle
grant execute on RecipeIngredientDelete to approle
grant execute on RecipeGet to approle
grant execute on RecipeDirectionUpdate to approle
grant execute on RecipeDirectionGet to approle
grant execute on RecipeDirectionDelete to approle
grant execute on RecipeDelete to approle
grant execute on MeasurementUpdate to approle
grant execute on MeasurementGet to approle
grant execute on MeasurementDelete to approle
grant execute on MealGet to approle
grant execute on IngredientUpdate to approle
grant execute on IngredientGet to approle
grant execute on IngredientDelete to approle
grant execute on DashboardGet to approle
grant execute on CuisineUpdate to approle
grant execute on CuisineGet to approle
grant execute on CuisineDelete to approle
grant execute on CourseUpdate to approle
grant execute on CourseGet to approle
grant execute on CourseDelete to approle
grant execute on CookbookUpdate to approle
grant execute on CookbookRecipeUpdate to approle
grant execute on CookbookRecipeGet to approle
grant execute on CookbookRecipeDelete to approle
grant execute on CookbookGet to approle
grant execute on CookbookDelete to approle
grant execute on CloneaRecipe to approle
grant execute on ChangeStatusUpdate to approle
grant execute on ChangeStatusGet to approle
grant execute on AutoCreateaCookbook to approle

grant select on Recipe to appadmin_user
grant select on RecipeIngredient to appadmin_user
grant select on RecipeDirection to appadmin_user
grant select on Users to appadmin_user
grant select on Cuisine to appadmin_user
grant delete on Cuisine to appadmin_user
grant update on Cuisine to appadmin_user

