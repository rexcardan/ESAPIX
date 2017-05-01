#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
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
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructFluence(fluenceMatrix, xOrigin, yOrigin);
                });
            else throw new Exception("There is no VMS Context to create the class");
        }

        public Fluence(float[,] fluenceMatrix, double xOrigin, double yOrigin, string mlcId)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructFluence(fluenceMatrix, xOrigin, yOrigin, mlcId);
                });
            else throw new Exception("There is no VMS Context to create the class");
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public int XSizePixel
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("XSizePixel") ? _client.XSizePixel : default(int);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("YSizePixel") ? _client.YSizePixel : default(int);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("XSizeMM") ? _client.XSizeMM : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("YSizeMM") ? _client.YSizeMM : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("XOrigin") ? _client.XOrigin : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("YOrigin") ? _client.YOrigin : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MLCId") ? _client.MLCId : default(string);
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