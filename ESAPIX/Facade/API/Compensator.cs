using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Compensator : ESAPIX.Facade.API.ApiDataObject
    {
        public Compensator() { _client = new ExpandoObject(); }
        public Compensator(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public ESAPIX.Facade.API.AddOnMaterial Material
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Material; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.AddOnMaterial>((sc) => { if (DefaultHelper.IsDefault(local._client.Material)) { return default(ESAPIX.Facade.API.AddOnMaterial); } else { return new ESAPIX.Facade.API.AddOnMaterial(local._client.Material); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Material = value; }
            }
        }
        public ESAPIX.Facade.API.Slot Slot
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Slot; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Slot>((sc) => { if (DefaultHelper.IsDefault(local._client.Slot)) { return default(ESAPIX.Facade.API.Slot); } else { return new ESAPIX.Facade.API.Slot(local._client.Slot); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Slot = value; }
            }
        }
        public ESAPIX.Facade.API.Tray Tray
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Tray; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Tray>((sc) => { if (DefaultHelper.IsDefault(local._client.Tray)) { return default(ESAPIX.Facade.API.Tray); } else { return new ESAPIX.Facade.API.Tray(local._client.Tray); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Tray = value; }
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