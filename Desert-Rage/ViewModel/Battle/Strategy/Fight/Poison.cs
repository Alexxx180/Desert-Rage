using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Things.Storage;
using System;

namespace DesertRage.ViewModel.Battle.Strategy.Fight
{
    public class Poison : Attack
    {
        public Poison(BattleUnit unit) : base(unit)
        {
            _poison = new Random();
        }

        public Poison(BattleUnit unit, Position chance) : this(unit)
        {
            _chance = chance;
        }

        public override void Fight()
        {
            if (_poison.Next(_chance.Y, _chance.X) == _chance.Y)
            {
                ViewModel.Human.Unit.SetStatus(StatusID.POISON, false);
            }
            else
            {
                base.Fight();
            }
        }

        private readonly Position _chance;
        private readonly Random _poison;
    }
}
