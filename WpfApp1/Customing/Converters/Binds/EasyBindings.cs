using System.Windows;
using System.Windows.Data;

namespace DesertRage.Customing.Converters.Binds
{
    public static class EasyBindings
    {
        public static Binding FastBind(object source, string path)
        {
            return new Binding
            {
                Source = source,
                Path = new PropertyPath(path)
            };
        }

        public static DependencyObject SetBind(DependencyObject @object, DependencyProperty property, BindingBase @base)
        {
            BindingOperations.SetBinding(@object, property, @base);
            return @object;
        }
        public static MultiBinding Multi(IMultiValueConverter converter, params Binding[] bindings)
        {
            MultiBinding multi = new MultiBinding { Converter = converter };
            foreach (Binding bind in bindings)
                multi.Bindings.Add(bind);
            return multi;
        }
        public static MultiBinding Multi(params Binding[] bindings)
        {
            MultiBinding multi = new MultiBinding();
            foreach (Binding bind in bindings)
                multi.Bindings.Add(bind);
            return multi;
        }
    }
}
