using DesertRage.Controls.Scenes;
//using DesertRage.Controls.Scenes.Battle.Avatar;
using DesertRage.Controls.Scenes.Battle.Strategy.Appear;
using DesertRage.Controls.Scenes.Map;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Map;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DesertRage.Model.Stats.Enemy;
using System.Windows.Input;

namespace DesertRage.ViewModel
{
    public class BattleViewModel : INotifyPropertyChanged
    {
        public ICommand Skill { get; set; }
        private EnemyAppearing _drawStrategy;

        private ObservableCollection<Foe> _enemies;
        public ObservableCollection<Foe> Enemies
        {
            get => _enemies;
            set
            {
                _enemies = value;
                OnPropertyChanged();
            }
        }

        public BattleViewModel()
        {
            Player = LevelMap.GetUserData();
            _drawStrategy = new DockStrategy
                (this, BattleScene.SceneArea, FoesList()); //

            Enemies = _drawStrategy.Build();


            //foreach (Foe enemy in _enemies)
            //{
            //    Trace.WriteLine(enemy.Name);
            //    Trace.WriteLine(new Range(enemy.Tile, enemy.Size).ToString());
            //}
                
        }

        private UserProfile _player;
        public UserProfile Player
        {
            get => _player;
            set
            {
                _player = value;
                OnPropertyChanged();
            }
        }

        private Foe[] FoesList()
        {
            Foe[] foes = Location.GetFoes();

            return new Foe[]
            {
                foes[0], foes[1],
                foes[2], foes[3],
            };
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