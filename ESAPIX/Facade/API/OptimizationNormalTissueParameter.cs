#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion


namespace ESAPIX.Facade.API
{
    public class OptimizationNormalTissueParameter : OptimizationParameter
    {
        public OptimizationNormalTissueParameter()
        {
            _client = new ExpandoObject();
        }

        public OptimizationNormalTissueParameter(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public double DistanceFromTargetBorderInMM
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DistanceFromTargetBorderInMM")
                        ? _client.DistanceFromTargetBorderInMM
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc =>
                {
                    return local._client.DistanceFromTargetBorderInMM;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.DistanceFromTargetBorderInMM = value;
            }
        }

        public double EndDosePercentage
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("EndDosePercentage")
                        ? _client.EndDosePercentage
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.EndDosePercentage; });
            }
            set
            {
                if (_client is ExpandoObject) _client.EndDosePercentage = value;
            }
        }

        public double FallOff
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("FallOff") ? _client.FallOff : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.FallOff; });
            }
            set
            {
                if (_client is ExpandoObject) _client.FallOff = value;
            }
        }

        public bool IsAutomatic
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("IsAutomatic") ? _client.IsAutomatic : default(bool);
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.IsAutomatic; });
            }
            set
            {
                if (_client is ExpandoObject) _client.IsAutomatic = value;
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

        public double StartDosePercentage
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("StartDosePercentage")
                        ? _client.StartDosePercentage
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.StartDosePercentage; });
            }
            set
            {
                if (_client is ExpandoObject) _client.StartDosePercentage = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}