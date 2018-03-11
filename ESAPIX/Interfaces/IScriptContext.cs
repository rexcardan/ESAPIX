#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Threading;
using ESAPIX.Facade.API;
using ESAPIX.Logging;
using static ESAPIX.Common.StandAloneContext;

#endregion

namespace ESAPIX.Interfaces
{
    /// <summary>
    ///     The common interface for use in standalone and plugin applications. It exposes properties that found in a the
    ///     "ScriptContext" class
    /// </summary>
    public interface IScriptContext
    {
#if !VMS110
        string ApplicationName { get; }

        BrachyPlanSetup BrachyPlanSetup { get; }

        IEnumerable<BrachyPlanSetup> BrachyPlansInScope { get; }

        ExternalPlanSetup ExternalPlanSetup { get; }

        IEnumerable<ExternalPlanSetup> ExternalPlansInScope { get; }
#endif
        User CurrentUser { get; }

        Course Course { get; }

        Image Image { get; }

        Patient Patient { get; }

        PlanSetup PlanSetup { get; }

        IEnumerable<PlanSetup> PlansInScope { get; }

        IEnumerable<PlanSum> PlanSumsInScope { get; }

#if (VMS150 || VMS151 || VMS155)
        IonPlanSetup IonPlanSetup {get;}

        IEnumerable<IonPlanSetup> IonPlansInScope {get;}

        event IonPlanSetupChangedHandler IonPlanSetupChanged;
#endif


        StructureSet StructureSet { get; }

        /// <summary>
        ///     The thread that can access VMS objects
        /// </summary>
        IVMSThread Thread { get; }

        Dispatcher UIDispatcher { get; set; }

        /// <summary>
        ///     Gets a value on the correct thread and returns it
        /// </summary>
        /// <typeparam name="T">the type of value to be returned</typeparam>
        /// <param name="toExecute">the function that assigns the value</param>
        /// <returns>the value requested</returns>
        T GetValue<T>(Func<IScriptContext, T> toExecute);

        /// <summary>
        ///     Gets a value asynchronously on the correct thread and returns it
        /// </summary>
        /// <typeparam name="T">the type of value to be returned</typeparam>
        /// <param name="toExecute">the function that assigns the value</param>
        /// <returns>a task of the value requested</returns>
        Task<T> GetValueAsync<T>(Func<IScriptContext, T> toExecute);

        Logger Logger { get; }

        #region EVENTS

        //These are only used in Standalone Context, but are here so casting does not have to be performed to check
        event PatientChangedHandler PatientChanged;
        event PlanSetupChangedHandler PlanSetupChanged;
#if !VMS110
        event ExternalPlanSetupChangedHandler ExternalPlanSetupChanged;
        event BrachyPlanSetupChangedHandler BrachyPlanSetupChanged;
#endif
        event CourseChangedHandler CourseChanged;
        #endregion
    }
}