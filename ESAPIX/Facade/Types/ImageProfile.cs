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
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public ImageProfile(ESAPIX.Facade.Types.VVector origin, ESAPIX.Facade.Types.VVector step, System.Double[] data, System.String unit)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructImageProfile(origin, step, data, unit); });
            else
            {
                _client = new ExpandoObject();
                _client.Origin = origin;
                _client.Step = step;
                _client.Data = data;
                _client.Unit = unit;
            }
        }
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