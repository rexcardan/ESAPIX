using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class SourcePosition : ESAPIX.Facade.API.ApiDataObject
    {
        public SourcePosition() { _client = new ExpandoObject(); }
        public SourcePosition(dynamic client) { _client = client; }
        public System.Double DwellTime
        {
            get
            {
                if (_client is ExpandoObject) { return _client.DwellTime; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.DwellTime; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.DwellTime = value; }
            }
        }
        public ESAPIX.Facade.API.RadioactiveSource RadioactiveSource
        {
            get
            {
                if (_client is ExpandoObject) { return _client.RadioactiveSource; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.RadioactiveSource>((sc) => { return new ESAPIX.Facade.API.RadioactiveSource(local._client.RadioactiveSource); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.RadioactiveSource = value; }
            }
        }
        public System.Double[,] Transform
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Transform; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double[,]>((sc) => { return local._client.Transform; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Transform = value; }
            }
        }
        public ESAPIX.Facade.Types.VVector Translation
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Translation; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.VVector>((sc) => { return new ESAPIX.Facade.Types.VVector(local._client.Translation); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Translation = value; }
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