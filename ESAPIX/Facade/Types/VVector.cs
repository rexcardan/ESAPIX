#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class VVector
    {
        internal dynamic _client;

        public VVector()
        {
            _client = new ExpandoObject();
        }

        public VVector(dynamic client)
        {
            _client = client;
        }

        public VVector(double xi, double yi, double zi)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(
                    () => { _client = VMSConstructor.ConstructVVector(xi, yi, zi); });
            else throw new Exception("There is no VMS Context to create the class");
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public double this[int index]
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("this[int index]") ? _client[index] : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client[index]; });
            }
            set
            {
                if (_client is ExpandoObject) _client[index] = value;
            }
        }

        public double LengthSquared
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("LengthSquared")
                        ? _client.LengthSquared
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.LengthSquared; });
            }
            set
            {
                if (_client is ExpandoObject) _client.LengthSquared = value;
            }
        }

        public double Length
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Length") ? _client.Length : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Length; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Length = value;
            }
        }

        public double x
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("x") ? _client.x : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.x; });
            }
            set
            {
                if (_client is ExpandoObject) _client.x = value;
            }
        }

        public double y
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("y") ? _client.y : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.y; });
            }
            set
            {
                if (_client is ExpandoObject) _client.y = value;
            }
        }

        public double z
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("z") ? _client.z : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.z; });
            }
            set
            {
                if (_client is ExpandoObject) _client.z = value;
            }
        }

        public static double Distance(VVector left, VVector right)
        {
            return StaticHelper.VVector_Distance(left._client, right._client);
        }

        public void ScaleToUnitLength()
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.ScaleToUnitLength(); });
        }

        public double ScalarProduct(VVector left)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.ScalarProduct(left._client);
            });
            return retVal;
        }
    }
}