create or alter procedure dbo.IngredientUpdate(
    @IngredientId int output,
    @IngredientName varchar (30),
    @Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @IngredientId = isnull(@IngredientId,0)

	if @IngredientId = 0
	begin		
		insert Ingredient(IngredientName) 
		values(@IngredientName)

		select @IngredientId = SCOPE_IDENTITY()
	end
	else
	begin
		update Ingredient
		set
        IngredientName = @IngredientName
        where IngredientId = @IngredientId
	end

end
go

--select * from Ingredient where IngredientName = 'milk'