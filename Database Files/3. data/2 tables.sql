use HeartyHearthDB
go

drop table if exists CookbookRecipe
drop table if exists Cookbook
drop table if exists MealCourseRecipe
drop table if exists MealCourse
drop table if exists Meal
drop table if exists RecipeDirection
drop table if exists RecipeIngredient
drop table if exists Ingredient
drop table if exists Measurement
drop table if exists Recipe
drop table if exists Course
drop table if exists Cuisine
drop table if exists Users

create table dbo.Users(
    UserId int not null identity primary key,
    FirstName varchar(30) not null 
        constraint ck_Users_FirstName_cannot_be_blank check(FirstName <> ''),
    LastName varchar(50) not null 
        constraint ck_Users_LastName_cannot_be_blank check(LastName <> ''),   
    UserName varchar(20) not null
        constraint ck_Users_UserName_cannot_be_blank check(UserName <> '') 
        constraint u_Users_UserName unique
)
go

create table dbo.Cuisine(
    CuisineId int not null identity primary key,
    Title varchar(50) not null 
        constraint ck_Cuisine_Title_cannot_be_blank check(Title <> '')
        constraint u_Cuisine_Title unique
)
go

create table dbo.Course(
    CourseId int not null identity primary key,
    CourseName varchar(20) 
        constraint ck_Course_CourseName_cannot_be_blank check(CourseName <> '')
        constraint u_Course_CourseName unique,
    CourseSequence int not null 
        constraint u_Course_CourseSequence unique
        constraint ck_Course_CourseSequence_must_be_larger_than_0 check(CourseSequence > 0),

)
go

create table dbo.Recipe(
    RecipeId int not null identity primary key,
    UserId int not null 
        constraint f_Recipe_User foreign key references Users(UserId),
    CuisineId int not null 
        constraint f_Recipe_Cuisine foreign key references Cuisine(CuisineId),
    RecipeName varchar(100) not null 
        constraint ck_Recipe_RecipeName_cannot_be_blank check(RecipeName <> '')
        constraint u_Recipe_RecipeName unique,
   DateDraft Datetime null--not null
        constraint ck_Recipe_Draft_cannot_be_future_date check(DateDraft <= getdate()), 
    DatePublished Datetime null,
    DateArchived Datetime null,
    Calories int not null
        constraint ck_Recipe_Calories_must_be_greater_than_0 check(Calories > 0),   
    Picture as concat('Recipe', '_', replace(RecipeName, ' ', '_'), '.jpeg') persisted,
    RecipeStatus as case 
        when DatePublished is null and DateArchived is null then 'Draft'
        when DateArchived is null then 'Published' 
        else 'Archived' 
        end
        persisted,
        constraint ck_Recipe_Draft_date_before_published_and_archive check(DateDraft < DatePublished and DateDraft < DateArchived),
        constraint ck_Recipe_Published_before_archived check(DatePublished < DateArchived)
)
go

create table dbo.Measurement(
    MeasurementId int not null identity primary key,
    MeasurementType varchar(20)  
        constraint u_Measurement_MeasurementType unique
        constraint ck_Measurement_MeasurementType check(MeasurementType <> '')
)
go

create table dbo.Ingredient(
    IngredientId int not null identity primary key,
    IngredientName varchar(30) not null 
        constraint ck_Ingredient_IngredientName_cannot_be_blank check(IngredientName <> '' )
        constraint u_Ingredient_IngrdientName unique,
    Picture as concat('Ingredient', '_', replace(IngredientName, ' ', '_'), '.jpeg') persisted
)
go

create table dbo.RecipeIngredient(
    RecipeIngredientId int not null identity primary key,
    RecipeId int not null 
        constraint f_RecipeIngredient_Recipe foreign key references Recipe(RecipeID),
    MeasurementId int null
        constraint f_RecipeIngredient_Measurment foreign key references Measurement(MeasurementId),
    IngredientId int not null 
        constraint f_RecipeIngredient_Ingredient foreign key references Ingredient(IngredientId),
    Amount decimal(4,2) not null
        constraint ck_RecipeIngredient_Amount_cannot_be_negative check(Amount > 0),
    RecipeIngredientSequence int not null,
        constraint ck_RecipeIngredient_RecipeIngredientSequence check(RecipeIngredientSequence > 0),
        constraint u_RecipeIngredient_RecipeId_IngredientId unique(RecipeId, IngredientId),
        constraint u_RecipeIngredient_RecipeId_RecipeIngredientSequence unique(RecipeId, RecipeIngredientSequence)
)
go

create table dbo.RecipeDirection(
    DirectionId int not null identity primary key,
    RecipeId int not null 
        constraint f_Direction_RecipeId foreign key references Recipe(RecipeId),
    DirectionSequence int not null 
        constraint ck_Direction_DirectionSequence_cannot_be_blank check(DirectionSequence <> ''),
    DirectionDescription varchar(1000) not null 
        constraint ck_Direction_DirectionDescription_cannot_be_blank check(DirectionDescription <> ''),
        constraint u_Direction_RecipeId_DirectionSequence unique(DirectionSequence, RecipeId)
)
go

create table dbo.Meal(
    MealId int not null identity primary key,
    UserId int not null 
        constraint f_Meal_UserId foreign key references Users(UserId),
    MealName varchar(50) not null 
        constraint ck_Meal_MealName_cannot_be_blank check(MealName <> '')
        constraint u_Meal_MealName unique, 
    DateCreated date not null
        constraint ck_Meal_DateCreated_cannot_be_future_date check(DateCreated <= getdate()), 
    Active bit not null default 1,
    Picture as concat('Meal', '_', replace(MealName, ' ', '_'), '.jpeg') persisted
)
go

create table dbo.MealCourse(
    MealCourseId int not null identity primary key,
    MealId int not null 
        constraint f_MealCourse_MealId foreign key references Meal(MealId),
    CourseId int not null 
        constraint f_MealCourse_CourseId foreign key references Course(CourseId),
        constraint u_MealCourse_MealId_CourseId unique(MealId, CourseId)
)
go

create table dbo.MealCourseRecipe(
    MealCourseRecipeId int not null identity primary key,
    MealCourseId int not null 
        constraint f_MealCourseRecipe_MealCourseId foreign key references MealCourse(MealCourseId),
    RecipeId int not null 
        constraint f_MealCourseRecipe_RecipeId foreign key references Recipe(RecipeId),
    IsItMain bit not null,
        constraint u_MealCourse_MealCourseId_RecipeId unique(MealCourseId, RecipeId)
)
go

create table dbo.Cookbook(
    CookbookId int not null identity primary key,
    UserId int not null 
        constraint f_Cookbook_Users foreign key references Users(UserId),
    CookbookName varchar(100) not null
        constraint ck_Cookbook_CookbookName_cannot_be_blank check(CookbookName <> '') 
        constraint u_Cookbook_CookbookName unique,
    Price decimal(5,2) not null 
        constraint ck_Cookbook_Price_must_be_more_than_0 check(Price > 0),
    DateCreated date not null
        constraint ck_Cookbook_DateCreated_cannot_be_future_date check(DateCreated <= getdate()),
    Active bit not null default 1,
    Picture as concat('CookBook', '_', replace(CookbookName, ' ', '_'), '.jpeg') persisted
)
go

create table dbo.CookBookRecipe(
    CookBookRecipeId int not null identity primary key,  
    CookbookId int not null 
        constraint f_CookbookRecipe_CookbookId foreign key references Cookbook(CookbookId),  
    RecipeId int not null 
        constraint f_CookbookRecipe_RecipeId foreign key references Recipe(RecipeId),
    CookbookRecipeSequence int not null 
        constraint ck_CookBookRecipe_CookbookRecipeSequence_cannot_be_negative check(CookbookRecipeSequence > 0), 
        constraint ck_CookBookRecipe_CookbookId_RecipeId unique(CookbookId, RecipeId),
        constraint ck_CookBookRecipe_CookbookId_CookbookRecipeSequence unique(CookbookId, CookbookRecipeSequence),
)
go










