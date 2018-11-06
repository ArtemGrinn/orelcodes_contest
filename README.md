# orelcodes_contest	
## Server setup	
Open a command prompt and run the following commands:	
```	
wget -q https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb	
sudo dpkg -i packages-microsoft-prod.deb	
sudo apt-get install apt-transport-https	
sudo apt-get update	
sudo apt-get install aspnetcore-runtime-2.1	
```	
 ## Run	
```dotnet WebApi.dll```	
 ### Reqeust	
```	
{	
  id: 'Rand ID',	
  first_name: 'Rand Name',	
  last_name: 'Rand Last Name',	
}	
```	
### Response	
```	
{	
  "id":"Rand ID",	
  "first_name":"Rand Name 8e29f97d26fb9c33ac642fadcf435615",	
  "last_name":"Rand Last Name 6303ce184a41418f20f330af67d760f8",	
  "current_time":"2018-11-04 09:28 +00:00",	
  "say":"C# is best!"	
}
