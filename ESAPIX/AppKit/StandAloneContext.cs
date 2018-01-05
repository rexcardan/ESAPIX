#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Threading;
using ESAPIX.Facade;
using ESAPIX.Facade.API;
using ESAPIX.Interfaces;
using ESAPIX.Logging;

#endregion

namespace ESAPIX.AppKit
{
    /// <summary>
    ///     Wraps a VMS application in a way that replicates the ScriptContext class. Can be used for debugging or building two
    ///     sided apps
    /// </summary>
    public class StandAloneContext : IScriptContext, IDisposable
    {
        private readonly Application _app;

        public StandAloneContext(Application app, IVMSThread thread)
        {
            _app = app;
            Thread = thread ?? new AppComThread(false); //Same thread
            Logger = new Logger();
        }

        public void Dispose()
        {
            _app?.Dispose();
        }

        public Course Course { get; private set; }

        public User CurrentUser => _app?.CurrentUser;

        public Image Image => PlanSetup?.StructureSet.Image;

        public Patient Patient { get; private set; }

        public PlanSetup PlanSetup { get; private set; }

        public IEnumerable<PlanSetup> PlansInScope => Course?.PlanSetups;

        public IEnumerable<PlanSum> PlanSumsInScope => Course?.PlanSums;

        public StructureSet StructureSet => PlanSetup?.StructureSet;

        public IVMSThread Thread { get; set; }

        public Dispatcher UIDispatcher { get; set; }

        public string ApplicationName { get; set; } = "VMS Application";

        public BrachyPlanSetup BrachyPlanSetup { get; private set; }

        public IEnumerable<BrachyPlanSetup> BrachyPlansInScope => Course?.BrachyPlanSetups;

        public ExternalPlanSetup ExternalPlanSetup { get; private set; }

        public IEnumerable<ExternalPlanSetup> ExternalPlansInScope => Course?.ExternalPlanSetups;

        public Logger Logger { get; private set; }

        /// <summary>
        ///     Creates a new application context and binds it to a new thread
        /// </summary>
        /// <param name="username">VMS username</param>
        /// <param name="password">VMS password</param>
        /// <returns>app context</returns>
        public static StandAloneContext Create(string username, string password, bool singleThread = false)
        {
            var app = Application.CreateApplication(username, password, singleThread);
            var thread = XContext.Instance.CurrentContext.Thread;
            return new StandAloneContext(app, thread);
        }

        public bool SetPatient(string id)
        {
            _app.ClosePatient();
            Patient = _app.OpenPatientById(id);
            var found = Patient!=null && Patient.IsLive;
            if (found)
                OnPatientChanged(Patient);
            else
                OnPatientChanged(null);
            return found;
        }

        public async Task<bool> SetPatientAsync(string id)
        {
            Patient = await Task.Run(() => { return _app.OpenPatientById(id); });
            var found = Patient.IsLive;
            if (found)
                OnPatientChanged(Patient);
            else
                OnPatientChanged(null);
            return found;
        }

        public bool SetCourse(Course course)
        {
            Course = course;
            //Notify
            OnCourseChanged(course);
            return Course != null;
        }

        public bool SetPlanSetup(PlanSetup plan)
        {
            PlanSetup = plan;
            //Notify
            OnPlanSetupChanged(plan);
            return PlanSetup != null;
        }

        public bool SetExternalPlanSetup(ExternalPlanSetup ex)
        {
            PlanSetup = ex;
            ExternalPlanSetup = ex;
            //Notify
            OnExternalPlanSetupChanged(ex);
            OnPlanSetupChanged(ex);
            return ExternalPlanSetup != null;
        }

        public void SetImage(Image im)
        {
            throw new NotImplementedException();
        }

        public bool SetBrachyPlanSetup(BrachyPlanSetup bs)
        {
            PlanSetup = bs;
            BrachyPlanSetup = bs;
            //Notify
            OnBrachyPlanSetupChanged(bs);
            OnPlanSetupChanged(bs);
            return BrachyPlanSetup != null;
        }

        public void ClosePatient()
        {
            _app.ClosePatient();
            this.Patient = null;
            this.PlanSetup = null;
            this.Course = null;
            this.BrachyPlanSetup = null;
            this.ExternalPlanSetup = null;
            OnPatientChanged(null);
            SetPlanSetup(null);
            SetCourse(null);
            SetBrachyPlanSetup(null);
            SetExternalPlanSetup(null);
        }

        public void SetPlansInScope(IEnumerable<PlanSetup> plans)
        {
            throw new NotImplementedException();
        }

        public void SetExternalPlansInScope(IEnumerable<ExternalPlanSetup> plans)
        {
            throw new NotImplementedException();
        }

        #region CONTEXT CHANGED EVENTS

        public delegate void PatientChangedHandler(Patient newPatient);

        public void SetBrachyPlansInScope(IEnumerable<BrachyPlanSetup> plans)
        {
            throw new NotImplementedException();
        }

        public event PatientChangedHandler PatientChanged;

        public void OnPatientChanged(Patient p)
        {
            UIDispatcher?.Invoke(() => PatientChanged?.Invoke(p));
        }

        public delegate void PlanSetupChangedHandler(PlanSetup ps);

        public event PlanSetupChangedHandler PlanSetupChanged;

        public void OnPlanSetupChanged(PlanSetup ps)
        {
            UIDispatcher?.Invoke(() => PlanSetupChanged?.Invoke(ps));
        }

        public delegate void ExternalPlanSetupChangedHandler(ExternalPlanSetup ps);

        public event ExternalPlanSetupChangedHandler ExternalPlanSetupChanged;

        public void OnExternalPlanSetupChanged(ExternalPlanSetup ps)
        {
            UIDispatcher?.Invoke(() => ExternalPlanSetupChanged?.Invoke(ps));
        }

        public delegate void BrachyPlanSetupChangedHandler(BrachyPlanSetup ps);

        public event PlanSetupChangedHandler BrachyPlanSetupChanged;

        public void OnBrachyPlanSetupChanged(BrachyPlanSetup ps)
        {
            UIDispatcher?.Invoke(() => BrachyPlanSetupChanged?.Invoke(ps));
        }

        public delegate void CourseChangedHandler(Course c);

        public event CourseChangedHandler CourseChanged;

        public void OnCourseChanged(Course c)
        {
            UIDispatcher?.Invoke(() => CourseChanged?.Invoke(c));
        }

        public async Task<T> GetValueAsync<T>(Func<IScriptContext, T> toExecute)
        {
            var result = default(T);
            await Thread.InvokeAsync(() => { result = toExecute(this); });
            return result;
        }

        public T GetValue<T>(Func<IScriptContext, T> toExecute)
        {
            var result = default(T);
            Thread.Invoke(() => { result = toExecute(this); });
            return result;
        }

        #endregion
    }
}