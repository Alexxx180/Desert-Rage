﻿using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent
{
    public class RecoverMaxCommand : CureMaxCommand, INotifyPropertyChanged
    {
        /// <summary>
        /// Fully refills hero HP
        /// and AP at the same time
        /// </summary>
        public RecoverMaxCommand() : base() { }

        protected void Rest()
        {
            Man.Rest();
        }

        public override void Use(object parameter)
        {
            Rest();
            base.Use(parameter);
        }
    }
}
