create or alter procedure dbo.CourseDelete(
	@CourseId int,
    @Message varchar(500) = '' output
)
as
begin
    declare @return int = 0

	select @CourseId = isnull(@CourseId,0)
	
	begin try
		begin tran
	delete mcr from MealCourseRecipe mcr join MealCourse mc on mcr.MealCourseId = mc.MealCourseId where mc.CourseId = @CourseId
	delete mc from MealCourse mc where mc.CourseId = @CourseId
	delete c from Course c where c.CourseId = @CourseId
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

/*
create or alter procedure dbo.MedalDelete(
	@MedalId int = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0


end
go
*/