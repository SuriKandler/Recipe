create or alter procedure dbo.RecipeIngredientUpdate(
	@RecipeIngredientId int  output,
	@RecipeId int ,
	@MeasurementId int ,
	@IngredientId int,
    @Amount int,
    @RecipeIngredientSequence int,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @RecipeIngredientId = isnull(@RecipeIngredientId,0), @MeasurementId = nullif(@MeasurementId, 0)

	if @RecipeIngredientId = 0
	begin
		insert RecipeIngredient(RecipeId, MeasurementId, IngredientId, Amount, RecipeIngredientSequence)
		values(@RecipeId, @MeasurementId, @IngredientId, @Amount, @RecipeIngredientSequence)

		select @RecipeIngredientId= scope_identity()
	end
	else
	begin
		update RecipeIngredient
		set
			RecipeId = @RecipeId,
            MeasurementId = @MeasurementId,
            IngredientId = @IngredientId,
            Amount = @Amount,
            RecipeIngredientSequence = @RecipeIngredientSequence
		where RecipeIngredientId = @RecipeIngredientId
	end

	return @return
end
go

--select * from recipeingredient

