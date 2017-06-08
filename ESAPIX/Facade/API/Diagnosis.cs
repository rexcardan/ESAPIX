#region

using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Diagnosis : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Diagnosis()
        {
            _client = new ExpandoObject();
        }

        public Diagnosis(dynamic client)
        {
            _client = client;
        }

        public string ClinicalDescription
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ClinicalDescription"))
                        return _client.ClinicalDescription;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ClinicalDescription; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ClinicalDescription = value;
            }
        }

        public string Code
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Code"))
                        return _client.Code;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Code; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Code = value;
            }
        }

        public string CodeTable
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CodeTable"))
                        return _client.CodeTable;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CodeTable; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.CodeTable = value;
                }
            }
        }
    }
}