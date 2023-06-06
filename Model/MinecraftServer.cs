using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServerStatusChecker.Model
{
    public class MinecraftServer
    {
        public bool IsOnline { get; set; }
        public string HostName { get; set; }
        public string IpAddress { get; set; }
        public int ServerPort { get; set; }
        public string GameVersion { get; set; }
        public string MessageOfTheDay { get; set; }
        public Players Players { get; set; }
        public string Base64Icon { get; set; } //base64 encoded, decode to display
        public string MapName { get; set; }
        public string GameMode { get; set; }
        public string[] Plugins { get; set; }
        public string[] Mods { get; set; }

    }

    public class Players
    {
        public int Online { get; set; }
        public int MaxPlayers { get; set; }
        public string[] PlayerList { get; set; } //might be empty if server settings don't allow for player querying
    }
}


