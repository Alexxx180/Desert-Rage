using System.Windows;
using static WpfApp1.Customing.Converters.Converters;

namespace WpfApp1.Helpers
{
    public static class SkillInfo
    {
        public static readonly DependencyProperty NameProperty = DependencyProperty.RegisterAttached(
        "Name", typeof(string), typeof(SkillInfo), new PropertyMetadata(""));
        public static void SetName(DependencyObject element, string value)
        {
            element.SetValue(NameProperty, value);
        }

        public static string GetName(DependencyObject element)
        {
            return element.GetValue(NameProperty).ToString();
        }

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.RegisterAttached(
        "Description", typeof(string), typeof(SkillInfo), new PropertyMetadata(""));
        public static void SetDescription(DependencyObject element, string value)
        {
            element.SetValue(DescriptionProperty, value);
        }

        public static string GetDescription(DependencyObject element)
        {
            return element.GetValue(DescriptionProperty).ToString();
        }

        public static readonly DependencyProperty CostProperty = DependencyProperty.RegisterAttached(
        "Cost", typeof(byte), typeof(SkillInfo), new PropertyMetadata(Bits(0)));
        public static void SetCost(DependencyObject element, byte value)
        {
            element.SetValue(CostProperty, value);
        }

        public static byte GetCost(DependencyObject element)
        {
            return Bits(element.GetValue(CostProperty));
        }
    }
}
