--replace //loginname// and //password with secret values from vault
/*
Database: HeartyHearthDB
1. SQL Server: dev-sk.database.windows.net
2. SQL login: dev_login, 
   SQL password: //password//
3. Firewall Details: 
    Login: //login//, 
    Password://Password//
4. add following recipe:

Pasta alla vodka

2 tbsp olive oil
½ onion, 
3 garlic cloves,
¼ tsp chilli flakes
100g tomato purée
5 tbsp vodka
100ml double cream
200g penne or rigatoni pasta
30g grated parmesan
small handful of basil leaves, to serve 


Fry onion in oil on a low heat for 10 mins or until softened and translucent. 
Add the garlic and chilli flakes and cook for 30 seconds. 
Stir through the tomato purée, cook for 2 mins, 
then stir through the vodka and cook for 3 mins. 
Quickly stir through the cream to combine, then remove from the heat.
Cook the pasta drain 
Tossing everything together until well coated
Season to taste, then serve with basil leaves scattered over the top.
*/

create user dev_user from login dev_login

alter role db_datareader add member dev_user
alter role db_datawriter add member dev_user