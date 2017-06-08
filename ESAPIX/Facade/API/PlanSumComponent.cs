#region

using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class PlanSumComponent : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public PlanSumComponent()
        {
            _client = new ExpandoObject();
        }

        public PlanSumComponent(dynamic client)
        {
            _client = client;
        }

        public string PlanSetupId
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PlanSetupId"))
                        return _client.PlanSetupId;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PlanSetupId; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PlanSetupId = value;
            }
        }

        public PlanSumOperation PlanSumOperation
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PlanSumOperation"))
                        return _client.PlanSumOperation;
                    else
                        return default(PlanSumOperation);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PlanSumOperation; }
                    );
                return default(PlanSumOperation);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PlanSumOperation = value;
            }
        }

        public double PlanWeight
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PlanWeight"))
                        return _client.PlanWeight;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PlanWeight; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.PlanWeight = value;
                }
            }
        }
    }
}