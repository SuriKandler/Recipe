delete r
from Recipe r
where r.RecipeName in('Blueberry Muffins','Fried Fish', 'Pizza')

insert Recipe(UserId, CuisineId, RecipeName, DateDraft, DatePublished, DateArchived, Calories)
select 1, 2, 'Blueberry Muffins', '2022-10-5', '2022-10-10', '2023-01-25', 289 
union select 2, 2, 'Fried Fish', '2020-02-08', null, null, 289 
union select 3, 3, 'Pizza', '2022-06-15', '2022-08-23', null, 289  

