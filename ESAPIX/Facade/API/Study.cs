#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Study : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Study()
        {
            _client = new ExpandoObject();
        }

        public Study(dynamic client)
        {
            _client = client;
        }

        public DateTime? CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CreationDateTime"))
                        return _client.CreationDateTime;
                    else
                        return default(DateTime?);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CreationDateTime; }
                    );
                return default(DateTime?);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CreationDateTime = value;
            }
        }

        public IEnumerable<Series> Series
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Series"))
                        foreach (var item in _client.Series)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Series;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Series();
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
                    _client.Series = value;
            }
        }

        public string UID
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("UID"))
                        return _client.UID;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.UID; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.UID = value;
            }
        }
    }
}