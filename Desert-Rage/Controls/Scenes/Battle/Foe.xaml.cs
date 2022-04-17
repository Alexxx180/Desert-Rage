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

namespace DesertRage.Controls.Scenes.Battle
{
    /// <summary>
    /// Логика взаимодействия для Foe.xaml
    /// </summary>
    public partial class Foe : UserControl
    {
        public Foe()
        {
            InitializeComponent();
        }

        //private void BadTime()
        //{
        //    int strength = GetATK + (GetATK * GetAGL / 100);
        //    ushort EnemyDefence = foes[Sets.SelectedTarget].Defence;
        //    ushort total = Shrt(Math.Max(strength - EnemyDefence, 0));
        //    AnyHideX(SelectMenuFight, TargetImage);
        //    Lab2.Foreground = Brushes.White;
        //    FoesKickedOne(Sets.SelectedTarget, total, Shrt(500 / GameSpeed.Value));
        //    PhysicalAttack(MainHero.Weapon);
        //    FoesRefresh();
        //}

        //private void SuperCheckFoes(in byte seltrg)
        //{
        //    PlaySound(foes[seltrg].Death);
        //    Image[] images = { Img6, Img7, Img8 };
        //    string name = foes[seltrg].Name;
        //    RecordFoes[name]--;
        //    int count = RecordFoes[name];
        //    if (count <= 0)
        //    {
        //        _ = RecordFoes.Remove(name);
        //        AnyHide(HideCheck(name));
        //    }
        //    if (Sets.SpecialBattle == 0)
        //        AnyHide(images[seltrg]);
        //    else
        //        AnyHide(BossSlot1);
        //    foes[seltrg] = DeadFoe;
        //    FoesRefresh();
        //    Sets.SelectedTarget = ReSelect();
        //    EnemiesTotal(RecordFoes);
        //}

        //private Label HideCheck(string name)
        //{
        //    Label[] labels = { FoesCount1, FoesCount2, FoesCount3 };
        //    for (byte i = 0; i < labels.Length; i++)
        //    {
        //        if (labels[i].Content.ToString().Contains(name))
        //            return labels[i];
        //    }
        //    return labels[2];
        //}
    }
}