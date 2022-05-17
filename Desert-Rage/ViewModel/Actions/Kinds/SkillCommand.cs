using System.ComponentModel;
using System.Runtime.CompilerServices;
using DesertRage.Model.Menu.Things;

namespace DesertRage.ViewModel.Actions
{
    public class SkillCommand : INotifyPropertyChanged, IThing
    {
        public SkillCommand() { }

        public SkillCommand(Skill skill)
        {
            Ability = skill;
        }

        private BattleViewModel _viewModel;
        public BattleViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        private Skill _ability;
        public Skill Ability
        {
            get => _ability;
            set
            {
                _ability = value;
                OnPropertyChanged();
            }
        }

        public void Use()
        {
            ViewModel.Player.Hero.Act(Ability.Value);
            ViewModel.Player.UpdateHero();
        }

        public bool CanUse => ViewModel.Player.Hero.CanAct(Ability.Value);
        public float Power => ViewModel.Player.Hero.Special * Ability.Power;

        public ValuableUnit Unit => Ability;

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