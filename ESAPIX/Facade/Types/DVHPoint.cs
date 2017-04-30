#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class DVHPoint
    {
        internal dynamic _client;

        public DVHPoint()
        {
            _client = new ExpandoObject();
        }

        public DVHPoint(dynamic client)
        {
            _client = client;
        }

        public DVHPoint(DoseValue dose, double volume, string volumeUnit)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructDVHPoint(dose, volume, volumeUnit);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.Dose = dose;
                _client.Volume = volume;
                _client.VolumeUnit = volumeUnit;
            }
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public DoseValue DoseValue
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DoseValue") ? _client.DoseValue : default(DoseValue);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.DoseValue)) return default(DoseValue);
                    return new DoseValue(local._client.DoseValue);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.DoseValue = value;
            }
        }

        public double Volume
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Volume") ? _client.Volume : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Volume; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Volume = value;
            }
        }

        public string VolumeUnit
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("VolumeUnit") ? _client.VolumeUnit : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.VolumeUnit; });
            }
            set
            {
                if (_client is ExpandoObject) _client.VolumeUnit = value;
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