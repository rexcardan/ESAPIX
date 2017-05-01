#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class MLC : AddOn
    {
        public MLC()
        {
            _client = new ExpandoObject();
        }

        public MLC(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public string ManufacturerName
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ManufacturerName")
                        ? _client.ManufacturerName
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.ManufacturerName; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ManufacturerName = value;
            }
        }

        public double MinDoseDynamicLeafGap
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MinDoseDynamicLeafGap")
                        ? _client.MinDoseDynamicLeafGap
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc =>
                {
                    return local._client.MinDoseDynamicLeafGap;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.MinDoseDynamicLeafGap = value;
            }
        }

        public string Model
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Model") ? _client.Model : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Model; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Model = value;
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

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}