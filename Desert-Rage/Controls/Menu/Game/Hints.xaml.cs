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
    /// Логика взаимодействия для Hints.xaml
    /// </summary>
    public partial class Hints : UserControl
    {
        public Hints()
        {
            InitializeComponent();
        }

        //private void FastInfoChange(TextBlock[] Texts, Label[] Headers, in string[] text, in string[] content)
        //{
        //    for (byte i = 0; i < Headers.Length; i++)
        //    {
        //        Headers[i].Content = content[i];
        //        Texts[i].Text = text[i];
        //    }
        //}

        ////[EN] Game interactive documentation
        ////[RU] Игровое интерактивное руководство.
        //private void InfoImgs_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    Image img = sender as Image;
        //    string[,] inf = Paths.Static.Menu.MInfo.MAfter.HelpAfter;
        //    img.Source = Bmper(inf[Bits(img.Tag), Txts.Docs.InfoChange1]);
        //}

        //private void InfoImgs_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    Image img = sender as Image;
        //    string[,] inf = Paths.Static.Menu.MInfo.MBefore.HelpBefore;
        //    img.Source = Bmper(inf[Bits(img.Tag), Txts.Docs.InfoChange1]);
        //}

        //private void GameHint()
        //{
        //    string[,] inf = Paths.Static.Menu.MInfo.MBefore.HelpBefore;
        //    FastImgChange(BmpersToX(inf[0, Txts.Docs.InfoChange1],
        //        inf[1, Txts.Docs.InfoChange1], inf[2, Txts.Docs.InfoChange1]),
        //        InfoImg1, InfoImg2, InfoImg3);
        //}

        //private void FastImgChange(BitmapImage bitmapImage, params Image[] ImageArray)
        //{
        //    for (byte i = 0; i < ImageArray.Length; i++)
        //        ImageArray[i].Source = bitmapImage;
        //}

        //private void FastImgChange(BitmapImage[] bitmapImage, params Image[] ImageArray)
        //{
        //    for (byte i = 0; i < ImageArray.Length; i++)
        //        ImageArray[i].Source = bitmapImage[i];
        //}
    }
}
