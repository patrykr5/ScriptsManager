using System.Windows;

namespace ScriptsManager.Extensions
{
    public static class Extension
    {
        /// <summary>
        /// If value equal true then Visibility.Visible, if not then Visibility.Collapsed.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Visibility</returns>
        public static Visibility ToVisible(this bool value)
        {
            return value ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
