using System.Windows.Controls;

namespace DesertRage.Decorators.UI
{
    public static class Media
    {
        public static void PlayOST(MediaElement element, in string Path)
        {
            element.Stop();
            element.Source = Path.ToUri();
            element.Play();
        }
    }
}