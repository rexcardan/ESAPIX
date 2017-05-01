#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public string ClinicalDescription
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ClinicalDescription")
                        ? _client.ClinicalDescription
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Code") ? _client.Code : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CodeTable") ? _client.CodeTable : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.CodeTable; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CodeTable = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}