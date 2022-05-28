using System.Windows;
using System.Windows.Data;

namespace DesertRage.Decorators.UI.Bindings
{
    public static class Bindings
    {
        public static void Bind(this
            DependencyObject @object,
            DependencyProperty property,
            object reference, string path
            )
        {
            Binding myBinding = new Binding
            {
                Source = reference,
                Path = new PropertyPath(path)
            };
            BindingOperations.SetBinding
                (@object, property, myBinding);
        }

        public static void Bind(this
            DependencyObject @object,
            DependencyProperty property,
            object reference, string path,
            BindingMode mode,
            UpdateSourceTrigger trigger
            )
        {
            Binding myBinding = new Binding
            {
                Source = reference,
                Path = new PropertyPath(path),
                Mode = mode,
                UpdateSourceTrigger = trigger
            };
            BindingOperations.SetBinding
                (@object, property, myBinding);
        }
    }
}