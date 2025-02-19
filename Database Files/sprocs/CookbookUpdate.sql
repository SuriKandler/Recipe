create or alter procedure dbo.CookbookUpdate(
    @CookbookId int output,
    @UserId int,
    @CookbookName varchar(100),
    @Price int,
    @DateCreated date,
    @Active bit,
    @Message varchar(500) = '' output
)
as
begin
	
	select @CookbookId = isnull(@CookbookId,0)

	if @CookbookId = 0
	begin		
		insert Cookbook(UserId, CookbookName, Price, DateCreated, Active) 
		values(@UserId, @CookbookName, @Price, @DateCreated, @Active)

		select @CookbookId = SCOPE_IDENTITY()
	end
	else
	begin
		update Cookbook
		set
        UserId = @UserId,
        CookbookName = @CookbookName,
        Price = @Price,
        DateCreated = @DateCreated,
        Active = @Active
		where CookbookId = @CookbookId
	end

end
go

/*
exec CookbookUpdate
@CookbookId = 0,
@UserId = 1,
@CookbookName = treats,
@Price = 12,
@DateCreated = '01/01/2020' ,
@Active = 1,
@Message = null
*/