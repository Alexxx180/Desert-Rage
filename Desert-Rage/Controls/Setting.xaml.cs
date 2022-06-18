using System.Windows;
using System.Windows.Controls;
using Slider = DesertRage.Model.Locations.Battle.Stats.Slider;

namespace DesertRage.Controls
{
    /// <summary>
    /// Setting component based on slider
    /// </summary>
    public partial class Setting : UserControl
    {
        #region Caption Members
        public static readonly DependencyProperty
            CaptionProperty = DependencyProperty.Register
                (nameof(Caption), typeof(string), typeof(Setting));

        public string Caption
        {
            get => GetValue(CaptionProperty) as string;
            set => SetValue(CaptionProperty, value);
        }
        #endregion

        #region Slider Members
        public static readonly DependencyProperty
            SliderSettingProperty = DependencyProperty.Register
                (nameof(SliderSetting), typeof(Slider), typeof(Setting));

        public Slider SliderSetting
        {
            get => GetValue(SliderSettingProperty) as Slider;
            set => SetValue(SliderSettingProperty, value);
        }
        #endregion

        public Setting()
        {
            InitializeComponent();
        }
    }
}