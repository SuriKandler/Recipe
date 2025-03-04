create or alter proc dbo.CloneaRecipe(
    @RecipeId int = null output,
    @BaseRecipeId int,    
    @Message varchar(1000) = '' output
)
as
begin
    declare @return int = 0
    
    insert Recipe(RecipeName,UserId, CuisineId, DateDraft, Calories)
    select r.RecipeName + ' - clone', r.UserId, r.CuisineId, r.DateDraft, r.Calories
    from recipe r
    where r.RecipeId = @BaseRecipeId
    
    select @RecipeId = scope_identity();

    insert RecipeIngredient(RecipeId, Amount, MeasurementId, IngredientId, RecipeIngredientSequence)
    select @RecipeId, ri.Amount, m.MeasurementId, i.IngredientId, ri.RecipeIngredientSequence
	from RecipeIngredient ri
	join Recipe r
	on r.RecipeId = ri.recipeid
	left join Measurement m
	on ri.MeasurementId = m.MeasurementId
	join Ingredient i
	on ri.IngredientId = i.IngredientId
	where ri.RecipeId = @baseRecipeId

    insert RecipeDirection(RecipeId, DirectionSequence,DirectionDescription)
    select @RecipeId, d.DirectionSequence, d.DirectionDescription
	from RecipeDirection d
	join Recipe r
	on r.RecipeId = d.RecipeId
	where d.recipeid = @baseRecipeId

return @return
end
go

/*
declare 
    @RecipeId int,
    --@RecipeName varchar(500),
    @BaseRecipeId int, 
    @i int,
    @m varchar(500)

  
   --select top 1 @BaseRecipeId = r.recipeid, @RecipeName = r.RecipeName + ' - clone' from recipe r order by r.recipeid desc 
  -- select top 1 @BaseRecipeId = r.recipeid from recipe r order by r.recipeid desc 


--select @RecipeName, @BaseRecipeId

exec @i = CloneaRecipe
    @RecipeId = @RecipeId output,
    --@RecipeName = @RecipeName,
    @BaseRecipeId = 5
  

    select @i, @m

    select * 
    from recipe r
    left join RecipeIngredient ri
    on r.RecipeId = ri.RecipeId
    join RecipeDirection rd
    on rd.RecipeId = r.RecipeId    
    where r.recipeid = @recipeid 
  
  
*/