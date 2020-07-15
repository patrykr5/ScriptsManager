using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace ScriptsManager.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; }

        public HomeViewModel()
        {
            CloseCommand = new RelayCommand(CloseApplication);
        }

        private void CloseApplication()
        {
            Environment.Exit(0);
        }
    }
}