using System;

namespace DesertRage.Decorators.UI
{
    public static class Converters
    {
        public static Uri ToUri(this string Path, UriKind kind)
        {
            return new Uri(Path, kind);
        }

        public static Uri ToUri(this string Path)
        {
            return Path.ToUri(UriKind.RelativeOrAbsolute);
        }
    }
}