create or alter proc dbo.DashboardGet(
    @Message varchar (500) = '' output
)
as
begin
    declare @return int = 0

        select Type = 'Recipes', Number = count(*) from recipe
        union select Type = 'Meals', Number = count(*) from Meal
        union select Type = 'Cookbooks', Number = count(*) from Cookbook
        order by type desc
    return @return
end