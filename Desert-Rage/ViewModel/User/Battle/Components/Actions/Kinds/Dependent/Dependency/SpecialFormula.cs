using DesertRage.Model.Helpers;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency
{
    public class SpecialFormula : Battle, IFormula
    {
        /// <summary>
        /// Power dependency, based on hero
        /// special stat and fixed multiplier
        /// </summary>
        
        public void SetAttributes(Dictionary<string, Attribute> attributes)
        {
            _multiplier = attributes["Value"].Power;
        }

        private readonly float _multiplier;
        public int Power => (ViewModel.Human.Unit.Stats.Special * _multiplier).ToInt();
    }
}
