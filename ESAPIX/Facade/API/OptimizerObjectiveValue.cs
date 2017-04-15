using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizerObjectiveValue
    {
        internal dynamic _client;
        public OptimizerObjectiveValue() { }
        public OptimizerObjectiveValue(dynamic client) { _client = client; }
        public ESAPIX.Facade.API.Structure Structure
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Structure(local._client.Structure);
            }
        }
        public System.Double Value
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Value; });
            }
        }
    }
}