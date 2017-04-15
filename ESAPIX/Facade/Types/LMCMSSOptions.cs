using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class LMCMSSOptions
    {
        internal dynamic _client;
        public LMCMSSOptions() { }
        public LMCMSSOptions(dynamic client) { _client = client; }
        public LMCMSSOptions(System.Int32 numberOfIterations) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructLMCMSSOptions(numberOfIterations)); }
        public System.Int32 NumberOfIterations
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.NumberOfIterations; });
            }
        }
    }
}