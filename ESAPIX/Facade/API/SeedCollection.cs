using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Windows.Media;
using System.Xml;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class SeedCollection : ApiDataObject
    {
        public SeedCollection()
        {
            _client = new ExpandoObject();
        }

        public SeedCollection(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public Color Color
        {
            get
            {
                if (_client is ExpandoObject) return _client.Color;
                var local = this;
                return X.Instance.CurrentContext.GetValue<Color>(sc => { return local._client.Color; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Color = value;
            }
        }

        public IEnumerable<SourcePosition> SourcePositions
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.SourcePositions;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new SourcePosition();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                            facade._client = vms;
                    });
                    if (facade._client != null)
                        yield return facade;
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}