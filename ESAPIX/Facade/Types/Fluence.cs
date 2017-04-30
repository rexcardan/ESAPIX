#region

using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class Fluence
    {
        internal dynamic _client;

        public Fluence()
        {
            _client = new ExpandoObject();
        }

        public Fluence(dynamic client)
        {
            _client = client;
        }

        public Fluence(float[,] fluenceMatrix, double xOrigin, double yOrigin)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructFluence(fluenceMatrix, xOrigin, yOrigin);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.FluenceMatrix = fluenceMatrix;
                _client.XOrigin = xOrigin;
                _client.YOrigin = yOrigin;
            }
        }

        public Fluence(float[,] fluenceMatrix, double xOrigin, double yOrigin, string mlcId)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructFluence(fluenceMatrix, xOrigin, yOrigin, mlcId);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.FluenceMatrix = fluenceMatrix;
                _client.XOrigin = xOrigin;
                _client.YOrigin = yOrigin;
                _client.MlcId = mlcId;
            }
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public int XSizePixel
        {
            get
            {
                if (_client is ExpandoObject) return _client.XSizePixel;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.XSizePixel; });
            }
            set
            {
                if (_client is ExpandoObject) _client.XSizePixel = value;
            }
        }

        public int YSizePixel
        {
            get
            {
                if (_client is ExpandoObject) return _client.YSizePixel;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.YSizePixel; });
            }
            set
            {
                if (_client is ExpandoObject) _client.YSizePixel = value;
            }
        }

        public double XSizeMM
        {
            get
            {
                if (_client is ExpandoObject) return _client.XSizeMM;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.XSizeMM; });
            }
            set
            {
                if (_client is ExpandoObject) _client.XSizeMM = value;
            }
        }

        public double YSizeMM
        {
            get
            {
                if (_client is ExpandoObject) return _client.YSizeMM;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.YSizeMM; });
            }
            set
            {
                if (_client is ExpandoObject) _client.YSizeMM = value;
            }
        }

        public double XOrigin
        {
            get
            {
                if (_client is ExpandoObject) return _client.XOrigin;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.XOrigin; });
            }
            set
            {
                if (_client is ExpandoObject) _client.XOrigin = value;
            }
        }

        public double YOrigin
        {
            get
            {
                if (_client is ExpandoObject) return _client.YOrigin;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.YOrigin; });
            }
            set
            {
                if (_client is ExpandoObject) _client.YOrigin = value;
            }
        }

        public string MLCId
        {
            get
            {
                if (_client is ExpandoObject) return _client.MLCId;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.MLCId; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MLCId = value;
            }
        }

        public float[,] GetPixels()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.GetPixels(); });
            return retVal;
        }
    }
}