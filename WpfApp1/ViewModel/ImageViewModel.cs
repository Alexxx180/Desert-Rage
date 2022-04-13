using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.ViewModel
{
    public class ImageViewModel : INotifyPropertyChanged
    {
        private string _standardImage;
        public string StandardImage
        {
            get => _standardImage;
            set
            {
                _standardImage = value;
                OnPropertyChanged();
            }
        }

        private string _hoverImage;
        public string HoverImage
        {
            get => _hoverImage;
            set
            {
                _hoverImage = value;
                OnPropertyChanged();
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