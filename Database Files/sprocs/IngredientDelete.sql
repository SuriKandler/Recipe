create or alter procedure dbo.IngredientDelete(
	@IngredientId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0

		select @IngredientId = isnull(@IngredientId,0)
	begin try
		begin tran
		
	delete r from RecipeIngredient r where r.IngredientId = @IngredientId
	delete i from Ingredient i where i.IngredientId = @IngredientId

		commit
	end try
	begin catch
		rollback;
		throw
	end catch

    finished: 
    return @return
end
go
