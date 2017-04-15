using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class LMCVOptions
    {
        internal dynamic _client;
        public LMCVOptions() { _client = new ExpandoObject(); }
        public LMCVOptions(dynamic client) { _client = client; }
        public LMCVOptions(System.Boolean fixedJaws) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructLMCVOptions(fixedJaws)); }
        public System.Boolean FixedJaws
        {
            get
            {
                if (_client is ExpandoObject) { return _client.FixedJaws; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.FixedJaws; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.FixedJaws = value; }
            }
        }
    }
}