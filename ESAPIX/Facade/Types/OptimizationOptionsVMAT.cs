using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class OptimizationOptionsVMAT : ESAPIX.Facade.Types.OptimizationOptionsBase
    {
        public OptimizationOptionsVMAT() { }
        public OptimizationOptionsVMAT(dynamic client) { _client = client; }
        public OptimizationOptionsVMAT(ESAPIX.Facade.Types.OptimizationOption startOption, System.String mlcId) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructOptimizationOptionsVMAT(startOption, mlcId)); }
        public OptimizationOptionsVMAT(ESAPIX.Facade.Types.OptimizationIntermediateDoseOption intermediateDoseOption, System.String mlcId) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructOptimizationOptionsVMAT(intermediateDoseOption, mlcId)); }
        public OptimizationOptionsVMAT(System.Int32 numberOfCycles, System.String mlcId) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructOptimizationOptionsVMAT(numberOfCycles, mlcId)); }
        public OptimizationOptionsVMAT(ESAPIX.Facade.Types.OptimizationOption startOption, ESAPIX.Facade.Types.OptimizationIntermediateDoseOption intermediateDoseOption, System.Int32 numberOfCycles, System.String mlcId) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructOptimizationOptionsVMAT(startOption, intermediateDoseOption, numberOfCycles, mlcId)); }
        public OptimizationOptionsVMAT(ESAPIX.Facade.Types.OptimizationOptionsVMAT options) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructOptimizationOptionsVMAT(options)); }
        public System.Int32 NumberOfOptimizationCycles
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.NumberOfOptimizationCycles; });
            }
        }
    }
}