#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public DateTime? CalibrationDate
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CalibrationDate")
                        ? _client.CalibrationDate
                        : default(DateTime?);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("NominalActivity")
                        ? _client.NominalActivity
                        : default(bool);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("RadioactiveSourceModel")
                        ? _client.RadioactiveSourceModel
                        : default(RadioactiveSourceModel);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("SerialNumber")
                        ? _client.SerialNumber
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Strength") ? _client.Strength : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Strength; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Strength = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}