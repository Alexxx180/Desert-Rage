﻿using DesertRage.Customing.Converters;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency
{
    public class SpecialFormula : Battle, IFormula
    {
        public SpecialFormula(float multiplier)
        {
            _multiplier = multiplier;
        }

        public SpecialFormula(float multiplier, BattleViewModel battle) : this(multiplier)
        {
            SetViewModel(battle);
        }

        private readonly float _multiplier;
        public int Power => (ViewModel.Human.Player.Hero.Stats.Special * _multiplier).ToInt();
    }
}