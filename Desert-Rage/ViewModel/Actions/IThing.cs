namespace DesertRage.ViewModel.Actions
{
    public interface IThing
    {
        public void Spend();

        public bool CanSpend { get; }
    }
}