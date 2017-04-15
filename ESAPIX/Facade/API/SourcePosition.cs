using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class SourcePosition : ESAPIX.Facade.API.ApiDataObject
    {
        public SourcePosition() { }
        public SourcePosition(dynamic client) { _client = client; }
        public System.Double DwellTime
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.DwellTime; });
            }
        }
        public ESAPIX.Facade.API.RadioactiveSource RadioactiveSource
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.RadioactiveSource(local._client.RadioactiveSource);
            }
        }
        public System.Double[,] Transform
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double[,]>((sc) => { return local._client.Transform; });
            }
        }
        public ESAPIX.Facade.Types.VVector Translation
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.Translation);
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