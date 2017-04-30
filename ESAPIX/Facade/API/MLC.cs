using System.Dynamic;
using System.Xml;
using X = ESAPIX.Facade.XContext;

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

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public string ManufacturerName
        {
            get
            {
                if (_client is ExpandoObject) return _client.ManufacturerName;
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
                if (_client is ExpandoObject) return _client.MinDoseDynamicLeafGap;
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
                if (_client is ExpandoObject) return _client.Model;
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
                if (_client is ExpandoObject) return _client.SerialNumber;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.SerialNumber; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SerialNumber = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}