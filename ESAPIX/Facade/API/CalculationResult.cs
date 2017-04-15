using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class CalculationResult
    {
        internal dynamic _client;
        public CalculationResult() { }
        public CalculationResult(dynamic client) { _client = client; }
        public System.Boolean Success
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.Success; });
            }
        }
    }
}