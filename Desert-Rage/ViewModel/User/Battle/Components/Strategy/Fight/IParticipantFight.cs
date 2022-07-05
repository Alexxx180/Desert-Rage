using System;
using DesertRage.Model;
using DesertRage.Model.Locations.Battle.Stats;

namespace DesertRage.ViewModel.User.Battle.Components.Strategy.Fight
{
    public interface IParticipantFight : IBattle, IDisposable, ICloneable<IParticipantFight>
    {
        /// <summary>
        /// Determines how enemy will
        /// be acting during the battle
        /// </summary>
    
        public void Fight();
        public void SetUnit(BattleUnit unit);
    }
}
