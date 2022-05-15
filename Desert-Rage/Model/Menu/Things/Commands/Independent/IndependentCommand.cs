namespace DesertRage.Model.Menu.Things.Commands.Independent
{
    public abstract class IndependentCommand : ActionCommand
    {
        public override void Execute(object parameter)
        {
            Thing.Spend();
            Use();
        }

        private protected abstract void Use();

        public override bool CanExecute(object parameter)
        {
            return Thing.CanSpend;
        }
    }
}