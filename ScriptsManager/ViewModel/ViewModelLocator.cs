using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace ScriptsManager.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<ManageViewModel>();
        }

        public HomeViewModel HomeViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();
        public ManageViewModel ManageViewModel => ServiceLocator.Current.GetInstance<ManageViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}