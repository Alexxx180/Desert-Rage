using DesertRage.ViewModel.Battle;
using System.Collections.ObjectModel;

namespace DesertRage.Controls.Scenes.Battle.Strategy.Appear
{
    public interface EnemyAppearing
    {
        public ObservableCollection<Enemy> Build();
    }
}