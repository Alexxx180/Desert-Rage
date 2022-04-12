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
        public static void SetActive
            (this FrameworkElement element, bool setToActive)
        {
            element.Visibility = setToActive ?
                Visibility.Visible : Visibility.Collapsed;
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
            return Math.Max(Bits(img.GetValue(Grid.ColumnProperty)) - offset, 0);
        }
        public static int CheckRow(in Image img, int offset)
        {
            return Math.Max(Bits(img.GetValue(Grid.RowProperty)) - offset, 0);
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