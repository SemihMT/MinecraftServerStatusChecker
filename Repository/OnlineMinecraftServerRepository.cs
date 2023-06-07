using MinecraftServerStatusChecker.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServerStatusChecker.Repository
{
    public class OnlineMinecraftServerRepository
    {
        private static List<MinecraftServer> _onlineMinecraftServers = new List<MinecraftServer>();


        public static List<MinecraftServer> GetServers()
        {
            return _onlineMinecraftServers;
        }

        public static void AddServerToList(MinecraftServer server)
        {

            _onlineMinecraftServers.Add(server);
        }


    }
}
