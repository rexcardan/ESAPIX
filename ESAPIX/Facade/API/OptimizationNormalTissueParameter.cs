#region

using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class OptimizationNormalTissueParameter : OptimizationParameter, System.Xml.Serialization.IXmlSerializable
    {
        public OptimizationNormalTissueParameter()
        {
            _client = new ExpandoObject();
        }

        public OptimizationNormalTissueParameter(dynamic client)
        {
            _client = client;
        }

        public double DistanceFromTargetBorderInMM
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("DistanceFromTargetBorderInMM"))
                        return _client.DistanceFromTargetBorderInMM;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.DistanceFromTargetBorderInMM; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.DistanceFromTargetBorderInMM = value;
            }
        }

        public double EndDosePercentage
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("EndDosePercentage"))
                        return _client.EndDosePercentage;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.EndDosePercentage; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.EndDosePercentage = value;
            }
        }

        public double FallOff
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("FallOff"))
                        return _client.FallOff;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.FallOff; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.FallOff = value;
            }
        }

        public bool IsAutomatic
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("IsAutomatic"))
                        return _client.IsAutomatic;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.IsAutomatic; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.IsAutomatic = value;
            }
        }

        public double Priority
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Priority"))
                        return _client.Priority;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Priority; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Priority = value;
            }
        }

        public double StartDosePercentage
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("StartDosePercentage"))
                        return _client.StartDosePercentage;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.StartDosePercentage; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.StartDosePercentage = value;
                }
            }
        }
    }
}