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
        /// <param name="multiplier">Fixed multiplier value</param>
        public MergedFormula(float multiplier)
        {
            _multiplier = multiplier;
        }

        public MergedFormula(float multiplier, BattleViewModel battle) : this(multiplier)
        {
            SetModel(battle);
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
