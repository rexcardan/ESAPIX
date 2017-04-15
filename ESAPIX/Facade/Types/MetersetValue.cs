using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public struct MetersetValue
    {
        internal dynamic _client;
        public MetersetValue(dynamic client) { _client = client; }
        public MetersetValue(System.Double value, ESAPIX.Facade.Types.DosimeterUnit unit) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructMetersetValue(value, unit)); }
        public System.Double Value
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Value; });
            }
        }
        public ESAPIX.Facade.Types.DosimeterUnit Unit
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.DosimeterUnit)local._client.Unit;
            }
        }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetSchema(); });
            return retVal;

        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.ReadXml(reader);
            });

        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
    }
}