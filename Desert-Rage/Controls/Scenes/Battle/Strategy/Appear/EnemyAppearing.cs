//using DesertRage.Controls.Scenes.Battle.Avatar;
using DesertRage.Model.Stats.Enemy;
using System.Collections.ObjectModel;

namespace DesertRage.Controls.Scenes.Battle.Strategy.Appear
{
    public interface EnemyAppearing
    {
        public ObservableCollection<Foe> Build();
    }
}