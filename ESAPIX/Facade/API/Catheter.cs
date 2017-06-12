#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Catheter : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Catheter()
        {
            _client = new ExpandoObject();
        }

        public Catheter(dynamic client)
        {
            _client = client;
        }

        public double ApplicatorLength
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ApplicatorLength"))
                        return _client.ApplicatorLength;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ApplicatorLength; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ApplicatorLength = value;
            }
        }

        public int BrachySolidApplicatorPartID
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("BrachySolidApplicatorPartID"))
                        return _client.BrachySolidApplicatorPartID;
                    else
                        return default(int);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.BrachySolidApplicatorPartID; }
                    );
                return default(int);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.BrachySolidApplicatorPartID = value;
            }
        }

        public int ChannelNumber
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ChannelNumber"))
                        return _client.ChannelNumber;
                    else
                        return default(int);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ChannelNumber; }
                    );
                return default(int);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ChannelNumber = value;
            }
        }

        public System.Windows.Media.Color Color
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Color"))
                        return _client.Color;
                    else
                        return default(System.Windows.Media.Color);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Color; }
                    );
                return default(System.Windows.Media.Color);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Color = value;
            }
        }

        public VVector[] Shape
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Shape"))
                        return _client.Shape;
                    else
                        return default(VVector[]);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Shape; }
                    );
                return default(VVector[]);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Shape = value;
            }
        }

        public IEnumerable<SourcePosition> SourcePositions
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("SourcePositions"))
                        foreach (var item in _client.SourcePositions)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.SourcePositions;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new SourcePosition();
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
                    _client.SourcePositions = value;
            }
        }

        public double StepSize
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("StepSize"))
                        return _client.StepSize;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.StepSize; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.StepSize = value;
            }
        }

        public BrachyTreatmentUnit TreatmentUnit
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TreatmentUnit"))
                        return _client.TreatmentUnit;
                    else
                        return default(BrachyTreatmentUnit);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.TreatmentUnit != null)
                                return new BrachyTreatmentUnit(_client.TreatmentUnit);
                            return null;
                        }
                    );
                return default(BrachyTreatmentUnit);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.TreatmentUnit = value;
            }
        }

        public double GetSourcePosCenterDistanceFromTip(SourcePosition sourcePosition)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.GetSourcePosCenterDistanceFromTip(sourcePosition._client);
                    }
                );
                return vmsResult;
            }
            return (double) _client.GetSourcePosCenterDistanceFromTip(sourcePosition);
        }

        public double GetTotalDwellTime()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc => { return _client.GetTotalDwellTime(); }
                );
                return vmsResult;
            }
            return (double) _client.GetTotalDwellTime();
        }
    }
}