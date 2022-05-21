﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.ViewModel.Battle
{
    public class Battle : IBattle, INotifyPropertyChanged
    {
        private BattleViewModel _viewModel;
        public BattleViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        public virtual void SetViewModel(BattleViewModel viewModel)
        {
            System.Diagnostics.Trace.WriteLine("OH SHIT...");
            ViewModel = viewModel;
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