using DesertRage.Model.Menu.Things;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.ViewModel.Actions
{
    public class ItemCommand : IThing, INotifyPropertyChanged
    {
        public ItemCommand() { }

        public ItemCommand(Item item)
        {
            Item = item;
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

        private Item _item;
        public Item Item
        {
            get => _item;
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }

        #region IThing Members
        public void Use()
        {
            Item.Value--;
            OnPropertyChanged(nameof(Item));
        }

        public bool CanUse => Item.Value > 0;
        public float Power => Item.Power;

        public ValuableUnit Unit => Item;
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