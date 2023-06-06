using CommunityToolkit.Mvvm.ComponentModel;
using MinecraftServerStatusChecker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServerStatusChecker.ViewModel
{
    public class DetailPageVM : ObservableObject
    {
        private MinecraftServer _currentServer;
        public MinecraftServer CurrentServer { get { return _currentServer; } set { _currentServer = value; OnPropertyChanged(nameof(CurrentServer)); } }
        public DetailPageVM()
        {
            CurrentServer = new MinecraftServer{ };
        }
    }
}
