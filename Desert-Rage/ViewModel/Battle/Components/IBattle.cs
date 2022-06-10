namespace DesertRage.ViewModel.Battle.Components
{
    public interface IBattle : IViewModelObservable<BattleViewModel>
    {
        public BattleViewModel ViewModel { get; set; }
    }
}