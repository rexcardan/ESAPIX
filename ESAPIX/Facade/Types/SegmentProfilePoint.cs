using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public struct SegmentProfilePoint
    {
        internal dynamic _client;
        public SegmentProfilePoint(dynamic client) { _client = client; }
        public SegmentProfilePoint(ESAPIX.Facade.Types.VVector position, System.Boolean value) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructSegmentProfilePoint(position, value)); }
        public ESAPIX.Facade.Types.VVector Position
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.Position);
            }
        }
        public System.Boolean Value
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.Value; });
            }
        }
    }
}