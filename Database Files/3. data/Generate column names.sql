declare @tablename varchar(50) = 'recipe'

select 
concat('@', c.COLUMN_NAME, ' ', C.DATA_TYPE, ' ', 
	case when C.CHARACTER_MAXIMUM_LENGTH is null then '' else concat('(', C.CHARACTER_MAXIMUM_LENGTH, ')') end,
	case when c.TABLE_NAME + 'Id' = c.COLUMN_NAME then 'output' else '' end,
	','
	)
from INFORMATION_SCHEMA.COLUMNS c
where c.TABLE_NAME = @tablename

declare @insertlist varchar(5000) = ''

select @insertlist = @insertlist + concat(c.column_name, ', ')
from INFORMATION_SCHEMA.COLUMNS c
where c.TABLE_NAME = @tablename
and c.COLUMN_NAME <> c.TABLE_NAME + 'Id'

select @insertlist

select @insertlist = ''

select @insertlist = @insertlist + concat('@', c.column_name, ', ')
from INFORMATION_SCHEMA.COLUMNS c
where c.TABLE_NAME = @tablename
and c.COLUMN_NAME <> c.TABLE_NAME + 'Id'

select @insertlist

select concat(c.column_name, ' = ','@', c.column_name, ', ')
from INFORMATION_SCHEMA.COLUMNS c
where c.TABLE_NAME = @tablename
and c.COLUMN_NAME <> c.TABLE_NAME + 'Id'