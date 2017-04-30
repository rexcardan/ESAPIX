using System.Dynamic;
using System.Xml;
using System.Xml.Schema;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class StructureCodeInfo
    {
        internal dynamic _client;

        public StructureCodeInfo()
        {
            _client = new ExpandoObject();
        }

        public StructureCodeInfo(dynamic client)
        {
            _client = client;
        }

        public StructureCodeInfo(string codingScheme, string code)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructStructureCodeInfo(codingScheme, code);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.CodingScheme = codingScheme;
                _client.Code = code;
            }
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public string CodingScheme
        {
            get
            {
                if (_client is ExpandoObject) return _client.CodingScheme;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.CodingScheme; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CodingScheme = value;
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

        public string ToString()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.ToString(); });
            return retVal;
        }

        public bool Equals(object obj)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.Equals(obj); });
            return retVal;
        }

        public int GetHashCode()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.GetHashCode(); });
            return retVal;
        }

        public bool Equals(StructureCodeInfo other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.Equals(other._client); });
            return retVal;
        }

        public XmlSchema GetSchema()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.GetSchema(); });
            return retVal;
        }

        public void ReadXml(XmlReader reader)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.ReadXml(reader); });
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}