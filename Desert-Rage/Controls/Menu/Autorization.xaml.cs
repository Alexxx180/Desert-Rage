using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using DesertRage.Writers;
using DesertRage.ViewModel;

namespace DesertRage.Controls.Menu
{
    /// <summary>
    /// Player autorization
    /// </summary>
    public partial class Autorization : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
                typeof(GameStart), typeof(Autorization));

        public GameStart ViewModel
        {
            get => GetValue(ViewModelProperty) as GameStart;
            set => SetValue(ViewModelProperty, value);
        }

        private readonly HashSet<string> _toDrop;

        public Autorization()
        {
            InitializeComponent();
            _toDrop = new HashSet<string>();
        }

        #region ProfilesManagement Members
        private void ProfilesMove(object sender, MouseEventArgs e)
        {
            Point mPos = e.GetPosition(null);

            if (e.LeftButton == MouseButtonState.Pressed &&
               Math.Abs(mPos.X) > SystemParameters.MinimumHorizontalDragDistance &&
               Math.Abs(mPos.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                try
                {
                    ListBox profileList = sender as ListBox;
                    string selectedItem = profileList.SelectedItem as string;

                    _ = ViewModel.Profiles.Remove(selectedItem);
                    _ = _toDrop.Add(selectedItem);

                    DragDrop.DoDragDrop(this, new DataObject(DataFormats.FileDrop, selectedItem), DragDropEffects.Move);
                }
                catch { }
            }
        }

        private void ProfilesDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) is string item)
            {
                ViewModel.Profiles.Add(item);
                _ = _toDrop.Remove(item);
            }
        }
        #endregion

        #region Selection Members
        private void SelectProfile(object sender, SelectionChangedEventArgs e)
        {
            ListBox profileList = sender as ListBox;
            ViewModel.CurrentProfile = profileList.SelectedItem as string;
        }

        private void UseProfile(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ViewModel.IsListVisible = !ViewModel.IsListVisible;

            if (ViewModel.IsListVisible)
            {
                button.Content = "▼";
            }
            else
            {
                button.Content = "▲";
                foreach (string file in _toDrop)
                {
                    Processors.TruncateFile(file);
                }
            }
        }
        #endregion

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