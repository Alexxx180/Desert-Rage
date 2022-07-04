﻿using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Things.Storage;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent.Status
{
    public class StatusCommand : ActCommand, IAction, INotifyPropertyChanged
    {
        public StatusCommand(NoiseUnit thing) : base(thing)
        {
            UnitCursor = Targeting.HERO;
        }

        public StatusCommand
            (StatusID status, NoiseUnit thing) : this(thing)
        {
            Status = status;
        }

        public virtual void Use(object parameter)
        {
            Act();
        }

        public StatusID Status { get; set; }
        public bool State { get; set; }

        public virtual bool CanUse => true;
    }
}