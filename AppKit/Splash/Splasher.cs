using ESAPIX.AppKit.Splash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ESAPIX.AppKit.Splash
{
    public class Splasher
    {
        public static Window ShowSplash()
        {
                var calling = Assembly.GetEntryAssembly();
                var name = calling.GetName().Name;
                var version = calling.GetName().Version;
                var label = string.Format("{0} {1}", name, version);
                var s = new SplashScreen(label);
                return s;
        }
    }
}
