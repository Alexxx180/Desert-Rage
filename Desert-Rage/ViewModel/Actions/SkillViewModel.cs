using DesertRage.Model.Stats.Player;
using DesertRage.Model.Menu.Things;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.ViewModel.Actions
{
    public class SkillViewModel : INotifyPropertyChanged
    {
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

        private SkillCommand _action;
        public SkillCommand Action
        {
            get => _action;
            set
            {
                _action = value;
                OnPropertyChanged();
            }
        }

        //public void Spend()
        //{
        //    Player.Hero.Act(Player.Hero.HeroSkills[0].Value);
        //    Player.UpdateHero();
        //}

        //public bool CanSpend => Player.Hero.CanAct(Player.Hero.HeroSkills[0].Value);

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