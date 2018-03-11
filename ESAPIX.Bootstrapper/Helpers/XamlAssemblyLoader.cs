#region

using System.Runtime.Serialization.Formatters;
using System.Windows;
using Prism.Interactivity;
using Prism.Mvvm;
using i = System.Windows.Interactivity;

#endregion

namespace ESAPIX.Helpers
{
    public class XamlAssemblyLoader
    {
        /// <summary>
        ///     This method exists as a hack to get the XAML assemblies loaded in the plugin.
        /// </summary>
        public static void LoadAssemblies()
        {
            var formatter = FormatterAssemblyStyle.Full;
            var action = new i.InvokeCommandAction();
            action.CommandName = "Loaded";
            var window = new Window();
            ViewModelLocator.SetAutoWireViewModel(window, false);
            var action2 = new InvokeCommandAction();
            action.CommandName = "Loaded";
        }
    }
}