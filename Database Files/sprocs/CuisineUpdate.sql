create or alter procedure dbo.CuisineUpdate(
    @CuisineId int output,
    @Title varchar (50),
    @Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @CuisineId = isnull(@CuisineId,0)

	if @CuisineId = 0
	begin		
		insert Cuisine(Title) 
		values(@Title)

		select @CuisineId = SCOPE_IDENTITY()
	end
	else
	begin
		update Cuisine
		set
        Title = @Title
		where CuisineId = @CuisineId
	end

end
go

--select * from Cuisine