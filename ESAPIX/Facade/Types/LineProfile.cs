using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class LineProfile
    {
        internal dynamic _client;
        public LineProfile() { _client = new ExpandoObject(); }
        public LineProfile(dynamic client) { _client = client; }
        public LineProfile(ESAPIX.Facade.Types.VVector origin, ESAPIX.Facade.Types.VVector step, System.Double[] data)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructLineProfile(origin, step, data); });
            else
            {
                _client = new ExpandoObject();
                _client.Origin = origin;
                _client.Step = step;
                _client.Data = data;
            }
        }
        public ESAPIX.Facade.Types.ProfilePoint Item
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Item; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.ProfilePoint>((sc) => { return new ESAPIX.Facade.Types.ProfilePoint(local._client.Item); });
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
    }
}