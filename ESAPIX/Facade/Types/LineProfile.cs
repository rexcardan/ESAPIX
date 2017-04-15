using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class LineProfile
    {
        internal dynamic _client;
        public LineProfile() { }
        public LineProfile(dynamic client) { _client = client; }
        public LineProfile(ESAPIX.Facade.Types.VVector origin, ESAPIX.Facade.Types.VVector step, System.Double[] data) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructLineProfile(origin, step, data)); }
        public ESAPIX.Facade.Types.ProfilePoint Item
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.ProfilePoint(local._client.Item);
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
    }
}