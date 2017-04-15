using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public struct VRect<T>
    {
        internal dynamic _client;
        public VRect(dynamic client) { _client = client; }
        public VRect(T x1, T y1, T x2, T y2) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructVRect(x1, y1, x2, y2)); }
        public T X1
        {
            get
            {
                var local = this;
                return local._client.X1;
            }
        }
        public T Y1
        {
            get
            {
                var local = this;
                return local._client.Y1;
            }
        }
        public T X2
        {
            get
            {
                var local = this;
                return local._client.X2;
            }
        }
        public T Y2
        {
            get
            {
                var local = this;
                return local._client.Y2;
            }
        }
        public System.String ToString()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.ToString(); });
            return retVal;

        }
        public System.Boolean Equals(System.Object obj)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.Equals(obj); });
            return retVal;

        }
        public System.Boolean Equals(ESAPIX.Facade.Types.VRect<T> other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.Equals(other._client); });
            return retVal;

        }
        public System.Int32 GetHashCode()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetHashCode(); });
            return retVal;

        }
    }
}