using DesertRage.Model.Stats;

namespace DesertRage.Model.Menu.Things.Commands.Independent
{
    public class StatusMaxCommand : IndependentCommand
    {
        public BattleUnit Unit { get; set; }
        public bool State { get; set; }

        private protected override void Use()
        {
            Unit.SetStatus(State);
        }
    }
}