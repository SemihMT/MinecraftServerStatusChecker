# MinecraftServerStatusChecker

This is a C# tool for the ToolDev course @ DAE.

## Usage

The app is divided into two pages:
1. **Local Servers Page:** Shows a list of Minecraft servers from `Resources/Data/LocalServers.json`.
2. **Search Page:** Initially shows an empty list and a search bar for querying servers via the Minecraft Server Status API.

Switching between pages is done by pressing the "SWITCH TO X" button at the bottom of the page.

### Local Servers Page

The local data page displays servers read from the provided JSON array. Note that the displayed information may be outdated.

### Search Page

The search page connects to the [Minecraft Server Status API](https://api.mcsrvstat.us/). When an IP address or hostname is searched, it is sent to the API. If the server exists, it will be listed with accurate information. If not, a dummy server with the provided hostname and "not found" IP address will be shown.

The server list displays the following information returned by the API:
- Server icon
- Hostname
- IP address
- Port
- Maximum number of players
- Current number of players online
- Online status of the server

![Local Servers Page](https://github.com/SemihMT/MinecraftServerStatusChecker/assets/113976242/66da9e06-9128-4774-84dd-17c05535f199)

### Detail Page

The detail page provides more detailed information about the server:
- Message of the day
- Subset of online players (with player heads from [mc-heads.net](https://mc-heads.net/))
- List of mods (if present)
- List of plugins (if present)

![Detail Page](https://github.com/SemihMT/MinecraftServerStatusChecker/assets/113976242/5a81aaa2-8cc3-4e56-8a8a-ca51eb8f6a6a)

Feel free to modify as needed!
