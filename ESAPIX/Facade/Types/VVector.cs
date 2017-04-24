using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class VVector
    {
        internal dynamic _client;
        public VVector() { _client = new ExpandoObject(); }
        public VVector(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public VVector(System.Double xi, System.Double yi, System.Double zi)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructVVector(xi, yi, zi); });
            else
            {
                _client = new ExpandoObject();
                _client.Xi = xi;
                _client.Yi = yi;
                _client.Zi = zi;
            }
        }
        public System.Double Item
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Item; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Item; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Item = value; }
            }
        }
        public System.Double LengthSquared
        {
            get
            {
                if (_client is ExpandoObject) { return _client.LengthSquared; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.LengthSquared; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.LengthSquared = value; }
            }
        }
        public System.Double Length
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Length; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Length; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Length = value; }
            }
        }
        public System.Double x
        {
            get
            {
                if (_client is ExpandoObject) { return _client.x; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.x; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.x = value; }
            }
        }
        public System.Double y
        {
            get
            {
                if (_client is ExpandoObject) { return _client.y; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.y; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.y = value; }
            }
        }
        public System.Double z
        {
            get
            {
                if (_client is ExpandoObject) { return _client.z; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.z; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.z = value; }
            }
        }
        public static System.Double Distance(ESAPIX.Facade.Types.VVector left, ESAPIX.Facade.Types.VVector right)
        {
            return StaticHelper.VVector_Distance(left._client, right._client);
        }
        public void ScaleToUnitLength()
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.ScaleToUnitLength();
            });

        }
        public System.Double ScalarProduct(ESAPIX.Facade.Types.VVector left)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.ScalarProduct(left._client); });
            return retVal;

        }
    }
}