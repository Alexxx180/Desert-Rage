using DesertRage.Model.Helpers;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency
{
    public class MergedFormula : AttackFormula
    {
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