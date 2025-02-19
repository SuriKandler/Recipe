create or alter procedure dbo.ChangeStatusUpdate(
    @RecipeId int = 0,
	@Date DATETIME output,
    @Status varchar(9) output,
    @Message varchar (1000) = '' output
)
as
begin
        
	select @RecipeId = nullif(@RecipeId,0)

    if @Status = 'Draft'
    begin
        update Recipe
        set  
        DateDraft = @Date,
        DatePublished = null,
        DateArchived = null
        from recipe r
        where r.recipeid = @RecipeId
    end
    else if @Status = 'Publish'
    begin
        update Recipe
        set  
        DatePublished = @Date,
        DateArchived = null
        from recipe r
        where r.recipeid = @RecipeId
    end
    else if @Status = 'Archive'
    begin
        update Recipe
        set  
        DateArchived = @Date
        from recipe r
        where r.recipeid = @RecipeId
    end
end
go   

/*
declare @Date datetime = getdate()
select @Date = getdate()

exec ChangeStatusUpdate 
--@Date = @Date,
@status = 'Draft',
@RecipeId = 1

exec ChangeStatusUpdate
@RecipeId = 1,
@Status = Archive,
@Message = null

select * from recipe
*/

--exec ChangeStatusGet @recipeid = 1
