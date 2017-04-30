#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class OptimizationOptionsVMAT : OptimizationOptionsBase
    {
        public OptimizationOptionsVMAT()
        {
            _client = new ExpandoObject();
        }

        public OptimizationOptionsVMAT(dynamic client)
        {
            _client = client;
        }

        public OptimizationOptionsVMAT(OptimizationOption startOption, string mlcId)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructOptimizationOptionsVMAT(startOption, mlcId);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.StartOption = startOption;
                _client.MlcId = mlcId;
            }
        }

        public OptimizationOptionsVMAT(OptimizationIntermediateDoseOption intermediateDoseOption, string mlcId)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructOptimizationOptionsVMAT(intermediateDoseOption, mlcId);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.IntermediateDoseOption = intermediateDoseOption;
                _client.MlcId = mlcId;
            }
        }

        public OptimizationOptionsVMAT(int numberOfCycles, string mlcId)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructOptimizationOptionsVMAT(numberOfCycles, mlcId);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.NumberOfCycles = numberOfCycles;
                _client.MlcId = mlcId;
            }
        }

        public OptimizationOptionsVMAT(OptimizationOption startOption,
            OptimizationIntermediateDoseOption intermediateDoseOption, int numberOfCycles, string mlcId)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructOptimizationOptionsVMAT(startOption, intermediateDoseOption,
                        numberOfCycles, mlcId);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.StartOption = startOption;
                _client.IntermediateDoseOption = intermediateDoseOption;
                _client.NumberOfCycles = numberOfCycles;
                _client.MlcId = mlcId;
            }
        }

        public OptimizationOptionsVMAT(OptimizationOptionsVMAT options)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructOptimizationOptionsVMAT(options);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.Options = options;
            }
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public int NumberOfOptimizationCycles
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("NumberOfOptimizationCycles")
                        ? _client.NumberOfOptimizationCycles
                        : default(int);
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc =>
                {
                    return local._client.NumberOfOptimizationCycles;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.NumberOfOptimizationCycles = value;
            }
        }
    }
}