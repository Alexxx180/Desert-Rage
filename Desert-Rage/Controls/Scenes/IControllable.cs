using System.Windows.Input;

namespace DesertRage.Controls.Scenes
{
    public interface IControllable
    {
        /// <summary>
        /// Element, which able 
        /// to receive user input
        /// </summary>
        
        public void KeyHandle(object sender, KeyEventArgs e);
        public void KeyRelease(object sender, KeyEventArgs e);

        public void Pause();
        public void Resume();
    }
}
