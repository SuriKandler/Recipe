create or alter procedure dbo.RecipeDirectionUpdate(
	@DirectionId int = 0 output,
	@RecipeId int ,
    @DirectionSequence int,
    @DirectionDescription varchar(1000),
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @DirectionId = isnull(@DirectionId,0)

	if @DirectionId = 0
	begin
		insert RecipeDirection(RecipeId, DirectionSequence, DirectionDescription)
		values(@RecipeId, @DirectionSequence, @DirectionDescription)

		select @DirectionId= scope_identity()
	end
	else
	begin
		update RecipeDirection
		set
			RecipeId = @RecipeId,
            DirectionSequence = @DirectionSequence,
            DirectionDescription = @DirectionDescription
		where DirectionId = @DirectionId
	end

	return @return
end
go

--select * from RecipeDirection
/*
exec RecipeDirectionUpdate
@DirectionId = 14,
@RecipeId = 1,
@DirectionSequence = 1,
@DirectionDescription = 'Slit bread every 1/2 inch',
@Message = null
*/