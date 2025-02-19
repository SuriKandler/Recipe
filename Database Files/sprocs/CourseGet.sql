create or alter procedure dbo.CourseGet(
	@CourseId int = 0, 
	@CourseName varchar(20) = '',
	@All bit = 0)
as
begin
	select @CourseName = nullif(@CourseName,'')

	select i.CourseId, i.CourseName, i.CourseSequence
	from Course i
	where i.CourseId = @CourseId
	or @All = 1
	or CourseName like '%' + @CourseName + '%'
	order by CourseName
end
go


/*
exec CourseGet

exec CourseGet @CourseName = '' --no results

exec CourseGet @CourseName = 'i' 

exec CourseGet @All = 1

declare @CourseId int
select top 1 @CourseId = i.CourseId from Course i
exec CourseGet @CourseId = @CourseId

select * from Course
*/
