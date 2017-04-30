#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class BeamCalculationLog : SerializableObject
    {
        public BeamCalculationLog()
        {
            _client = new ExpandoObject();
        }

        public BeamCalculationLog(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public string Category
        {
            get
            {
                if (_client is ExpandoObject) return _client.Category;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Category; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Category = value;
            }
        }

        public IEnumerable<string> MessageLines
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.MessageLines;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = default(string);
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                            facade = (string) vms;
                    });
                    if (facade != null)
                        yield return facade;
                }
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}