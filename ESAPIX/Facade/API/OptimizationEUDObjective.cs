using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationEUDObjective : ESAPIX.Facade.API.OptimizationObjective
    {
        public OptimizationEUDObjective() { _client = new ExpandoObject(); }
        public OptimizationEUDObjective(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public ESAPIX.Facade.Types.DoseValue Dose
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Dose; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValue>((sc) => { if (DefaultHelper.IsDefault(local._client.Dose)) { return default(ESAPIX.Facade.Types.DoseValue); } else { return new ESAPIX.Facade.Types.DoseValue(local._client.Dose); } });
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
        public System.Double ParameterA
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ParameterA; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.ParameterA; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ParameterA = value; }
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