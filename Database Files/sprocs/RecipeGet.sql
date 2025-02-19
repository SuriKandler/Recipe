create or alter procedure dbo.RecipeGet(
	@RecipeId int = 0,
    @All bit = 0,
    @IncludeBlank bit = 1,
    @Message varchar (1000) = '' output
)
as
begin
    declare @return int = 0
    
	select @RecipeId = nullif(@RecipeId,0), @All = nullif(@All,0), @IncludeBlank = nullif(@IncludeBlank,0)

    select 
        r.RecipeId, 
		u.UserId,
		r.CuisineId,
        r.RecipeName, 
        r.RecipeStatus,  
        r.DateDraft,
        r.DatePublished,
        r.DateArchived,
        UserName = concat(u.FirstName, ' ', u.Lastname), 
        r.Calories, 
        NumIngredients = count(i.IngredientId),
        ListOrder = 1
    from Recipe r
    join users u
    on r.userid = u.userid
    left join RecipeIngredient ri
    on ri.RecipeId = r.RecipeId
    left join Ingredient i
    on i.IngredientId = ri.IngredientId 
    where r.RecipeId = @RecipeId
    or @All = 1
    group by r.RecipeId, r.RecipeName, r.RecipeStatus, u.FirstName,u.Lastname,r.Calories,r.CuisineId, u.UserId, r.DateArchived,r.DateDraft,r.DatePublished
    union select 0,0,0,'','','',0,0,'','','', ListOrder = 0
    where @IncludeBlank = 1
	order by ListOrder, r.RecipeStatus desc

    return @return
end
go

/*
select * from recipe
exec RecipeGet @All = 1, @IncludeBlank =0

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

/*create or alter procedure dbo.RecipeGet(
	@RecipeId int = 0, 
	@All bit = 0, 
	@RecipeName varchar(100) = '')
as
begin

	select @RecipeName = nullif(@RecipeName,'')

	select 
	RecipeDesc = dbo.RecipeDesc(r.RecipeId),
	r.RecipeId, r.RecipeName, r.UserId, r.CuisineId, r.RecipeStatus, r.Calories, r.DateDraft, r.DatePublished, r.DateArchived		
	from Recipe r
	where r.RecipeId = @RecipeId
	or @All = 1
	or r.RecipeName like '%' + @RecipeName + '%'
	order by r.RecipeName, r.RecipeStatus
end
go


exec RecipeGet

exec RecipeGet @RecipeName = '' --no results

exec RecipeGet @RecipeName = 'i' 

exec RecipeGet @All = 1

declare @RecipeId int
select top 1 @RecipeId = r.RecipeId from Recipe r
exec RecipeGet @RecipeId = @RecipeId

*/