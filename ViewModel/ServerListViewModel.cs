using CommunityToolkit.Mvvm.ComponentModel;
using MinecraftServerStatusChecker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServerStatusChecker.ViewModel
{
    public class ServerListViewModel : ObservableObject
    {
        public List<MinecraftServer> Servers{ get; set; } = new List<MinecraftServer>();
        public MinecraftServer SelectedServer { get; set; }

        public ServerListViewModel()
        {
            Servers = MinecraftServerRepository.GetServers();
        }
    }
}
