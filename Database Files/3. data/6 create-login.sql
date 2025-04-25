-- IMPORTANT create login in MASTER
--use Master
create login appadmin with password = '*****'

if @@SERVERNAME like '%SQLExpress%'
begin
	alter login appadmin with password = 'qwe123!@#'

end

--IMPORTANT switch to HeartyHearthDB
--use HeartyHearthDB
create user appadmin_user from login appadmin