﻿using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.User.Battle.Components.Participation;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent
{
    public class LearnCommand : ActCommand, IAction, INotifyPropertyChanged
    {
        /// <summary>
        /// Reveal selected enemy in the bestiary
        /// </summary>
        public LearnCommand()
        {
            UnitCursor = Targeting.ONE;
        }

        public virtual void Use(object parameter)
        {
            Act();
            Enemy enemy = parameter as Enemy;
            User.AnalyzeFoe(enemy.ID);
        }

        public virtual bool CanUse => ViewModel.IsBattle;
    }
}
