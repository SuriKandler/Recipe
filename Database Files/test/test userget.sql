exec UserGet

exec UserGet @LastName = '' --no results

exec UserGet @LastName = 'i' 

exec UserGet @All = 1

declare @UserId int
select top 1 @UserId = u.UserId from Users u
exec UserGet @UserId = @UserId