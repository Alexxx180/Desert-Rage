using DesertRage.Model;

namespace DesertRage.ViewModel.User.Battle.Components
{
    public interface IBattle : IModel<BattleViewModel>
    {
        public BattleViewModel ViewModel { get; set; }
    }
}