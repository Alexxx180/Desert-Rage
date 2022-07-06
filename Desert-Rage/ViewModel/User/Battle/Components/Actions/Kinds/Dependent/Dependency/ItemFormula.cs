using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency
{
    public class ItemFormula : Battle, IFormula, INotifyPropertyChanged
    {
        /// <summary>
        /// Power dependency, based on fixed value
        /// </summary>

        public void SetAttributes(Dictionary<string, Attribute> attributes)
        {
            Power = attributes["Value"].Value;
        }

        public int Power { get; private set; }
    }
}
