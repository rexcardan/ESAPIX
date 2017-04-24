using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class ExternalBeam : ESAPIX.Facade.API.ApiDataObject
    {
        public ExternalBeam() { _client = new ExpandoObject(); }
        public ExternalBeam(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.Double SourceAxisDistance
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SourceAxisDistance; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SourceAxisDistance; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SourceAxisDistance = value; }
            }
        }
        public System.String MachineModel
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MachineModel; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MachineModel; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MachineModel = value; }
            }
        }
        public System.String MachineModelName
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MachineModelName; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MachineModelName; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MachineModelName = value; }
            }
        }
        public System.String MachineScaleDisplayName
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MachineScaleDisplayName; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MachineScaleDisplayName; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MachineScaleDisplayName = value; }
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