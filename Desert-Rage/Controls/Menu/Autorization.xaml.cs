using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using DesertRage.ViewModel;
using Serilog;

namespace DesertRage.Controls.Menu
{
    /// <summary>
    /// Player autorization
    /// </summary>
    public partial class Autorization : UserControl, IDisposable, INotifyPropertyChanged
    {
        #region ViewModel Members
        public static readonly DependencyProperty
            ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
                typeof(GameStart), typeof(Autorization));

        public GameStart ViewModel
        {
            get => GetValue(ViewModelProperty) as GameStart;
            set => SetValue(ViewModelProperty, value);
        }
        #endregion

        private string _arrow;
        public string Arrow
        {
            get => _arrow;
            set
            {
                _arrow = value;
                OnPropertyChanged();
            }
        }

        private readonly HashSet<string> _toDrop;

        public Autorization()
        {
            InitializeComponent();
            _toDrop = new HashSet<string>();
            Arrow = "▲";
        }

        private void NextHero(object sender, RoutedEventArgs e)
        {
            ViewModel.Next();
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

                    if (selectedItem is null ||
                        selectedItem == string.Empty)
                        return;

                    _ = ViewModel.Profiles.Remove(selectedItem);
                    _ = _toDrop.Add(selectedItem);

                    DragDrop.DoDragDrop(this, new DataObject(DataFormats.FileDrop, selectedItem), DragDropEffects.Move);
                }
                catch (ArgumentNullException exception)
                {
                    Log.Error("Failed to do Drag-N-Drop:" + exception.Message);
                }
            }
        }

        private void ProfilesDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) is string item)
            {
                ViewModel.Profiles.Add(item);
                _toDrop.Remove(item);
            }
        }
        #endregion

        #region Selection Members
        private void UseProfile(object sender, RoutedEventArgs e)
        {
            if (ViewModel.ResetVisibility())
            {
                Arrow = "▼";
            }
            else
            {
                Arrow = "▲";
                foreach (string profile in _toDrop)
                {
                    Bank.DropProfile(profile);
                }
                _toDrop.Clear();
                ViewModel.UpdatePlayers();
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}