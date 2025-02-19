create or alter procedure dbo.CuisineDelete(
	@CuisineId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0

			select @CuisineId = isnull(@CuisineId,0)

	delete Cuisine where CuisineId = @CuisineId

	return @return

    /*if exists(select * from Cuisine r where r.CuisineId = @CuisineId and (r.CuisineStatus = 'Archived' and getdate() - r.DateArchived < 30) or r.CuisineStatus = 'Published')
    begin
        select @return = 1, @Message = 'Cannot delete Cuisine, either it has been archived for less than 30 days, or its a published Cuisine.'
        goto finished
    end

	begin try
		begin tran
        delete CuisineDirection where CuisineId = @CuisineId
		delete CuisineCuisine where CuisineId = @CuisineId
		delete Cuisine where CuisineId = @CuisineId
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