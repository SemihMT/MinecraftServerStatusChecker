using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MinecraftServerStatusChecker.Model;
using Newtonsoft.Json;

namespace MinecraftServerStatusChecker.ViewModel
{
    public class ServerListViewModel : ObservableObject
    {
        public ObservableCollection<MinecraftServer> Servers { get; set; } = new ObservableCollection<MinecraftServer>();
        public MinecraftServer SelectedServer { get; set; }
        public AsyncRelayCommand<string> SearchServerAddress { get; private set; }

        private async Task SearchServer(string serverAddress)
        {
            if (string.IsNullOrEmpty(serverAddress))
                return;

            string endpoint = "https://api.mcsrvstat.us/2/" + serverAddress;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(endpoint);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException(response.ReasonPhrase);
                    }

                    string json = await response.Content.ReadAsStringAsync();

                    MinecraftServer server = JsonConvert.DeserializeObject<MinecraftServer>(json);
                    if (server.IpAddress == "127.0.0.1" && server.IsOnline == false)
                    {
                        //This server does not exist, ip address returned is localhost
                        MinecraftServer failedServer = new MinecraftServer
                        {
                            IpAddress = "not found",
                            HostName = serverAddress,
                            IsOnline = false,
                            
                           
                        };
                        MinecraftServerRepository.AddServerToList(failedServer);
                        //Update the observable collection
                        Servers.Clear();
                        foreach (var s in MinecraftServerRepository.GetServers())
                        {
                            Servers.Add(s);
                        }
                        return;
                    }
                    MinecraftServerRepository.AddServerToList(server);

                    //Update the observable collection
                    Servers.Clear();
                    foreach (var s in MinecraftServerRepository.GetServers())
                    {
                        Servers.Add(s);
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Handle exception
                    Console.WriteLine(ex.Message);

                }
            }
        }

        public ServerListViewModel()
        {
            foreach (var server in MinecraftServerRepository.GetServers())
            {
                Servers.Add(server);
            }

            SearchServerAddress = new AsyncRelayCommand<string>(SearchServer);
        }
    }
}
