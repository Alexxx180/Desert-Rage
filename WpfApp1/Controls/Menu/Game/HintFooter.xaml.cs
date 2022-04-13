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
    /// Логика взаимодействия для HintFooter.xaml
    /// </summary>
    public partial class HintFooter : UserControl
    {
        public HintFooter()
        {
            InitializeComponent();
        }

        //private void InfoIndexPlus_Click(object sender, RoutedEventArgs e)
        //{
        //    Txts.Docs.InfoChange1 += 1;

        //    FastInfoChange(new TextBlock[] { InfoText1, InfoText2, InfoText3 },
        //        new Label[] { InfoHeaderText1, InfoHeaderText2, InfoHeaderText3 },
        //        new string[] { Txts.Docs.HelpInfo2[0, Txts.Docs.InfoChange1],
        //            Txts.Docs.HelpInfo2[1, Txts.Docs.InfoChange1],
        //            Txts.Docs.HelpInfo2[2, Txts.Docs.InfoChange1] },
        //        new string[] { Txts.Docs.HelpInfo1[0, Txts.Docs.InfoChange1],
        //            Txts.Docs.HelpInfo1[1, Txts.Docs.InfoChange1],
        //            Txts.Docs.HelpInfo1[2, Txts.Docs.InfoChange1] });
        //    InfoIndex.Content = $"{Txts.Docs.InfoChange1 + 1}/19";
        //    AnyShow(InfoIndexMinus);

        //    if (Txts.Docs.InfoChange1 >= 18)
        //        AnyHide(InfoIndexPlus);

        //    GameHint();
        //}

        //private void InfoIndexMinus_Click(object sender, RoutedEventArgs e)
        //{
        //    Txts.Docs.InfoChange1 -= 1;
        //    FastInfoChange(new TextBlock[] { InfoText1, InfoText2, InfoText3 },
        //        new Label[] { InfoHeaderText1, InfoHeaderText2, InfoHeaderText3 },
        //        new string[] { Txts.Docs.HelpInfo2[0, Txts.Docs.InfoChange1],
        //            Txts.Docs.HelpInfo2[1, Txts.Docs.InfoChange1],
        //            Txts.Docs.HelpInfo2[2, Txts.Docs.InfoChange1] },
        //        new string[] { Txts.Docs.HelpInfo1[0, Txts.Docs.InfoChange1],
        //            Txts.Docs.HelpInfo1[1, Txts.Docs.InfoChange1],
        //            Txts.Docs.HelpInfo1[2, Txts.Docs.InfoChange1] });
        //    InfoIndex.Content = $"{Txts.Docs.InfoChange1 + 1}/19";
        //    AnyShow(InfoIndexPlus);
        //    if (Txts.Docs.InfoChange1 <= 0)
        //        AnyHide(InfoIndexMinus);
        //    GameHint();
        //}
    }
}