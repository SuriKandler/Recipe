create or alter procedure dbo.ChangeStatusGet(
	@RecipeId int = 0,
    @Message varchar (1000) = '' output
)
as
begin
    declare @return int = 0
    
	select @RecipeId = nullif(@RecipeId,0)

    select 
        r.RecipeName,
        r.DateDraft,
        r.DatePublished,
        r.DateArchived,
        r.RecipeId,
        r.RecipeStatus
    from Recipe r
    where r.RecipeId = @RecipeId
    
    return @return
end
go


--exec ChangeStatusGet @recipeid = 1
