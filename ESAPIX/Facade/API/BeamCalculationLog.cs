using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class BeamCalculationLog : ESAPIX.Facade.API.SerializableObject
    {
        public BeamCalculationLog() { }
        public BeamCalculationLog(dynamic client) { _client = client; }
        public System.String Category
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Category; });
            }
        }
        public IEnumerable<System.String> MessageLines
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<System.String>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.MessageLines).Select(s => new System.String(s));
                });
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