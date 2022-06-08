using DesertRage.Model.Locations.Battle.Stats.Enemy;
using System.Collections.ObjectModel;

namespace DesertRage.ViewModel.Battle.Strategy.Appear
{
    public interface IEnemyAppearing
    {
        public ObservableCollection<Enemy> Build();
        public void ResetEnemies(params Foe[] foes);
    }
}