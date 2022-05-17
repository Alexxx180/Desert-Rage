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
using DesertRage.ViewModel.Actions;
using DesertRage.Model.Menu.Things;
using DesertRage.ViewModel.Actions.Dependent;
using DesertRage.ViewModel.Actions.Independent;

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

        private ObservableCollection<ActCommand> _skills;
        public ObservableCollection<ActCommand> Skills
        {
            get => _skills;
            set
            {
                _skills = value;

                foreach (ActCommand skill in _skills)
                {
                    skill.SetViewModel(this);
                }
                    
                OnPropertyChanged();
            }
        }

        public static ObservableCollection<ActCommand>
            GetSkills(List<Skill> skills)
        {
            Skill cure = skills[0];
            Skill cure2 = skills[1];
            Skill fire = skills[6];

            return new ObservableCollection<ActCommand>
            {
                new CureCommand(new SkillCommand(cure)),
                new CureMaxCommand(new SkillCommand(cure2)),
                new FightCommand(new SkillCommand(fire))
            };
        }

        public BattleViewModel()
        {
            Player = LevelMap.GetUserData();
            _drawStrategy = new DockStrategy
                (this, BattleScene.SceneArea, FoesList()); //

            Enemies = _drawStrategy.Build();

            Skills = GetSkills(Player.Hero.HeroSkills);
            
            //foreach (Foe enemy in _enemies)
            //{
            //    Trace.WriteLine(enemy.Name);
            //    Trace.WriteLine(new Range(enemy.Tile, enemy.Size).ToString());
            //}

        }

        public void UpdatePlayer()
        {
            OnPropertyChanged(nameof(Player));
        }

        public void UpdateEnemies()
        {
            OnPropertyChanged(nameof(Enemies));
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