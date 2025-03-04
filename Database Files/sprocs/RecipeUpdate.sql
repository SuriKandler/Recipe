create or alter procedure dbo.RecipeUpdate(
    @RecipeId int output,
    @UserId int,
    @CuisineId int,
    @RecipeName varchar (100),
    @DateDraft date output,
    @RecipeStatus varchar(9)output,
    @Calories int ,
    @Message varchar(500) = '' output
)
as
begin
	
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
    @UserId =17,
    @CuisineId =13,
    @RecipeName =huhoh,
    @DateDraft ='',
    @RecipeStatus = '',
    --@DatePublished datetime,
   -- @DateArchived datetime,
    @Calories = 33,
    @Message = null

select * from recipe

exec RecipeGet
@RecipeId = 7,
@All = null,
@IncludeBlank = 0,
@Message = null*/