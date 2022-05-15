namespace DesertRage.Model.Menu.Things.Commands.Dependent
{
    public abstract class DependentCommand : ActionCommand
    {
        public override void Execute(object parameter)
        {
            Thing.Spend();
            Use(Thing.Attribute);
        }

        private protected abstract void Use(int value);

        public override bool CanExecute(object parameter)
        {
            return Thing.CanSpend;
        }
    }
}
