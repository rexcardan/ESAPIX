using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class DoseValue
    {
        internal dynamic _client;
        public DoseValue() { _client = new ExpandoObject(); }
        public DoseValue(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public DoseValue(System.Double value, System.String unitName)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructDoseValue(value, unitName); });
            else
            {
                _client = new ExpandoObject();
                _client.Value = value;
                _client.UnitName = unitName;
            }
        }
        public DoseValue(System.Double value, ESAPIX.Facade.Types.DoseValue.DoseUnit unit)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructDoseValue(value, unit); });
            else
            {
                _client = new ExpandoObject();
                _client.Value = value;
                _client.Unit = unit;
            }
        }
        public System.Double Dose
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Dose; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Dose; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Dose = value; }
            }
        }
        public ESAPIX.Facade.Types.DoseValue.DoseUnit Unit
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Unit; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValue.DoseUnit>((sc) => { return (ESAPIX.Facade.Types.DoseValue.DoseUnit)local._client.Unit; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Unit = value; }
            }
        }
        public System.String UnitAsString
        {
            get
            {
                if (_client is ExpandoObject) { return _client.UnitAsString; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.UnitAsString; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.UnitAsString = value; }
            }
        }
        public System.String ValueAsString
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ValueAsString; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ValueAsString; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ValueAsString = value; }
            }
        }
        public System.Int32 Decimals
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Decimals; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.Decimals; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Decimals = value; }
            }
        }
        public System.String ToString()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.ToString(); });
            return retVal;

        }
        public static ESAPIX.Facade.Types.DoseValue UndefinedDose()
        {
            return StaticHelper.DoseValue_UndefinedDose();
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
        public enum DoseUnit
        {
            Unknown,
            Gy,
            cGy,
            Percent
        }
    }
}