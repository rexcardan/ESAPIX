using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class BrachySolidApplicator : ESAPIX.Facade.API.ApiDataObject
    {
        public BrachySolidApplicator() { }
        public BrachySolidApplicator(dynamic client) { _client = client; }
        public System.String ApplicatorSetName
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ApplicatorSetName; });
            }
        }
        public System.String ApplicatorSetType
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ApplicatorSetType; });
            }
        }
        public System.String Category
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Category; });
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
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Note; });
            }
        }
        public System.String PartName
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PartName; });
            }
        }
        public System.String PartNumber
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PartNumber; });
            }
        }
        public System.String Summary
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Summary; });
            }
        }
        public System.String UID
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.UID; });
            }
        }
        public System.String Vendor
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Vendor; });
            }
        }
        public System.String Version
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Version; });
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