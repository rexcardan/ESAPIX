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
using VMS.TPS.Common.Model.API;
using System.Windows;

namespace ESAPIX.Helpers
{
    public class XamlAssemblyLoader
    {
        //This method exists as a hack to get the XAML assebmlies loaded in the plugin
        public static void LoadAssemblies()
        {
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
