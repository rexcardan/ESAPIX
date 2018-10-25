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
    public class Catheter : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.Double ApplicatorLength
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ApplicatorLength"))
                    {
                        return _client.ApplicatorLength;
                    }
                    else
                    {
                        return default (System.Double);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.ApplicatorLength;
                    }

                    );
                }
                else
                {
                    return default (System.Double);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ApplicatorLength = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.BrachyFieldReferencePoint> BrachyFieldReferencePoints
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("BrachyFieldReferencePoints"))
                    {
                        foreach (var item in _client.BrachyFieldReferencePoints)
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
                        var asEnum = (IEnumerable)_client.BrachyFieldReferencePoints;
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
                        var facade = new ESAPIX.Facade.API.BrachyFieldReferencePoint();
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
                    _client.BrachyFieldReferencePoints = value;
            }
        }

        public System.Int32 BrachySolidApplicatorPartID
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("BrachySolidApplicatorPartID"))
                    {
                        return _client.BrachySolidApplicatorPartID;
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
                        return _client.BrachySolidApplicatorPartID;
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
                    _client.BrachySolidApplicatorPartID = (value);
                }
                else
                {
                }
            }
        }

        public System.Int32 ChannelNumber
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ChannelNumber"))
                    {
                        return _client.ChannelNumber;
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
                        return _client.ChannelNumber;
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
                    _client.ChannelNumber = (value);
                }
                else
                {
                }
            }
        }

        public System.Windows.Media.Color Color
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Color"))
                    {
                        return _client.Color;
                    }
                    else
                    {
                        return default (System.Windows.Media.Color);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Color;
                    }

                    );
                }
                else
                {
                    return default (System.Windows.Media.Color);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Color = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.VVector[] Shape
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Shape"))
                    {
                        return _client.Shape;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.VVector[]);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Shape;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.VVector[]);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Shape = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.SourcePosition> SourcePositions
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("SourcePositions"))
                    {
                        foreach (var item in _client.SourcePositions)
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
                        var asEnum = (IEnumerable)_client.SourcePositions;
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
                        var facade = new ESAPIX.Facade.API.SourcePosition();
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
                    _client.SourcePositions = value;
            }
        }

        public System.Double StepSize
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("StepSize"))
                    {
                        return _client.StepSize;
                    }
                    else
                    {
                        return default (System.Double);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.StepSize;
                    }

                    );
                }
                else
                {
                    return default (System.Double);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.StepSize = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.BrachyTreatmentUnit TreatmentUnit
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TreatmentUnit"))
                    {
                        return _client.TreatmentUnit;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.BrachyTreatmentUnit);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.TreatmentUnit) != (null))
                        {
                            return new ESAPIX.Facade.API.BrachyTreatmentUnit(_client.TreatmentUnit);
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
                    return default (ESAPIX.Facade.API.BrachyTreatmentUnit);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TreatmentUnit = (value);
                }
                else
                {
                }
            }
        }

        public System.Double GetSourcePosCenterDistanceFromTip(ESAPIX.Facade.API.SourcePosition sourcePosition)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetSourcePosCenterDistanceFromTip(sourcePosition._client));
                    if (fromClient.Equals(default (System.Double)))
                    {
                        return default (System.Double);
                    }

                    return (System.Double)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Double)(_client.GetSourcePosCenterDistanceFromTip(sourcePosition));
            }
        }

        public System.Double GetTotalDwellTime()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetTotalDwellTime());
                    if (fromClient.Equals(default (System.Double)))
                    {
                        return default (System.Double);
                    }

                    return (System.Double)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Double)(_client.GetTotalDwellTime());
            }
        }

        public Catheter()
        {
            _client = (new ExpandoObject());
        }

        public Catheter(dynamic client)
        {
            _client = (client);
        }
    }
}