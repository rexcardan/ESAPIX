using System;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Common.AppComThread;
using V = VMS.TPS.Common.Model.API;
using Types = VMS.TPS.Common.Model.Types;

namespace ESAPIX.Facade.API
{
    public class Application : ESAPIX.Facade.API.SerializableObject, System.Xml.Serialization.IXmlSerializable, System.IDisposable
    {
        public ESAPIX.Facade.API.User CurrentUser
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CurrentUser"))
                    {
                        return _client.CurrentUser;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.User);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.CurrentUser) != (null))
                        {
                            return new ESAPIX.Facade.API.User(_client.CurrentUser);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    );
                }
                else
                {
                    return default (ESAPIX.Facade.API.User);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CurrentUser = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.PatientSummary> PatientSummaries
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PatientSummaries"))
                    {
                        foreach (var item in _client.PatientSummaries)
                        {
                            yield return item;
                        }
                    }
                    else
                    {
                        yield break;
                    }
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.Invoke(() =>
                    {
                        var asEnum = (IEnumerable)_client.PatientSummaries;
                        if ((asEnum) != null)
                        {
                            enumerator = asEnum.GetEnumerator();
                        }
                    }

                    );
                    if (enumerator == null)
                    {
                        yield break;
                    }

                    while (XC.Instance.GetValue<bool>(sc => enumerator.MoveNext()))
                    {
                        var facade = new ESAPIX.Facade.API.PatientSummary();
                        XC.Instance.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            if (vms != null)
                            {
                                facade._client = vms;
                            }
                        }

                        );
                        if (facade._client != null)
                        {
                            yield return facade;
                        }
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PatientSummaries = value;
            }
        }

        public ESAPIX.Facade.API.ScriptEnvironment ScriptEnvironment
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ScriptEnvironment"))
                    {
                        return _client.ScriptEnvironment;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.ScriptEnvironment);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.ScriptEnvironment) != (null))
                        {
                            return new ESAPIX.Facade.API.ScriptEnvironment(_client.ScriptEnvironment);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    );
                }
                else
                {
                    return default (ESAPIX.Facade.API.ScriptEnvironment);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ScriptEnvironment = (value);
                }
                else
                {
                }
            }
        }

        public static ESAPIX.Facade.API.Application CreateApplication(System.String username, System.String password)
        {
            return StaticHelper.Application_CreateApplication(username, password);
        }

        public static ESAPIX.Facade.API.Application CreateApplication()
        {
            return StaticHelper.Application_CreateApplication();
        }

        public ESAPIX.Facade.API.Patient OpenPatient(ESAPIX.Facade.API.PatientSummary patientSummary)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.OpenPatient(patientSummary._client));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.Patient(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.Patient)(_client.OpenPatient(patientSummary));
            }
        }

        public ESAPIX.Facade.API.Patient OpenPatientById(System.String id)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.OpenPatientById(id));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.Patient(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.Patient)(_client.OpenPatientById(id));
            }
        }

        public void ClosePatient()
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.ClosePatient();
                }

                );
            }
            else
            {
                _client.ClosePatient();
            }
        }

        public void SaveModifications()
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.SaveModifications();
                }

                );
            }
            else
            {
                _client.SaveModifications();
            }
        }

        public void Dispose()
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.Dispose();
                }

                );
            }
            else
            {
                _client.Dispose();
            }
        }

        public Application()
        {
            _client = (new ExpandoObject());
        }

        public Application(dynamic client)
        {
            _client = (client);
        }
    }
}