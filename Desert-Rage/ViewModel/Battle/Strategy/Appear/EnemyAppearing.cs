using DesertRage.Model.Locations.Battle.Stats.Enemy;
using System.Collections.ObjectModel;

namespace DesertRage.ViewModel.Battle.Strategy.Appear
{
    public interface EnemyAppearing
    {
        public ObservableCollection<Enemy> Build();
        public void ResetEnemies(params Foe[] foes);
    }
}