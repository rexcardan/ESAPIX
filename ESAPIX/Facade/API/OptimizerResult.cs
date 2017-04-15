using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizerResult : ESAPIX.Facade.API.CalculationResult
    {
        public OptimizerResult() { _client = new ExpandoObject(); }
        public OptimizerResult(dynamic client) { _client = client; }
        public IEnumerable<ESAPIX.Facade.API.OptimizerDVH> StructureDVHs
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.StructureDVHs;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.OptimizerDVH();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.OptimizerObjectiveValue> StructureObjectiveValues
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.StructureObjectiveValues;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.OptimizerObjectiveValue();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
            }
        }
        public System.Double TotalObjectiveFunctionValue
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TotalObjectiveFunctionValue; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.TotalObjectiveFunctionValue; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TotalObjectiveFunctionValue = value; }
            }
        }
        public System.Int32 NumberOfIMRTOptimizerIterations
        {
            get
            {
                if (_client is ExpandoObject) { return _client.NumberOfIMRTOptimizerIterations; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.NumberOfIMRTOptimizerIterations; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.NumberOfIMRTOptimizerIterations = value; }
            }
        }
    }
}