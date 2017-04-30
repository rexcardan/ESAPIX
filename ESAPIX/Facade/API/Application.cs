using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Application : ESAPIX.Facade.API.SerializableObject
    {
        public Application() { _client = new ExpandoObject(); }
        public Application(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public ESAPIX.Facade.API.User CurrentUser
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CurrentUser; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.User>((sc) => { if (DefaultHelper.IsDefault(local._client.CurrentUser)) { return default(ESAPIX.Facade.API.User); } else { return new ESAPIX.Facade.API.User(local._client.CurrentUser); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CurrentUser = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.PatientSummary> PatientSummaries
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.PatientSummaries;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.PatientSummary();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
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