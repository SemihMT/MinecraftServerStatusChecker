using CommunityToolkit.Mvvm.ComponentModel;
using MinecraftServerStatusChecker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MinecraftServerStatusChecker.ViewModel
{
    public class DetailPageVM : ObservableObject
    {
        private MinecraftServer _currentServer;
        private List<BitmapImage> _playerHeads = new List<BitmapImage>();
        public List<BitmapImage> PlayerHeads{get{return _playerHeads;} } 
        public MinecraftServer CurrentServer { get { return _currentServer; } set { _currentServer = value; OnPropertyChanged(nameof(CurrentServer)); } }
        public DetailPageVM()
        {
            CurrentServer = new MinecraftServer { };
        }

        public void AddPlayerHeads(MinecraftServer currentServer)
        {

        }
    }
}
