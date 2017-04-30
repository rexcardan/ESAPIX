using System.Dynamic;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationMeanDoseObjective : OptimizationObjective
    {
        public OptimizationMeanDoseObjective()
        {
            _client = new ExpandoObject();
        }

        public OptimizationMeanDoseObjective(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public DoseValue Dose
        {
            get
            {
                if (_client is ExpandoObject) return _client.Dose;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Dose)) return default(DoseValue);
                    return new DoseValue(local._client.Dose);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Dose = value;
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

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}