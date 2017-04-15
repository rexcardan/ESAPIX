using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class SeedCollection : ESAPIX.Facade.API.ApiDataObject
    {
        public SeedCollection() { _client = new ExpandoObject(); }
        public SeedCollection(dynamic client) { _client = client; }
        public System.Windows.Media.Color Color
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Color; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Color>((sc) => { return local._client.Color; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Color = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.SourcePosition> SourcePositions
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.SourcePositions;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.SourcePosition();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
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