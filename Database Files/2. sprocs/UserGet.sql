create or alter procedure dbo.UserGet(
	@UserId int = 0, 
	@All bit = 0, 
	@IncludeBlank bit = 0,
	@LastName varchar(50) = ''
)
as
begin
	select @LastName = nullif(@LastName, ''), @UserId = nullif(@UserId,0), @IncludeBlank = nullif(@IncludeBlank,0)

	select u.UserId, 
	UserCode = u.UserName, 
	u.FirstName,
	u.LastName,
	UserName = concat(u.FirstName,' ', u.LastName), 
	ListOrder = 1
	from users u
	where u.UserId = @UserId
	or @All = 1
	or u.LastName like '%' + @LastName + '%'
	union select 0,'','','','',Listorder = 0
	where @IncludeBlank = 1
	order by ListOrder, u.UserId
end
go


/*
exec UserGet

exec UserGet @LastName = '' --no results

exec UserGet @LastName = 'i' 

exec UserGet @All = 0

declare @UserId int
select top 1 @UserId = u.UserId from Users u
exec UserGet @UserId = @UserId

*/