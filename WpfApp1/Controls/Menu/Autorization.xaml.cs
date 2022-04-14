using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Collections.ObjectModel;

//using DesertRage.Model;


namespace DesertRage.Controls.Menu
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<string> _profiles;
        public ObservableCollection<string> Profiles
        {
            get => _profiles;
            set
            {
                _profiles = value;
                OnPropertyChanged();
            }
        }

        public Autorization()
        {
            InitializeComponent();

            Profiles = new ObservableCollection<string>();

            Profiles.Add("АляТополя");
            Profiles.Add("МистерПерпендыкович");
            Profiles.Add("СерьезныйСэм");
            Profiles.Add("Еще");
            Profiles.Add("И еще");
            Profiles.Add("И еще один");
        }

        private void ProfilesMouseMove(object sender, MouseEventArgs e)
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
                    

                    Trace.WriteLine(selectedItem);
                    _ = Profiles.Remove(selectedItem);

                    DragDrop.DoDragDrop(this, new DataObject(DataFormats.FileDrop, selectedItem), DragDropEffects.Move);
                }
                catch { }
            }
        }

        private void ProfilesDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) is string item)
            {
                Profiles.Add(item);
            }
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