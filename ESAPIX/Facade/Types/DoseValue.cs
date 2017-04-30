#region

using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class DoseValue
    {
        public enum DoseUnit
        {
            Unknown,
            Gy,
            cGy,
            Percent
        }

        internal dynamic _client;

        public DoseValue()
        {
            _client = new ExpandoObject();
        }

        public DoseValue(dynamic client)
        {
            _client = client;
        }

        public DoseValue(double value, string unitName)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructDoseValue(value, unitName);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.Value = value;
                _client.UnitName = unitName;
            }
        }

        public DoseValue(double value, DoseUnit unit)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructDoseValue(value, unit);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.Value = value;
                _client.Unit = unit;
            }
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public double Dose
        {
            get
            {
                if (_client is ExpandoObject) return _client.Dose;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Dose; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Dose = value;
            }
        }

        public DoseUnit Unit
        {
            get
            {
                if (_client is ExpandoObject) return _client.Unit;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc => { return (DoseUnit) local._client.Unit; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Unit = value;
            }
        }

        public string UnitAsString
        {
            get
            {
                if (_client is ExpandoObject) return _client.UnitAsString;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.UnitAsString; });
            }
            set
            {
                if (_client is ExpandoObject) _client.UnitAsString = value;
            }
        }

        public string ValueAsString
        {
            get
            {
                if (_client is ExpandoObject) return _client.ValueAsString;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.ValueAsString; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ValueAsString = value;
            }
        }

        public int Decimals
        {
            get
            {
                if (_client is ExpandoObject) return _client.Decimals;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.Decimals; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Decimals = value;
            }
        }

        public string ToString()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.ToString(); });
            return retVal;
        }

        public static DoseValue UndefinedDose()
        {
            return StaticHelper.DoseValue_UndefinedDose();
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