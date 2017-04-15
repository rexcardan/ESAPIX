using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class PlanSumComponent : ESAPIX.Facade.API.ApiDataObject
    {
        public PlanSumComponent() { _client = new ExpandoObject(); }
        public PlanSumComponent(dynamic client) { _client = client; }
        public System.String PlanSetupId
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PlanSetupId; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PlanSetupId; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PlanSetupId = value; }
            }
        }
        public ESAPIX.Facade.Types.PlanSumOperation PlanSumOperation
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PlanSumOperation; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.PlanSumOperation>((sc) => { return (ESAPIX.Facade.Types.PlanSumOperation)local._client.PlanSumOperation; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PlanSumOperation = value; }
            }
        }
        public System.Double PlanWeight
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PlanWeight; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.PlanWeight; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PlanWeight = value; }
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