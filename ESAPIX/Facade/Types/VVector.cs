using System.Dynamic;
using X = ESAPIX.Facade.XContext;

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
            {
                X.Instance.CurrentContext.Thread.Invoke(
                    () => { _client = VMSConstructor.ConstructVVector(xi, yi, zi); });
            }
            else
            {
                _client = new ExpandoObject();
                _client.Xi = xi;
                _client.Yi = yi;
                _client.Zi = zi;
            }
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public double Item
        {
            get
            {
                if (_client is ExpandoObject) return _client.Item;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Item; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Item = value;
            }
        }

        public double LengthSquared
        {
            get
            {
                if (_client is ExpandoObject) return _client.LengthSquared;
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
                if (_client is ExpandoObject) return _client.Length;
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
                if (_client is ExpandoObject) return _client.x;
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
                if (_client is ExpandoObject) return _client.y;
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
                if (_client is ExpandoObject) return _client.z;
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