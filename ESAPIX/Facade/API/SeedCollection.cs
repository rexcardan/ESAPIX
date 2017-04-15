using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class SeedCollection : ESAPIX.Facade.API.ApiDataObject
    {
        public SeedCollection() { }
        public SeedCollection(dynamic client) { _client = client; }
        public System.Windows.Media.Color Color
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Color>((sc) => { return local._client.Color; });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.SourcePosition> SourcePositions
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.SourcePosition>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.SourcePositions).Select(s => new ESAPIX.Facade.API.SourcePosition(s));
                });
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