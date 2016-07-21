using ESAPIX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;

namespace ESAPIX.AppKit
{
    /// <summary>
    /// Wraps a VMS application in a way that replicates the ScriptContext class. Can be used for debugging or building two sided apps
    /// </summary>
    public class StandAloneContext : IScriptContext, IDisposable
    {
        private Application _app;
        private Course _course;
        private Patient _patient;
        private PlanSetup _planSetup;
        private BrachyPlanSetup _brachyPlanSetup;
        private ExternalPlanSetup _exPlanSetup;

        public StandAloneContext(Application app, IVMSThread thread)
        {
            _app = app;
            Thread = thread ?? new AppComThread(false); //Same thread
        }

        /// <summary>
        /// Creates a new application context and binds it to a new thread
        /// </summary>
        /// <param name="username">VMS username</param>
        /// <param name="password">VMS password</param>
        /// <returns>app context</returns>
        public static StandAloneContext Create(string username, string password)
        {
            var thread = new AppComThread();
            Application app = null;
            thread.Invoke(() =>
            {
                app = Application.CreateApplication(username, password);
            });
            return new StandAloneContext(app, thread);
        }

        public bool SetPatient(string id)
        {
            Thread.Invoke(() =>
            {
                _patient = _app.OpenPatientById(id);
                OnPatientChanged(_patient);
            });
            return _patient != null;
        }

        public async Task<bool> SetPatientAsync(string id)
        {
            await Thread.InvokeAsync(() =>
            {
                _patient = _app.OpenPatientById(id);
                OnPatientChanged(_patient);
            });
            return _patient != null;
        }

        public bool SetCourse(Course course)
        {
            _course = course;
            OnCourseChanged();
            return _course != null;
        }

        public bool SetExternalPlanSetup(ExternalPlanSetup ex)
        {
            _planSetup = ex;
            _exPlanSetup = ex;
            return _exPlanSetup != null;
        }

        public bool SetBrachyPlanSetup(BrachyPlanSetup bs)
        {
            _planSetup = bs;
            _brachyPlanSetup = bs;
            return _brachyPlanSetup != null;
        }

        public void ClosePatient()
        {
            Thread.Invoke(() =>
            {
                _app.ClosePatient();
                OnPatientChanged(null);
            });
        }

        public void Dispose()
        {
            Thread.Invoke(() =>
            {
                _app.Dispose();
            });
        }

        public Course Course { get { return _course; } }

        public User CurrentUser { get { return _app?.CurrentUser; } }

        public Image Image { get { return _planSetup?.StructureSet.Image; } }

        public Patient Patient { get { return _patient; } }

        public PlanSetup PlanSetup { get { return _planSetup; } }

        public IEnumerable<PlanSetup> PlansInScope { get { return _course?.PlanSetups; } }

        public IEnumerable<PlanSum> PlanSumsInScope { get { return _course?.PlanSums; } }

        public StructureSet StructureSet { get { return _planSetup?.StructureSet; } }

        public IVMSThread Thread { get; private set; }

        #region CONTEXT CHANGED EVENTS
        public delegate void PatientChangedHandler(Patient newPatient);
        public event PatientChangedHandler PatientChanged;
        public void OnPatientChanged(Patient p) => PatientChanged?.Invoke(p);
        public string ApplicationName { get; set; } = "VMS Application";

        public BrachyPlanSetup BrachyPlanSetup { get; }

        public IEnumerable<BrachyPlanSetup> BrachyPlansInScope { get { return _course?.BrachyPlanSetups; } }

        public delegate void PlanSetupChangedHandler();
        public event PlanSetupChangedHandler PlanSetupChanged;
        public void OnPlanSetupChanged() => PlanSetupChanged?.Invoke();
        public ExternalPlanSetup ExternalPlanSetup { get { return _exPlanSetup; } }

        public delegate void CourseChangedHandler();
        public event CourseChangedHandler CourseChanged;
        public void OnCourseChanged() => CourseChanged?.Invoke();
        #endregion
        public IEnumerable<ExternalPlanSetup> ExternalPlansInScope { get { return _course?.ExternalPlanSetups; } }
    }
}
