#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class PlanSum : PlanningItem, System.Xml.Serialization.IXmlSerializable
    {
        public PlanSum()
        {
            _client = new ExpandoObject();
        }

        public PlanSum(dynamic client)
        {
            _client = client;
        }

        public Course Course
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Course"))
                        return _client.Course;
                    else
                        return default(Course);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Course != null)
                                return new Course(_client.Course);
                            return null;
                        }
                    );
                return default(Course);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Course = value;
            }
        }

        public IEnumerable<PlanSumComponent> PlanSumComponents
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PlanSumComponents"))
                        foreach (var item in _client.PlanSumComponents)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.PlanSumComponents;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new PlanSumComponent();
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
                    _client.PlanSumComponents = value;
            }
        }

        public StructureSet StructureSet
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("StructureSet"))
                        return _client.StructureSet;
                    else
                        return default(StructureSet);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.StructureSet != null)
                                return new StructureSet(_client.StructureSet);
                            return null;
                        }
                    );
                return default(StructureSet);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.StructureSet = value;
            }
        }

        public IEnumerable<PlanSetup> PlanSetups
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PlanSetups"))
                        foreach (var item in _client.PlanSetups)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.PlanSetups;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new PlanSetup();
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
                    _client.PlanSetups = value;
            }
        }

        public PlanSumOperation GetPlanSumOperation(PlanSetup planSetupInPlanSum)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.GetPlanSumOperation(planSetupInPlanSum._client);
                    }
                );
                return vmsResult;
            }
            return (PlanSumOperation) _client.GetPlanSumOperation(planSetupInPlanSum);
        }

        public double GetPlanWeight(PlanSetup planSetupInPlanSum)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.GetPlanWeight(planSetupInPlanSum._client); }
                );
                return vmsResult;
            }
            return (double) _client.GetPlanWeight(planSetupInPlanSum);
        }
    }
}