--Note: some of these scripts are needed for specific items, when the instructions say "specific" pick 
--one item in your data and specify it in the where clause using a unique value that identifies it, do not use the primary key.
use HeartyHearthDB
go
--1) Sometimes when a staff member is fired. We need to eradicate everything from that user in our system. Write the SQL to delete a specific user and all the user's related records.

delete cr
from CookBookRecipe cr
join Recipe r
on cr.RecipeId = r.RecipeId
join Users u
on u.UserId = r.UserId 
where u.FirstName = 'Miriam'
and u.LastName = 'Cohen'

delete cr
from CookBookRecipe cr
join Cookbook cb
on cb.CookbookId = cr.CookbookId
join Users u
on u.UserId = cb.UserId
where u.FirstName = 'Miriam'
and u.LastName = 'Cohen'

delete c
from CookBook c
join Users u
on u.UserId = c.UserId 
where u.FirstName = 'Miriam'
and u.LastName = 'Cohen'

delete r
from MealCourseRecipe r 
join recipe p
on p.RecipeId = r.RecipeId
join Users u
on u.UserId = p.UserId
where u.FirstName = 'Miriam'
and u.LastName = 'Cohen'

delete mcr
from MealCourseRecipe mcr
join MealCourse mc
on mc.MealCourseId = mcr.MealCourseId
join meal m
on mc.MealId = m.MealId
join Users u
on u.UserId = m.UserId 
where u.FirstName = 'Miriam'
and u.LastName = 'Cohen'

delete mc
from MealCourse mc
join meal m
on mc.MealId = m.MealId
join Users u
on u.UserId = m.UserId 
where u.FirstName = 'Miriam'
and u.LastName = 'Cohen'

delete m
from Meal m
join Users u
on u.UserId = m.UserId 
where u.FirstName = 'Miriam'
and u.LastName = 'Cohen'

delete d
from RecipeDirection d
join Recipe r
on r.RecipeId = d.RecipeId
join Users u
on u.UserId = r.UserId 
where u.FirstName = 'Miriam'
and u.LastName = 'Cohen'

delete ri
from RecipeIngredient ri
join Recipe r
on r.RecipeId = ri.RecipeId
join Users u
on u.UserId = r.UserId 
where u.FirstName = 'Miriam'
and u.LastName = 'Cohen'

delete r
from Recipe r
join Users u
on u.UserId = r.UserId 
where u.FirstName = 'Miriam'
and u.LastName = 'Cohen'

delete u
from Users u
where u.FirstName = 'Miriam'
and u.LastName = 'Cohen'

--2) Sometimes we want to clone a recipe as a starting point and then edit it. 
--For example we have a complex recipe (steps and ingredients) and want to make a modified version. Write the SQL that clones a specific recipe, add " - clone" to its name.
insert Recipe(UserId, CuisineId, RecipeName, DateDraft, DatePublished, DateArchived, Calories)
select u.UserId, c.CuisineId, r.RecipeName + ' - clone', getdate(), null, null, r.Calories
from Recipe r
join Cuisine c
on c.CuisineId = r.CuisineId
join Users u
on u.UserId = r.UserId
where r.RecipeName = 'Apple Yogurt Smoothie'

;
with x as(
	select r.RecipeId, r.RecipeName, ri.Amount, m.MeasurementId, i.IngredientId, ri.RecipeIngredientSequence, r.Calories
	from Recipe r
	join RecipeIngredient ri
	on r.recipeid = ri.recipeid
	left join Measurement m
	on ri.MeasurementId = m.MeasurementId
	join Ingredient i
	on ri.IngredientId = i.IngredientId
	where r.RecipeName = 'Apple Yogurt Smoothie'
)
insert RecipeIngredient(RecipeId, Amount, MeasurementId, IngredientId, RecipeIngredientSequence)
select r.RecipeId, x.Amount, x.MeasurementId, x.IngredientId, x.RecipeIngredientSequence
from Recipe r
join x
on r.Calories = x.Calories
where r.RecipeName = x.RecipeName + ' - clone'

;
with x as(
	select r.RecipeName, r.Calories, d.DirectionSequence, d.DirectionDescription
	from RecipeDirection d
	join Recipe r
	on r.RecipeId = d.RecipeId
	where r.RecipeName = 'Apple Yogurt Smoothie'
)
insert RecipeDirection(RecipeId, DirectionSequence,DirectionDescription) 
select r.RecipeId, x.DirectionSequence, x.DirectionDescription
from Recipe r
join x
on r.Calories = x.Calories
where r.RecipeName = x.RecipeName + ' - clone'

/*
3) We offer users an option to auto-create a recipe book containing all of their recipes. 
Write a SQL script that creates the book for a specific user and fills it with their recipes.
The name of the book should be Recipes by Firstname Lastname. 
The price should be the number of recipes multiplied by $1.33
Sequence the book by recipe name.

Tip: To get a unique sequential number for each row in the result set use the ROW_NUMBER() function. See Microsoft Docs.
	 The following can be a column in your select statement: Sequence = ROW_NUMBER() over (order by colum name) , replace column name with the name of the column that the row number should be sorted
*/
insert Cookbook(UserId, CookbookName, Price, DateCreated, Active)
select u.UserId, concat('Recipes by ', u.FirstName, ' ', u.LastName), count(r.RecipeId)*1.33, getdate(), 1 
from Recipe r
join Users u
on u.UserId = r.UserId
where u.UserName = 'SK101'
group by u.UserId, u.FirstName, u.LastName

;
with x as(
	select u.FirstName, u.LastName, u.UserId, r.RecipeId, CookbookRecipeSequence = ROW_NUMBER() over (order by r.RecipeName)
	from Recipe r
	join Users u
	on u.UserId = r.UserId
	where u.UserName = 'SK101'
)
insert CookBookRecipe(CookbookId, RecipeId, CookbookRecipeSequence)
select c.CookbookId, x.RecipeId, x.CookbookRecipeSequence
from Cookbook c
join x
on c.userid = x.UserId
where c.CookbookName = concat('Recipes by ', x.FirstName, ' ', x.LastName)


/*
4) Sometimes the calorie count of of an ingredient changes and we need to change the calorie total for all recipes that use that ingredient.
Our staff nutritionist will specify the amount to change per measurement type, and of course multiply the amount by the quantity of the ingredient.
For example, the calorie count for butter went down by 2 per ounce, and 10 per stick of butter. 
Write an update statement that changes the number of calories of a recipe for a specific ingredient. 
The statement should include at least two measurement types, like the example above. 
*/
;
with x as(
	select r.recipeid, NewCalorieTotal =  case 
		when m.MeasurementType = 'cup' then sum((ri.Amount * 5) + r.Calories)
		when m.MeasurementType = 'tsp' then sum((ri.Amount * 1.5) + r.Calories)
		end
	from Ingredient i
	join RecipeIngredient ri
	on i.IngredientId = ri.IngredientId
	join Measurement m
	on m.MeasurementId = ri.MeasurementId
	join Recipe r
	on r.RecipeId = ri.RecipeId
	where i.IngredientName = 'Sugar'
	group by m.MeasurementType, r.RecipeId
)
update r
set r.calories = x.NewCalorieTotal
from x
join Recipe r
on r.RecipeId = x.RecipeId 

/*
5) We need to send out alerts to users that have recipes sitting in draft longer the average amount of time that recipes have taken to be published.
Produce a result set that has 4 columns (Data values in brackets should be replaced with actual data)
	User First Name, 
	User Last Name, 
	email address (first initial + lastname@heartyhearth.com),
	Alert: 
		Your recipe [recipe name] is sitting in draft for [X] hours.
		That is [Z] hours more than the average [Y] hours all other recipes took to be published.
*/
;
with x as(
select avghours = avg(datediff(hour, r.DateDraft, r.DatePublished))
from Recipe r
)
select distinct 
	u.FirstName, 
	u.LastName, 
	EmailAddress = concat(substring(u.FirstName, 1,1), u.LastName, '@heartyhearth.com'),
	Alert = concat('Your recipe ', r.RecipeName, ' is sitting in draft for ', datediff(hour, r.DateDraft, getdate()) , ' hours. That is ', 
		datediff(hour, r.DateDraft, getdate()) - x.avghours, 
		' hours more than the average ', x.avghours, 
		' hours all other recipes took to be published' ) 
from Recipe r
join x
on datediff(hour, r.DateDraft, getdate()) > x.avghours
join Users u
on u.UserId = r.UserId
where r.DatePublished is null
and r.DateArchived is null
group by r.DateDraft, x.avghours, u.FirstName, u.LastName, r.RecipeName

/*
6) We want to send out marketing emails for books. Produce a result set with one row and one column "Email Body" as specified below.
The email should have a unique guid link to follow, which should be shown in the format specified. 

Email Body:
Order cookbooks from HeartyHearth.com! We have [X] books for sale, average price is [Y]. You can order them all and recieve a 25% discount, for a total of [Z].
Click <a href = "www.heartyhearth.com/order/[GUID]">here</a> to order.
*/
select EmailBody = concat('Order cookbooks from HeartyHearth.com! We have ', count(c.CookbookId), ' books for sale, average price is £', cast(avg(c.Price) as decimal (5,2)),'. You can order them all and recieve a 25% discount, for a total of £',
cast(sum((c.price)*0.75) as decimal (5,2)), '. Click <a href = "www.heartyhearth.com/order/', newid(),'">here</a> to order.')
from Cookbook c

