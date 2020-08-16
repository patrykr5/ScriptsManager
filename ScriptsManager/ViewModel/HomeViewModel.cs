using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using ScriptsManager.Extensions;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ScriptsManager.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private Visibility _buttonOpenMenuVisibility;
        private Visibility _buttonCloseMenuVisibility;
        private Visibility _menuItemsVisibility;
        private bool _isCheckedDarkModeToggle;
        private readonly PaletteHelper _paletteHelper = new PaletteHelper();
        private SolidColorBrush _foregroundColorForMenu;
        private double _gridMenuBlurRadius;
        private double _gridMenuShadowDepth;
        private Thickness _gridMenuMargin;
        private ViewModelBase _currentViewModel;

        public ICommand CloseCommand { get; }
        public ICommand ButtonOpenMenuCommand { get; set; }
        public ICommand ButtonCloseMenuCommand { get; set; }
        public ICommand ButtonItemHomeMenuCommand { get; set; }
        public ICommand ButtonItemManageMenuCommand { get; set; }
        public ICommand GridMenuLostFocusCommand { get; set; }

        public HomeViewModel()
        {
            CloseCommand = new RelayCommand(CloseApplication);
            ButtonOpenMenuCommand = new RelayCommand(ButtonOpenMenu);
            ButtonCloseMenuCommand = new RelayCommand(ButtonCloseMenu);
            ButtonItemHomeMenuCommand = new RelayCommand(ButtonItemHomeMenu);
            ButtonItemManageMenuCommand = new RelayCommand(ButtonItemManageMenu);
            GridMenuLostFocusCommand = new RelayCommand(GridMenuLostFocus);
            ButtonCloseMenuVisibility = Visibility.Collapsed;
            SetForegroundColorForMenu(_isCheckedDarkModeToggle);
            SetSettingsForGridMenu();
        }

        private void GridMenuLostFocus()
        {
            throw new NotImplementedException();
        }

        private void ButtonItemManageMenu()
        {
            CurrentViewModel = new ManageViewModel();
        }

        private void ButtonItemHomeMenu()
        {
            CurrentViewModel = this;
        }

        private void SetThemeApplication()
        {
            ITheme theme = _paletteHelper.GetTheme();
            IBaseTheme baseTheme = _isCheckedDarkModeToggle ? new MaterialDesignDarkTheme() : (IBaseTheme)new MaterialDesignLightTheme();
            theme.SetBaseTheme(baseTheme);
            _paletteHelper.SetTheme(theme);
            SetForegroundColorForMenu(_isCheckedDarkModeToggle);
        }

        private void ButtonCloseMenu()
        {
            SetVisibilityForButtonOpenCloseMenu(whetherButtonOpenMenuIsClicked: false);
            SetSettingsForGridMenu();
        }

        private void ButtonOpenMenu()
        {
            SetVisibilityForButtonOpenCloseMenu(whetherButtonOpenMenuIsClicked: true);
            SetSettingsForGridMenu(true);
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

        private void SetSettingsForGridMenu(bool whetherMenuIsOpening = false)
        {
            if (whetherMenuIsOpening)
            {
                MenuItemsVisibility = Visibility.Visible;
                GridMenuBlurRadius = 8;
                GridMenuShadowDepth = 1;
                GridMenuMargin = new Thickness();
            }
            else
            {
                MenuItemsVisibility = Visibility.Collapsed;
                GridMenuBlurRadius = 0;
                GridMenuShadowDepth = 0;
                GridMenuMargin = new Thickness(0, 60, 0, 0);
            }
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

        public bool IsCheckedDarkModeToggle
        {
            get => _isCheckedDarkModeToggle;
            set
            {
                if (_isCheckedDarkModeToggle == value)
                {
                    return;
                }
                _isCheckedDarkModeToggle = value;
                SetThemeApplication();
                RaisePropertyChanged();
            }
        }

        public SolidColorBrush ForegroundColorForMenu
        {
            get => _foregroundColorForMenu;
            set
            {
                if (_foregroundColorForMenu == value)
                {
                    return;
                }
                _foregroundColorForMenu = value;
                RaisePropertyChanged();
            }
        }

        public double GridMenuBlurRadius
        {
            get => _gridMenuBlurRadius;
            set
            {
                if (_gridMenuBlurRadius == value)
                {
                    return;
                }
                _gridMenuBlurRadius = value;
                RaisePropertyChanged();
            }
        }

        public double GridMenuShadowDepth
        {
            get => _gridMenuShadowDepth;
            set
            {
                if (_gridMenuShadowDepth == value)
                {
                    return;
                }
                _gridMenuShadowDepth = value;
                RaisePropertyChanged();
            }
        }

        public Thickness GridMenuMargin
        {
            get => _gridMenuMargin;
            set
            {
                if (_gridMenuMargin == value)
                {
                    return;
                }
                _gridMenuMargin = value;
                RaisePropertyChanged();
            }
        }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel == value)
                {
                    return;
                }
                _currentViewModel = value;
                RaisePropertyChanged();
            }
        }

        public Visibility MenuItemsVisibility
        {
            get => _menuItemsVisibility;
            set
            {
                if (_menuItemsVisibility == value)
                {
                    return;
                }
                _menuItemsVisibility = value;
                RaisePropertyChanged();
            }
        }

        private void SetForegroundColorForMenu(bool whetherSetColorForDarkTheme)
        {
            System.Windows.Media.Color color = whetherSetColorForDarkTheme ? System.Windows.Media.Color.FromRgb(255, 255, 255) : System.Windows.Media.Color.FromRgb(0, 0, 0);
            ForegroundColorForMenu = new SolidColorBrush(color);
        }
    }
}