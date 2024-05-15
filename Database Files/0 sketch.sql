/*
User
    FirstName varcher(30) 
    LastName varchar(50)
    UserName varchar(20) unique

Cuisine
    Name varchar(50) unique

Course
    Name varchar(20) unique
    Sequence int unique

Recipe
    UserId (fk User)
    CuisineId (fk Cuisine)
    Name varchar(100) unique
    Draft Date check draft < Published and draft < Archived
    Published Datetime allow null check Published < Archived
    Archived Date allow null 
    Calories int    
    Picture as Recipe_Name.jpeg persisted
    Status as case when Published and Archived is null then 'Draft' when Archived is null then 'Published' else 'Archived' persisted

Measurement
    Type varchar(20) unique

Ingredient
    Name varchar(30) unique
    Picture as Ingredient_Name.jpeg persisted

RecipeIngredients
    RecipeId (fk recipe)
    Amount decimal
    MeasurmentId(fk Measurement) allow null
    IngredientId (fk Ingredient)
    Sequence int
    unique recipeid, ingredientid
    unique RecipeId, Sequence

Direction
    RecipeId (fk Recipe)
    Sequence varchar(20)
    Description varchar(1000)
    unique sequence, recipeId

Meal
    Name varchar(50) unique 
    UserId (fk User)
    DateCreated date  
    Active bit
    Picture as Meal_Name.jpeg persisted

MealCourse
    MealId (fk Meal)
    CourseId (fk Course) 
    unique MealId, CourseId

MealCourseRecipe
    MealCourseId (fk MealCourse)
    RecipeId (fk recipe)
    IsItMain bit
    unique MealCourseId, RecipeId

CookBook
    UserId (fk User)
    Name varchar(100) unique
    Price decimal
    DateCreated date
    Active bit
    Picture as CookBook_Name.jpeg persisted

CookBookRecipe   
    BookID (fk Book)    
    RecipeId (fk Recipe)
    Sequence int 
    unique book, recipe
    unique book, sequence
*/