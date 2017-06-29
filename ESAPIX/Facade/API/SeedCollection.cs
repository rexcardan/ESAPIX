#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Windows.Media;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class SeedCollection : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public SeedCollection()
        {
            _client = new ExpandoObject();
        }

        public SeedCollection(dynamic client)
        {
            _client = client;
        }

        public Color Color
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Color"))
                        return _client.Color;
                    else
                        return default(Color);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Color; }
                    );
                return default(Color);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Color = value;
            }
        }

        public IEnumerable<SourcePosition> SourcePositions
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("SourcePositions"))
                        foreach (var item in _client.SourcePositions)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.SourcePositions;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new SourcePosition();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SourcePositions = value;
            }
        }
    }
}