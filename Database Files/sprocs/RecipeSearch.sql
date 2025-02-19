create or alter procedure dbo.RecipeList(
	@RecipeId int = 0,
    @All bit = 0,
    @IncludeBlank bit = 0,
    @Message varchar (1000) = '' output
)
as
begin
    declare @return int = 0--, @count int = 0
    --declare @t table(recipeid int)

	select @RecipeId = nullif(@RecipeId,''), @All = nullif(@All,0), @IncludeBlank = nullif(@IncludeBlank,0)

    /*insert @t (recipeid)
	select r.RecipeId	
	from Recipe r
    join users u
    on r.userid = u.userid
    
    select @count = count(*)
    from @t

    if @count > 10
        begin
            select @message = concat('Search would return ', @count, ' rows. You are only allowed to return 10 rows')
        goto finished
    end

	select 
	r.RecipeId, r.RecipeName, r.RecipeStatus,  UserName = concat(u.FirstName, ' ', u.Lastname), r.Calories, NumIngredients = count(i.IngredientId)	
	from @t t
    join Recipe r
    on t.recipeid = r.RecipeId
    join users u
    on r.userid = u.userid
    join RecipeIngredient ri
    on ri.RecipeId = r.RecipeId
    join Ingredient i
    on i.IngredientId = ri.IngredientId    
	group by r.RecipeId, r.RecipeName, r.RecipeStatus, u.FirstName,u.Lastname,r.Calories
	order by r.RecipeStatus desc

    finished:*/

    select 
        r.RecipeId, 
        r.RecipeName, 
        r.RecipeStatus,  
        UserName = concat(u.FirstName, ' ', u.Lastname), 
        r.Calories, 
        NumIngredients = count(i.IngredientId),
        ListOrder = 1
    from Recipe r
    join users u
    on r.userid = u.userid
    join RecipeIngredient ri
    on ri.RecipeId = r.RecipeId
    join Ingredient i
    on i.IngredientId = ri.IngredientId 
    where r.RecipeId = @RecipeId
    or @All = 1
    group by r.RecipeId, r.RecipeName, r.RecipeStatus, u.FirstName,u.Lastname,r.Calories
    union select 0,'','','',0,0, ListOrder = 0
    where @IncludeBlank = 1
	order by ListOrder, r.RecipeStatus desc

    return @return
end
go


exec RecipeList @All = 1, @IncludeBlank =1
/*
select *, i.IngredientName
from recipe r
join RecipeIngredient ri
on ri.RecipeId = r.RecipeId
join Ingredient i
on i.IngredientId = ri.IngredientId


exec RecipeList

exec RecipeList @RecipeName = '' --no results

exec RecipeList @RecipeName = 'i' 

exec RecipeList @All = 1

declare @RecipeId int
select top 1 @RecipeId = r.RecipeId from Recipe r
exec RecipeList @RecipeId = @RecipeId

*/