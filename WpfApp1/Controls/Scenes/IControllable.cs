using System.Windows.Input;

namespace DesertRage.Controls.Scenes
{
    public interface IControllable
    {
        public void KeyHandle(object sender, KeyEventArgs e);
    }
}