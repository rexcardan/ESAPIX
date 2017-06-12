#region

using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class OptimizationPointCloudParameter : OptimizationParameter, System.Xml.Serialization.IXmlSerializable
    {
        public OptimizationPointCloudParameter()
        {
            _client = new ExpandoObject();
        }

        public OptimizationPointCloudParameter(dynamic client)
        {
            _client = client;
        }

        public double PointResolutionInMM
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PointResolutionInMM"))
                        return _client.PointResolutionInMM;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PointResolutionInMM; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PointResolutionInMM = value;
            }
        }

        public Structure Structure
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Structure"))
                        return _client.Structure;
                    else
                        return default(Structure);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Structure != null)
                                return new Structure(_client.Structure);
                            return null;
                        }
                    );
                return default(Structure);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.Structure = value;
                }
            }
        }
    }
}