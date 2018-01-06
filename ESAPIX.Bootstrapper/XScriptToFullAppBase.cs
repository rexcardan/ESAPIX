using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
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
        public string AppStartPath { get; set; }

        public void Execute(ScriptContext context, Window window)
        {
            //When hooked up to bootstrapper (comment out otherwise)
            FacadeInitializer.Initialize();
            //Get this window barely visible so that when it does show, it isn't ugly ;)
            window.Height = window.Width = 0;
            window.WindowStyle = WindowStyle.None;
            window.Hide();
            window.Loaded += Window_Loaded;

            var args = ArgumentBuilder.Build(context);
            Process.Start(AppStartPath, args);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var win = sender as Window;
            win.Loaded += Window_Loaded;
            win.Close();
        }

        public class ArgumentBuilder
        {
            public static string Build(ScriptContext ctx)
            {
                var sb = new StringBuilder();
                sb.Append($"{ArgumentKey.CurrentUser} {ctx.CurrentUser?.Id} ");

                if (!string.IsNullOrEmpty(ctx.ApplicationName))
                {
                    sb.Append($"{ArgumentKey.ApplicationName} {ctx.ApplicationName} ");
                }
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
                if (ctx.BrachyPlanSetup != null)
                {
                    sb.Append($"{ArgumentKey.BrachyPlanSetup} {ctx.BrachyPlanSetup?.UID} ");
                }
                if (ctx.ExternalPlanSetup != null)
                {
                    sb.Append($"{ArgumentKey.ExternalPlanSetup} {ctx.ExternalPlanSetup?.UID} ");
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
                if (ctx.PlanSumsInScope != null && ctx.PlanSumsInScope.Any())
                {
                    var ids = ctx.PlanSumsInScope.Select(p => p.Id).ToArray();
                    sb.Append($"{ArgumentKey.PlanSumsInScope} {string.Join(" ", ids)} ");
                }
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
        public class ArgumentKey
        {
            public const string CurrentUser = "-u";
            public const string Course = "-c";
            public const string Image = "-i";
            public const string StructureSet = "-ss";
            public const string ApplicationName = "-a";
            public const string PatientId = "-id";
            public const string PlanSetup = "-p";
            public const string BrachyPlanSetup = "-bp";
            public const string BrachyPlansInScope = "-bpsc";
            public const string ExternalPlanSetup = "-ep";
            public const string ExternalPlansInScope = "-epsc";
            public const string PlansInScope = "-psc";
            public const string PlanSumsInScope = "-pssc";

        }
    }
}
