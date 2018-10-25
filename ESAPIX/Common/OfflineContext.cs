#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;
using ESAPIX.Interfaces;
using ESAPIX.Logging;

#endregion

namespace ESAPIX.Common
{
    public class OfflineContext : IScriptContext
    {
        public string ApplicationName { get; set; }

#if !VMS110
        public BrachyPlanSetup BrachyPlanSetup { get; set; }

        public IEnumerable<BrachyPlanSetup> BrachyPlansInScope { get; set; }

        public ExternalPlanSetup ExternalPlanSetup { get; set; }

        public IEnumerable<ExternalPlanSetup> ExternalPlansInScope { get; set; }
#endif
        public User CurrentUser { get; set; }

        public Course Course { get; set; }

        public Image Image { get; set; }

        public Patient Patient { get; set; }

        public PlanSetup PlanSetup { get; set; }

        public IEnumerable<PlanSetup> PlansInScope { get; set; }

        public IEnumerable<PlanSum> PlanSumsInScope { get; set; }

        public StructureSet StructureSet { get; set; }

        public IVMSThread Thread { get; set; }

        public System.Windows.Threading.Dispatcher UIDispatcher { get; set; }

        public Logger Logger => throw new NotImplementedException();

#if (VMS150 || VMS151 || VMS155)
        public IonPlanSetup IonPlanSetup { get; set; }
        public IEnumerable<IonPlanSetup> IonPlansInScope { get; set; }
        public event StandAloneContext.IonPlanSetupChangedHandler IonPlanSetupChanged;
#endif

        public event StandAloneContext.PatientChangedHandler PatientChanged;
        public event StandAloneContext.PlanSetupChangedHandler PlanSetupChanged;
#if (!VMS110)
        public event StandAloneContext.ExternalPlanSetupChangedHandler ExternalPlanSetupChanged;
        public event StandAloneContext.BrachyPlanSetupChangedHandler BrachyPlanSetupChanged;
#endif
        public event StandAloneContext.CourseChangedHandler CourseChanged;


        public T GetValue<T>(Func<IScriptContext, T> toExecute)
        {
            return toExecute(this);
        }

        public Task<T> GetValueAsync<T>(Func<IScriptContext, T> toExecute)
        {
            return Task.Run(() => toExecute(this));
        }
    }
}