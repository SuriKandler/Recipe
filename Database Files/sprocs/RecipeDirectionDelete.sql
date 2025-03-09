create or alter procedure dbo.RecipeDirectionDelete(
	@DirectionId int = 0,
--LB: This parameter is not needed. 
	@RecipeId int = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @DirectionId = isnull(@DirectionId,0)

	delete RecipeDirection where DirectionId = @DirectionId

	return @return
end
go

