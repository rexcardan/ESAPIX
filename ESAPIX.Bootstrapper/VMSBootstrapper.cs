using ESAPIX.AppKit;
using ESAPIX.Facade;
using ESAPIX.Facade.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ESAPIX.Bootstrapper
{
    public class VMSBootstrapper
    {
        public VMSBootstrapper() { FacadeInitializer.Initialize(); }
        public Facade.API.Application GenerateFacadeApp(string username, string password)
        {
            return Facade.API.Application.CreateApplication(username, password);
        }

        public PluginContext GenerateFacadeScriptContext(VMS.TPS.Common.Model.API.ScriptContext sc, Window w)
        {
            var facade = new ScriptContext(sc);
            var plugin = new PluginContext(facade, w);
            XContext.Instance.CurrentContext = plugin;
            return plugin;
        }
    }
}
