using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public struct DVHPoint
    {
        internal dynamic _client;
        public DVHPoint(dynamic client) { _client = client; }
        public DVHPoint(ESAPIX.Facade.Types.DoseValue dose, System.Double volume, System.String volumeUnit) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructDVHPoint(dose, volume, volumeUnit)); }
        public ESAPIX.Facade.Types.DoseValue DoseValue
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.DoseValue(local._client.DoseValue);
            }
        }
        public System.Double Volume
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Volume; });
            }
        }
        public System.String VolumeUnit
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.VolumeUnit; });
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