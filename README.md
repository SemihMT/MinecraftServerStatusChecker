# MinecraftServerStatusChecker
This the C# tool for the ToolDev course @ DAE

Usage:
The app is divided into two pages: one that shows an example list of minecraft server that are part of **Resources/Data/LocalServers.json** and another page that will initially show an empty list and a search bar.
Switching repositories is done by pressing the "SWITCH TO X" button at the bottom of the page.

The page that shows local data is exactly that. The program reads from the provided json array of minecraft servers and displays them. Note that the information displayed is most likely inaccurate by now.

The page with the search bar is the one that's more interesting, as it connects and retrieves data from the Minecraft Server Status API (https://api.mcsrvstat.us/).
Any ip address or hostname that gets searched via the search bar will be sent to the API. If the server at the given address exists it will be listed with the correct information.
If there is no server at said address, the program will list a dummy server with the hostname you provided with an ip adress that displays "not found"

The server list displays the more general pieces of information the API returns:

 - The server icon
 - The hostname
 - the ip address
 - the port
 - the maximum amount of players
 - the current number players online
 - the online status of the server

![image](https://github.com/SemihMT/MinecraftServerStatusChecker/assets/113976242/66da9e06-9128-4774-84dd-17c05535f199)



The detail page gives more detailed information about the server:
 - The message of the day
 - A subset of players that are online (with the player head, acquired using https://mc-heads.net/)
 - If mods are present and their names
 - If plugins are present and their names 

![image](https://github.com/SemihMT/MinecraftServerStatusChecker/assets/113976242/5a81aaa2-8cc3-4e56-8a8a-ca51eb8f6a6a)
