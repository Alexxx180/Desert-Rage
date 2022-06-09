namespace DesertRage.ViewModel.Battle.Components.Actions
{
    public interface IThing : IBattle
    {
        public void Use();

        public bool CanUse { get; }
        public int Value { get; set; }
    }
}