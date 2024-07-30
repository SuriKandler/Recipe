create or alter procedure dbo.RecipeUpdate(
    @RecipeId int output,
    @UserId int,
    @CuisineId int,
    @RecipeName varchar (100),
    @DateDraft datetime,
    @DatePublished datetime,
    @DateArchived datetime,
    @Calories int ,
    @Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @RecipeId = isnull(@RecipeId,0)

	if @RecipeId = 0
	begin		
		insert Recipe(UserId, CuisineId, RecipeName, DateDraft, DatePublished, DateArchived, Calories) 
		values(@UserId, @CuisineId, @RecipeName, @DateDraft, @DatePublished, @DateArchived, @Calories)

		select @RecipeId = SCOPE_IDENTITY()
	end
	else
	begin
		update Recipe
		set
        UserId = @UserId,
        CuisineId = @CuisineId,
        RecipeName = @RecipeName,
        DateDraft = @DateDraft,
        DatePublished = @DatePublished,
        DateArchived = @DateArchived,
        Calories = @Calories
		where RecipeId = @RecipeId
	end

end
go
