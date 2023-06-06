using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MinecraftServerStatusChecker.Model;
using MinecraftServerStatusChecker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MinecraftServerStatusChecker.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public ServerListPage ServerListPage { get; set; }
        public DetailPage DetailPage { get; set; }
        private Page _currentPage;
        public Page CurrentPage { get { return _currentPage; } set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); } }
        public RelayCommand SwitchPageCommand{ get; set; }  
        public void SwitchPage()
        {
            if(CurrentPage is ServerListPage)
            {
                MinecraftServer selecterdServer = (ServerListPage.DataContext as ServerListViewModel) .SelectedServer;
                if(selecterdServer == null) return;

                var serverDetailPage = DetailPage.DataContext as DetailPageVM;
                serverDetailPage.CurrentServer = selecterdServer;
                CurrentPage = DetailPage;
            }
        }

        public MainViewModel()
        {
            ServerListPage = new ServerListPage();
            DetailPage = new DetailPage();

            CurrentPage = ServerListPage;
            SwitchPageCommand = new RelayCommand(SwitchPage);
        }
    }
}
