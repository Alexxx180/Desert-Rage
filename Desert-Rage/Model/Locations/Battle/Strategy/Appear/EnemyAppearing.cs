using DesertRage.ViewModel.Battle;
using System.Collections.ObjectModel;

namespace DesertRage.Model.Locations.Battle.Strategy.Appear
{
    public interface EnemyAppearing
    {
        public ObservableCollection<Enemy> Build();
    }
}