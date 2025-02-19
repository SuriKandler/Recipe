create or alter procedure dbo.RecipeIngredientGet(
	@RecipeIngredientId int = 0,
	@RecipeId int =0,
	@All bit = 0,
	--@IncludeBlank bit = 1,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @All = isnull(@All,0), @RecipeIngredientId = isnull(@RecipeIngredientId,0), @RecipeId = isnull(@RecipeId,0)--,@IncludeBlank = nullif(@IncludeBlank,0)


	select ri.RecipeIngredientId, ri.RecipeId, ri.MeasurementId,ri.IngredientId, ri.Amount, ri.RecipeIngredientSequence --m.MeasurementType, 
	from RecipeIngredient ri
	join Measurement m
	on m.MeasurementId = ri.MeasurementId
	where RecipeIngredientId = @RecipeIngredientId
	or @All = 1
    or ri.RecipeId = @RecipeId
	--union select 0,0,0,' ',0,0,0
	--where @IncludeBlank = 1
	return @return
end
go

--select * from RecipeIngredient