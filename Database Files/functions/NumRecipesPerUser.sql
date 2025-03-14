create or alter function dbo.NumRecipesPerUser(@UserId int)
returns int
as
begin
    declare @value int   
    
    select @value = Count(r.RecipeName)
    from recipe r
    where r.UserId = @UserId

    if @value = 0
    return 1
        
    return @value
    
end
go


--exec dbo.NumRecipesPerUser(select UserId = 4 from users)