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
    public class TradeoffObjective
    {
        internal dynamic _client;

        public System.Int32 Id
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
                        return default (System.Int32);
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
                    return default (System.Int32);
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
            }
        }

        public IEnumerable<ESAPIX.Facade.API.OptimizationObjective> OptimizationObjectives
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("OptimizationObjectives"))
                    {
                        foreach (var item in _client.OptimizationObjectives)
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
                        var asEnum = (IEnumerable)_client.OptimizationObjectives;
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
                        var facade = new ESAPIX.Facade.API.OptimizationObjective();
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
                    _client.OptimizationObjectives = value;
            }
        }

        public ESAPIX.Facade.API.Structure Structure
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Structure"))
                    {
                        return _client.Structure;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Structure);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Structure) != (null))
                        {
                            return new ESAPIX.Facade.API.Structure(_client.Structure);
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
                    return default (ESAPIX.Facade.API.Structure);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Structure = (value);
                }
                else
                {
                }
            }
        }

        public TradeoffObjective()
        {
            _client = (new ExpandoObject());
        }

        public TradeoffObjective(dynamic client)
        {
            _client = (client);
        }
    }
}