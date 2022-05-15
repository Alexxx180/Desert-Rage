using DesertRage.Model.Stats;

namespace DesertRage.Model.Menu.Things.Commands.Independent
{
    public class CureMaxCommand : IndependentCommand
    {
        public BattleUnit Unit { get; set; }

        private protected override void Use()
        {
            Unit.Cure();
        }
    }
}