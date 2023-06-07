using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using MinecraftServerStatusChecker.Model;
using Newtonsoft.Json;

namespace MinecraftServerStatusChecker
{
    public class MinecraftServerRepository
    {
        private static List<MinecraftServer> _minecraftServers = new List<MinecraftServer>();
    

        public static List<MinecraftServer> GetServers()
        {
            //data list is full, use it
            if (_minecraftServers.Count != 0)
                return _minecraftServers;

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var resourceName = "MinecraftServerStatusChecker.Resources.Data.mc.hypixel.net.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    List<MinecraftServer> servers = JsonConvert.DeserializeObject<List<MinecraftServer>>(json);
                    _minecraftServers.AddRange(servers);
                }

                //list is empty, fill it
                return _minecraftServers;
            }
        }

        public static void AddServerToList(string json)
        {
            MinecraftServer server = JsonConvert.DeserializeObject<MinecraftServer>(json);
            _minecraftServers.Add(server);
        }

     
    }
}
