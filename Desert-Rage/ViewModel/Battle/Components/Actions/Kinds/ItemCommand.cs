using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Components.Actions.Kinds
{
    public class ItemCommand : Battle, INotifyPropertyChanged, IThing
    {
        public ItemCommand(int count)
        {
            Value = count;
        }

        public ItemCommand() : this(0) { }

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
            Value--;
        }

        public bool CanUse => Value > 0;
        #endregion
    }
}