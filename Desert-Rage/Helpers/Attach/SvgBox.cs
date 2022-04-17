using SharpVectors.Converters;
using System;
using System.Windows;
using System.Windows.Media;

namespace DesertRage.Helpers.Attach
{
    public class SvgBox : DependencyObject
    {
        #region SourceProperty Members
        public static Uri GetSource(DependencyObject obj)
        {
            return obj.GetValue(SourceProperty) as Uri;
        }

        public static void SetSource(DependencyObject obj, Uri value)
        {
            obj.SetValue(SourceProperty, value);
        }

        private static void OnSourceChanged
            (DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            SvgViewbox svgControl = obj as SvgViewbox;
            if (svgControl is not null)
            {
                Uri path = e.NewValue as Uri;
                if (path is not null)
                    svgControl.Source = path;

                svgControl.Stretch = Stretch.Fill;
            }
        }
        #endregion

        #region StretchProperty Members
        public static Stretch GetStretch(DependencyObject obj)
        {
            return (Stretch)obj.GetValue(StretchProperty);
        }

        public static void SetStretch(DependencyObject obj, Stretch value)
        {
            obj.SetValue(StretchProperty, value);
        }

        private static void OnStretchChanged
            (DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            SvgViewbox svgControl = obj as SvgViewbox;
            if (svgControl is not null)
            {
                if (e.NewValue is Stretch kind)
                {
                    svgControl.Stretch = kind;
                }
            }
        }
        #endregion

        public static readonly DependencyProperty
            SourceProperty = DependencyProperty.RegisterAttached
                ("Source", typeof(Uri), typeof(SvgBox),
                new PropertyMetadata(OnSourceChanged));

        public static readonly DependencyProperty
            StretchProperty = DependencyProperty.RegisterAttached
                ("Stretch", typeof(Stretch), typeof(SvgBox),
                new PropertyMetadata(OnStretchChanged));
    }
}