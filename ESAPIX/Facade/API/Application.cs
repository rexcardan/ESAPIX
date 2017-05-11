#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion


namespace ESAPIX.Facade.API
{
    public class Application : SerializableObject
    {
        public Application()
        {
            _client = new ExpandoObject();
        }

        public Application(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public User CurrentUser
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CurrentUser") ? _client.CurrentUser : default(User);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.CurrentUser)) return default(User);
                    return new User(local._client.CurrentUser);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.CurrentUser = value;
            }
        }

        public IEnumerable<PatientSummary> PatientSummaries
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PatientSummaries"))
                        foreach (var item in _client.PatientSummaries) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.PatientSummaries;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new PatientSummary();
                        X.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            if (vms != null)
                                facade._client = vms;
                        });
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }
            set
            {
                if (_client is ExpandoObject) _client.PatientSummaries = value;
            }
        }

        public static Application CreateApplication(string username, string password, bool useCurrentThread = false)
        {
            return StaticHelper.Application_CreateApplication(username, password, useCurrentThread);
        }

        public Patient OpenPatient(PatientSummary patientSummary)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Patient(local._client.OpenPatient(patientSummary._client));
            });
            return retVal;
        }

        public Patient OpenPatientById(string id)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Patient(local._client.OpenPatientById(id));
            });
            return retVal;
        }

        public void ClosePatient()
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.ClosePatient(); });
        }

        public void SaveModifications()
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.SaveModifications(); });
        }

        public void Dispose()
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.Dispose(); });
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}