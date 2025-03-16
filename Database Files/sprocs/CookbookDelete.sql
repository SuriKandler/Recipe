create or alter procedure dbo.CookbookDelete(
	@CookbookId int,
    @Message varchar(500) = '' output
)
as
begin
	declare @return int = 0
	--select @CuisineId = isnull(@CuisineId,0)
	
	begin try
		begin tran
        delete CookBookRecipe where CookbookId = @CookbookId
	    delete Cookbook where CookbookId = @CookbookId
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