using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizerResult : ESAPIX.Facade.API.CalculationResult
    {
        public OptimizerResult() { }
        public OptimizerResult(dynamic client) { _client = client; }
        public IEnumerable<ESAPIX.Facade.API.OptimizerDVH> StructureDVHs
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.OptimizerDVH>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.StructureDVHs).Select(s => new ESAPIX.Facade.API.OptimizerDVH(s));
                });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.OptimizerObjectiveValue> StructureObjectiveValues
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.OptimizerObjectiveValue>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.StructureObjectiveValues).Select(s => new ESAPIX.Facade.API.OptimizerObjectiveValue(s));
                });
            }
        }
        public System.Double TotalObjectiveFunctionValue
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.TotalObjectiveFunctionValue; });
            }
        }
        public System.Int32 NumberOfIMRTOptimizerIterations
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.NumberOfIMRTOptimizerIterations; });
            }
        }
    }
}