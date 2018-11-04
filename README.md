# orelcodes_contest
## Server setup
Open a command prompt and run the following commands:

- wget -q https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb
- sudo dpkg -i packages-microsoft-prod.deb
- sudo apt-get install apt-transport-https
- sudo apt-get update
- sudo apt-get install aspnetcore-runtime-2.1

## Run
- dotnet WebApi.dll --urls http://0.0.0.0:80
