using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServerStatusChecker.Model
{
    [Serializable]
    public class MinecraftServer
    {
        [JsonProperty("online")]
        public bool IsOnline { get; set; }
        [JsonProperty("hostname")]
        public string HostName { get; set; }
        [JsonProperty("ip")]
        public string IpAddress { get; set; }
        [JsonProperty("port")]
        public int ServerPort { get; set; }
        [JsonProperty("version")]
        public string GameVersion { get; set; }
        [JsonProperty("motd")]
        public Motd MessageOfTheDay { get; set; }
        [JsonProperty("players")]
        public Players Players { get; set; }
        [JsonProperty("icon")]
        public string Base64Icon { get; set; } //base64 encoded, decode to display
        [JsonProperty("map")]
        public string MapName { get; set; }
        [JsonProperty("gamemode")]
        public string GameMode { get; set; }
        [JsonProperty("plugins")]
        public Plugins Plugins { get; set; }
        [JsonProperty("mods")]
        public Mods Mods { get; set; }

    }

    public class Players
    {
        [JsonProperty("online")]
        public int Online { get; set; }
        [JsonProperty("max")]
        public int MaxPlayers { get; set; }
        [JsonProperty("list")]
        public string[] PlayerList { get; set; } //might be empty if server settings don't allow for player querying
    }
    public class Motd
    {
        [JsonProperty("raw")]
        public string[] RawMOTD { get; set; } //unprocessed characters still in the string
        [JsonProperty("clean")]
        public string[] CleanMOTD { get; set; } // cleaned up string
        [JsonProperty("html")]
        public string[] HtmlMOTD { get; set; } //html representation of the MOTD
    }
    public class Plugins
    {
        [JsonProperty("names")]
        public string[] PluginNames { get; set; } // only the names of the plugins
        [JsonProperty("raw")]
        public string[] PluginNamesRaw { get; set; } // also the version number of said plugins

    }
    public class Mods
    {
        [JsonProperty("names")]
        public string[] ModNames { get; set; }// only the names of the mods
        [JsonProperty("raw")]
        public string[] ModNamesRaw { get; set; }// also the version number of said mods

    }
}


