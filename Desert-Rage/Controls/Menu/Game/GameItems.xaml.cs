﻿using DesertRage.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DesertRage.Controls.Menu.Game
{
    /// <summary>
    /// Character bag component
    /// </summary>
    public partial class GameItems : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            PlayerProperty = DependencyProperty.Register(nameof(Player),
                typeof(UserProfile), typeof(GameItems));

        public UserProfile Player
        {
            get => GetValue(PlayerProperty) as UserProfile;
            set => SetValue(PlayerProperty, value);
        }

        public GameItems()
        {
            InitializeComponent();
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