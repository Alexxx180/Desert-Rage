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

namespace DesertRage.Controls.Menu.Game
{
    /// <summary>
    /// Логика взаимодействия для GameSkills.xaml
    /// </summary>
    public partial class GameSkills : UserControl
    {
        public GameSkills()
        {
            InitializeComponent();
        }

        //private void SwitchAbils_Click(object sender, RoutedEventArgs e)
        //{
        //    Button b = sender as Button;
        //    Grid currentSkills = b.Parent as Grid;
        //    Grid nextSkills = b.Tag as Grid;
        //    AnyHide(currentSkills);
        //    AnyShow(nextSkills);
        //}

        //private void AbilsMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    Button[] abils = new Button[] { Cure1, Cure2Out, Heal1,
        //        Torch1, Whip1, Thrower1, Super0, Tornado1, Quake1,
        //        Learn1, BuffUp1, ToughenUp1, Regen1, Control1 };
        //    string[] uris = new string[] { Paths.OST.Noises.Cure,
        //        Paths.OST.Noises.Cure2, Paths.OST.Noises.Heal,
        //        Paths.OST.Noises.Torch, Paths.OST.Noises.Whip,
        //        Paths.OST.Noises.Thrower, Paths.OST.Noises.Super,
        //        Paths.OST.Noises.Whirl, Paths.OST.Noises.Quake,
        //        Paths.OST.Noises.Learn, Paths.OST.Noises.PowUp,
        //        Paths.OST.Noises.Shield, Paths.OST.Noises.HpUp,
        //        Paths.OST.Noises.ApUp };
        //    for (byte i = 0; i < abils.Length; i++)
        //        if (sender.Equals(abils[i]))
        //            PlayNoise(uris[i]);
        //    if (sender.Equals(Cure1))
        //    {
        //        GetHP = Math.Min(GetMHP, Shrt(GetHP + ACure.Cure()));
        //        GetAP -= ACure.Cost;
        //    }
        //    if (sender.Equals(Cure2Out))
        //    {
        //        GetHP = ACure2.Cure();
        //        GetAP -= ACure2.Cost;
        //    }
        //    if (sender.Equals(Heal1))
        //    {
        //        HeroSetStatus(AHeal.HealStatus());
        //        GetAP -= AHeal.Cost;
        //    }
        //}

        //private void AbilitiesOutFight_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    AbilsCost.Content = Numb((sender as Button).Tag);
        //    AnyShow(AbilsCost);
        //}
    }
}
