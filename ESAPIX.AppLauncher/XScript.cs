using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VMS.TPS.Common.Model.API;

namespace ESAPIX.AppLauncher
{
    /// <summary>
    /// A script.cs file should be included in your WPF app which inherits from this class. Set the AppStartPath in the 
    /// constructor. Pass the arguments to the AppBootstrapper.Run to preload the same context that was in Eclipse when 
    /// launched
    /// </summary>
    public class XScript
    {
        public string AppStartPath { get; set; }

        public void Execute(ScriptContext context, string startPath)
        {
            var args = ArgumentBuilder.Build(context);
            AppStartPath = startPath;

            if (string.IsNullOrEmpty(AppStartPath))
            {
                throw new ArgumentException("AppStartPath must be set before calling Execute");
            }
            Process.Start(AppStartPath, args);
        }
    }

}
