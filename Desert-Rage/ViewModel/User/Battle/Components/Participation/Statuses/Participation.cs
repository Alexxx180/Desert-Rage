using DesertRage.Model.Locations.Battle.Stats;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.ViewModel.User.Battle.Components.Participation.Statuses
{
    public class Participation : IParticipation, INotifyPropertyChanged
    {
        /// <summary>
        /// Battle participant and unit data container
        /// <param name="participant">Battle participant</param>
        public Participation
            (Participant participant)
        {
            Participant = participant;
        }

        private Participant _viewModel;
        public Participant Participant
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        public virtual void SetModel(Participant model)
        {
            Participant = model;
        }

        private protected BattleUnit Unit => Participant.Unit;

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
