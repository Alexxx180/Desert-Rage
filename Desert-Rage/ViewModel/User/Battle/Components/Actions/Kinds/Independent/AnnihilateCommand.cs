﻿using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.User.Battle.Components.Participation;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent
{
    public class AnnihilateCommand : ActCommand, IAction, INotifyPropertyChanged
    {
        public AnnihilateCommand(NoiseUnit thing) : base(thing)
        {
            UnitCursor = Targeting.ONE;
        }

        protected void Defeat(in Enemy unit)
        {
            unit.Annihilate();
        }

        public virtual void Use(object parameter)
        {
            Act();
            Defeat(parameter as Enemy);
        }

        public bool CanUse => ViewModel.IsBattle;
    }
}