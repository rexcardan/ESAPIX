#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

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
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructOptimizationOptionsIMRT(maxIterations, initialState,
                        numberOfStepsBeforeIntermediateDose, convergenceOption, mlcId);
                });
            else throw new Exception("There is no VMS Context to create the class");
        }

        public OptimizationOptionsIMRT(int maxIterations, OptimizationOption initialState,
            OptimizationConvergenceOption convergenceOption, OptimizationIntermediateDoseOption intermediateDoseOption,
            string mlcId)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructOptimizationOptionsIMRT(maxIterations, initialState,
                        convergenceOption, intermediateDoseOption, mlcId);
                });
            else throw new Exception("There is no VMS Context to create the class");
        }

        public OptimizationOptionsIMRT(int maxIterations, OptimizationOption initialState,
            OptimizationConvergenceOption convergenceOption, string mlcId)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client =
                        VMSConstructor.ConstructOptimizationOptionsIMRT(maxIterations, initialState,
                            convergenceOption, mlcId);
                });
            else throw new Exception("There is no VMS Context to create the class");
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public OptimizationConvergenceOption ConvergenceOption
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ConvergenceOption")
                        ? _client.ConvergenceOption
                        : default(OptimizationConvergenceOption);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("NumberOfStepsBeforeIntermediateDose")
                        ? _client.NumberOfStepsBeforeIntermediateDose
                        : default(int);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MaximumNumberOfIterations")
                        ? _client.MaximumNumberOfIterations
                        : default(int);
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