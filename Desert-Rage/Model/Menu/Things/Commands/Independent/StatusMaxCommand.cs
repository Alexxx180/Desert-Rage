using DesertRage.Model.Stats;

namespace DesertRage.Model.Menu.Things.Commands.Independent
{
    public class StatusMaxCommand
    {
        public BattleUnit Unit { get; set; }
        public bool State { get; set; }

        private protected void Use()
        {
            Unit.SetStatus(State);
        }
    }
}