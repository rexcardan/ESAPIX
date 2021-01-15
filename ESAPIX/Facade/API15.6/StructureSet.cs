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
    public class StructureSet : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public IEnumerable<ESAPIX.Facade.API.Structure> Structures
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Structures"))
                    {
                        foreach (var item in _client.Structures)
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
                        var asEnum = (IEnumerable)_client.Structures;
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
                        var facade = new ESAPIX.Facade.API.Structure();
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
                    _client.Structures = value;
            }
        }

        public System.String Id
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Id"))
                    {
                        return _client.Id;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Id;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Id = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.Id = (value));
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.ApplicationScriptLog> ApplicationScriptLogs
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("ApplicationScriptLogs"))
                    {
                        foreach (var item in _client.ApplicationScriptLogs)
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
                        var asEnum = (IEnumerable)_client.ApplicationScriptLogs;
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
                        var facade = new ESAPIX.Facade.API.ApplicationScriptLog();
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
                    _client.ApplicationScriptLogs = value;
            }
        }

        public ESAPIX.Facade.API.Image Image
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Image"))
                    {
                        return _client.Image;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Image);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Image) != (null))
                        {
                            return new ESAPIX.Facade.API.Image(_client.Image);
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
                    return default (ESAPIX.Facade.API.Image);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Image = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Patient Patient
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Patient"))
                    {
                        return _client.Patient;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Patient);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Patient) != (null))
                        {
                            return new ESAPIX.Facade.API.Patient(_client.Patient);
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
                    return default (ESAPIX.Facade.API.Patient);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Patient = (value);
                }
                else
                {
                }
            }
        }

        public System.String UID
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("UID"))
                    {
                        return _client.UID;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.UID;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.UID = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Structure AddStructure(System.String dicomType, System.String id)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddStructure(dicomType, id));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.Structure(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.Structure)(_client.AddStructure(dicomType, id));
            }
        }

        public System.Boolean CanAddStructure(System.String dicomType, System.String id)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CanAddStructure(dicomType, id));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.CanAddStructure(dicomType, id));
            }
        }

        public System.Boolean CanRemoveStructure(ESAPIX.Facade.API.Structure structure)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CanRemoveStructure(structure._client));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.CanRemoveStructure(structure));
            }
        }

        public ESAPIX.Facade.API.StructureSet Copy()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Copy());
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.StructureSet(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.StructureSet)(_client.Copy());
            }
        }

        public ESAPIX.Facade.API.Structure CreateAndSearchBody(ESAPIX.Facade.API.SearchBodyParameters parameters)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CreateAndSearchBody(parameters._client));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.Structure(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.Structure)(_client.CreateAndSearchBody(parameters));
            }
        }

        public void Delete()
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.Delete();
                }

                );
            }
            else
            {
                _client.Delete();
            }
        }

        public ESAPIX.Facade.API.SearchBodyParameters GetDefaultSearchBodyParameters()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetDefaultSearchBodyParameters());
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.SearchBodyParameters(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.SearchBodyParameters)(_client.GetDefaultSearchBodyParameters());
            }
        }

        public void RemoveStructure(ESAPIX.Facade.API.Structure structure)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.RemoveStructure(structure._client);
                }

                );
            }
            else
            {
                _client.RemoveStructure(structure);
            }
        }

        public StructureSet()
        {
            _client = (new ExpandoObject());
        }

        public StructureSet(dynamic client)
        {
            _client = (client);
        }
    }
}