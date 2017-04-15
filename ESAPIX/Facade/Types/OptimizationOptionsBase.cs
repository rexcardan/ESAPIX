using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class OptimizationOptionsBase
    {
        internal dynamic _client;
        public OptimizationOptionsBase() { }
        public OptimizationOptionsBase(dynamic client) { _client = client; }
        public System.String MLC
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MLC; });
            }
        }
        public ESAPIX.Facade.Types.OptimizationOption StartOption
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.OptimizationOption)local._client.StartOption;
            }
        }
        public ESAPIX.Facade.Types.OptimizationIntermediateDoseOption IntermediateDoseOption
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.OptimizationIntermediateDoseOption)local._client.IntermediateDoseOption;
            }
        }
    }
}