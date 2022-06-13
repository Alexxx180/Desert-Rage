using System.Windows.Controls;

namespace DesertRage.Decorators.UI
{
    public static class Media
    {
        public static void PlayOST(MediaElement element, in string path)
        {
            element.Stop();
            element.Source = path.ToUri();
            element.Play();
        }
    }
}