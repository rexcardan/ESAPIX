using System.Dynamic;
using System.Xml;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Bolus : SerializableObject
    {
        public Bolus()
        {
            _client = new ExpandoObject();
        }

        public Bolus(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public string Id
        {
            get
            {
                if (_client is ExpandoObject) return _client.Id;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Id; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Id = value;
            }
        }

        public double MaterialCTValue
        {
            get
            {
                if (_client is ExpandoObject) return _client.MaterialCTValue;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.MaterialCTValue; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MaterialCTValue = value;
            }
        }

        public string Name
        {
            get
            {
                if (_client is ExpandoObject) return _client.Name;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Name; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Name = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}