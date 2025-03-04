create or alter function dbo.NumCoursesPerMeal(@MealId int)
returns int
as
begin
    declare @value int   
    
    select @value = Count(distinct c.CourseName)
    from mealcourserecipe mcr   
    join mealcourse mc    
    on mcr.mealcourseid = mc.mealcourseid
    join course c
    on c.courseid = mc.CourseId
    join meal m
    on m.mealid = mc.mealid
    where m.mealid = @mealid
    group by m.mealname
    
    return @value
end
go

/*
select NumCoursesPerMeal = dbo.NumCoursesPerMeal(m.mealid), m.*
from meal m
*/