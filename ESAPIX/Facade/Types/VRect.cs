#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class VRect<T>
    {
        internal dynamic _client;

        public VRect()
        {
            _client = new ExpandoObject();
        }

        public VRect(dynamic client)
        {
            _client = client;
        }

        public VRect(T x1, T y1, T x2, T y2)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructVRect(x1, y1, x2, y2);
                });
            else throw new Exception("There is no VMS Context to create the class");
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public T X1
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("X1") ? _client.X1 : default(T);
                var local = this;
                return X.Instance.CurrentContext.GetValue<T>(sc => { return local._client.X1; });
            }
            set
            {
                if (_client is ExpandoObject) _client.X1 = value;
            }
        }

        public T Y1
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Y1") ? _client.Y1 : default(T);
                var local = this;
                return X.Instance.CurrentContext.GetValue<T>(sc => { return local._client.Y1; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Y1 = value;
            }
        }

        public T X2
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("X2") ? _client.X2 : default(T);
                var local = this;
                return X.Instance.CurrentContext.GetValue<T>(sc => { return local._client.X2; });
            }
            set
            {
                if (_client is ExpandoObject) _client.X2 = value;
            }
        }

        public T Y2
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Y2") ? _client.Y2 : default(T);
                var local = this;
                return X.Instance.CurrentContext.GetValue<T>(sc => { return local._client.Y2; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Y2 = value;
            }
        }

        public string ToString()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.ToString(); });
            return retVal;
        }

        public bool Equals(object obj)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.Equals(obj); });
            return retVal;
        }

        public bool Equals(VRect<T> other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.Equals(other._client); });
            return retVal;
        }

        public int GetHashCode()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.GetHashCode(); });
            return retVal;
        }
    }
}