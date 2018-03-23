using ESAPIX.Bootstrapper;
using $safeprojectname$.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace $safeprojectname$
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bs = new AppBootstrapper<MainView>(()=> { return VMS.TPS.Common.Model.API.Application.CreateApplication(); });
            bs.Run();
        }
    }
}
