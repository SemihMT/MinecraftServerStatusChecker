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
        public static bool UsingLocalRepository { get; private set; } = true;
        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged(nameof(CurrentPage));
                    UpdateCommandText();
                }
            }
        }

        private string _commandText = "SHOW DETAILS";
        public string CommandText
        {
            get { return _commandText; }
            set
            {
                if (_commandText != value)
                {
                    _commandText = value;
                    OnPropertyChanged(nameof(CommandText));
                }
            }
        }

        public RelayCommand SwitchPageCommand { get; set; }


        private string _currentRepoText = "SWITCH TO ONLINE";
        public string CurrentRepoText
        {
            get { return _currentRepoText; }
            set
            {
                if (_currentRepoText != value)
                {
                    _currentRepoText = value;
                    OnPropertyChanged(nameof(CurrentRepoText));
                }
            }
        }
        public RelayCommand SwitchRepositoryCommand { get; set; }

        public void SwitchPage()
        {
            if (CurrentPage is ServerListPage)
            {
                MinecraftServer selectedServer = (ServerListPage.DataContext as ServerListViewModel).SelectedServer;
                if (selectedServer == null) return;

                var serverDetailPage = DetailPage.DataContext as DetailPageVM;
                serverDetailPage.CurrentServer = selectedServer;
                CurrentPage = DetailPage;
            }
            else
            {
                CurrentPage = ServerListPage;
            }
        }

        public void SwitchRepository()
        {
            UsingLocalRepository = !UsingLocalRepository;

            ServerListPage = new ServerListPage();
            DetailPage = new DetailPage();
            CurrentPage = ServerListPage;
            UpdateRepoText();
        }

        public MainViewModel()
        {
            ServerListPage = new ServerListPage();
            DetailPage = new DetailPage();

            CurrentPage = ServerListPage;
            SwitchPageCommand = new RelayCommand(SwitchPage);
            SwitchRepositoryCommand = new RelayCommand(SwitchRepository);
        }

        private void UpdateCommandText()
        {
            if (CurrentPage is ServerListPage)
            {
                CommandText = "SHOW DETAILS";
            }
            else
            {
                CommandText = "GO BACK";
            }
        }

        private void UpdateRepoText()
        {
            if (UsingLocalRepository)
            {
                CurrentRepoText = "SWITCH TO ONLINE";
            }
            else
            {
                CurrentRepoText = "SWITCH TO LOCAL";
            }
        }
    }
}
