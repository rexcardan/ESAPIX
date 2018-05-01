using System;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;
using Types = VMS.TPS.Common.Model.Types;

namespace ESAPIX.Facade.API
{
    public class OptimizerResult : ESAPIX.Facade.API.CalculationResult
    {
        public IEnumerable<ESAPIX.Facade.API.OptimizerDVH> StructureDVHs
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("StructureDVHs"))
                    {
                        foreach (var item in _client.StructureDVHs)
                        {
                            yield return item;
                        }
                    }
                    else
                    {
                        yield break;
                    }
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable)_client.StructureDVHs;
                        enumerator = asEnum.GetEnumerator();
                    }

                    );
                    while (XC.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                    {
                        var facade = new ESAPIX.Facade.API.OptimizerDVH();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            if (vms != null)
                            {
                                facade._client = vms;
                            }
                        }

                        );
                        if (facade._client != null)
                        {
                            yield return facade;
                        }
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.StructureDVHs = value;
            }
        }

        public IEnumerable<ESAPIX.Facade.API.OptimizerObjectiveValue> StructureObjectiveValues
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("StructureObjectiveValues"))
                    {
                        foreach (var item in _client.StructureObjectiveValues)
                        {
                            yield return item;
                        }
                    }
                    else
                    {
                        yield break;
                    }
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable)_client.StructureObjectiveValues;
                        enumerator = asEnum.GetEnumerator();
                    }

                    );
                    while (XC.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                    {
                        var facade = new ESAPIX.Facade.API.OptimizerObjectiveValue();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            if (vms != null)
                            {
                                facade._client = vms;
                            }
                        }

                        );
                        if (facade._client != null)
                        {
                            yield return facade;
                        }
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.StructureObjectiveValues = value;
            }
        }

        public System.Double TotalObjectiveFunctionValue
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TotalObjectiveFunctionValue"))
                    {
                        return _client.TotalObjectiveFunctionValue;
                    }
                    else
                    {
                        return default (System.Double);
                    }
                }
                else if ((XC.Instance.CurrentContext) != (null))
                {
                    return XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.TotalObjectiveFunctionValue;
                    }

                    );
                }
                else
                {
                    return default (System.Double);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TotalObjectiveFunctionValue = (value);
                }
                else
                {
                }
            }
        }

        public System.Int32 NumberOfIMRTOptimizerIterations
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("NumberOfIMRTOptimizerIterations"))
                    {
                        return _client.NumberOfIMRTOptimizerIterations;
                    }
                    else
                    {
                        return default (System.Int32);
                    }
                }
                else if ((XC.Instance.CurrentContext) != (null))
                {
                    return XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.NumberOfIMRTOptimizerIterations;
                    }

                    );
                }
                else
                {
                    return default (System.Int32);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.NumberOfIMRTOptimizerIterations = (value);
                }
                else
                {
                }

                if ((XC.Instance.CurrentContext) != (null))
                {
                    XC.Instance.CurrentContext.Thread.Invoke(() => _client.NumberOfIMRTOptimizerIterations = (value));
                }
            }
        }

        public OptimizerResult()
        {
            _client = (new ExpandoObject());
        }

        public OptimizerResult(dynamic client)
        {
            _client = (client);
        }
    }
}