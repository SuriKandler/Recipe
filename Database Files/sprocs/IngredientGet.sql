create or alter procedure dbo.IngredientGet(
	@IngredientId int = 0, 
	@IngredientName varchar(30) = '',
	@All bit = 0)
as
begin
	select @IngredientName = nullif(@IngredientName,'')

	select i.IngredientId, i.IngredientName
	from Ingredient i
	where i.IngredientId = @IngredientId
	or @All = 1
	or IngredientName like '%' + @IngredientName + '%'
	order by IngredientName
end
go


/*
exec IngredientGet

exec IngredientGet @IngredientName = '' --no results

exec IngredientGet @IngredientName = 'i' 

exec IngredientGet @All = 1

declare @IngredientId int
select top 1 @IngredientId = i.IngredientId from Ingredient i
exec IngredientGet @IngredientId = @IngredientId

*/