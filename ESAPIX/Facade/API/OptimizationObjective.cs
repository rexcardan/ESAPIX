using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationObjective : ESAPIX.Facade.API.SerializableObject
    {
        public OptimizationObjective() { _client = new ExpandoObject(); }
        public OptimizationObjective(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public ESAPIX.Facade.API.Structure Structure
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Structure; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Structure>((sc) => { return new ESAPIX.Facade.API.Structure(local._client.Structure); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Structure = value; }
            }
        }
        public System.String StructureId
        {
            get
            {
                if (_client is ExpandoObject) { return _client.StructureId; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.StructureId; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.StructureId = value; }
            }
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
        public System.Boolean Equals(System.Object obj)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.Equals(obj); });
            return retVal;

        }
        public System.Int32 GetHashCode()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetHashCode(); });
            return retVal;

        }
    }
}