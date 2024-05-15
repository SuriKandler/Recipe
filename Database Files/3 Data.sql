use HeartyHearthDB
go

delete CookBookRecipe
delete Cookbook
delete MealCourseRecipe
delete MealCourse
delete Meal 
delete RecipeDirection
delete RecipeIngredient
delete Ingredient
delete Measurement
delete Recipe
delete Course
delete Cuisine
delete Users
go

insert Users(FirstName, LastName, UserName)
select 'Kitty', 'Spencer', 'SK101'
union select 'Liba', 'Pereira', 'PL102'
union select 'Miriam', 'Cohen', 'CM103'
union select 'Aidy', 'Feld', 'FA104'

insert Cuisine(Title)
select 'American'
union select 'English'
union select 'French'

insert Course(CourseName, CourseSequence)
select 'Appetizer', 1
union select 'Main Course', 2
union select 'Dessert', 3

;
with x as(
   select UserName = 'SK101' ,Cuisine = 'American', RecipeName = 'Chocolate Chip Cookies' , Draft = '2023-04-22 01:23:56',Published = '2023-05-18 15:24:06', Archived = null, Calories = 168
   union select 'PL102', 'French', 'Apple Yogurt Smoothie', '2020-06-18 12:23:53','2020-07-02 02:20:55', null, 96
   union select 'CM103', 'English', 'Cheese Bread', '2019-08-29 04:15:28', '2019-10-15 05:45:30', null, 264
   union select 'SK101', 'American', 'Butter Muffins', '2021-03-05 15:25:10', '2021-07-26 12:15:42', '2022-06-15 16:10:04', 523
   union select 'PL102', 'English', 'Butter Cakes', '2020-02-15 03:55:10', null, null, 568
   union select 'CM103', 'English', 'Egg Cake', '2020-02-15 03:55:10', null, '2020-03-23 04:58:20', 352
)
insert Recipe(UserId, CuisineId, RecipeName, DateDraft, DatePublished, DateArchived, Calories)
select u.UserId, c.CuisineId, x.RecipeName, x.Draft, x.Published, x.Archived, x.Calories
from Users u
join x
on u.UserName = x.UserName
join Cuisine c
on c.Title = x.Cuisine 

insert Measurement(MeasurementType)
select 'cup'
union select 'tsp'
union select 'tbsp'
union select 'oz'
union select 'pinch'
union select 'stick'


insert Ingredient(IngredientName)
select 'sugar'
union select 'oil'
union select 'eggs'
union select 'flour'
union select 'vanilla sugar'
union select 'baking powder'
union select 'baking soda'
union select 'chocolate chips'
union select 'granny smith apples'
union select 'vanilla yogurt'
union select 'orange juice'
union select 'honey'
union select 'ice cubes'
union select 'club bread'
union select 'butter'
union select 'shredded cheese'
union select 'cloves garlic (crushed)'
union select 'black pepper'
union select 'salt'
union select 'sour cream cheese'
union select 'whipped cream cheese'
union select 'vanilla pudding'
union select 'butter'

;
with x as(
   select Amount = 1, MeasurementType = 'cup', IngredientType = 'sugar', RecipeIngredientSequence = 1
   union select 0.5, 'cup', 'oil', 2
   union select 3, null, 'eggs', 3 
   union select 2, 'cup', 'Flour', 4 
   union select 1, 'tsp', 'vanilla sugar', 5
   union select 2, 'tsp', 'baking powder' , 6
   union select 0.5, 'tsp', 'baking soda', 7 
   union select 1, 'cup', 'chocolate chips', 8
)
insert RecipeIngredient(RecipeId, Amount, MeasurementId, IngredientId, RecipeIngredientSequence)
select r.recipeid, x.Amount, m.MeasurementId, i.IngredientId, x.RecipeIngredientSequence
from x
left join Measurement M
on m.MeasurementType = x.MeasurementType
join ingredient i
on i.IngredientName = x.IngredientType 
join Recipe r
on r.RecipeName = 'Chocolate Chip Cookies'

;
with x as(
   select Amount = 3, MeasurementType = null, IngredientType = 'granny smith apples', RecipeIngredientSequence = 1
   union select 2, 'cup', 'vanilla yogurt', 2
   union select 2, 'tsp', 'sugar', 3 
   union select 0.5, 'cup', 'orange juice', 4 
   union select 2, 'tbsp', 'honey', 5
   union select 5.5, null, 'ice cubes' , 6
)
insert RecipeIngredient(RecipeId, Amount, MeasurementId, IngredientId, RecipeIngredientSequence)
select r.recipeid, x.Amount, m.MeasurementId, i.IngredientId, x.RecipeIngredientSequence
from x
join ingredient i
on i.IngredientName = x.IngredientType 
join Recipe r
on r.RecipeName = 'Apple Yogurt Smoothie'
left join Measurement M
on m.MeasurementType = x.MeasurementType


;
with x as(
   select Amount = 1, MeasurementType = null, IngredientType = 'club bread', RecipeIngredientSequence = 1
   union select 4, 'oz', 'butter', 2
   union select 8, 'oz', 'shredded cheese', 3 
   union select 2, null, 'cloves garlic (crushed)', 4 
   union select 0.25, 'tsp', 'black pepper', 5
   union select 1, 'pinch','salt' , 6
)
insert RecipeIngredient(RecipeId, Amount, MeasurementId, IngredientId, RecipeIngredientSequence)
select r.recipeid, x.Amount, m.MeasurementId, i.IngredientId, x.RecipeIngredientSequence
from x
join ingredient i
on i.IngredientName = x.IngredientType
join Recipe r
on r.RecipeName = 'Cheese Bread'
left join Measurement M
on m.MeasurementType = x.MeasurementType

;
with x as(
   select Amount = 1, MeasurementType = 'stick', IngredientType = 'butter', RecipeIngredientSequence = 1
   union select 3, 'cup', 'sugar', 2
   union select 2, 'tbsp', 'vanilla pudding', 3 
   union select 4, null, 'eggs', 4 
   union select 8, 'oz', 'whipped cream cheese', 5
   union select 8, 'oz', 'sour cream cheese', 6
   union select 1, 'cup', 'flour', 7
   union select 2, 'tsp', 'baking powder', 8
)
insert RecipeIngredient(RecipeId, Amount, MeasurementId, IngredientId, RecipeIngredientSequence)
select r.recipeid, x.Amount, m.MeasurementId, i.IngredientId, x.RecipeIngredientSequence
from x
join ingredient i
on i.IngredientName = x.IngredientType
join Recipe r
on r.RecipeName = 'Butter Muffins'
left join Measurement M
on m.MeasurementType = x.MeasurementType

;
with x as(
   select Amount = 1, MeasurementType = 'stick', IngredientType = 'butter', RecipeIngredientSequence = 1
   union select 3, 'cup', 'sugar', 2
   union select 2, 'tbsp', 'vanilla pudding', 3 
   union select 4, null, 'eggs', 4 
   union select 8, 'oz', 'whipped cream cheese', 5
   union select 1, 'cup', 'flour', 6
   union select 2, 'tsp', 'baking powder', 7
)
insert RecipeIngredient(RecipeId, Amount, MeasurementId, IngredientId, RecipeIngredientSequence)
select r.recipeid, x.Amount, m.MeasurementId, i.IngredientId, x.RecipeIngredientSequence
from x
join ingredient i
on i.IngredientName = x.IngredientType
join Recipe r
on r.RecipeName = 'Butter Cakes'
left join Measurement M
on m.MeasurementType = x.MeasurementType

;
with x as(
   select Amount = 1, MeasurementType = 'stick', IngredientType = 'butter', RecipeIngredientSequence = 1
   union select 3, 'cup', 'sugar', 2
   union select 9, null, 'eggs', 3 
   union select 8, 'oz', 'whipped cream cheese', 4
   union select 1, 'cup', 'flour', 5
   union select 2, 'tsp', 'baking powder', 6
)
insert RecipeIngredient(RecipeId, Amount, MeasurementId, IngredientId, RecipeIngredientSequence)
select r.recipeid, x.Amount, m.MeasurementId, i.IngredientId, x.RecipeIngredientSequence
from x
join ingredient i
on i.IngredientName = x.IngredientType
join Recipe r
on r.RecipeName = 'Egg Cake'
left join Measurement M
on m.MeasurementType = x.MeasurementType

;
with x as( 
   select DirectionSequence = 1, DirectionDescription = 'First combine sugar, oil and eggs in a bowl'
   union select 2, 'mix well'
   union select 3, 'add flour, vanilla sugar, baking powder and baking soda'
   union select 4, 'beat for 5 minutes'
   union select 5, 'add chocolate chips'
   union select 6, 'freeze for 1-2 hours'
   union select 7, 'roll into balls and place spread out on a cookie sheet'
   union select 8, 'bake on 350 for 10 min.'
)
insert RecipeDirection(RecipeId, DirectionSequence,DirectionDescription) 
select r.RecipeId, x.DirectionSequence, x.DirectionDescription
from x
join Recipe r
on r.RecipeName = 'Chocolate Chip Cookies'

;
with x as(
   select DirectionSequence = 1, DirectionDescription = 'Peel the apples and dice'
   union select 2, 'Combine all ingredients in bowl except for apples and ice cubes'
   union select 3, 'mix until smooth'
   union select 4, 'add apples and ice cubes'
   union select 5, 'pour into glasses.'
)
insert RecipeDirection(RecipeId, DirectionSequence,DirectionDescription) 
select r.RecipeId, x.DirectionSequence, x.DirectionDescription
from x
join Recipe r
on r.RecipeName = 'Apple Yogurt Smoothie'

;
with x as(
   select DirectionSequence = 1, DirectionDescription = 'Slit bread every 3/4 inch'
   union select 2, 'Combine all ingredients in bowl'
   union select 3, 'fill slits with cheese mixture'
   union select 4, 'wrap bread into a foil and bake for 30 minutes.'
)                      
insert RecipeDirection(RecipeId, DirectionSequence,DirectionDescription) 
select r.RecipeId, x.DirectionSequence, x.DirectionDescription
from x
join Recipe r
on r.RecipeName = 'Cheese Bread'

;
with x as(
   select DirectionSequence = 1, DirectionDescription = 'Cream butter with sugars'
   union select 2, 'Add eggs and mix well'
   union select 3, 'Slowly add rest of ingredients and mix well'
   union select 4, 'fill muffin pans 3/4 full and bake for 30 minutes.'
)
insert RecipeDirection(RecipeId, DirectionSequence,DirectionDescription) 
select r.RecipeId, x.DirectionSequence, x.DirectionDescription
from x
join Recipe r
on r.RecipeName = 'Butter Muffins'

;
with x as(
   select DirectionSequence = 1, DirectionDescription = 'Cream butter with sugars'
   union select 2, 'Add eggs and mix well'
   union select 3, 'Slowly add rest of ingredients and mix well'
   union select 4, 'fill pans and bake for 40 minutes.'
)
insert RecipeDirection(RecipeId, DirectionSequence,DirectionDescription) 
select r.RecipeId, x.DirectionSequence, x.DirectionDescription
from x
join Recipe r
on r.RecipeName = 'Butter Cakes'

;
with x as(
   select DirectionSequence = 1, DirectionDescription = 'Cream butter with sugar'
   union select 2, 'Add eggs and mix well'
   union select 3, 'Slowly add rest of ingredients and mix well'
   union select 4, 'fill pans and bake for 40 minutes.'
)
insert RecipeDirection(RecipeId, DirectionSequence,DirectionDescription) 
select r.RecipeId, x.DirectionSequence, x.DirectionDescription
from x
join Recipe r
on r.RecipeName = 'Egg Cake'

;
with x as(
   select MealName = 'Breakfast bash', UserId = 'PL102', DateCreated = '2023-05-02', Active = 1
   union select 'Dinner Done', 'CM103', '2023-08-15', 0
   union select 'Breakfast Buffet', 'SK101', '2023-09-24', 1
)
insert Meal(MealName, UserId, DateCreated, Active)
select x.MealName, u.UserId, x.DateCreated, x.Active 
from x
join Users u
on u.UserName = x.UserId   

insert MealCourse(MealId, CourseId)
select m.MealId, c.CourseId
from Meal m
cross join Course c

insert MealCourseRecipe(MealCourseId, RecipeId, IsItMain)
select MealCourseId = mc.MealCourseId, r.recipeId, IsItMain = 1
from MealCourse mc
join Meal m
on m.MealId = mc.MealId
join Recipe r
on r.RecipeName = 'Apple Yogurt Smoothie'
join Course C
on c.CourseId = mc.CourseId
where m.MealName = 'Breakfast bash'
and c.CourseName = 'Appetizer'

insert MealCourseRecipe(MealCourseId, RecipeId, IsItMain)
select MealCourseId = mc.MealCourseId, r.recipeId, IsItMain = 1
from MealCourse mc
join Meal m
on m.MealId = mc.MealId
join Recipe r
on r.RecipeName = 'Cheese Bread'
join Course C
on c.CourseId = mc.CourseId
where m.MealName = 'Breakfast bash'
and c.CourseName = 'Main course' 

insert MealCourseRecipe(MealCourseId, RecipeId, IsItMain)
select MealCourseId = mc.MealCourseId, r.recipeId, IsItMain = 0
from MealCourse mc
join Meal m
on m.MealId = mc.MealId
join Recipe r
on r.RecipeName = 'Butter Muffins'
join Course C
on c.CourseId = mc.CourseId
where m.MealName = 'Breakfast bash'
and c.CourseName = 'Main course' 

insert MealCourseRecipe(MealCourseId, RecipeId, IsItMain)
select MealCourseId = mc.MealCourseId, r.recipeId, IsItMain = 1
from MealCourse mc
join Meal m
on m.MealId = mc.MealId
join Recipe r
on r.RecipeName = 'Apple Yogurt Smoothie'
join Course C
on c.CourseId = mc.CourseId
where m.MealName = 'Dinner Done'
and c.CourseName = 'Appetizer' 

insert MealCourseRecipe(MealCourseId, RecipeId, IsItMain)
select MealCourseId = mc.MealCourseId, r.recipeId, IsItMain = 1
from MealCourse mc
join Meal m
on m.MealId = mc.MealId
join Recipe r
on r.RecipeName = 'Cheese Bread'
join Course C
on c.CourseId = mc.CourseId
where m.MealName = 'Dinner Done'
and c.CourseName = 'Main course' 

insert MealCourseRecipe(MealCourseId, RecipeId, IsItMain)
select MealCourseId = mc.MealCourseId, r.recipeId, IsItMain = 0
from MealCourse mc
join Meal m
on m.MealId = mc.MealId
join Recipe r
on r.RecipeName = 'Butter Muffins'
join Course C
on c.CourseId = mc.CourseId
where m.MealName = 'Dinner Done'
and c.CourseName = 'Main course' 

insert MealCourseRecipe(MealCourseId, RecipeId, IsItMain)
select MealCourseId = mc.MealCourseId, r.recipeId, IsItMain = 1 
from MealCourse mc
join Meal m
on m.MealId = mc.MealId
join Recipe r
on r.RecipeName = 'Chocolate Chip Cookies'
join Course C
on c.CourseId = mc.CourseId
where m.MealName = 'Dinner Done'
and c.CourseName = 'dessert' 

insert MealCourseRecipe(MealCourseId, RecipeId, IsItMain)
select MealCourseId = mc.MealCourseId, r.recipeId, IsItMain = 1
from MealCourse mc
join Meal m
on m.MealId = mc.MealId
join Recipe r
on r.RecipeName = 'Chocolate Chip Cookies'
join Course C
on c.CourseId = mc.CourseId
where m.MealName = 'Breakfast Buffet'
and c.CourseName = 'Appetizer' 

insert MealCourseRecipe(MealCourseId, RecipeId, IsItMain)
select MealCourseId = mc.MealCourseId, r.recipeId, IsItMain = 1
from MealCourse mc
join Meal m
on m.MealId = mc.MealId
join Recipe r
on r.RecipeName = 'Butter Muffins'
join Course C
on c.CourseId = mc.CourseId
where m.MealName = 'Breakfast Buffet'
and c.CourseName = 'Main course' 

insert MealCourseRecipe(MealCourseId, RecipeId, IsItMain)
select MealCourseId = mc.MealCourseId, r.recipeId, IsItMain = 1 
from MealCourse mc
join Meal m
on m.MealId = mc.MealId
join Recipe r
on r.RecipeName = 'Apple Yogurt Smoothie'
join Course C
on c.CourseId = mc.CourseId
where m.MealName = 'Breakfast Buffet'
and c.CourseName = 'dessert' 

insert Cookbook(UserId, CookbookName, Price, DateCreated, Active)  
select u.UserId, 'Treats for two', 30, '2022-05-16', 1 from Users u where u.firstname = 'Kitty' and u.LastName = 'Spencer'
union select u.UserId, 'Special cooking', 26, '2022-05-16', 0 from Users u where u.firstname = 'Kitty' and u.LastName = 'Spencer'
union select u.UserId, 'All Occasions', 40, '2022-05-16', 1 from Users u where u.firstname = 'Liba' and u.LastName = 'Pereira'

;
with x as(
   select RecipeName = 'Chocolate Chip Cookies', CookbookRecipeSequence = 1
   union select 'Apple Yogurt Smoothie', 2
   union select 'Cheese Bread', 3
   union select 'Butter Muffins', 4
)
insert CookBookRecipe(CookbookId, RecipeId, CookbookRecipeSequence)
select cb.CookbookId, r.RecipeId, x.CookbookRecipeSequence
from x
join Cookbook cb
on cb.CookbookName = 'Treats for two'
join Recipe r
on r.RecipeName = x.RecipeName

;
with x as(
   select RecipeName = 'Butter Muffins', CookbookRecipeSequence = 1
   union select 'Cheese Bread', 2
   union select 'Apple Yogurt Smoothie', 3
   union select 'Chocolate Chip Cookies', 4
)
insert CookBookRecipe(CookbookId, RecipeId, CookbookRecipeSequence)
select cb.CookbookId, r.RecipeId, x.CookbookRecipeSequence
from x
join Cookbook cb
on cb.CookbookName = 'Special cooking'
join Recipe r
on r.RecipeName = x.RecipeName
;
with x as(
   select RecipeName = 'Cheese Bread', CookbookRecipeSequence = 1
   union select 'Butter Muffins', 2
   union select 'Chocolate Chip Cookies', 3
)
insert CookBookRecipe(CookbookId, RecipeId, CookbookRecipeSequence)
select cb.CookbookId, r.RecipeId, x.CookbookRecipeSequence
from x
join Cookbook cb
on cb.CookbookName = 'All Occasions'
join Recipe r
on r.RecipeName = x.RecipeName

