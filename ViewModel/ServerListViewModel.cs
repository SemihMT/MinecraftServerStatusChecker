using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MinecraftServerStatusChecker.Model;

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
                    MinecraftServerRepository.AddServerToList(json);

                    Servers.Clear();
                    foreach (var server in MinecraftServerRepository.GetServers())
                    {
                        Servers.Add(server);
                    }
                }
                catch
                {
                    // Handle exception
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
