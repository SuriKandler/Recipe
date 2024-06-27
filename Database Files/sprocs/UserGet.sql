create or alter procedure dbo.UserGet(
	@UserId int = 0, 
	@All bit = 0, 
	@LastName varchar(50) = '')
as
begin
	select @LastName = nullif(@LastName, '')

	select u.UserId, u.UserName, u.FirstName, u.LastName
	from users u
	where u.UserId = @UserId
	or @All = 1
	or u.LastName like '%' + @LastName + '%'
	order by u.UserId, u.UserName, u.FirstName, u.LastName
end
go


/*
exec UserGet

exec UserGet @LastName = '' --no results

exec UserGet @LastName = 'i' 

exec UserGet @All = 1

declare @UserId int
select top 1 @UserId = u.UserId from Users u
exec UserGet @UserId = @UserId

*/