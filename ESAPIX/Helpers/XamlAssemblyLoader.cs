using i = System.Windows.Interactivity;
using x = Microsoft.Expression.Interactivity;
using ESAPIX.AppKit;
using ESAPIX.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Facade.API;
using System.Windows;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization;

namespace ESAPIX.Helpers
{
    public class XamlAssemblyLoader
    {
        /// <summary>
        ///   This method exists as a hack to get the XAML assemblies loaded in the plugin. 
        /// </summary>
        public static void LoadAssemblies()
        {
            var formatter = FormatterAssemblyStyle.Full;
            i.InvokeCommandAction action = new i.InvokeCommandAction();
            action.CommandName = "Loaded";
            var window = new Window();
            x.VisualStateUtilities.GetVisualStateGroups(window);
            ViewModelLocator.SetAutoWireViewModel(window, false);
            var action2 = new Prism.Interactivity.InvokeCommandAction();
            action.CommandName = "Loaded";
        }
    }
}
