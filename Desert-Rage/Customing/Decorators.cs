using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using static DesertRage.Customing.Converters.Converters;

namespace DesertRage.Customing
{
    public static class Decorators
    {
        public static void SetActive(
            this FrameworkElement element,
            bool setToActive)
        {
            element.Visibility = setToActive ?
                Visibility.Visible :
                Visibility.Collapsed;
        }

        public static void Refresh<T>
            (this IList<T> list, IEnumerable<T> value)
        {
            list.Clear();
            foreach (T item in value)
            {
                list.Add(item);
            }
        }

        public static void
            SetViewModel<T>(this IEnumerable
            <IViewModelObservable<T>> items, T viewModel)
        {
            foreach (IViewModelObservable<T> item in items)
            {
                item.SetViewModel(viewModel);
            }
        }

        #region Binding Members
        public static void Bind(
            this DependencyObject @object,
            DependencyProperty property,
            object reference, string path
            )
        {
            Binding myBinding = new Binding
            {
                Source = reference,
                Path = new PropertyPath(path)
            };
            BindingOperations.SetBinding(@object, property, myBinding);
        }

        public static void Bind(
            this DependencyObject @object,
            DependencyProperty property,
            object reference, string path,
            BindingMode mode,
            UpdateSourceTrigger trigger
            )
        {
            Binding myBinding = new Binding
            {
                Source = reference,
                Path = new PropertyPath(path),
                Mode = mode,
                UpdateSourceTrigger = trigger
            };
            BindingOperations.SetBinding(@object, property, myBinding);
        }
        #endregion

        #region Bar Management Members
        public static bool Drop(
            this Bar statBar,
            out Bar newStatBar,
            ushort decrement)
        {
            ushort newValue = Math.Max(
                statBar.Current - decrement,
                statBar.Minimum
            ).ToUShort();

            newStatBar = new Bar
            {
                Minimum = statBar.Minimum,
                Current = newValue,
                Max = statBar.Max
            };

            return newValue <= statBar.Minimum;
        }

        public static bool Fill(
            this Bar statBar,
            out Bar newStatBar,
            ushort increment
            )
        {
            ushort newValue = Math.Min(
                statBar.Current + increment,
                statBar.Max
            ).ToUShort();

            newStatBar = new Bar
            {
                Minimum = statBar.Minimum,
                Current = newValue,
                Max = statBar.Max
            };

            return newValue >= statBar.Max;
        }
        #endregion

        public static void AnyShow(this MediaElement element)
        {
            element.Play();
            element.SetActive(true);
        }

        public static void AnyShowAdvanced
            (this MediaElement element,
            Uri Source, TimeSpan timeSpan)
        {
            element.Source = Source;
            element.Position = timeSpan;
            element.Play();
            element.SetActive(true);
        }

        public static void AnyHide(this MediaElement element)
        {
            element.SetActive(false);
            element.Stop();
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
                elements[i].SetActive(true);
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