using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds
{
    public class SkillCommand : Battle, INotifyPropertyChanged, IThing
    {
        /// <summary>
        /// Consume hero AP's when used
        /// </summary>

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
            ViewModel.Human.Player.Hero.Act(Value);
            ViewModel.Human.Player.UpdateHero();
        }

        public void SetValue(int value)
        {
            Value = value;
        }

        public bool CanUse => ViewModel.Human.Player.Hero.CanAct(Value);
        #endregion
    }
}