/*
Our website development is underway! 
Below is the layout of the pages on our website, please provide the SQL to produce the necessary result sets.

Note: 
a) When the word 'specific' is used, pick one record (of the appropriate type, recipe, meal, etc.) for the query. 
    The way the website works is that a list of items are displayed and then the user picks one and navigates to the "details" page.
b) Whenever you have a record for a specific item include the name of the picture for that item. That is because the website will always show a picture of the item.
*/
use HeartyHearthDB
go

/*
Home Page
    One result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
*/
select Category = 'Recipes', Amount = count(r.RecipeId) from Recipe r
union select 'Meals', count(m.MealId) from Meal m
union select 'Cookbooks', count(c.CookbookId) from Cookbook c

/*
Recipe list page:
    List of all Recipes that are either published or archived, published recipes should appear at the top. 
	Archived recipes should appear gray. Surround the archived recipe with <span style="color:gray">recipe name</span>
    In the resultset show the Recipe with its status, dates it was published and archived in mm/dd/yyyy format (blank if not archived), user, number of calories and number of ingredients.
    Tip: You'll need to use the convert function for the dates
*/
select Recipe = 
    case RecipeStatus 
    when 'Archived' then concat('<span style="color:gray">', r.RecipeName, '</span>') 
    else r.RecipeName 
    end, 
        RecipeStatus, 
        DatePublished = convert(varchar, r.DatePublished,101), 
        DateArchived = isnull(convert(varchar,r.DateArchived,101),''), 
        u.UserName, 
        r.Calories,
        TotalIngredient = count(ri.RecipeIngredientId)
from Recipe r 
join RecipeIngredient ri
on ri.RecipeId = r.RecipeId
join Users u
on u.UserId = r.UserId
where r.RecipeStatus <> 'Draft'
group by r.RecipeName, r.RecipeStatus, u.UserName, r.Calories, r.DatePublished, r.DateArchived
order by RecipeStatus desc

/*
Recipe details page:
    Show for a specific recipe (three result sets):
        a) Recipe header: recipe name, number of calories, number of ingredients and number of steps.
        b) List of ingredients: show the measurement quantity, measurement type and ingredient in one column, sorted by sequence. Ex. 1 Teaspoon Salt  
        c) List of prep steps sorted by sequence.
*/
--a) 
select r.Picture, r.RecipeName, r.Calories, TotalIngredient = count(distinct ri.RecipeIngredientId), NumberOfSteps = count(distinct d.DirectionId)
from Recipe r 
    join RecipeIngredient ri
    on ri.RecipeId = r.RecipeId
join RecipeDirection d
on d.RecipeId = r.RecipeId
where r.RecipeName = 'Apple Yogurt Smoothie'
group by r.RecipeName, r.Calories, r.Picture

--b) 
select ListOfIngredients = concat(ri.Amount, ' ', isnull(m.MeasurementType, ''), ' ', i.IngredientName)
from Recipe r
join RecipeIngredient ri
on r.recipeid = ri.recipeid
join Ingredient i
on ri.IngredientId = i.IngredientId
left join Measurement m
on ri.MeasurementId = m.MeasurementId
where r.RecipeName = 'Apple Yogurt Smoothie'
order by ri.RecipeIngredientSequence 

--c)
select RecipeDirection = d.DirectionDescription
from RecipeDirection d
join Recipe r
on d.RecipeId = r.RecipeId
where r.RecipeName = 'Apple Yogurt Smoothie'
order by d.DirectionSequence

/*
Meal list page:
    For all active meals, show the meal name, user that created the meal, number of calories for the meal, number of courses, and number of recipes per each meal, sorted by name of meal
*/
select m.MealName, u.UserName, TotalCalories = sum(r.Calories), NumberOfCourses = count(distinct mcr.MealCourseId), RecipeTotal = count(mcr.RecipeId)
from MealCourseRecipe mcr
join MealCourse mc
on mc.MealCourseId = mcr.MealCourseId
join meal m
on m.MealId = mc.MealId
join Recipe r
on r.RecipeId = mcr.RecipeId
join Users u
on u.UserId = m.UserId 
where m.Active = 1
group by m.MealName, u.UserName
order by m.MealName

/*
Meal details page:
    Show for a specific meal:
        a) Meal header: meal name, user, date created.
        b) List of all recipes: Result set should have one column, including the course type, whether the dish is serverd as main/side (if it's the main course), and recipe name. 
			Format for main course: CourseType: Main/Side dish - Recipe Name. 
            Format for non-main course: CourseType: Recipe Name
            Main dishes of the main course should be bold, using the bold tags as shown below
                ex: 
                    Appetizer: Mixed Greens
                    <b>Main: Main dish - Onion Pastrami Chicken</b>
					Main: Side dish - Roasted cucumbers with mustard
*/
--a)
select m.Picture, m.MealName, u.UserName, m.DateCreated 
from Meal m
join Users u
on u.UserId = m.UserId
where m.MealName = 'Dinner Done'

--b)
select MealDetail = 
    case 
    when mcr.IsItMain = 1 and c.CourseName =  'Main Course' then concat('<b>', 'Main: ', 'Main dish - ', r.RecipeName, '</b>')
    when mcr.IsItMain = 0 and c.CourseName =  'Main Course' then concat('Main: ', 'Side dish - ', r.RecipeName)
    else concat(c.CourseName, ': ', r.RecipeName)
    end
from MealCourseRecipe mcr
join MealCourse mc
on mc.MealCourseId = mcr.MealCourseId
join course c
on c.CourseId = mc.CourseId
join Meal m
on m.MealId = mc.MealId
join Recipe r
on r.RecipeId = mcr.RecipeId
where m.MealName = 'Dinner Done'
order by c.CourseSequence

/*
Cookbook list page:
    Show all active cookbooks with author and number of recipes per book. Sorted by book name.
*/
select cb.CookbookName, Author = concat(u.FirstName,' ', u.LastName), RecipeTotal = count(r.RecipeId) 
from CookBookRecipe cbr
join Cookbook cb
on cb.CookbookId = cbr.CookbookId
join Recipe r
on r.RecipeId = cbr.RecipeId
join Users u
on u.UserId = cb.UserId 
where cb.Active = 1
group by cb.CookbookName, u.FirstName, u.LastName
order by cb.CookbookName

/*
Cookbook details page:
    Show for specific cookbook:
    a) Cookbook header: cookbook name, user, date created, price, number of recipes.
    b) List of all recipes in the correct order. Include recipe name, cuisine and number of ingredients and steps.  
        Note: User will click on recipe to see all ingredients and steps.
*/
--a)
select cb.Picture, cb.CookbookName, u.UserName, cb.DateCreated, cb.Price, TotalRecipe = count(cbr.RecipeId)  
from CookBookRecipe cbr
join Cookbook cb
on cbr.CookbookId = cb.CookbookId
join Users u
on u.UserId = cb.UserId
where cb.CookbookName = 'Special cooking'
group by cb.CookbookName, u.UserName, cb.DateCreated, cb.Price, cb.Picture

--b)
select r.RecipeName, Cuisine = c.Title, TotalIngredient = count(distinct ri.RecipeIngredientId), NumberOfSteps = count(distinct d.DirectionId)
from CookBookRecipe cbr
join Cookbook cb
on cbr.CookbookId = cb.CookbookId
join Recipe r
on r.RecipeId = cbr.RecipeId
join RecipeIngredient ri
on ri.RecipeId = r.RecipeId
join RecipeDirection d
on d.RecipeId = r.RecipeId
join Cuisine c
on c.CuisineId = r.CuisineId
where cb.CookbookName = 'Special cooking'
group by r.RecipeName, c.Title, cbr.CookbookRecipeSequence
order by cbr.CookbookRecipeSequence

/*
April Fools Page:
    On April 1st we have a page with a joke cookbook. For that page provide the following.
    a) A list of all the recipes that are in all cookbooks. The recipe name should be the reverse of the real name with the first letter capitalized and all others lower case.
        There are matching pictures for those names, include the reversed picture names so that we can show the joke pictures.
        Note: ".jpg" file extension must be at the end of the reversed picture name EX: Recipe_Seikooc_pihc_etalocohc.jpg
    b) When the user clicks on any recipe they should see a spoof steps lists showing the step instructions for the LAST step of EACH recipe in the system. No sequence required.
        Hint: Use CTE
*/
--a)
select distinct 
    RecipeName = upper(left(reverse(r.RecipeName),1)) + lower(substring(reverse(r.RecipeName),2,len(reverse(r.RecipeName)))),
    Picture = concat('Recipe_', replace(upper(left(reverse(r.RecipeName),1)) + lower(substring(reverse(r.RecipeName),2,len(reverse(r.RecipeName)))), ' ', '_'), '.jpeg')
from CookBookRecipe cbr
join Cookbook cb
on cbr.CookbookId = cb.CookbookId
join Recipe r
on r.RecipeId = cbr.RecipeId

--b)
;
with x as(
    select DirectionSequence = max(d.DirectionSequence), d.RecipeId
    from RecipeDirection d
    group by d.RecipeId
)
select d.DirectionDescription
from x
join RecipeDirection d
on x.DirectionSequence = d.DirectionSequence
and x.RecipeId = d.RecipeId


/*
For site administration page:
5 seperate reports
    a) List of how many recipes each user created per status. Show 0 if user has no recipes at all.
    b) List of how many recipes each user created and average amount of days that it took for the user's recipes to be published.
    c) For each user, show three columns: Total number of meals, Total Active meals, Total Inactive meals. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    d) For each user, show three columns: Total number of cookbooks, Total Active cookbooks, Total Inactive cookbooks. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    e) List of archived recipes that were never published, and how long it took for them to be archived.
*/
--a) 
select 
    TotalDraftRecipe = sum(case Recipestatus when 'draft' then 1 else 0 end),
    TotalPublishedRecipe = sum(case Recipestatus when 'published' then 1 else 0 end),
    TotalArchivedRecipe = sum(case Recipestatus when 'archived' then 1 else 0 end),
    u.UserName
from Users u
left join Recipe r 
on u.UserId = r.UserId
group by u.UserName

--b)
select TotalRecipeCount = count(r.RecipeId), AvgDaysToPublish = avg(datediff(day, r.DateDraft, r.DatePublished)), u.UserName
from Recipe r
join Users u
on u.UserId = r.UserId
group by u.UserName

--c)
select 
    u.UserName, 
    TotalMeal = count(M.MealId), 
    TotalActiveMeal = sum(case when m.active = 1 then 1 else 0 end), 
    TotalInactiveMeal =  sum(case when m.active = 0 then 1 else 0 end)
from users u
left join Meal m
on u.UserId = m.UserId
group by u.UserName, m.Active

--d) 
select 
    u.UserName, 
    TotalCookbook = count(cb.CookbookId), 
    TotalActiveCookbook = sum(case when cb.active = 1 then 1 else 0 end), 
    TotalInactiveCookbook = sum(case when cb.active = 0 then 1 else 0 end)
from Users u
left join Cookbook cb
on u.UserId = cb.UserId
group by u.UserName

--e)
select r.recipename, DaysTillArchived = datediff(day, r.DateDraft, r.DateArchived)
from Recipe r
where r.DateArchived is not null
and r.DatePublished is null

/*
For user dashboard page:
    a) For a specific user, show one result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
        Tip: If you would like, you can use a CTE to get the User Id once instead of in each union select
    b) List of the user's recipes, display the status and the number of hours between the status it's in and the one before that. Omit recipes in drafted status.
*/
--a)
select Category = 'Recipe', Total = count(r.recipeid) from Recipe r join Users u on u.UserId = r.UserId where u.UserName = 'SK101'
union select Category = 'Meal', Total = count(m.MealId) from Meal m join Users u on u.UserId = m.UserId where u.UserName = 'SK101'
union select Category = 'Cookbook', Total = count(c.CookbookId) from Cookbook c join Users u on u.UserId = c.UserId where u.UserName = 'SK101'

--b) 
select r.RecipeName, r.RecipeStatus, HoursBetweenStatus = 
    case 
    when r.RecipeStatus = 'Archived'  then datediff(hour, isnull(r.DatePublished, r.DateDraft), r.DateArchived)
    when r.RecipeStatus = 'Published' then datediff(hour, r.DateDraft, r.DatePublished) 
    end
from Recipe r
join Users u
on u.UserId = r.UserId
where u.UserName = 'SK101'
and r.RecipeStatus <> 'Draft'

/*
    OPTIONAL CHALLENGE QUESTION
    c) Show a list of cuisines and the count of recipes the user has per cuisine, 0 if none
        Hint: Start by writing a CTE to give you cuisines for which the user does have recipes. 
*/
