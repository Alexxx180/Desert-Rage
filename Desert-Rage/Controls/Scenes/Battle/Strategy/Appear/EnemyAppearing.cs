using DesertRage.Controls.Scenes.Battle.Avatar;
using System.Collections.ObjectModel;

namespace DesertRage.Controls.Scenes.Battle.Strategy.Appear
{
    public interface EnemyAppearing
    {
        public ObservableCollection<Foe> Build();
    }
}