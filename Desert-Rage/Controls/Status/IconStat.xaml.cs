using DesertRage.Customing.Converters;
using System.Windows;
using System.Windows.Controls;

namespace DesertRage.Controls.Status
{
    /// <summary>
    /// Characteristic with image behind
    /// </summary>
    public partial class IconStat : UserControl
    {
        public static readonly DependencyProperty
            IconProperty = DependencyProperty.Register(
                nameof(Icon), typeof(string), typeof(IconStat));

        public static readonly DependencyProperty
            StatProperty = DependencyProperty.Register(
                nameof(Stat), typeof(byte), typeof(IconStat));

        public string Icon
        {
            get => GetValue(IconProperty) as string;
            set => SetValue(IconProperty, value);
        }

        public byte Stat
        {
            get => GetValue(StatProperty).ToByte();
            set => SetValue(StatProperty, value);
        }

        public IconStat()
        {
            InitializeComponent();
            //Icon = "";
        }
    }
}