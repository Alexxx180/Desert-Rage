using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency
{
    public class ItemFormula : Battle, IFormula, INotifyPropertyChanged
    {
        /// <summary>
        /// Power dependency, based on fixed value
        /// </summary>
        /// <param name="power">Fixed value of power</param>
        public ItemFormula(int power)
        {
            Power = power;
        }

        public int Power { get; }
    }
}