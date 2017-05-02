#region

using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using X = ESAPIX.Facade.XContext;

#endregion


namespace ESAPIX.Facade.API
{
    public class OptimizationEUDObjective : OptimizationObjective
    {
        public OptimizationEUDObjective()
        {
            _client = new ExpandoObject();
        }

        public OptimizationEUDObjective(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public DoseValue Dose
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Dose") ? _client.Dose : default(DoseValue);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DoseValue>(sc => { return local._client.Dose; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Dose = value;
            }
        }

        public OptimizationObjectiveOperator Operator
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Operator")
                        ? _client.Operator
                        : default(OptimizationObjectiveOperator);
                var local = this;
                return X.Instance.CurrentContext.GetValue<OptimizationObjectiveOperator>(sc =>
                {
                    return local._client.Operator;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Operator = value;
            }
        }

        public double ParameterA
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ParameterA") ? _client.ParameterA : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.ParameterA; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ParameterA = value;
            }
        }

        public double Priority
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Priority") ? _client.Priority : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Priority; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Priority = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}