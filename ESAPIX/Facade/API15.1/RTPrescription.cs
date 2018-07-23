using System;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;
using Types = VMS.TPS.Common.Model.Types;

namespace ESAPIX.Facade.API
{
    public class RTPrescription : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public IEnumerable<System.String> Energies
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Energies"))
                    {
                        foreach (var item in _client.Energies)
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
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable)_client.Energies;
                        enumerator = asEnum.GetEnumerator();
                    }

                    );
                    while (XC.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                    {
                        var facade = default (System.String);
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            facade = (System.String)vms;
                        }

                        );
                        yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Energies = value;
            }
        }

        public IEnumerable<System.String> EnergyModes
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("EnergyModes"))
                    {
                        foreach (var item in _client.EnergyModes)
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
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable)_client.EnergyModes;
                        enumerator = asEnum.GetEnumerator();
                    }

                    );
                    while (XC.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                    {
                        var facade = default (System.String);
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            facade = (System.String)vms;
                        }

                        );
                        yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.EnergyModes = value;
            }
        }

        public System.String Site
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Site"))
                    {
                        return _client.Site;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance.CurrentContext) != (null))
                {
                    return XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.Site;
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
                    _client.Site = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.RTPrescriptionTarget> Targets
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Targets"))
                    {
                        foreach (var item in _client.Targets)
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
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable)_client.Targets;
                        if ((asEnum) == null)
                        {
                            return null;
                        }

                        enumerator = asEnum.GetEnumerator();
                    }

                    );
                    while (XC.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                    {
                        var facade = new ESAPIX.Facade.API.RTPrescriptionTarget();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
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
                    _client.Targets = value;
            }
        }

        public RTPrescription()
        {
            _client = (new ExpandoObject());
        }

        public RTPrescription(dynamic client)
        {
            _client = (client);
        }
    }
}