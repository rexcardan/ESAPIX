using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Study : ESAPIX.Facade.API.ApiDataObject
    {
        public Study() { }
        public Study(dynamic client) { _client = client; }
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CreationDateTime; });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Series> Series
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.Series>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.Series).Select(s => new ESAPIX.Facade.API.Series(s));
                });
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