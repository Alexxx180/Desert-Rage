using DesertRage.Controls.Scenes.Battle.Avatar;
using DesertRage.Controls.Scenes.Map;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Map;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesertRage.ViewModel
{
    public class BattleViewModel : INotifyPropertyChanged
    {
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
            RegularBattleStrategy();
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

        private void RegularBattleStrategy()
        {
            Model.Stats.Enemy.Foe[] foes = Location.GetFoes();

            Model.Stats.Enemy.Foe[]
                locationFoes = new
                Model.Stats.Enemy.Foe[]
            {
                foes[0], foes[1],
                foes[2], foes[3],
            };
            //locationFoes.Length
            Random randomApproach = new Random();
            //randomApproach.Next();
            int count = randomApproach.Next(1, 5);
            for (byte i = 0; i < count; i++)
            {

                Foe foe = new Foe
                {
                    Battle = this,
                    Tile = new Position(1)
                };

                Enemies.Add(foe);
            }
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