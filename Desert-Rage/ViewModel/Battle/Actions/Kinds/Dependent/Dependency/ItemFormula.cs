using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency
{
    public class ItemFormula : Battle, IFormula, INotifyPropertyChanged
    {
        public ItemFormula(int power)
        {
            Power = power;
        }

        public int Power { get; }
    }
}