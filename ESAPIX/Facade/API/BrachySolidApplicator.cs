using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class BrachySolidApplicator : ESAPIX.Facade.API.ApiDataObject
    {
        public BrachySolidApplicator() { _client = new ExpandoObject(); }
        public BrachySolidApplicator(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.String ApplicatorSetName
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ApplicatorSetName; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ApplicatorSetName; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ApplicatorSetName = value; }
            }
        }
        public System.String ApplicatorSetType
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ApplicatorSetType; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ApplicatorSetType; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ApplicatorSetType = value; }
            }
        }
        public System.String Category
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Category; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Category; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Category = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Catheter> Catheters
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.Catheters;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.Catheter();
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
        public System.String Note
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Note; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Note; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Note = value; }
            }
        }
        public System.String PartName
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PartName; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PartName; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PartName = value; }
            }
        }
        public System.String PartNumber
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PartNumber; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PartNumber; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PartNumber = value; }
            }
        }
        public System.String Summary
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Summary; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Summary; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Summary = value; }
            }
        }
        public System.String UID
        {
            get
            {
                if (_client is ExpandoObject) { return _client.UID; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.UID; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.UID = value; }
            }
        }
        public System.String Vendor
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Vendor; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Vendor; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Vendor = value; }
            }
        }
        public System.String Version
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Version; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Version; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Version = value; }
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