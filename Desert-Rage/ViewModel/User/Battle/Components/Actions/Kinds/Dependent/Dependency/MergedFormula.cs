using DesertRage.Model.Helpers;
using System.Collections.Generic;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency
{
    public class MergedFormula : AttackFormula
    {
        /// <summary>
        /// Power dependency, based on hero
        /// equipment, attack, special stat
        /// and fixed multiplier
        /// </summary>
        
        public override void SetAttributes(Dictionary<string, float> attributes)
        {
            _multiplier = attributes["Power"];
        }

        private float _multiplier;

        public override int Power
        {
            get
            {
                float power = base.Power;
                power += Hero.Stats.Special;
                power *= _multiplier;
                return power.ToInt();
            }
        }
    }
}
