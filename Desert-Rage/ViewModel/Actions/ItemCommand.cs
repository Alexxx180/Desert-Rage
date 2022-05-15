using DesertRage.Model.Menu.Things;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.ViewModel.Actions
{
    public class ItemCommand : INotifyPropertyChanged, IAttributeThing
    {
        public Item Item { get; set; }

        #region IAttrubuteThing Members
        public void Spend()
        {
            Item.Count--;
            OnPropertyChanged(nameof(Item));
        }

        public bool CanSpend => Item.Count > 0;
        public int Attribute => Item.Power;
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