using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationPointObjective : ESAPIX.Facade.API.OptimizationObjective
    {
        public OptimizationPointObjective() { _client = new ExpandoObject(); }
        public OptimizationPointObjective(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public ESAPIX.Facade.Types.DoseValue Dose
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Dose; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValue>((sc) => { return new ESAPIX.Facade.Types.DoseValue(local._client.Dose); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Dose = value; }
            }
        }
        public ESAPIX.Facade.Types.OptimizationObjectiveOperator Operator
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Operator; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.OptimizationObjectiveOperator>((sc) => { return (ESAPIX.Facade.Types.OptimizationObjectiveOperator)local._client.Operator; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Operator = value; }
            }
        }
        public System.Double Priority
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Priority; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Priority; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Priority = value; }
            }
        }
        public System.Double Volume
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Volume; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Volume; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Volume = value; }
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