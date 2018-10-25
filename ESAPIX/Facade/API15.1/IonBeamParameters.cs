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
    public class IonBeamParameters : ESAPIX.Facade.API.BeamParameters
    {
        public IEnumerable<ESAPIX.Facade.API.IonControlPointParameters> ControlPoints
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("ControlPoints"))
                    {
                        foreach (var item in _client.ControlPoints)
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
                        var asEnum = (IEnumerable)_client.ControlPoints;
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
                        var facade = new ESAPIX.Facade.API.IonControlPointParameters();
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
                    _client.ControlPoints = value;
            }
        }

        public ESAPIX.Facade.API.IonControlPointPairCollection IonControlPointPairs
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IonControlPointPairs"))
                    {
                        return _client.IonControlPointPairs;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.IonControlPointPairCollection);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.IonControlPointPairs) != (null))
                        {
                            return new ESAPIX.Facade.API.IonControlPointPairCollection(_client.IonControlPointPairs);
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
                    return default (ESAPIX.Facade.API.IonControlPointPairCollection);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.IonControlPointPairs = (value);
                }
                else
                {
                }
            }
        }

        public IonBeamParameters()
        {
            _client = (new ExpandoObject());
        }

        public IonBeamParameters(dynamic client)
        {
            _client = (client);
        }
    }
}