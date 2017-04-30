using System.Dynamic;
using System.Xml;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationNormalTissueParameter : OptimizationParameter
    {
        public OptimizationNormalTissueParameter()
        {
            _client = new ExpandoObject();
        }

        public OptimizationNormalTissueParameter(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public double DistanceFromTargetBorderInMM
        {
            get
            {
                if (_client is ExpandoObject) return _client.DistanceFromTargetBorderInMM;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc =>
                {
                    return local._client.DistanceFromTargetBorderInMM;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.DistanceFromTargetBorderInMM = value;
            }
        }

        public double EndDosePercentage
        {
            get
            {
                if (_client is ExpandoObject) return _client.EndDosePercentage;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.EndDosePercentage; });
            }
            set
            {
                if (_client is ExpandoObject) _client.EndDosePercentage = value;
            }
        }

        public double FallOff
        {
            get
            {
                if (_client is ExpandoObject) return _client.FallOff;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.FallOff; });
            }
            set
            {
                if (_client is ExpandoObject) _client.FallOff = value;
            }
        }

        public bool IsAutomatic
        {
            get
            {
                if (_client is ExpandoObject) return _client.IsAutomatic;
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.IsAutomatic; });
            }
            set
            {
                if (_client is ExpandoObject) _client.IsAutomatic = value;
            }
        }

        public double Priority
        {
            get
            {
                if (_client is ExpandoObject) return _client.Priority;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Priority; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Priority = value;
            }
        }

        public double StartDosePercentage
        {
            get
            {
                if (_client is ExpandoObject) return _client.StartDosePercentage;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.StartDosePercentage; });
            }
            set
            {
                if (_client is ExpandoObject) _client.StartDosePercentage = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}