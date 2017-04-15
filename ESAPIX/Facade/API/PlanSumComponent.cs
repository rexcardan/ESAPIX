using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class PlanSumComponent : ESAPIX.Facade.API.ApiDataObject
    {
        public PlanSumComponent() { }
        public PlanSumComponent(dynamic client) { _client = client; }
        public System.String PlanSetupId
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PlanSetupId; });
            }
        }
        public ESAPIX.Facade.Types.PlanSumOperation PlanSumOperation
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.PlanSumOperation)local._client.PlanSumOperation;
            }
        }
        public System.Double PlanWeight
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.PlanWeight; });
            }
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
    }
}