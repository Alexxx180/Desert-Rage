using DesertRage.Model.Helpers;
using System.Collections.Generic;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency
{
    public class SpecialFormula : Battle, IFormula
    {
        /// <summary>
        /// Power dependency, based on hero
        /// special stat and fixed multiplier
        /// </summary>
        
        public void SetAttributes(Dictionary<string, float> attributes)
        {
            _multiplier = attributes["Power"];
        }

        private float _multiplier;
        public int Power => (ViewModel.Human.Unit.Stats.Special * _multiplier).ToInt();
    }
}
