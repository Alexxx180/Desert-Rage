using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using static DesertRage.Customing.Converters.Converters;

namespace DesertRage.Customing
{
    public static class Decorators
    {
        //#region Deprecated Members
        //private async void ShowAndHide(Label label, string content, ushort time)
        //{
        //    label.Content = content;
        //    AnyShow(label);
        //    await Task.Delay(time);
        //    AnyHide(label);
        //}

        //private void ChangeBackground(in byte loc, in byte NoSpoilers)
        //{
        //    string[] Bmps = new string[] { Paths.Static.Map.Location1,
        //        Paths.Static.Map.Location2, Paths.Static.Map.Location3,
        //        Paths.Static.Map.Location4 };
        //    Img1.Source = Bmper((NoSpoilers == 0) ?
        //        Paths.Static.Map.Main : Bmps[loc]);
        //}

        //private void ChangeBackground(in byte loc)
        //{
        //    string[] Bmps = new string[] { Paths.Static.Map.Location1,
        //        Paths.Static.Map.Location2, Paths.Static.Map.Location3,
        //        Paths.Static.Map.Location4 };
        //    Img1.Source = Bmper(Bmps[loc]);
        //}

        //private void SettingsSetAll(params byte[] SettingValues)
        //{
        //    Slider[] Sliders = { MusicLoud, SoundsLoud,
        //        NoiseLoud, GameSpeed, Brightness };
        //    for (byte i = 0; i < Sliders.Length; i++)
        //        Sliders[i].Value = Dble(SettingValues[i]) * 0.01;
        //    TimerTurnOn.IsChecked = SettingValues[5] >= 1;
        //}

        //private void PlayerSetLocation(in int row, in int column)
        //{
        //    MainHero.Y = row;
        //    MainHero.X = column;
        //    AnyGrid(Img2, row, column);
        //}

        //private void FastTextChange(Label[] Labs, in string[] texts)
        //{
        //    for (byte i = 0; i < Labs.Length; i++)
        //        Labs[i].Content = texts[i];
        //}
        //#endregion


        public static void SetActive
            (this FrameworkElement element, bool setToActive)
        {
            element.Visibility = setToActive ?
                Visibility.Visible :
                Visibility.Collapsed;
        }

        public static void AnyFontSize(TextBlock textBlock, in double fontSize)
        {
            textBlock.FontSize = fontSize;
        }
        public static void AnyFontSize(ContentControl control, in double fontSize)
        {
            control.FontSize = fontSize;
        }
        public static void AnyShrink(FrameworkElement element,
            in double width, in double height)
        {
            element.Width = width;
            element.Height = height;
        }
        public static void AnyShrinkX(in double width, in double height,
            params FrameworkElement[] elements)
        {
            for (byte i = 0; i < elements.Length; i++)
                AnyShrink(elements[i], width, height);
        }
        public static void AnyHide(FrameworkElement element)
        {
            element.Visibility = Visibility.Hidden;
            element.IsEnabled = false;
        }
        public static void AnyShow(FrameworkElement element)
        {
            element.Visibility = Visibility.Visible;
            element.IsEnabled = true;
        }
        public static void AnyShow(MediaElement element)
        {
            element.Play();
            AnyShow(element as FrameworkElement);
        }
        public static void AnyShowAdvanced(MediaElement element,
            Uri Source, TimeSpan timeSpan)
        {
            element.Source = Source;
            element.Position = timeSpan;
            element.Play();
            AnyShow(element as FrameworkElement);
        }
        public static void AnyHide(MediaElement element)
        {
            AnyHide(element as FrameworkElement);
            element.Stop();
        }
        public static void AnyHideX(params MediaElement[] elements)
        {
            for (byte i = 0; i < elements.Length; i++)
                AnyHide(elements[i]);
        }
        public static void AnyHideX(params FrameworkElement[] elements)
        {
            for (byte i = 0; i < elements.Length; i++)
                AnyHide(elements[i]);
        }
        public static void AnyHideX(params FrameworkElement[][] elements)
        {
            for (byte i = 0; i < elements.Length; i++)
                AnyHideX(elements[i]);
        }
        public static void AnyGrid(UIElement element, in int row, in int column)
        {
            Grid.SetRow(element, row);
            Grid.SetColumn(element, column);
        }
        public static void Scales(ScaleTransform scl, in double w, in double h)
        {
            scl.ScaleX = w;
            scl.ScaleY = h;
        }
        
        public static void AnyShowX(params FrameworkElement[] elements)
        {
            for (byte i = 0; i < elements.Length; i++)
                AnyShow(elements[i]);
        }
        public static void AnyShowX2(in bool[] Conditions,
            params FrameworkElement[][] Objects)
        {
            for (byte i = 0; i < Conditions.Length; i++)
                if (Conditions[i])
                    AnyShowX(Objects[i]);
        }
        public static void AnyShowX2(in BitArray Conditions,
            params FrameworkElement[][] Objects)
        {
            for (byte i = 0; i < Conditions.Length; i++)
                if (Conditions[i])
                    AnyShowX(Objects[i]);
        }
        public static void AnyGridX(UIElement[] Elements,
            in int[] rows, in int[] columns)
        {
            for (byte i = 0; i < Elements.Length; i++)
                AnyGrid(Elements[i], rows[i], columns[i]);
        }
        //[EN] Bitmapimages and URI from string converting
        //[RU] Преобразование в изображения и URI из строки
        public static Uri Ura(in string Path)
        {
            return new Uri(Path, UriKind.RelativeOrAbsolute);
        }

        public static BitmapImage Bmper(string UriToBmp)
        {
            return new BitmapImage(new Uri(UriToBmp, UriKind.RelativeOrAbsolute));
        }

        public static BitmapImage[] BmpersToX(params string[] texts)
        {
            List<BitmapImage> bmps = new List<BitmapImage>();
            for (byte i = 0; i < texts.Length; i++)
                bmps.Add(Bmper(texts[i]));
            return bmps.ToArray();
        }

        public static int CheckColumn(in Image img, int offset)
        {
            return Math.Max(img.GetValue(Grid.ColumnProperty).ToByte() - offset, 0);
        }

        public static int CheckRow(in Image img, int offset)
        {
            return Math.Max(img.GetValue(Grid.RowProperty).ToByte() - offset, 0);
        }

        public static void FastEnableDisableBtn(bool enabled, params Button[] buttons)
        {
            for (byte i = 0; i < buttons.Length; i++)
                buttons[i].IsEnabled = enabled;
        }

        public static void FastEnableDisableBtn(bool[] enabled, params Button[] buttons)
        {
            for (byte i = 0; i < buttons.Length; i++)
                buttons[i].IsEnabled = enabled[i];
        }

        public static void TimerOn(ref DispatcherTimer timer)
        {
            timer.Start();
        }

        public static void TimerOn(ref DispatcherTimer timer, in ushort time)
        {
            timer.Interval = TimeSpan.FromMilliseconds(time);
            timer.Start();
        }

        public static void TimerOff(ref DispatcherTimer timer)
        {
            timer.Stop();
        }

        public static void PlayOST(MediaElement element, in string Path)
        {
            element.Stop();
            element.Source = Ura(Path);
            element.Play();
        }
    }
}