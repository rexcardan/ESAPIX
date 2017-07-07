#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Application : SerializableObject, System.Xml.Serialization.IXmlSerializable, IDisposable
    {
        public Application()
        {
            _client = new ExpandoObject();
        }

        public Application(dynamic client)
        {
            _client = client;
        }

        public User CurrentUser
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CurrentUser"))
                        return _client.CurrentUser;
                    else
                        return default(User);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.CurrentUser != null)
                                return new User(_client.CurrentUser);
                            return null;
                        }
                    );
                return default(User);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CurrentUser = value;
            }
        }

        public IEnumerable<PatientSummary> PatientSummaries
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PatientSummaries"))
                        foreach (var item in _client.PatientSummaries)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.PatientSummaries;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new PatientSummary();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PatientSummaries = value;
            }
        }

        public void Dispose()
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.Dispose(); }
                );
            else
                _client.Dispose();
        }

        public static Application CreateApplication(string username, string password, bool singleThread=false)
        {
            return StaticHelper.Application_CreateApplication(username, password, singleThread);
        }

        public Patient OpenPatient(PatientSummary patientSummary)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new Patient(_client.OpenPatient(patientSummary._client));
                    }
                );
                return vmsResult;
            }
            return _client.OpenPatient(patientSummary);
        }

        public Patient OpenPatientById(string id)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new Patient(_client.OpenPatientById(id)); }
                );
                return vmsResult;
            }
            return _client.OpenPatientById(id);
        }

        public void ClosePatient()
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.ClosePatient(); }
                );
            else
                _client.ClosePatient();
        }

        public void SaveModifications()
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.SaveModifications(); }
                );
            else
                _client.SaveModifications();
        }
    }
}