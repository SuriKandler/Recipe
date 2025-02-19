create or alter procedure dbo.IngredientDelete(
	@IngredientId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0

		select @IngredientId = isnull(@IngredientId,0)

	delete Ingredient where IngredientId = @IngredientId

	return @return

    /*if exists(select * from Ingredient r where r.IngredientId = @IngredientId and (r.IngredientStatus = 'Archived' and getdate() - r.DateArchived < 30) or r.IngredientStatus = 'Published')
    begin
        select @return = 1, @Message = 'Cannot delete Ingredient, either it has been archived for less than 30 days, or its a published Ingredient.'
        goto finished
    end

	begin try
		begin tran
        delete IngredientDirection where IngredientId = @IngredientId
		delete IngredientIngredient where IngredientId = @IngredientId
		delete Ingredient where IngredientId = @IngredientId
		commit
	end try
	begin catch
		rollback;
		throw
	end catch

    finished: 
    return @return*/
end
go
