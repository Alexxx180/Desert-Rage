using System;
using DesertRage.Model;
using DesertRage.Model.Locations.Battle.Stats;

namespace DesertRage.ViewModel.User.Battle.Components.Strategy.Fight
{
    public interface IParticipantFight : IBattle, IDisposable, ICloneable<IParticipantFight>
    {
        public void Fight();
        public void SetUnit(BattleUnit unit);
    }
}