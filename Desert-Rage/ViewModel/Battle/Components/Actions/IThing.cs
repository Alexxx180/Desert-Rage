namespace DesertRage.ViewModel.Battle.Components.Actions
{
    public interface IThing : IBattle
    {
        public void Use();
        public void SetValue(int value);

        public bool CanUse { get; }
        public int Value { get; set; }
    }
}