#region

using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using X = ESAPIX.Facade.XContext;

#endregion


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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public string PlanSetupId
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PlanSetupId")
                        ? _client.PlanSetupId
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PlanSumOperation")
                        ? _client.PlanSumOperation
                        : default(PlanSumOperation);
                var local = this;
                return X.Instance.CurrentContext.GetValue<PlanSumOperation>(sc =>
                {
                    return local._client.PlanSumOperation;
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PlanWeight") ? _client.PlanWeight : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.PlanWeight; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanWeight = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}