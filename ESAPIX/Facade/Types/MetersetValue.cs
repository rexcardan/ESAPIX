#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class MetersetValue
    {
        internal dynamic _client;

        public MetersetValue()
        {
            _client = new ExpandoObject();
        }

        public MetersetValue(dynamic client)
        {
            _client = client;
        }

        public MetersetValue(double value, DosimeterUnit unit)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructMetersetValue(value, unit);
                });
            else throw new Exception("There is no VMS Context to create the class");
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public double Value
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Value") ? _client.Value : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Value; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Value = value;
            }
        }

        public DosimeterUnit Unit
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Unit") ? _client.Unit : default(DosimeterUnit);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc => { return (DosimeterUnit) local._client.Unit; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Unit = value;
            }
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.GetSchema(); });
            return retVal;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.ReadXml(reader); });
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}