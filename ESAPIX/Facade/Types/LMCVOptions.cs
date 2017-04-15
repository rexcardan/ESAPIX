using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class LMCVOptions
    {
        internal dynamic _client;
        public LMCVOptions() { }
        public LMCVOptions(dynamic client) { _client = client; }
        public LMCVOptions(System.Boolean fixedJaws) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructLMCVOptions(fixedJaws)); }
        public System.Boolean FixedJaws
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.FixedJaws; });
            }
        }
    }
}