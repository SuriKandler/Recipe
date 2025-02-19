create or alter procedure dbo.MeasurementUpdate(
    @MeasurementId int output,
    @Measurementtype varchar (20),
    @Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @MeasurementId = isnull(@MeasurementId,0)

	if @MeasurementId = 0
	begin		
		insert Measurement(MeasurementType) 
		values(@Measurementtype)
		select @MeasurementId = SCOPE_IDENTITY()
	end
	else
	begin
		update Measurement
		set
        MeasurementType = @MeasurementType
        where MeasurementId = @MeasurementId
	end

end
go


--select * from Measurement