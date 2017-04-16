using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class ImageProfile : ESAPIX.Facade.Types.LineProfile
    {
        public ImageProfile() { _client = new ExpandoObject(); }
        public ImageProfile(dynamic client) { _client = client; }
        public ImageProfile(ESAPIX.Facade.Types.VVector origin, ESAPIX.Facade.Types.VVector step, System.Double[] data, System.String unit) { X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructImageProfile(origin, step, data, unit); }); }
        public System.String Unit
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Unit; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Unit; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Unit = value; }
            }
        }
    }
}