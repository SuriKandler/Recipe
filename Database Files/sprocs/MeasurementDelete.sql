create or alter procedure dbo.MeasurementDelete(
	@MeasurementId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0

		select @MeasurementId = isnull(@MeasurementId,0)
	begin try
		delete r from RecipeIngredient r where r.MeasurementId = @MeasurementId
		delete m from Measurement m where m.MeasurementId = @MeasurementId
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

