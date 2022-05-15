using System.ComponentModel;
using System.Runtime.CompilerServices;
using DesertRage.Model.Stats;

namespace DesertRage.Model.Menu.Things.Commands.Dependent
{
    public class CureCommand : DependentCommand, INotifyPropertyChanged
    {
        public BattleUnit Unit { get; set; }

        private protected override void Use(int value)
        {
            Unit.Cure(value);
            OnPropertyChanged(nameof(Unit));

            System.Diagnostics.Trace.WriteLine(Thing.Attribute);
            System.Diagnostics.Trace.WriteLine(Unit.Hp.ToString());
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion
    }
}