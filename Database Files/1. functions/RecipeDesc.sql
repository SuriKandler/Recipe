create or alter function dbo.RecipeDesc(@RecipeId int)
returns varchar(200)
as
begin
    declare @value varchar(200)

    select @value = concat(r.RecipeName, ' (', c.Title, ') ', 'has ', count(distinct ri.RecipeIngredientId), ' ingredients and ', count(distinct rd.DirectionId), ' steps.')
    from recipe r
    left join cuisine c
    on r.CuisineId = c.CuisineId
    left join RecipeIngredient ri
    on r.recipeid = ri.recipeid
    left join RecipeDirection rd
    on r.recipeid = rd.RecipeId
    where r.RecipeId = @RecipeId
    group by r.RecipeName, c.Title

    return @value
end
go

/*
select Recipedesc = dbo.RecipeDesc(r.recipeid),*
from Recipe r
*/