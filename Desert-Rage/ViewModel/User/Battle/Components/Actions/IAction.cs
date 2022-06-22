using DesertRage.Model;
using DesertRage.ViewModel.User.Battle;
using DesertRage.ViewModel.User.Battle.Components.Actions;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DesertRage.ViewModel.User.Battle.Components.Actions
{
    public interface IAction : IModel<BattleViewModel>
    {
        public void Use(object parameter);
        public bool CanUse { get; }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                        