﻿using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Things.Storage;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Components.Actions.Kinds.Independent
{
    public class StatusCommand : ActCommand, IAction, INotifyPropertyChanged
    {
        public StatusCommand(NoiseUnit thing) : base(thing)
        {
            UnitCursor = Targeting.HERO;
        }

        public StatusCommand(StatusID status, bool state,
            NoiseUnit thing) : this(thing)
        {
            Status = status;
            State = state;
        }

        public void Use(object parameter)
        {
            Act();
            Hero.SetStatus(Status, State);
            User.UpdateHero();
        }

        public StatusID Status { get; set; }
        public bool State { get; set; }

        public bool CanUse => true;
    }
}