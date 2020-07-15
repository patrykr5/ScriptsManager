using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ScriptsManager.Helper;
using System;
using System.Windows;
using System.Windows.Input;

namespace ScriptsManager.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private Visibility _buttonOpenMenuVisibility;
        private Visibility _buttonCloseMenuVisibility;

        public ICommand CloseCommand { get; }
        public ICommand ButtonOpenMenuCommand { get; set; }
        public ICommand ButtonCloseMenuCommand { get; set; }

        public HomeViewModel()
        {
            CloseCommand = new RelayCommand(CloseApplication);
            ButtonOpenMenuCommand = new RelayCommand(ButtonOpenMenu);
            ButtonCloseMenuCommand = new RelayCommand(ButtonCloseMenu);
            ButtonCloseMenuVisibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu()
        {
            SetVisibilityForButtonOpenCloseMenu(whetherButtonOpenMenuIsClicked: false);
        }

        private void ButtonOpenMenu()
        {
            SetVisibilityForButtonOpenCloseMenu(whetherButtonOpenMenuIsClicked: true);
        }

        private void CloseApplication()
        {
            Environment.Exit(0);
        }

        private void SetVisibilityForButtonOpenCloseMenu(bool whetherButtonOpenMenuIsClicked)
        {
            ButtonOpenMenuVisibility = (!whetherButtonOpenMenuIsClicked).ToVisible();
            ButtonCloseMenuVisibility = whetherButtonOpenMenuIsClicked.ToVisible();
        }

        public Visibility ButtonOpenMenuVisibility
        {
            get => _buttonOpenMenuVisibility;
            set
            {
                if (_buttonOpenMenuVisibility == value)
                {
                    return;
                }
                _buttonOpenMenuVisibility = value;
                RaisePropertyChanged();
            }
        }

        public Visibility ButtonCloseMenuVisibility
        {
            get => _buttonCloseMenuVisibility;
            set
            {
                if (_buttonCloseMenuVisibility == value)
                {
                    return;
                }
                _buttonCloseMenuVisibility = value;
                RaisePropertyChanged();
            }
        }
    }
}