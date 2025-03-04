create or alter procedure dbo.CookbookRecipeDelete(
	@CookbookRecipeId int = 0,
	@Message varchar(500) = ''  output
)
as
begin
declare @return int = 0
select @CookbookRecipeId  = isnull(@CookbookRecipeId,0)
	begin try
		begin tran
		delete CookBookRecipe where CookbookRecipeId = @CookbookRecipeId
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
