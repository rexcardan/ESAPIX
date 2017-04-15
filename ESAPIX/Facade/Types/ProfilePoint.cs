using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public struct ProfilePoint
    {
        internal dynamic _client;
        public ProfilePoint(dynamic client) { _client = client; }
        public ProfilePoint(ESAPIX.Facade.Types.VVector position, System.Double value) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructProfilePoint(position, value)); }
        public ESAPIX.Facade.Types.VVector Position
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.Position);
            }
        }
        public System.Double Value
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Value; });
            }
        }
    }
}