#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class BrachySolidApplicator : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public BrachySolidApplicator()
        {
            _client = new ExpandoObject();
        }

        public BrachySolidApplicator(dynamic client)
        {
            _client = client;
        }

        public string ApplicatorSetName
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ApplicatorSetName"))
                        return _client.ApplicatorSetName;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ApplicatorSetName; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ApplicatorSetName = value;
            }
        }

        public string ApplicatorSetType
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ApplicatorSetType"))
                        return _client.ApplicatorSetType;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ApplicatorSetType; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ApplicatorSetType = value;
            }
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

        public IEnumerable<Catheter> Catheters
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Catheters"))
                        foreach (var item in _client.Catheters)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Catheters;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Catheter();
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
                    _client.Catheters = value;
            }
        }

        public string Note
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Note"))
                        return _client.Note;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Note; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Note = value;
            }
        }

        public string PartName
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PartName"))
                        return _client.PartName;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PartName; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PartName = value;
            }
        }

        public string PartNumber
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PartNumber"))
                        return _client.PartNumber;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PartNumber; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PartNumber = value;
            }
        }

        public string Summary
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Summary"))
                        return _client.Summary;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Summary; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Summary = value;
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

        public string Vendor
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Vendor"))
                        return _client.Vendor;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Vendor; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Vendor = value;
            }
        }

        public string Version
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Version"))
                        return _client.Version;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Version; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Version = value;
            }
        }
    }
}