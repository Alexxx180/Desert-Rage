using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Things.Storage;
using System;

namespace DesertRage.ViewModel.Battle.Components.Strategy.Fight
{
    public class Poison : Attack
    {
        public Poison() : base()
        {
            _poison = new Random();
        }

        public Poison(Position chance) : this()
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

        public override void Dispose()
        {
            base.Dispose();
            _poison = null;
        }

        public override IParticipantFight Clone()
        {
            return new Poison(_chance)
            {
                Unit = Unit,
                ViewModel = ViewModel
            };
        }

        private readonly Position _chance;
        private Random _poison;
    }
}
