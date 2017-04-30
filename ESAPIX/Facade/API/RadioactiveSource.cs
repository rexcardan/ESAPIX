using System;
using System.Dynamic;
using System.Xml;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class RadioactiveSource : ApiDataObject
    {
        public RadioactiveSource()
        {
            _client = new ExpandoObject();
        }

        public RadioactiveSource(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public DateTime? CalibrationDate
        {
            get
            {
                if (_client is ExpandoObject) return _client.CalibrationDate;
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime?>(sc => { return local._client.CalibrationDate; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CalibrationDate = value;
            }
        }

        public bool NominalActivity
        {
            get
            {
                if (_client is ExpandoObject) return _client.NominalActivity;
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.NominalActivity; });
            }
            set
            {
                if (_client is ExpandoObject) _client.NominalActivity = value;
            }
        }

        public RadioactiveSourceModel RadioactiveSourceModel
        {
            get
            {
                if (_client is ExpandoObject) return _client.RadioactiveSourceModel;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.RadioactiveSourceModel))
                        return default(RadioactiveSourceModel);
                    return new RadioactiveSourceModel(local._client.RadioactiveSourceModel);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.RadioactiveSourceModel = value;
            }
        }

        public string SerialNumber
        {
            get
            {
                if (_client is ExpandoObject) return _client.SerialNumber;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.SerialNumber; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SerialNumber = value;
            }
        }

        public double Strength
        {
            get
            {
                if (_client is ExpandoObject) return _client.Strength;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Strength; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Strength = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}