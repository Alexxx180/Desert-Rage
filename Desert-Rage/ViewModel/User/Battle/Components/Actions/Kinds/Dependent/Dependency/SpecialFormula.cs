using DesertRage.Model.Helpers;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency
{
    public class SpecialFormula : Battle, IFormula
    {
        /// <summary>
        /// Power dependency, based on hero
        /// special stat and fixed multiplier
        /// </summary>
        /// <param name="multiplier">Fixed multiplier value</param>
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
