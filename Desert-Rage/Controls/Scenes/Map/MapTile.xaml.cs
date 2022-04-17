using DesertRage.Customing.Converters;
using System.Windows;
using System.Windows.Controls;

namespace DesertRage.Controls.Scenes.Map
{
    /// <summary>
    /// Логика взаимодействия для MapTile.xaml
    /// </summary>
    public partial class MapTile : UserControl
    {
        public static readonly DependencyProperty
            PathProperty = DependencyProperty.Register(
                nameof(Path), typeof(string), typeof(MapTile));

        public static readonly DependencyProperty
            XProperty = DependencyProperty.Register(
                nameof(X), typeof(int), typeof(MapTile));

        public static readonly DependencyProperty
            YProperty = DependencyProperty.Register(
                nameof(Y), typeof(int), typeof(MapTile));

        public int X
        {
            get => GetValue(XProperty).ToInt();
            set => SetValue(XProperty, value);
        }

        public int Y
        {
            get => GetValue(YProperty).ToInt();
            set => SetValue(YProperty, value);
        }

        public string Path
        {
            get => GetValue(PathProperty) as string;
            set => SetValue(PathProperty, value);
        }


        public MapTile()
        {
            InitializeComponent();
        }
    }
}