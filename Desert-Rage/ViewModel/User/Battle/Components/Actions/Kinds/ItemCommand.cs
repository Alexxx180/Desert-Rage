using DesertRage.Model.Helpers;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds
{
    public class ItemCommand : Battle, INotifyPropertyChanged, IThing
    {
        /// <summary>
        /// Consume specified item count when used
        /// </summary>

        #region IThing Members
        public int Value
        {
            get => ViewModel.Human.Player.Hero.Items[Item];
            set
            {
                ViewModel.Human.Player.Hero.Items[Item] = value.ToByte();
                OnPropertyChanged();
            }
        }

        public void Use()
        {
            Value--;
        }

        public void SetValue(int value)
        {
            Item = value;
        }

        public bool CanUse => true;
        #endregion

        public int Item { get; set; }
    }
}