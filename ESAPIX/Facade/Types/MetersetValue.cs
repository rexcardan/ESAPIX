using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class MetersetValue
    {
        internal dynamic _client;
        public MetersetValue() { _client = new ExpandoObject(); }
        public MetersetValue(dynamic client) { _client = client; }
        public MetersetValue(System.Double value, ESAPIX.Facade.Types.DosimeterUnit unit)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructMetersetValue(value, unit); });
            else
            {
                _client = new ExpandoObject();
                _client.Value = value;
                _client.Unit = unit;
            }
        }
        public System.Double Value
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Value; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Value; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Value = value; }
            }
        }
        public ESAPIX.Facade.Types.DosimeterUnit Unit
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Unit; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DosimeterUnit>((sc) => { return (ESAPIX.Facade.Types.DosimeterUnit)local._client.Unit; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Unit = value; }
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