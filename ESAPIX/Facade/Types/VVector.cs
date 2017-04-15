using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public struct VVector
    {
        internal dynamic _client;
        public VVector(dynamic client) { _client = client; }
        public VVector(System.Double xi, System.Double yi, System.Double zi) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructVVector(xi, yi, zi)); }
        public System.Double Item
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Item; });
            }
        }
        public System.Double LengthSquared
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.LengthSquared; });
            }
        }
        public System.Double Length
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Length; });
            }
        }
        public System.Double x
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.x; });
            }
        }
        public System.Double y
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.y; });
            }
        }
        public System.Double z
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.z; });
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