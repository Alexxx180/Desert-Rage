using DesertRage.Model.Menu.Battle;
using DesertRage.Model.Stats.Player;

namespace DesertRage.ViewModel.Actions.Dependent
{
    public class StatusCommand : ActCommand
    {
        public StatusCommand(IThing thing,
            int status, bool state) : base(thing)
        {
            UnitCursor = Targeting.HERO;
            Status = status;
            State = state;
        }

        private protected override void Use(object parameter)
        {
            UserProfile user = ViewModel.Player;
            Character character = user.Hero;

            character.SetStatus(Status, State);
            user.UpdateHero();

            System.Diagnostics.Trace.WriteLine(user);
            System.Diagnostics.Trace.WriteLine(character.Hp.ToString());
        }

        public int Status { get; set; }
        public bool State { get; set; }
    }
}