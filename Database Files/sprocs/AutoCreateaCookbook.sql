/*We offer users an option to auto-create a recipe book containing all of their recipes.
On this screen allow a user to be picked and then upon click create the book filled in with the selected
user's recipes.
The name of the book should be "Recipes by Firstname Lastname".
The price should be the number of recipes multiplied by $1.33
Sequence the recipes by recipe name.
*/

create or alter proc dbo.AutoCreateaCookbook(
    @CookbookId int = null output,
    @UserId int,
    @RecipeName varchar (50) = '',
    @Message varchar (500) = '' output    
)
as
begin
    declare @return int = 0, @count int = 0
  
insert cookbook(UserId, CookbookName, Price, DateCreated, Active)
select 
@userId, 
concat = ('Recipes by '+ u.FirstName + ' ' + u.LastName),
dbo.NumRecipesPerUser(@userid) * 1.33,
getdate(),
1
from users u
where u.userid = @userid
group by u.userid, u.firstname, u.lastname

select @cookbookid = scope_identity();

insert CookbookRecipe(cookbookid,recipeid,cookbookrecipesequence)
select @cookbookid, r.recipeid, ROW_NUMBER() OVER (ORDER BY r.recipeId)
from recipe r
where r.userid = @userid
order by r.RecipeName

    return @return
    
end
go

/*


exec dbo.AutoCreateaCookbook @userid = 4
select * from cookbook
select * from recipe r where r.userid = 4
select * from cookbookrecipe cr join recipe r on cr.recipeid = r.recipeid where r.userid = 4

select *--c.cookbookname, u.userid, r.recipename 
from cookbookrecipe cr 
left join cookbook c on cr. = c.cookbookid
left join recipe r on r.recipeid = cr.recipeid
left join users u on u.userid = r.userid
where u.userid = 3

select *
from recipe r
join users u
on r.userid = u.userid
where u.userid = 2

DECLARE @i int = 0
select *, seq = ROW_NUMBER() OVER (ORDER BY recipeId) 
from CookBookRecipe*/