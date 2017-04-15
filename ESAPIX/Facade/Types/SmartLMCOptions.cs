using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class SmartLMCOptions
    {
        internal dynamic _client;
        public SmartLMCOptions() { }
        public SmartLMCOptions(dynamic client) { _client = client; }
        public SmartLMCOptions(System.Boolean fixedFieldBorders, System.Boolean jawTracking) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructSmartLMCOptions(fixedFieldBorders, jawTracking)); }
        public System.Boolean FixedFieldBorders
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.FixedFieldBorders; });
            }
        }
        public System.Boolean JawTracking
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.JawTracking; });
            }
        }
    }
}