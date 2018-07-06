#define VMS155

using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.Generic;
using System.Reflection;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using System.IO;

namespace VMS.TPS
{
    public class Script : MarshalByRefObject
    {
        public Script()
        {
        }

        public void Execute(ScriptContext context, System.Windows.Window window)
        {
            //Get this window barely visible so that when it does show, it isn't ugly ;)
            window.Height = window.Width = 0;
            window.WindowStyle = WindowStyle.None;
            window.Loaded += Window_Loaded;

            window.Hide();

            var assemblyPath = @"D:\Git\XCheck\XCheck\XCheck\XCheck\bin\x64\Release\XCheck.esapi.exe";

            var args = ArgumentBuilder.Build(context);
            MessageBox.Show(args);
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationBase = Path.GetDirectoryName(assemblyPath);
            MessageBox.Show("Creating app domain");
            var evidence = AppDomain.CurrentDomain.Evidence;
            var appDomain = AppDomain.CreateDomain("ESAPIX" + Guid.NewGuid(), evidence, setup);
            MessageBox.Show("Executing app domain");
            try
            {
                appDomain.DoCallBack(() => AppDomain.CurrentDomain.ExecuteAssembly(assemblyPath));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #region WINDOW PLUMBING

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var win = sender as Window;
            win.Loaded -= Window_Loaded;
            win.Close();
        }

        #endregion

    }

    public class ArgumentBuilder
    {
        public static string Build(ScriptContext ctx)
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("{0} {1}", ArgumentKey.CurrentUserId, ctx.CurrentUser.Id));

#if !VMS110
            if (!string.IsNullOrEmpty(ctx.ApplicationName))
            {
                sb.Append(string.Format("{0} {1}", ArgumentKey.ApplicationName, ctx.ApplicationName));
            }
            if (ctx.BrachyPlansInScope != null && ctx.BrachyPlansInScope.Any())
            {
                var uids = ctx.BrachyPlansInScope.Select(p => p.UID).ToArray();
                sb.Append(string.Format("{0} {1}", ArgumentKey.BrachyPlansInScope, string.Join(" ", uids)));
            }
            if (ctx.ExternalPlansInScope != null && ctx.ExternalPlansInScope.Any())
            {
                var uids = ctx.ExternalPlansInScope.Select(p => p.UID).ToArray();
                sb.Append(string.Format("{0} {1}", ArgumentKey.ExternalPlansInScope, string.Join(" ", uids)));
            }
            if (ctx.BrachyPlanSetup != null)
            {
                sb.Append(string.Format("{0} {1}", ArgumentKey.BrachyPlanSetup, ctx.BrachyPlanSetup != null ? ctx.BrachyPlanSetup.UID : null));
            }
            if (ctx.ExternalPlanSetup != null)
            {
                sb.Append(string.Format("{0} {1}", ArgumentKey.ExternalPlanSetup, ctx.ExternalPlanSetup != null ? ctx.ExternalPlanSetup.UID : null));
            }
#endif
            if (ctx.Patient != null && !string.IsNullOrEmpty(ctx.Patient.Id))
            {
                sb.Append(string.Format("{0} {1}", ArgumentKey.PatientId, ctx.Patient.Id));
            }
            if (ctx.Image != null)
            {
                sb.Append(string.Format("{0} {1} {2}", ArgumentKey.Image, ctx.Image.Id, ctx.Image.Series.UID));
            }
            if (ctx.StructureSet != null)
            {
                sb.Append(string.Format("{0} {1}", ArgumentKey.StructureSet, ctx.StructureSet != null ? ctx.StructureSet.UID : null));
            }
            if (ctx.PlanSetup != null)
            {
                sb.Append(string.Format("{0} {1}", ArgumentKey.PlanSetup, ctx.PlanSetup != null ? ctx.PlanSetup.UID : null));
            }

            if (ctx.Course != null)
            {
                sb.Append(string.Format("{0} {1}", ArgumentKey.Course, ctx.Course != null ? ctx.Course.Id : null));
            }
            if (ctx.PlansInScope != null && ctx.PlansInScope.Any())
            {
                var uids = ctx.PlansInScope.Select(p => p.UID).ToArray();
                sb.Append(string.Format("{0} {1}", ArgumentKey.PlansInScope, string.Join(" ", uids)));
            }

            if (ctx.PlanSumsInScope != null && ctx.PlanSumsInScope.Any())
            {
                var ids = ctx.PlanSumsInScope.Select(p => p.Id).ToArray();
                sb.Append(string.Format("{0} {1}", ArgumentKey.PlanSumsInScope, string.Join(" ", ids)));
            }
#if (VMS151 || VMS150 || VMS155)
            if (ctx.IonPlansInScope != null && ctx.IonPlansInScope.Any())
            {
                var ids = ctx.IonPlansInScope.Select(p => p.Id).ToArray();
                sb.Append(string.Format("{0} {1}", ArgumentKey.IonPlansInScope, string.Join(" ", ids)));
            }
            if (ctx.IonPlanSetup != null)
            {
                sb.Append(string.Format("{0} {1}", ArgumentKey.IonPlanSetup, ctx.IonPlanSetup != null ? ctx.IonPlanSetup.UID : null));
            }
#endif
            return sb.ToString();
        }
    }

    public class ArgumentKey
    {
        public const string CurrentUserId = "-u";
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
        public const string IonPlansInScope = "-ipsc";
        public const string IonPlanSetup = "-ip";
    }
}
