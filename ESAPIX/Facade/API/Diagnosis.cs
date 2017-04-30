using System.Dynamic;
using System.Xml;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Diagnosis : ApiDataObject
    {
        public Diagnosis()
        {
            _client = new ExpandoObject();
        }

        public Diagnosis(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public string ClinicalDescription
        {
            get
            {
                if (_client is ExpandoObject) return _client.ClinicalDescription;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.ClinicalDescription; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ClinicalDescription = value;
            }
        }

        public string Code
        {
            get
            {
                if (_client is ExpandoObject) return _client.Code;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Code; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Code = value;
            }
        }

        public string CodeTable
        {
            get
            {
                if (_client is ExpandoObject) return _client.CodeTable;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.CodeTable; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CodeTable = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}