using DesertRage.Model.Helpers;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency
{
    public class SpecialFormula : Battle, IFormula
    {
        public SpecialFormula(float multiplier)
        {
            _multiplier = multiplier;
        }

        public SpecialFormula(float multiplier, BattleViewModel battle) : this(multiplier)
        {
            SetModel(battle);
        }

        private readonly float _multiplier;
        public int Power => (ViewModel.Human.Unit.Stats.Special * _multiplier).ToInt();
    }
}