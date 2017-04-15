using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class OptimizationOptionsIMRT : ESAPIX.Facade.Types.OptimizationOptionsBase
    {
        public OptimizationOptionsIMRT() { }
        public OptimizationOptionsIMRT(dynamic client) { _client = client; }
        public OptimizationOptionsIMRT(System.Int32 maxIterations, ESAPIX.Facade.Types.OptimizationOption initialState, System.Int32 numberOfStepsBeforeIntermediateDose, ESAPIX.Facade.Types.OptimizationConvergenceOption convergenceOption, System.String mlcId) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructOptimizationOptionsIMRT(maxIterations, initialState, numberOfStepsBeforeIntermediateDose, convergenceOption, mlcId)); }
        public OptimizationOptionsIMRT(System.Int32 maxIterations, ESAPIX.Facade.Types.OptimizationOption initialState, ESAPIX.Facade.Types.OptimizationConvergenceOption convergenceOption, ESAPIX.Facade.Types.OptimizationIntermediateDoseOption intermediateDoseOption, System.String mlcId) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructOptimizationOptionsIMRT(maxIterations, initialState, convergenceOption, intermediateDoseOption, mlcId)); }
        public OptimizationOptionsIMRT(System.Int32 maxIterations, ESAPIX.Facade.Types.OptimizationOption initialState, ESAPIX.Facade.Types.OptimizationConvergenceOption convergenceOption, System.String mlcId) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructOptimizationOptionsIMRT(maxIterations, initialState, convergenceOption, mlcId)); }
        public ESAPIX.Facade.Types.OptimizationConvergenceOption ConvergenceOption
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.OptimizationConvergenceOption)local._client.ConvergenceOption;
            }
        }
        public System.Int32 NumberOfStepsBeforeIntermediateDose
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.NumberOfStepsBeforeIntermediateDose; });
            }
        }
        public System.Int32 MaximumNumberOfIterations
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.MaximumNumberOfIterations; });
            }
        }
    }
}