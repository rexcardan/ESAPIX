#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class BeamCalculationLog : SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public BeamCalculationLog()
        {
            _client = new ExpandoObject();
        }

        public BeamCalculationLog(dynamic client)
        {
            _client = client;
        }

        public string Category
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Category"))
                        return _client.Category;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Category; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Category = value;
            }
        }

        public IEnumerable<string> MessageLines
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("MessageLines"))
                        foreach (var item in _client.MessageLines)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.MessageLines;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = default(string);
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                facade = (string) vms;
                            }
                        );
                        yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MessageLines = value;
            }
        }
    }
}