using DesertRage.Model.Helpers;
using System.Windows;
using System.Windows.Controls;

namespace DesertRage.Controls.Scenes.Map
{
    /// <summary>
    /// Positioned tile of game map
    /// </summary>
    public partial class MapTile : UserControl
    {
        #region Path Members
        public static readonly DependencyProperty
            PathProperty = DependencyProperty.Register(
                nameof(Path), typeof(string), typeof(MapTile));

        public string Path
        {
            get => GetValue(PathProperty) as string;
            set => SetValue(PathProperty, value);
        }
        #endregion

        #region X Vector Members
        public static readonly DependencyProperty
            XProperty = DependencyProperty.Register(
                nameof(X), typeof(int), typeof(MapTile));

        public int X
        {
            get => GetValue(XProperty).ToInt();
            set => SetValue(XProperty, value);
        }
        #endregion

        #region Y Vector Members
        public static readonly DependencyProperty
            YProperty = DependencyProperty.Register(
                nameof(Y), typeof(int), typeof(MapTile));

        public int Y
        {
            get => GetValue(YProperty).ToInt();
            set => SetValue(YProperty, value);
        }
        #endregion

        public MapTile()
        {
            InitializeComponent();
        }
    }
}