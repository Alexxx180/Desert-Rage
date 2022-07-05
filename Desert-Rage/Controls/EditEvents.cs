using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using static DesertRage.Controls.EditHelper;

namespace DesertRage.Controls
{
    public partial class EditEvents
    {
        /// <summary>
        /// Events attached to editing fields
        /// </summary>
        
        #region Naming Members
        private static readonly Regex _naming = new Regex(@"^[A-Za-zА-Яа-я0-9\s-_]*$");

        private void Naming(object sender, TextCompositionEventArgs e)
        {
            CheckForText(e, _naming);
        }

        private void PastingNaming(object sender, DataObjectPastingEventArgs e)
        {
            CheckForPastingText(sender, e, _naming);
        }
        #endregion
    }
}
