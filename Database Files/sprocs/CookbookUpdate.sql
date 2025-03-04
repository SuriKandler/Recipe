create or alter procedure dbo.CookbookUpdate(
    @CookbookId int output,
    @UserId int,
    @CookbookName varchar(100),
    @Price decimal(5,2),
    @DateCreated date output,
    @Active bit,
    @Message varchar(500) = '' output
)
as
begin
	
	select @CookbookId = isnull(@CookbookId,0)

	if @CookbookId = 0
	begin		
		insert Cookbook(UserId, CookbookName, Price, DateCreated, Active) 
		values(@UserId, @CookbookName, @Price, getdate(), @Active)

		select @CookbookId = SCOPE_IDENTITY()
		select @DateCreated = getdate()
	end
	else
	begin
		update Cookbook
		set
        UserId = @UserId,
        CookbookName = @CookbookName,
        Price = @Price,
        Active = @Active
		where CookbookId = @CookbookId
	end

end
go

/*
exec CookbookUpdate
@CookbookId = 0,
@UserId = 18,
@CookbookName = '4ji',
@Price = 12.36,
--@DateCreated = '01/01/2020' ,
@Active = 1,
@Message = null
*/
