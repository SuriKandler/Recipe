create or alter procedure dbo.RecipeUpdate(
    @RecipeId int output,
    @UserId int,
    @CuisineId int,
    @RecipeName varchar (100),
    @DateDraft datetime output,
    @RecipeStatus varchar(9)output,
    @Calories int ,
    @Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @RecipeId = isnull(@RecipeId,0)


	if @RecipeId = 0
	begin		
		insert Recipe(UserId, CuisineId, RecipeName,Calories, DateDraft)
		values(@UserId, @CuisineId, @RecipeName,@Calories, getdate())

		select @RecipeId = SCOPE_IDENTITY()
        select @DateDraft = getdate()
        
	end
	else
	begin
		update Recipe
		set
        UserId = @UserId,
        CuisineId = @CuisineId,
        RecipeName = @RecipeName,
        Calories = @Calories
		where RecipeId = @RecipeId
	end


    select @RecipeStatus = r.RecipeStatus
    from recipe r
    where r.RecipeId = @RecipeId
    
end
go


/*
exec RecipeUpdate
    @RecipeId = 0,
    @UserId =1,
    @CuisineId =1,
    @RecipeName =huho,
    --@DateDraft datetime,
    --@DatePublished datetime,
   -- @DateArchived datetime,
    @Calories = 33,
    @Message = null

*/

exec RecipeGet
@RecipeId = 7,
@All = null,
@IncludeBlank = 0,
@Message = null