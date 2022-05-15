using DesertRage.Model.Stats;

namespace DesertRage.Model.Menu.Things.Commands.Independent
{
    public class StatusCommand : IndependentCommand
    {
        public BattleUnit Unit { get; set; }

        public int Status { get; set; }
        public bool State { get; set; }

        private protected override void Use()
        {
            Unit.SetStatus(Status, State);
        }
    }
}