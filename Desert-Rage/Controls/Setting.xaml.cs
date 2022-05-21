using DesertRage.Model.Locations.Battle.Stats;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DesertRage.Controls
{
    /// <summary>
    /// Setting component based on slider
    /// </summary>
    public partial class Setting : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            SliderProperty = DependencyProperty.Register
                (nameof(Slider), typeof(Bar), typeof(Setting),
                new PropertyMetadata(OnSliderChangedCallBack));

        public static readonly DependencyProperty
            CaptionProperty = DependencyProperty.Register
                (nameof(Caption), typeof(string), typeof(Setting));

        #region Setting Members
        public string Caption
        {
            get => GetValue(CaptionProperty) as string;
            set => SetValue(CaptionProperty, value);
        }

        public Bar Slider
        {
            get => (Bar)GetValue(SliderProperty);
            set => SetValue(SliderProperty, value);
        }
        #endregion

        // Struct workaround
        public ushort Current
        {
            get => Slider.Current;
            set => SetValue(SliderProperty,
                new Bar(Slider.Minimum, value, Slider.Max));
        }

        #region RecordsCallBack Members
        private static void
            OnSliderChangedCallBack(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            if (sender is Setting collection)
            {
                collection?.OnRecordsChanged();
            }
        }

        protected virtual void OnRecordsChanged()
        {
            OnPropertyChanged(nameof(Current));
        }
        #endregion

        public Setting()
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