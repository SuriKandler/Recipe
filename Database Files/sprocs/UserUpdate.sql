create or alter procedure dbo.UserUpdate(
    @UserId int output,
    @FirstName varchar(30),
    @LastName varchar(50),
    @UserCode varchar (20),
    @Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @UserId = isnull(@UserId,0)

	if @UserId = 0
	begin		
		insert users(FirstName, LastName, UserName) 
		values(@FirstName, @LastName, @UserCode)

		select @UserId = SCOPE_IDENTITY()
	end
	else
	begin
		update Users
		set
        FirstName = @FirstName,
        LastName = @LastName,
        UserName = @UserCode
		where UserId = @UserId
	end

end
go

--select * from users