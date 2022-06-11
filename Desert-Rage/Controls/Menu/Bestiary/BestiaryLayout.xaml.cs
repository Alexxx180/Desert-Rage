using DesertRage.ViewModel;
using System;
using System.Collections.Generic;
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

        public BestiaryLayout()
        {
            InitializeComponent();
        }


    }
}
