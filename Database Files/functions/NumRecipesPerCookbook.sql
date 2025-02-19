create or alter function dbo.NumRecipesPerCookbook(@CookBookId int)
returns int
as
begin
    declare @value int   
    
    select @value = Count(r.RecipeName)
    from recipe r
    join cookbookrecipe cr
    on cr.recipeid = r.recipeid
    where cr.cookbookid = @CookbookId  
    
    return @value
end
go

select NumRecipesPerCookbook = dbo.NumRecipesPerCookbook(cb.cookbookid), cb.*
from cookbook cb
