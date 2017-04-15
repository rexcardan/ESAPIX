using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class SegmentProfile
    {
        internal dynamic _client;
        public SegmentProfile() { }
        public SegmentProfile(dynamic client) { _client = client; }
        public SegmentProfile(ESAPIX.Facade.Types.VVector origin, ESAPIX.Facade.Types.VVector step, System.Collections.BitArray data) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructSegmentProfile(origin, step, data)); }
        public ESAPIX.Facade.Types.SegmentProfilePoint Item
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.SegmentProfilePoint(local._client.Item);
            }
        }
        public System.Int32 Count
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.Count; });
            }
        }
        public IList<ESAPIX.Facade.Types.VVector> EdgeCoordinates
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IList<ESAPIX.Facade.Types.VVector>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.EdgeCoordinates).Select(s => new ESAPIX.Facade.Types.VVector(s)).ToList();
                });
            }
        }
    }
}