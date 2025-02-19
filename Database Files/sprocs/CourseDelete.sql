create or alter procedure dbo.CourseDelete(
	@CourseId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0

	select @CourseId = isnull(@CourseId,0)

	delete Course where CourseId = @CourseId

	return @return

  /*  if exists(select * from Course c where c.CourseId = @CourseId)
    begin
        select @return = 1, @Message = 'Cannot delete Course.'
        goto finished
    end

	begin try
		begin tran
        delete MealCourse where CourseId = @CourseId
		delete Course where CourseId = @CourseId
		commit
	end try
	begin catch
		rollback;
		throw
	end catch

    finished: 
    return @return*/
end
go

create or alter procedure dbo.MedalDelete(
	@MedalId int = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0


end
go
