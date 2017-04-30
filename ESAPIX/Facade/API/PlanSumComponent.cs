using System.Dynamic;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class PlanSumComponent : ApiDataObject
    {
        public PlanSumComponent()
        {
            _client = new ExpandoObject();
        }

        public PlanSumComponent(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public string PlanSetupId
        {
            get
            {
                if (_client is ExpandoObject) return _client.PlanSetupId;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.PlanSetupId; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanSetupId = value;
            }
        }

        public PlanSumOperation PlanSumOperation
        {
            get
            {
                if (_client is ExpandoObject) return _client.PlanSumOperation;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    return (PlanSumOperation) local._client.PlanSumOperation;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanSumOperation = value;
            }
        }

        public double PlanWeight
        {
            get
            {
                if (_client is ExpandoObject) return _client.PlanWeight;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.PlanWeight; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanWeight = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}