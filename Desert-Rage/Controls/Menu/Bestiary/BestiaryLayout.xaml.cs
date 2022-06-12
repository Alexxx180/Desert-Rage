using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesertRage.Controls.Menu.Bestiary
{
    /// <summary>
    /// Логика взаимодействия для BestiaryLayout.xaml
    /// </summary>
    public partial class BestiaryLayout : UserControl
    {
        public static readonly DependencyProperty
            PlayerProperty = DependencyProperty.Register(nameof(Player),
                typeof(UserProfile), typeof(BestiaryLayout));

        public UserProfile Player
        {
            get => GetValue(PlayerProperty) as UserProfile;
            set => SetValue(PlayerProperty, value);
        }

        public static readonly DependencyProperty
            SelectedFoeProperty = DependencyProperty.Register(
                nameof(SelectedFoe), typeof(Foe), typeof(BestiaryLayout));

        public Foe SelectedFoe
        {
            get => GetValue(SelectedFoeProperty) as Foe;
            set => SetValue(SelectedFoeProperty, value);
        }
        
        public BestiaryLayout()
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