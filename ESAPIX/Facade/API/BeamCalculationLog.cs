using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class BeamCalculationLog : ESAPIX.Facade.API.SerializableObject
    {
        public BeamCalculationLog() { _client = new ExpandoObject(); }
        public BeamCalculationLog(dynamic client) { _client = client; }
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
        public IEnumerable<System.String> MessageLines
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.MessageLines;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = default(System.String);
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade = (System.String)vms;
                        }
                    });
                    if (facade != null)
                    { yield return facade; }
                }
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