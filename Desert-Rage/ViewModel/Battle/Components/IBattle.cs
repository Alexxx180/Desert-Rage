namespace DesertRage.ViewModel.Battle
{
    public interface IBattle : IViewModelObservable<BattleViewModel>
    {
        public BattleViewModel ViewModel { get; set; }
    }
}