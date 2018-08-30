#region
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Threading;
using ESAPIX.Facade;
using ESAPIX.Facade.API;
using ESAPIX.Interfaces;
using ESAPIX.Logging;
using X = ESAPIX.Facade.API;
#endregion

namespace ESAPIX.Common
{
    /// <summary>
    ///     Wraps a VMS application in a way that replicates the ScriptContext class. Can be used for debugging or building two
    ///     sided apps
    /// </summary>
    public class StandAloneContext : IScriptContext, IDisposable
    {
        private Application _app;

        public StandAloneContext(Func<dynamic> createVMSApp, bool multithreaded = false)
        {
            Exception e = null;
            if (createVMSApp == null)
            {
                throw new Exception("Must assign a function to create VMS app. Call SetAppFunction() prior to this.");
            }

            var thread = new AppComThread(multithreaded);
            thread.Invoke(() =>
            {
                var vms = createVMSApp();
                _app = new X.Application(vms);
            });
            this.Thread = thread;

            if (_app == null)
                throw new Exception("App was not created. Check to make sure the VMS dll references are correct.", e);

            if (ExpandoGetter.GetClient(_app) == null)
                throw new Exception(
                    "App was not created. Make sure FacadeInitializer.Initialize() in ESAPIX.Bootstrapper is being called before invoking static methods",
                    e);

            XContext.Instance.CurrentContext = this;
            CurrentUser = _app?.CurrentUser;
            Logger = new Logger();
        }

        public void Dispose()
        {
            _app?.Dispose();
            Thread.Dispose();
        }

        public Application Application { get { return _app; } }

        public Course Course { get; set; }

        public User CurrentUser { get; set; }

        public Image Image { get; set; }

        public Patient Patient { get; set; }

        public PlanSetup PlanSetup { get; set; }

        public IEnumerable<PlanSetup> PlansInScope { get; set; }

        public IEnumerable<PlanSum> PlanSumsInScope { get; set; }

        public StructureSet StructureSet { get; set; }

        public IVMSThread Thread { get; set; }

        public Dispatcher UIDispatcher { get; set; }

#if !VMS110
        public string ApplicationName { get; set; } = "VMS Application";

        public BrachyPlanSetup BrachyPlanSetup { get; private set; }

        public IEnumerable<BrachyPlanSetup> BrachyPlansInScope { get; set; }

        public ExternalPlanSetup ExternalPlanSetup { get; private set; }

        public IEnumerable<ExternalPlanSetup> ExternalPlansInScope { get; set; }
#endif
        public Logger Logger { get; private set; }

        public bool SetPatient(string id)
        {
            _app.ClosePatient();
            Patient = _app.OpenPatientById(id);
            var found = Patient != null;
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

        public bool SetCourse(Course course, bool autoFillChildren = true)
        {
            Course = course;
            if (autoFillChildren)
            {
                PlanSumsInScope = course?.PlanSums;
                PlansInScope = course?.PlanSetups;
            }
            //Notify
            OnCourseChanged(course);
            return Course != null;
        }

        public bool SetPlanSetup(PlanSetup plan, bool autoFillChildren = true)
        {
            PlanSetup = plan;
            if (autoFillChildren)
            {
                StructureSet = plan?.StructureSet;
                Image = plan?.StructureSet?.Image;
            }
            //Notify
            OnPlanSetupChanged(plan);
            return PlanSetup != null;
        }

        public void SetImage(Image im)
        {
            Image = im;
        }

        public void ClosePatient()
        {
            _app.ClosePatient();
            this.Patient = null;
            this.PlanSetup = null;
            this.Course = null;
#if !VMS110
            this.BrachyPlanSetup = null;
            this.ExternalPlanSetup = null;
            SetBrachyPlanSetup(null);
            SetExternalPlanSetup(null);
#endif
#if (VMS150 || VMS151 || VMS155)
            SetIonPlanSetup(null);
#endif
            OnPatientChanged(null);
            SetPlanSetup(null);
            SetCourse(null);
        }

        public void SetPlansInScope(IEnumerable<PlanSetup> plans)
        {
            PlansInScope = plans;
        }

#if !VMS110
        public void SetExternalPlansInScope(IEnumerable<ExternalPlanSetup> plans)
        {
            ExternalPlansInScope = plans;
        }

        public void SetBrachyPlansInScope(IEnumerable<BrachyPlanSetup> plans)
        {
            BrachyPlansInScope = plans;
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

        public bool SetBrachyPlanSetup(BrachyPlanSetup bs)
        {
            PlanSetup = bs;
            BrachyPlanSetup = bs;
            //Notify
            OnBrachyPlanSetupChanged(bs);
            OnPlanSetupChanged(bs);
            return BrachyPlanSetup != null;
        }
#endif

        #region CONTEXT CHANGED EVENTS

        public delegate void PatientChangedHandler(Patient newPatient);

#if (VMS150 || VMS151 || VMS155)
        public IonPlanSetup IonPlanSetup { get; set; }
        public IEnumerable<IonPlanSetup> IonPlansInScope { get; set; }

        public void SetIonPlansInScope(IEnumerable<IonPlanSetup> plans)
        {
            IonPlansInScope = plans;
        }

        public bool SetIonPlanSetup(IonPlanSetup plan, bool autoFillChildren = true)
        {
            IonPlanSetup = plan;
            if (autoFillChildren)
            {
                StructureSet = plan?.StructureSet;
                Image = plan?.StructureSet?.Image;
            }
            //Notify
            OnIonPlanSetupChanged(plan);
            return IonPlanSetup != null;
        }

        public delegate void IonPlanSetupChangedHandler(IonPlanSetup ps);
        public event StandAloneContext.IonPlanSetupChangedHandler IonPlanSetupChanged;

        public void OnIonPlanSetupChanged(IonPlanSetup ps)
        {
            IonPlanSetupChanged?.Invoke(ps);
        }
#endif

        public event PatientChangedHandler PatientChanged;

        public void OnPatientChanged(Patient p)
        {
            PatientChanged?.Invoke(p);
        }

        public delegate void PlanSetupChangedHandler(PlanSetup ps);

        public event PlanSetupChangedHandler PlanSetupChanged;

        public void OnPlanSetupChanged(PlanSetup ps)
        {
            PlanSetupChanged?.Invoke(ps);
        }

#if !VMS110
        public delegate void ExternalPlanSetupChangedHandler(ExternalPlanSetup ps);

        public event ExternalPlanSetupChangedHandler ExternalPlanSetupChanged;

        public void OnExternalPlanSetupChanged(ExternalPlanSetup ps)
        {
            ExternalPlanSetupChanged?.Invoke(ps);
        }

        public delegate void BrachyPlanSetupChangedHandler(BrachyPlanSetup ps);

        public event BrachyPlanSetupChangedHandler BrachyPlanSetupChanged;

        public void OnBrachyPlanSetupChanged(BrachyPlanSetup ps)
        {
            BrachyPlanSetupChanged?.Invoke(ps);
        }
#endif
        public delegate void CourseChangedHandler(Course c);

        public event CourseChangedHandler CourseChanged;

        public void OnCourseChanged(Course c)
        {
            CourseChanged?.Invoke(c);
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