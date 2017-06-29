using ESAPIX.Facade.API;
using ESAPIX.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.AppKit
{
    public class OfflineContext : IScriptContext
    {
        public string ApplicationName { get; set; }

        public BrachyPlanSetup BrachyPlanSetup { get; set; }

        public IEnumerable<BrachyPlanSetup> BrachyPlansInScope { get; set; }

        public User CurrentUser { get; set; }

        public Course Course { get; set; }

        public Image Image { get; set; }

        public Patient Patient { get; set; }

        public ExternalPlanSetup ExternalPlanSetup { get; set; }

        public IEnumerable<ExternalPlanSetup> ExternalPlansInScope { get; set; }

        public PlanSetup PlanSetup { get; set; }

        public IEnumerable<PlanSetup> PlansInScope { get; set; }

        public IEnumerable<PlanSum> PlanSumsInScope { get; set; }

        public StructureSet StructureSet { get; set; }

        public IVMSThread Thread { get; set; }

        public System.Windows.Threading.Dispatcher UIDispatcher { get; set; }

        public event StandAloneContext.PatientChangedHandler PatientChanged;
        public event StandAloneContext.PlanSetupChangedHandler PlanSetupChanged;
        public event StandAloneContext.ExternalPlanSetupChangedHandler ExternalPlanSetupChanged;
        public event StandAloneContext.PlanSetupChangedHandler BrachyPlanSetupChanged;
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
