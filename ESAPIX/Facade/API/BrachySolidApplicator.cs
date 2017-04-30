#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class BrachySolidApplicator : ApiDataObject
    {
        public BrachySolidApplicator()
        {
            _client = new ExpandoObject();
        }

        public BrachySolidApplicator(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public string ApplicatorSetName
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ApplicatorSetName")
                        ? _client.ApplicatorSetName
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.ApplicatorSetName; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ApplicatorSetName = value;
            }
        }

        public string ApplicatorSetType
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ApplicatorSetType")
                        ? _client.ApplicatorSetType
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.ApplicatorSetType; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ApplicatorSetType = value;
            }
        }

        public string Category
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Category") ? _client.Category : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Category; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Category = value;
            }
        }

        public IEnumerable<Catheter> Catheters
        {
            get
            {
                if (_client is ExpandoObject)
                    if ((_client as ExpandoObject).HasProperty("Catheters"))
                        foreach (var item in _client.Catheters) yield return item;
                    else yield break;
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.Catheters;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new Catheter();
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
            set
            {
                if (_client is ExpandoObject) _client.Catheters = value;
            }
        }

        public string Note
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Note") ? _client.Note : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Note; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Note = value;
            }
        }

        public string PartName
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PartName") ? _client.PartName : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.PartName; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PartName = value;
            }
        }

        public string PartNumber
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PartNumber") ? _client.PartNumber : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.PartNumber; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PartNumber = value;
            }
        }

        public string Summary
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Summary") ? _client.Summary : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Summary; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Summary = value;
            }
        }

        public string UID
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("UID") ? _client.UID : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.UID; });
            }
            set
            {
                if (_client is ExpandoObject) _client.UID = value;
            }
        }

        public string Vendor
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Vendor") ? _client.Vendor : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Vendor; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Vendor = value;
            }
        }

        public string Version
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Version") ? _client.Version : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Version; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Version = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}