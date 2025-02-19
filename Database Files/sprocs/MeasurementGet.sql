create or alter procedure dbo.MeasurementGet(
	@MeasurementId int = 0, 
	@MeasurementType varchar(20) = '',
	@IncludeBlank bit = 1,
	@All bit = 0)
as
begin
	select @MeasurementType = nullif(@MeasurementType,' '),@MeasurementId = nullif(@MeasurementId,0), @IncludeBlank = nullif(@IncludeBlank,0)

	select i.MeasurementId, i.MeasurementType
	from Measurement i
	where i.MeasurementId = @MeasurementId
	or @All = 1
	or MeasurementType like '%' + @MeasurementType + '%'
	union select 0,' '
	where @IncludeBlank = 1
	order by MeasurementType
end
go


/*
exec MeasurementGet

exec MeasurementGet @MeasurementType = '' --no results

exec MeasurementGet @MeasurementType = 'i' 

exec MeasurementGet @All = 1

exec MeasurementGet @includeblank = 1

declare @MeasurementId int
select top 1 @MeasurementId = i.MeasurementId from Measurement i
exec MeasurementGet @MeasurementId = @MeasurementId

*/