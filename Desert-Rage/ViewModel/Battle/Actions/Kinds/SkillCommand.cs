using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds
{
    public class SkillCommand : Battle, INotifyPropertyChanged, IThing
    {
        public SkillCommand(int cost)
        {
            Value = cost;
        }

        public SkillCommand() : this(0) { }

        #region IThing Members
        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public void Use()
        {
            ViewModel.Player.Hero.Act(Value);
            ViewModel.Player.UpdateHero();
        }

        public bool CanUse => ViewModel.Player.Hero.CanAct(Value);
        #endregion
    }
}