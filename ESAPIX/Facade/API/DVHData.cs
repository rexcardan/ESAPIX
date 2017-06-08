#region

using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class DVHData : SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public DVHData()
        {
            _client = new ExpandoObject();
        }

        public DVHData(dynamic client)
        {
            _client = client;
        }

        public double Coverage
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Coverage"))
                        return _client.Coverage;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Coverage; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Coverage = value;
            }
        }

        public DVHPoint[] CurveData
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CurveData"))
                        return _client.CurveData;
                    else
                        return default(DVHPoint[]);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CurveData; }
                    );
                return default(DVHPoint[]);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CurveData = value;
            }
        }

        public DoseValue MaxDose
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MaxDose"))
                        return _client.MaxDose;
                    else
                        return default(DoseValue);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MaxDose; }
                    );
                return default(DoseValue);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MaxDose = value;
            }
        }

        public DoseValue MeanDose
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MeanDose"))
                        return _client.MeanDose;
                    else
                        return default(DoseValue);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MeanDose; }
                    );
                return default(DoseValue);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MeanDose = value;
            }
        }

        public DoseValue MedianDose
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MedianDose"))
                        return _client.MedianDose;
                    else
                        return default(DoseValue);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MedianDose; }
                    );
                return default(DoseValue);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MedianDose = value;
            }
        }

        public DoseValue MinDose
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MinDose"))
                        return _client.MinDose;
                    else
                        return default(DoseValue);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MinDose; }
                    );
                return default(DoseValue);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MinDose = value;
            }
        }

        public double SamplingCoverage
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SamplingCoverage"))
                        return _client.SamplingCoverage;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.SamplingCoverage; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SamplingCoverage = value;
            }
        }

        public double StdDev
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("StdDev"))
                        return _client.StdDev;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.StdDev; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.StdDev = value;
            }
        }

        public double Volume
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Volume"))
                        return _client.Volume;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Volume; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.Volume = value;
                }
            }
        }
    }
}