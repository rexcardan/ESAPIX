using ESAPIX.Bootstrapper.AppKit.Splash;
using ESAPIX.Bootstrapper.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using VMS.TPS.Common.Model.API;

namespace ESAPIX.Bootstrapper
{
    /// <summary>
    /// A script.cs file should be included in your WPF app which inherits from this class. Set the AppStartPath in the 
    /// constructor. Pass the arguments to the AppBootstrapper.Run to preload the same context that was in Eclipse when 
    /// launched
    /// </summary>
    public class XScriptToFullAppBase
    {
        /// <summary>
        /// The path to your WPF executable (standalone app).
        /// </summary>
        public string AppStartPath { get; set; }

        public void Execute(ScriptContext context, Window window)
        {
            //Get this window barely visible so that when it does show, it isn't ugly ;)
            window.Height = window.Width = 0;
            window.WindowStyle = WindowStyle.None;
            window.Loaded += Window_Loaded;

            if (Splash != null)
            {
                window.Content = Splash;
                window.Width = Splash.Width;
                window.Height = Splash.Height;
                Splash.Finished += (send, args1) =>
                {
                    window.Hide();
                };
            }
            else
            {
                window.Hide();
            }

            var args = ArgumentBuilder.Build(context);
            var process = Process.Start(AppStartPath, args);
            process.WaitForExit();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var win = sender as Window;
            win.Loaded -= Window_Loaded;
            win.Close();
        }

        public class ArgumentBuilder
        {
            public static string Build(ScriptContext ctx)
            {
                var sb = new StringBuilder();
                sb.Append($"{ArgumentKey.CurrentUserId} {ctx.CurrentUser?.Id} ");

#if !VMS110
                if (!string.IsNullOrEmpty(ctx.ApplicationName))
                {
                    sb.Append($"{ArgumentKey.ApplicationName} {ctx.ApplicationName} ");
                }
                if (ctx.BrachyPlansInScope != null && ctx.BrachyPlansInScope.Any())
                {
                    var uids = ctx.BrachyPlansInScope.Select(p => p.UID).ToArray();
                    sb.Append($"{ArgumentKey.BrachyPlansInScope} {string.Join(" ", uids)} ");
                }
                if (ctx.ExternalPlansInScope != null && ctx.ExternalPlansInScope.Any())
                {
                    var uids = ctx.ExternalPlansInScope.Select(p => p.UID).ToArray();
                    sb.Append($"{ArgumentKey.ExternalPlansInScope} {string.Join(" ", uids)} ");
                }
                if (ctx.BrachyPlanSetup != null)
                {
                    sb.Append($"{ArgumentKey.BrachyPlanSetup} {ctx.BrachyPlanSetup?.UID} ");
                }
                if (ctx.ExternalPlanSetup != null)
                {
                    sb.Append($"{ArgumentKey.ExternalPlanSetup} {ctx.ExternalPlanSetup?.UID} ");
                }
#endif
                if (!string.IsNullOrEmpty(ctx.Patient?.Id))
                {
                    sb.Append($"{ArgumentKey.PatientId} {ctx.Patient.Id} ");
                }
                if (ctx.Image != null)
                {
                    sb.Append($"{ArgumentKey.Image} {ctx.Image.Id} {ctx.Image.Series.UID} ");
                }
                if (ctx.Image != null)
                {
                    sb.Append($"{ArgumentKey.Image} {ctx.Image.Id} {ctx.Image.Series.UID}");
                }
                if (ctx.StructureSet != null)
                {
                    sb.Append($"{ArgumentKey.StructureSet} {ctx.StructureSet?.UID} ");
                }
                if (ctx.PlanSetup != null)
                {
                    sb.Append($"{ArgumentKey.PlanSetup} {ctx.PlanSetup?.UID} ");
                }

                if (ctx.Course != null)
                {
                    sb.Append($"{ArgumentKey.Course} {ctx.Course?.Id} ");
                }
                if (ctx.PlansInScope != null && ctx.PlansInScope.Any())
                {
                    var uids = ctx.PlansInScope.Select(p => p.UID).ToArray();
                    sb.Append($"{ArgumentKey.PlansInScope} {string.Join(" ", uids)} ");
                }

                if (ctx.PlanSumsInScope != null && ctx.PlanSumsInScope.Any())
                {
                    var ids = ctx.PlanSumsInScope.Select(p => p.Id).ToArray();
                    sb.Append($"{ArgumentKey.PlanSumsInScope} {string.Join(" ", ids)} ");
                }
#if (VMS151 || VMS150 || VMS155)
                if (ctx.IonPlansInScope != null && ctx.IonPlansInScope.Any())
                {
                    var ids = ctx.IonPlansInScope.Select(p => p.Id).ToArray();
                    sb.Append($"{ArgumentKey.IonPlansInScope} {string.Join(" ", ids)} ");
                }
                if (ctx.IonPlanSetup != null)
                {
                    sb.Append($"{ArgumentKey.IonPlanSetup} {ctx.IonPlanSetup?.UID} ");
                }
#endif
                return sb.ToString();
            }

            #region WINDOW PLUMBING

            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                var win = sender as Window;
                win.Loaded += Window_Loaded;
                win.Close();
            }

            #endregion
        }

        public SplashTemplate Splash { get; set; }
    }
}
