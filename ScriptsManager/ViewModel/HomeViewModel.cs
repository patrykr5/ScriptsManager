using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using ScriptsManager.Helper;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ScriptsManager.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private Visibility _buttonOpenMenuVisibility;
        private Visibility _buttonCloseMenuVisibility;
        private bool _isCheckedDarkModeToggle;
        private readonly PaletteHelper _paletteHelper = new PaletteHelper();
        private SolidColorBrush _gridMenuBackgroundColor;
        private SolidColorBrush _foregroundColorForMenu;
        private double _gridMenuBlurRadius;
        private double _gridMenuShadowDepth;

        public ICommand CloseCommand { get; }
        public ICommand ButtonOpenMenuCommand { get; set; }
        public ICommand ButtonCloseMenuCommand { get; set; }

        public HomeViewModel()
        {
            CloseCommand = new RelayCommand(CloseApplication);
            ButtonOpenMenuCommand = new RelayCommand(ButtonOpenMenu);
            ButtonCloseMenuCommand = new RelayCommand(ButtonCloseMenu);
            ButtonCloseMenuVisibility = Visibility.Collapsed;
            SetSettingsForGridMenu();
        }

        private void SetThemeApplication()
        {
            ITheme theme = _paletteHelper.GetTheme();
            IBaseTheme baseTheme = _isCheckedDarkModeToggle ? new MaterialDesignDarkTheme() : (IBaseTheme)new MaterialDesignLightTheme();
            theme.SetBaseTheme(baseTheme);
            _paletteHelper.SetTheme(theme);
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
            SolidColorBrush solidColorBrushWhite = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));

            if (whetherMenuIsOpening)
            {
                GridMenuBackgroundColor = solidColorBrushWhite;
                ForegroundColorForMenu = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
                GridMenuBlurRadius = 8;
                GridMenuShadowDepth = 1;
            }
            else
            {
                GridMenuBackgroundColor = new SolidColorBrush(System.Windows.Media.Color.FromRgb(92, 107, 192));
                ForegroundColorForMenu = solidColorBrushWhite;
                GridMenuBlurRadius = 0;
                GridMenuShadowDepth = 0;
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

        public SolidColorBrush GridMenuBackgroundColor
        {
            get => _gridMenuBackgroundColor;
            set
            {
                if (_gridMenuBackgroundColor == value)
                {
                    return;
                }
                _gridMenuBackgroundColor = value;
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
    }
}