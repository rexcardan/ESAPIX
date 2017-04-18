using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class LMCMSSOptions
    {
        internal dynamic _client;
        public LMCMSSOptions() { _client = new ExpandoObject(); }
        public LMCMSSOptions(dynamic client) { _client = client; }
        public LMCMSSOptions(System.Int32 numberOfIterations)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructLMCMSSOptions(numberOfIterations); });
            else
            {
                _client = new ExpandoObject();
                _client.NumberOfIterations = numberOfIterations;
            }
        }
        public System.Int32 NumberOfIterations
        {
            get
            {
                if (_client is ExpandoObject) { return _client.NumberOfIterations; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.NumberOfIterations; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.NumberOfIterations = value; }
            }
        }
    }
}