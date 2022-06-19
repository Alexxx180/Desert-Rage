using System.Windows.Input;

namespace DesertRage.Controls.Scenes
{
    public interface IControllable
    {
        public void KeyHandle(object sender, KeyEventArgs e);
        public void KeyRelease(object sender, KeyEventArgs e);

        public void Pause();
        public void Resume();
    }
}