#region

using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class OptimizationObjective : SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public OptimizationObjective()
        {
            _client = new ExpandoObject();
        }

        public OptimizationObjective(dynamic client)
        {
            _client = client;
        }

        public Structure Structure
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Structure"))
                        return _client.Structure;
                    else
                        return default(Structure);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return new Structure(_client.Structure); }
                    );
                return default(Structure);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Structure = value;
            }
        }

        public string StructureId
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("StructureId"))
                        return _client.StructureId;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.StructureId; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.StructureId = value;
                }
            }
        }
    }
}