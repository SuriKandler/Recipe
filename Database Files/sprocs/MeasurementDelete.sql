create or alter procedure dbo.MeasurementDelete(
	@MeasurementId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0

		select @MeasurementId = isnull(@MeasurementId,0)

	delete Measurement where MeasurementId = @MeasurementId

	return @return

    /*if exists(select * from Measurement r where r.MeasurementId = @MeasurementId and (r.MeasurementStatus = 'Archived' and getdate() - r.DateArchived < 30) or r.MeasurementStatus = 'Published')
    begin
        select @return = 1, @Message = 'Cannot delete Measurement, either it has been archived for less than 30 days, or its a published Measurement.'
        goto finished
    end

	begin try
		begin tran
        delete MeasurementDirection where MeasurementId = @MeasurementId
		delete MeasurementIngredient where MeasurementId = @MeasurementId
		delete Measurement where MeasurementId = @MeasurementId
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

