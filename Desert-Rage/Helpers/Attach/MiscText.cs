using System.Windows;

namespace DesertRage.Helpers.Attach
{
    public static class MiscText
    {
        public static readonly DependencyProperty PathProperty = DependencyProperty.RegisterAttached(
        "Path", typeof(string), typeof(MiscText), new PropertyMetadata(""));

        public static void SetPath(DependencyObject element, string value)
        {
            element.SetValue(PathProperty, value);
        }

        public static string GetPath(DependencyObject element)
        {
            return element.GetValue(PathProperty).ToString();
        }
    }
}
