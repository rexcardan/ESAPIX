using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class SegmentProfile
    {
        internal dynamic _client;
        public SegmentProfile() { _client = new ExpandoObject(); }
        public SegmentProfile(dynamic client) { _client = client; }
        public SegmentProfile(ESAPIX.Facade.Types.VVector origin, ESAPIX.Facade.Types.VVector step, System.Collections.BitArray data)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructSegmentProfile(origin, step, data); });
            else
            {
                _client = new ExpandoObject();
                _client.Origin = origin;
                _client.Step = step;
                _client.Data = data;
            }
        }
        public ESAPIX.Facade.Types.SegmentProfilePoint Item
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Item; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.SegmentProfilePoint>((sc) => { return new ESAPIX.Facade.Types.SegmentProfilePoint(local._client.Item); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Item = value; }
            }
        }
        public System.Int32 Count
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Count; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.Count; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Count = value; }
            }
        }
        public IList<ESAPIX.Facade.Types.VVector> EdgeCoordinates
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.EdgeCoordinates;
                    enumerator = asEnum.GetEnumerator();
                });
                {
                    var list = new List<ESAPIX.Facade.Types.VVector>();
                    while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                    {
                        var facade = new ESAPIX.Facade.Types.VVector();
                        X.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            if (vms != null)
                            {
                                facade._client = vms;
                            }
                        });
                        if (facade._client != null)
                        {
                            list.Add(facade);
                        }
                    }
                    return list;
                }
            }
        }
    }
}