using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class OptimizationOptionsVMAT : ESAPIX.Facade.Types.OptimizationOptionsBase
    {
        public OptimizationOptionsVMAT() { _client = new ExpandoObject(); }
        public OptimizationOptionsVMAT(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public OptimizationOptionsVMAT(ESAPIX.Facade.Types.OptimizationOption startOption, System.String mlcId)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructOptimizationOptionsVMAT(startOption, mlcId); });
            else
            {
                _client = new ExpandoObject();
                _client.StartOption = startOption;
                _client.MlcId = mlcId;
            }
        }
        public OptimizationOptionsVMAT(ESAPIX.Facade.Types.OptimizationIntermediateDoseOption intermediateDoseOption, System.String mlcId)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructOptimizationOptionsVMAT(intermediateDoseOption, mlcId); });
            else
            {
                _client = new ExpandoObject();
                _client.IntermediateDoseOption = intermediateDoseOption;
                _client.MlcId = mlcId;
            }
        }
        public OptimizationOptionsVMAT(System.Int32 numberOfCycles, System.String mlcId)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructOptimizationOptionsVMAT(numberOfCycles, mlcId); });
            else
            {
                _client = new ExpandoObject();
                _client.NumberOfCycles = numberOfCycles;
                _client.MlcId = mlcId;
            }
        }
        public OptimizationOptionsVMAT(ESAPIX.Facade.Types.OptimizationOption startOption, ESAPIX.Facade.Types.OptimizationIntermediateDoseOption intermediateDoseOption, System.Int32 numberOfCycles, System.String mlcId)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructOptimizationOptionsVMAT(startOption, intermediateDoseOption, numberOfCycles, mlcId); });
            else
            {
                _client = new ExpandoObject();
                _client.StartOption = startOption;
                _client.IntermediateDoseOption = intermediateDoseOption;
                _client.NumberOfCycles = numberOfCycles;
                _client.MlcId = mlcId;
            }
        }
        public OptimizationOptionsVMAT(ESAPIX.Facade.Types.OptimizationOptionsVMAT options)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructOptimizationOptionsVMAT(options); });
            else
            {
                _client = new ExpandoObject();
                _client.Options = options;
            }
        }
        public System.Int32 NumberOfOptimizationCycles
        {
            get
            {
                if (_client is ExpandoObject) { return _client.NumberOfOptimizationCycles; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.NumberOfOptimizationCycles; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.NumberOfOptimizationCycles = value; }
            }
        }
    }
}