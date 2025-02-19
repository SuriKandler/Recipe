create or alter procedure dbo.RecipeDelete(
	@RecipeId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0

    if exists(select * from recipe r where r.RecipeId = @RecipeId and ((r.RecipeStatus = 'Archived' and getdate() - r.DateArchived < 30) or r.RecipeStatus = 'Published'))
    begin
        select @return = 1, @Message = 'Cannot delete recipe, either it has been archived for less than 30 days, or its a published recipe.'
        goto finished
    end

	begin try
		begin tran
        delete RecipeDirection where RecipeId = @RecipeId
		delete RecipeIngredient where RecipeId = @RecipeId
		delete Recipe where RecipeId = @RecipeId
		commit
	end try
	begin catch
		rollback;
		throw
	end catch

    finished: 
    return @return
end
go

select * from Recipe

exec RecipeDelete @recipeid = 2