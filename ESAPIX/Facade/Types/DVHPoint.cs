using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class DVHPoint
    {
        internal dynamic _client;
        public DVHPoint() { _client = new ExpandoObject(); }
        public DVHPoint(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public DVHPoint(ESAPIX.Facade.Types.DoseValue dose, System.Double volume, System.String volumeUnit)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructDVHPoint(dose, volume, volumeUnit); });
            else
            {
                _client = new ExpandoObject();
                _client.Dose = dose;
                _client.Volume = volume;
                _client.VolumeUnit = volumeUnit;
            }
        }
        public ESAPIX.Facade.Types.DoseValue DoseValue
        {
            get
            {
                if (_client is ExpandoObject) { return _client.DoseValue; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValue>((sc) => { return new ESAPIX.Facade.Types.DoseValue(local._client.DoseValue); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.DoseValue = value; }
            }
        }
        public System.Double Volume
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Volume; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Volume; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Volume = value; }
            }
        }
        public System.String VolumeUnit
        {
            get
            {
                if (_client is ExpandoObject) { return _client.VolumeUnit; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.VolumeUnit; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.VolumeUnit = value; }
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