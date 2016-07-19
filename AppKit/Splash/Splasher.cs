using ESAPIX.AppKit.Splash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.AppKit.Splash
{
    public class Splasher
    {
        public async static Task ShowSplash()
        {
            await System.Windows.Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
            {
                var calling = Assembly.GetEntryAssembly();
                var name = calling.GetName().Name;
                var version = calling.GetName().Version;
                var label = string.Format("{0} {1}", name, version);
                var s = new SplashScreen(label);
                s.ShowDialog();
            }));
        }
    }
}
