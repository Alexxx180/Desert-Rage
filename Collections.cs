using System.Collections.Generic;

namespace DesertRage.Decorators
{
    public static class Collections
    {
        public static void Refresh<T>
            (this IList<T> list, IEnumerable<T> value)
        {
            list.Clear();
            foreach (T item in value)
            {
                list.Add(item);
            }
        }
    }
}