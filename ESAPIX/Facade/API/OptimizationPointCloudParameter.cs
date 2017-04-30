using System.Dynamic;
using System.Xml;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationPointCloudParameter : OptimizationParameter
    {
        public OptimizationPointCloudParameter()
        {
            _client = new ExpandoObject();
        }

        public OptimizationPointCloudParameter(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public double PointResolutionInMM
        {
            get
            {
                if (_client is ExpandoObject) return _client.PointResolutionInMM;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.PointResolutionInMM; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PointResolutionInMM = value;
            }
        }

        public Structure Structure
        {
            get
            {
                if (_client is ExpandoObject) return _client.Structure;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Structure)) return default(Structure);
                    return new Structure(local._client.Structure);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Structure = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}