create or alter procedure dbo.CookbookRecipeDelete(
	@CookbookRecipeId int = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0
	select @CookbookRecipeId  = isnull(@CookbookRecipeId,0)	
--LB: The transaction is not needed.		
	delete CookBookRecipe where CookbookRecipeId = @CookbookRecipeId
	
end
go
