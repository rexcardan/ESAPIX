using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Block : ESAPIX.Facade.API.ApiDataObject
    {
        public Block() { }
        public Block(dynamic client) { _client = client; }
        public ESAPIX.Facade.API.AddOnMaterial AddOnMaterial
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.AddOnMaterial(local._client.AddOnMaterial);
            }
        }
        public System.Boolean IsDiverging
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsDiverging; });
            }
        }
        public System.Double TransmissionFactor
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.TransmissionFactor; });
            }
        }
        public ESAPIX.Facade.API.Tray Tray
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Tray(local._client.Tray);
            }
        }
        public System.Double TrayTransmissionFactor
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.TrayTransmissionFactor; });
            }
        }
        public ESAPIX.Facade.Types.BlockType Type
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.BlockType)local._client.Type;
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
    }
}