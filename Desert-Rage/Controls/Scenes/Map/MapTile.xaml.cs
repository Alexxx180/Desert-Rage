using DesertRage.Model.Helpers;
using DesertRage.Model.Locations;
using DesertRage.ViewModel;
using System.Collections.Generic;
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

        //public static readonly DependencyProperty
        //    IncrementProperty = DependencyProperty.Register(
        //        nameof(Increment), typeof(Position), typeof(MapTile));

        //public Position Increment
        //{
        //    get => (Position)GetValue(YProperty);
        //    set => SetValue(YProperty, value);
        //}

        //public static readonly DependencyProperty
        //    UserProperty = DependencyProperty.Register(
        //        nameof(User), typeof(UserProfile), typeof(MapTile));

        //public UserProfile User
        //{
        //    get => GetValue(YProperty) as UserProfile;
        //    set => SetValue(YProperty, value);
        //}

        //private string Logic()
        //{
        //    string tile = _tiles["."];

        //    Position hero = User.Hero.Place;
        //    Position current = hero + Increment;

        //    if (current.IsOutTop(new Position(0)) ||
        //        current.IsOutBottom(new Position
        //        (_map[hero.Y].Length, _map.Length)))
        //        return tile;

        //    string code = _map.Tile(current).ToString();
        //    if (_tiles.ContainsKey(code))
        //    {
        //        tile = _tiles[code];
        //    }

        //    return tile;
        //}

        public MapTile()
        {
            InitializeComponent();
        }

        //private Dictionary<string, string> _tiles => User.Level.TileCodes;
        //private char[][] _map => User.Level.Map;
    }
}