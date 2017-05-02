#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion


namespace ESAPIX.Facade.API
{
    public class OptimizerResult : CalculationResult
    {
        public OptimizerResult()
        {
            _client = new ExpandoObject();
        }

        public OptimizerResult(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public IEnumerable<OptimizerDVH> StructureDVHs
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("StructureDVHs"))
                        foreach (var item in _client.StructureDVHs) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.StructureDVHs;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new OptimizerDVH();
                        X.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            if (vms != null)
                                facade._client = vms;
                        });
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }
            set
            {
                if (_client is ExpandoObject) _client.StructureDVHs = value;
            }
        }

        public IEnumerable<OptimizerObjectiveValue> StructureObjectiveValues
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("StructureObjectiveValues"))
                        foreach (var item in _client.StructureObjectiveValues) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.StructureObjectiveValues;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new OptimizerObjectiveValue();
                        X.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            if (vms != null)
                                facade._client = vms;
                        });
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }
            set
            {
                if (_client is ExpandoObject) _client.StructureObjectiveValues = value;
            }
        }

        public double TotalObjectiveFunctionValue
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("TotalObjectiveFunctionValue")
                        ? _client.TotalObjectiveFunctionValue
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc =>
                {
                    return local._client.TotalObjectiveFunctionValue;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.TotalObjectiveFunctionValue = value;
            }
        }

        public int NumberOfIMRTOptimizerIterations
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("NumberOfIMRTOptimizerIterations")
                        ? _client.NumberOfIMRTOptimizerIterations
                        : default(int);
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc =>
                {
                    return local._client.NumberOfIMRTOptimizerIterations;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.NumberOfIMRTOptimizerIterations = value;
            }
        }
    }
}