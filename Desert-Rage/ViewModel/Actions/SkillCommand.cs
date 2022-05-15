using DesertRage.Model.Stats.Player;
using DesertRage.Model.Menu.Things;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DesertRage.Customing.Converters;

namespace DesertRage.ViewModel.Actions
{
    public class SkillCommand : INotifyPropertyChanged, IAttributeThing
    {
        private Skill _skill;
        public Skill Skill
        {
            get => _skill;
            set
            {
                _skill = value;
                OnPropertyChanged();
            }
        }

        private Character _hero;
        public Character Hero
        {
            get => _hero;
            set
            {
                _hero = value;
                OnPropertyChanged();
            }
        }

        #region IAttributeThing Members
        public void Spend()
        {
            Hero.Act(Skill.Cost);
            OnPropertyChanged(nameof(Hero));
        }

        public bool CanSpend => Hero.CanAct(Skill.Cost);
        public int Attribute => (Skill.Power * Hero.Special).ToInt();
        #endregion

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