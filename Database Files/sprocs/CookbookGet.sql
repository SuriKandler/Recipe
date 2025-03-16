create or alter procedure dbo.CookbookGet(
	@CookbookId int = 0, 
	@All bit = 0
)
as
begin
	
select @CookbookId = nullif(@CookbookId,0), @All = nullif(@All, 0)

	select i.CookbookId, i.CookbookName,i.userId, 
	Author = concat(u.FirstName, ' ', u.LastName), 
	NumRecipes = dbo.NumRecipesPerCookbook(i.cookbookid), i.Price,
	i.DateCreated, i.Active
	from Cookbook i
	join users u
	on u.UserId = i.UserId
	where i.CookbookId = @CookbookId
	or @All = 1
	order by CookbookName
end
go


/*
exec CookbookGet

exec CookbookGet @All = 0

declare @CookbookId int
select top 1 @CookbookId = i.CookbookId from Cookbook i
exec CookbookGet @CookbookId = @CookbookId

select * from Cookbook
*/
