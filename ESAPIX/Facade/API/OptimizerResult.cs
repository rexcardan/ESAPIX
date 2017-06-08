#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

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

        public IEnumerable<OptimizerDVH> StructureDVHs
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("StructureDVHs"))
                        foreach (var item in _client.StructureDVHs)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.StructureDVHs;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new OptimizerDVH();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.StructureDVHs = value;
            }
        }

        public IEnumerable<OptimizerObjectiveValue> StructureObjectiveValues
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("StructureObjectiveValues"))
                        foreach (var item in _client.StructureObjectiveValues)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.StructureObjectiveValues;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new OptimizerObjectiveValue();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.StructureObjectiveValues = value;
            }
        }

        public double TotalObjectiveFunctionValue
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TotalObjectiveFunctionValue"))
                        return _client.TotalObjectiveFunctionValue;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.TotalObjectiveFunctionValue; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.TotalObjectiveFunctionValue = value;
            }
        }

        public int NumberOfIMRTOptimizerIterations
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("NumberOfIMRTOptimizerIterations"))
                        return _client.NumberOfIMRTOptimizerIterations;
                    else
                        return default(int);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.NumberOfIMRTOptimizerIterations; }
                    );
                return default(int);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.NumberOfIMRTOptimizerIterations = value;
            }
        }
    }
}