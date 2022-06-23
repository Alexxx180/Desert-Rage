using DesertRage.ViewModel.User.Battle.Components.Participation;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.ViewModel.User.Battle.Components.Participation.Statuses
{
    public class Participation : IParticipation, INotifyPropertyChanged
    {
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