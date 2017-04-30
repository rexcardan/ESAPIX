using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class SegmentProfile
    {
        internal dynamic _client;

        public SegmentProfile()
        {
            _client = new ExpandoObject();
        }

        public SegmentProfile(dynamic client)
        {
            _client = client;
        }

        public SegmentProfile(VVector origin, VVector step, BitArray data)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructSegmentProfile(origin, step, data);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.Origin = origin;
                _client.Step = step;
                _client.Data = data;
            }
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public SegmentProfilePoint Item
        {
            get
            {
                if (_client is ExpandoObject) return _client.Item;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Item)) return default(SegmentProfilePoint);
                    return new SegmentProfilePoint(local._client.Item);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Item = value;
            }
        }

        public int Count
        {
            get
            {
                if (_client is ExpandoObject) return _client.Count;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.Count; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Count = value;
            }
        }

        public IList<VVector> EdgeCoordinates
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.EdgeCoordinates;
                    enumerator = asEnum.GetEnumerator();
                });
                {
                    var list = new List<VVector>();
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new VVector();
                        X.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            if (vms != null)
                                facade._client = vms;
                        });
                        if (facade._client != null)
                            list.Add(facade);
                    }
                    return list;
                }
            }
        }
    }
}