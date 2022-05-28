using System.Collections.ObjectModel;

namespace DesertRage.ViewModel.Battle.Strategy.Appear
{
    public interface EnemyAppearing
    {
        public ObservableCollection<Enemy> Build();
    }
}