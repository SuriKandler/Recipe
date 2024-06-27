create or alter procedure dbo.CuisineGet(
	@CuisineId int = 0, 
	@CuisineTitle varchar(50) = '',
	@All bit = 0)
as
begin
	select @CuisineTitle = nullif(@CuisineTitle,'')

	select c.CuisineId, c.Title
	from cuisine c
	where c.CuisineId = @CuisineId
	or @All = 1
	or c.Title like '%' + @CuisineTitle + '%'
	order by c.Title
end
go


/*
exec CuisineGet

exec CuisineGet @cuisineTitle = '' --no results

exec CuisineGet @cuisineTitle = 'i' 

exec CuisineGet @All = 1

declare @CuisineId int
select top 1 @CuisineId = c.CuisineId from Cuisine c
exec CuisineGet @CuisineId = @CuisineID

*/