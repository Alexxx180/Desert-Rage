using System.Windows;

namespace DesertRage.Decorators.UI
{
    public static class Framework
    {
        public static void SetActive
            (this FrameworkElement element, bool setToActive)
        {
            element.IsEnabled = setToActive;
            element.Visibility = setToActive ?
                Visibility.Visible :
                Visibility.Collapsed;
        }
    }
}