using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public struct DoseValue
    {
        internal dynamic _client;
        public DoseValue(dynamic client) { _client = client; }
        public DoseValue(System.Double value, System.String unitName) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructDoseValue(value, unitName)); }
        public DoseValue(System.Double value, ESAPIX.Facade.Types.DoseValue.DoseUnit unit) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructDoseValue(value, unit)); }
        public System.Double Dose
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Dose; });
            }
        }
        public ESAPIX.Facade.Types.DoseValue.DoseUnit Unit
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.DoseValue.DoseUnit)local._client.Unit;
            }
        }
        public System.String UnitAsString
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.UnitAsString; });
            }
        }
        public System.String ValueAsString
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ValueAsString; });
            }
        }
        public System.Int32 Decimals
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.Decimals; });
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