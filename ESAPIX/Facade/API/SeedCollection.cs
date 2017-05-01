#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public System.Windows.Media.Color Color
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Color")
                        ? _client.Color
                        : default(System.Windows.Media.Color);
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Color>(sc =>
                {
                    return local._client.Color;
                });
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
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("SourcePositions"))
                        foreach (var item in _client.SourcePositions) yield return item;
                    else yield break;
                }
                else
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
            set
            {
                if (_client is ExpandoObject) _client.SourcePositions = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}