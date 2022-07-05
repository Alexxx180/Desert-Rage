using System;
using System.Collections.Generic;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats.Enemy;

namespace DesertRage.ViewModel.User.Battle.Components.Strategy.Appear
{
    public interface IEnemyAppearing
    {
        /// <summary>
        /// Determines how enemies should 
        /// be placed on the battle field
        /// </summary>
        
        public List<Tuple<Position, Foe>> Build();
        public void ResetEnemies(params Foe[] foes);
    }
}
