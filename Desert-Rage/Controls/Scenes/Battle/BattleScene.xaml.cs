using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.Battle;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DesertRage.Controls.Scenes
{
    /// <summary>
    /// Логика взаимодействия для BattleScene.xaml
    /// </summary>
    public partial class BattleScene : UserControl, INotifyPropertyChanged
    {
        public static readonly Range SceneArea;

        private System.Uri _battleBackground;
        public System.Uri BattleBackground
        {
            get => _battleBackground;
            set
            {
                _battleBackground = value;
                OnPropertyChanged();
            }
        }

        public static readonly DependencyProperty
            BattleModelProperty = DependencyProperty.Register(
                nameof(BattleModel), typeof(BattleViewModel),
                typeof(BattleScene));

        public BattleViewModel BattleModel
        {
            get => GetValue(BattleModelProperty) as BattleViewModel;
            set => SetValue(BattleModelProperty, value);
        }

        static BattleScene()
        {
            SceneArea = new Range
            {
                Point1 = new Position(1, 1),
                Point2 = new Position(5, 3)
            };
        }

        public BattleScene(BattleViewModel battle)
        {
            InitializeComponent();
            BattleModel = battle;
        }

        public void ReturnToMap()
        {
            Label container = Parent as Label;
            container.Content = BattleModel.Human.Player.Location;
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion
    }
}