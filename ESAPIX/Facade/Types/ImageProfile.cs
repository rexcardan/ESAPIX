using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class ImageProfile : ESAPIX.Facade.Types.LineProfile
    {
        public ImageProfile() { }
        public ImageProfile(dynamic client) { _client = client; }
        public ImageProfile(ESAPIX.Facade.Types.VVector origin, ESAPIX.Facade.Types.VVector step, System.Double[] data, System.String unit) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructImageProfile(origin, step, data, unit)); }
        public System.String Unit
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Unit; });
            }
        }
    }
}