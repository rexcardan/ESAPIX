#region

using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class OptimizationPointObjective : OptimizationObjective
    {
        public OptimizationPointObjective()
        {
            _client = new ExpandoObject();
        }

        public OptimizationPointObjective(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public Types.DoseValue Dose
        {
            get
            {
                if (_client is ExpandoObject) return _client.Dose;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Dose)) return default(Types.DoseValue);
                    return new Types.DoseValue(local._client.Dose);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Dose = value;
            }
        }

        public Types.OptimizationObjectiveOperator Operator
        {
            get
            {
                if (_client is ExpandoObject) return _client.Operator;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    return (Types.OptimizationObjectiveOperator) local._client.Operator;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Operator = value;
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

        public double Volume
        {
            get
            {
                if (_client is ExpandoObject) return _client.Volume;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Volume; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Volume = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}