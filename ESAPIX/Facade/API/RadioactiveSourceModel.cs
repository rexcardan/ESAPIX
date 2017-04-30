#region

using System;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class RadioactiveSourceModel : ApiDataObject
    {
        public RadioactiveSourceModel()
        {
            _client = new ExpandoObject();
        }

        public RadioactiveSourceModel(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public Types.VVector ActiveSize
        {
            get
            {
                if (_client is ExpandoObject) return _client.ActiveSize;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.ActiveSize)) return default(Types.VVector);
                    return new Types.VVector(local._client.ActiveSize);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ActiveSize = value;
            }
        }

        public double ActivityConversionFactor
        {
            get
            {
                if (_client is ExpandoObject) return _client.ActivityConversionFactor;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc =>
                {
                    return local._client.ActivityConversionFactor;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ActivityConversionFactor = value;
            }
        }

        public string CalculationModel
        {
            get
            {
                if (_client is ExpandoObject) return _client.CalculationModel;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.CalculationModel; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CalculationModel = value;
            }
        }

        public double DoseRateConstant
        {
            get
            {
                if (_client is ExpandoObject) return _client.DoseRateConstant;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.DoseRateConstant; });
            }
            set
            {
                if (_client is ExpandoObject) _client.DoseRateConstant = value;
            }
        }

        public double HalfLife
        {
            get
            {
                if (_client is ExpandoObject) return _client.HalfLife;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.HalfLife; });
            }
            set
            {
                if (_client is ExpandoObject) _client.HalfLife = value;
            }
        }

        public string LiteratureReference
        {
            get
            {
                if (_client is ExpandoObject) return _client.LiteratureReference;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.LiteratureReference; });
            }
            set
            {
                if (_client is ExpandoObject) _client.LiteratureReference = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                if (_client is ExpandoObject) return _client.Manufacturer;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Manufacturer; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Manufacturer = value;
            }
        }

        public string SourceType
        {
            get
            {
                if (_client is ExpandoObject) return _client.SourceType;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.SourceType; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SourceType = value;
            }
        }

        public string Status
        {
            get
            {
                if (_client is ExpandoObject) return _client.Status;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Status; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Status = value;
            }
        }

        public DateTime? StatusDate
        {
            get
            {
                if (_client is ExpandoObject) return _client.StatusDate;
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime?>(sc => { return local._client.StatusDate; });
            }
            set
            {
                if (_client is ExpandoObject) _client.StatusDate = value;
            }
        }

        public string StatusUserName
        {
            get
            {
                if (_client is ExpandoObject) return _client.StatusUserName;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.StatusUserName; });
            }
            set
            {
                if (_client is ExpandoObject) _client.StatusUserName = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}