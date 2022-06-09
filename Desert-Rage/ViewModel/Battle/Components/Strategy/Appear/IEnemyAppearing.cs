using System;
using System.Collections.Generic;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats.Enemy;

namespace DesertRage.ViewModel.Battle.Components.Strategy.Appear
{
    public interface IEnemyAppearing
    {
        public List<Tuple<Position, Foe>> Build();
        public void ResetEnemies(params Foe[] foes);
    }
}