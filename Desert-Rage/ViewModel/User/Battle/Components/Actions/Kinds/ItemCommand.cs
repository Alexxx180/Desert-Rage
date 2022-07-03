using DesertRage.Model.Locations.Battle.Things.Storage;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds
{
    public class ItemCommand : Battle, INotifyPropertyChanged, IThing
    {
        private ItemCommand() : this(0) { }

        private ItemCommand(int count)
        {
            SetValue(count);
        }

        public ItemCommand(ItemsID id, int count) : this(count)
        {
            ID = id;
        }

        /// <summary>
        /// Consume specified item count when used
        /// </summary>
        /// <param name="id">Item ID</param>
        public ItemCommand(ItemsID id) : this()
        {
            ID = id;
        }

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
            ViewModel.Human.Player.DecreaseItemCount(ID);
        }

        public void SetValue(int value)
        {
            Value = value;
        }

        public bool CanUse => true; //Value > 0
        #endregion

        public ItemsID ID { get; set; }
    }
}