
exec CuisineGet

exec CuisineGet @cuisineTitle = '' --no results

exec CuisineGet @cuisineTitle = 'i' 

exec CuisineGet @All = 1

declare @CuisineId int
select top 1 @CuisineId = c.CuisineId from Cuisine c
exec CuisineGet @CuisineId = @CuisineID
