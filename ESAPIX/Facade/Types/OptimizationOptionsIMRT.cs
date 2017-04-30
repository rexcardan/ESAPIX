using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class OptimizationOptionsIMRT : OptimizationOptionsBase
    {
        public OptimizationOptionsIMRT()
        {
            _client = new ExpandoObject();
        }

        public OptimizationOptionsIMRT(dynamic client)
        {
            _client = client;
        }

        public OptimizationOptionsIMRT(int maxIterations, OptimizationOption initialState,
            int numberOfStepsBeforeIntermediateDose, OptimizationConvergenceOption convergenceOption, string mlcId)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructOptimizationOptionsIMRT(maxIterations, initialState,
                        numberOfStepsBeforeIntermediateDose, convergenceOption, mlcId);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.MaxIterations = maxIterations;
                _client.InitialState = initialState;
                _client.NumberOfStepsBeforeIntermediateDose = numberOfStepsBeforeIntermediateDose;
                _client.ConvergenceOption = convergenceOption;
                _client.MlcId = mlcId;
            }
        }

        public OptimizationOptionsIMRT(int maxIterations, OptimizationOption initialState,
            OptimizationConvergenceOption convergenceOption, OptimizationIntermediateDoseOption intermediateDoseOption,
            string mlcId)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructOptimizationOptionsIMRT(maxIterations, initialState,
                        convergenceOption, intermediateDoseOption, mlcId);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.MaxIterations = maxIterations;
                _client.InitialState = initialState;
                _client.ConvergenceOption = convergenceOption;
                _client.IntermediateDoseOption = intermediateDoseOption;
                _client.MlcId = mlcId;
            }
        }

        public OptimizationOptionsIMRT(int maxIterations, OptimizationOption initialState,
            OptimizationConvergenceOption convergenceOption, string mlcId)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client =
                        VMSConstructor.ConstructOptimizationOptionsIMRT(maxIterations, initialState,
                            convergenceOption, mlcId);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.MaxIterations = maxIterations;
                _client.InitialState = initialState;
                _client.ConvergenceOption = convergenceOption;
                _client.MlcId = mlcId;
            }
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public OptimizationConvergenceOption ConvergenceOption
        {
            get
            {
                if (_client is ExpandoObject) return _client.ConvergenceOption;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    return (OptimizationConvergenceOption) local._client.ConvergenceOption;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ConvergenceOption = value;
            }
        }

        public int NumberOfStepsBeforeIntermediateDose
        {
            get
            {
                if (_client is ExpandoObject) return _client.NumberOfStepsBeforeIntermediateDose;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc =>
                {
                    return local._client.NumberOfStepsBeforeIntermediateDose;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.NumberOfStepsBeforeIntermediateDose = value;
            }
        }

        public int MaximumNumberOfIterations
        {
            get
            {
                if (_client is ExpandoObject) return _client.MaximumNumberOfIterations;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(
                    sc => { return local._client.MaximumNumberOfIterations; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MaximumNumberOfIterations = value;
            }
        }
    }
}