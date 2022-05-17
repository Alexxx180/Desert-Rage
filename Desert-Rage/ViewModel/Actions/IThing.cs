using DesertRage.Model.Menu.Things;

namespace DesertRage.ViewModel.Actions
{
    public interface IThing
    {
        public void Use();

        public bool CanUse { get; }
        public float Power { get; }

        public ValuableUnit Unit { get; }
        public BattleViewModel ViewModel { get; set; }
    }
}