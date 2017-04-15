using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class Fluence
    {
        internal dynamic _client;
        public Fluence() { }
        public Fluence(dynamic client) { _client = client; }
        public Fluence(System.Single[,] fluenceMatrix, System.Double xOrigin, System.Double yOrigin) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructFluence(fluenceMatrix, xOrigin, yOrigin)); }
        public Fluence(System.Single[,] fluenceMatrix, System.Double xOrigin, System.Double yOrigin, System.String mlcId) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructFluence(fluenceMatrix, xOrigin, yOrigin, mlcId)); }
        public System.Int32 XSizePixel
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.XSizePixel; });
            }
        }
        public System.Int32 YSizePixel
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.YSizePixel; });
            }
        }
        public System.Double XSizeMM
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.XSizeMM; });
            }
        }
        public System.Double YSizeMM
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.YSizeMM; });
            }
        }
        public System.Double XOrigin
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.XOrigin; });
            }
        }
        public System.Double YOrigin
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.YOrigin; });
            }
        }
        public System.String MLCId
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MLCId; });
            }
        }
        public System.Single[,] GetPixels()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetPixels(); });
            return retVal;

        }
    }
}