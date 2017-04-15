using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Application : ESAPIX.Facade.API.SerializableObject
    {
        public Application() { }
        public Application(dynamic client) { _client = client; }
        public ESAPIX.Facade.API.User CurrentUser
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.User(local._client.CurrentUser);
            }
        }
        public IEnumerable<ESAPIX.Facade.API.PatientSummary> PatientSummaries
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.PatientSummary>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.PatientSummaries).Select(s => new ESAPIX.Facade.API.PatientSummary(s));
                });
            }
        }
        public static ESAPIX.Facade.API.Application CreateApplication(System.String username, System.String password)
        {
            return StaticHelper.Application_CreateApplication(username, password);
        }
        public ESAPIX.Facade.API.Patient OpenPatient(ESAPIX.Facade.API.PatientSummary patientSummary)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.Patient(local._client.OpenPatient(patientSummary._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.Patient OpenPatientById(System.String id)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.Patient(local._client.OpenPatientById(id)); });
            return retVal;

        }
        public void ClosePatient()
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.ClosePatient();
            });

        }
        public void SaveModifications()
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.SaveModifications();
            });

        }
        public void Dispose()
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.Dispose();
            });

        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
    }
}