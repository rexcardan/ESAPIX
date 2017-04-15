using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Block : ESAPIX.Facade.API.ApiDataObject
    {
        public Block() { _client = new ExpandoObject(); }
        public Block(dynamic client) { _client = client; }
        public ESAPIX.Facade.API.AddOnMaterial AddOnMaterial
        {
            get
            {
                if (_client is ExpandoObject) { return _client.AddOnMaterial; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.AddOnMaterial>((sc) => { return new ESAPIX.Facade.API.AddOnMaterial(local._client.AddOnMaterial); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.AddOnMaterial = value; }
            }
        }
        public System.Boolean IsDiverging
        {
            get
            {
                if (_client is ExpandoObject) { return _client.IsDiverging; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsDiverging; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.IsDiverging = value; }
            }
        }
        public System.Double TransmissionFactor
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TransmissionFactor; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.TransmissionFactor; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TransmissionFactor = value; }
            }
        }
        public ESAPIX.Facade.API.Tray Tray
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Tray; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Tray>((sc) => { return new ESAPIX.Facade.API.Tray(local._client.Tray); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Tray = value; }
            }
        }
        public System.Double TrayTransmissionFactor
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TrayTransmissionFactor; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.TrayTransmissionFactor; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TrayTransmissionFactor = value; }
            }
        }
        public ESAPIX.Facade.Types.BlockType Type
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Type; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.BlockType>((sc) => { return (ESAPIX.Facade.Types.BlockType)local._client.Type; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Type = value; }
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