using DesertRage.Model.Helpers;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency
{
    public class MergedFormula : AttackFormula
    {
        /// <summary>
        /// Power dependency, based on hero
        /// equipment, attack, special stat
        /// and fixed multiplier
        /// </summary>
        
        public void SetAttributes(Dictionary<string, Attribute> attributes)
        {
            _multiplier = attributes["Power"].Power;
        }

        private readonly float _multiplier;

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
