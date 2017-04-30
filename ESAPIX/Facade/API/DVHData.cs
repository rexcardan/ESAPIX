using System.Dynamic;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class DVHData : SerializableObject
    {
        public DVHData()
        {
            _client = new ExpandoObject();
        }

        public DVHData(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public double Coverage
        {
            get
            {
                if (_client is ExpandoObject) return _client.Coverage;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Coverage; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Coverage = value;
            }
        }

        public DVHPoint[] CurveData
        {
            get
            {
                if (_client is ExpandoObject) return _client.CurveData;
                var local = this;
                return X.Instance.CurrentContext.GetValue<DVHPoint[]>(sc =>
                {
                    return ArrayHelper.GenerateDVHPointArray(local._client.CurveData);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.CurveData = value;
            }
        }

        public DoseValue MaxDose
        {
            get
            {
                if (_client is ExpandoObject) return _client.MaxDose;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.MaxDose)) return default(DoseValue);
                    return new DoseValue(local._client.MaxDose);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.MaxDose = value;
            }
        }

        public DoseValue MeanDose
        {
            get
            {
                if (_client is ExpandoObject) return _client.MeanDose;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.MeanDose)) return default(DoseValue);
                    return new DoseValue(local._client.MeanDose);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.MeanDose = value;
            }
        }

        public DoseValue MedianDose
        {
            get
            {
                if (_client is ExpandoObject) return _client.MedianDose;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.MedianDose)) return default(DoseValue);
                    return new DoseValue(local._client.MedianDose);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.MedianDose = value;
            }
        }

        public DoseValue MinDose
        {
            get
            {
                if (_client is ExpandoObject) return _client.MinDose;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.MinDose)) return default(DoseValue);
                    return new DoseValue(local._client.MinDose);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.MinDose = value;
            }
        }

        public double SamplingCoverage
        {
            get
            {
                if (_client is ExpandoObject) return _client.SamplingCoverage;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.SamplingCoverage; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SamplingCoverage = value;
            }
        }

        public double StdDev
        {
            get
            {
                if (_client is ExpandoObject) return _client.StdDev;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.StdDev; });
            }
            set
            {
                if (_client is ExpandoObject) _client.StdDev = value;
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

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}