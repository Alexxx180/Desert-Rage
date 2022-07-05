using DesertRage.Model.Helpers;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Things.Storage;
using System;

namespace DesertRage.ViewModel.User.Battle.Components.Strategy.Fight
{
    public class Poison : Attack
    {
        public Poison() : base()
        {
            _poison = new Random();
        }

        /// <summary>
        /// Poison victim with specified chance
        /// </summary>
        /// <param name="chance">
        /// Chance to poison after each turn
        /// </param>
        public Poison(Position chance) : this()
        {
            _chance = chance;
        }

        public override void Fight()
        {
            if (_poison.Next(_chance.Y, _chance.X) != _chance.Y)
            {
                base.Fight();
            }
            else
            {
                Venom();
            }
        }

        private void Venom()
        {
            StatusID poison = StatusID.POISON;

            Victim.ApplyEvent(poison);
            Target.MakeStatus(poison.Int());
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
