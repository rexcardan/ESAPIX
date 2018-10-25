using System;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Common.AppComThread;
using V = VMS.TPS.Common.Model.API;
using Types = VMS.TPS.Common.Model.Types;

namespace ESAPIX.Facade.API
{
    public class PlanSum : ESAPIX.Facade.API.PlanningItem, System.Xml.Serialization.IXmlSerializable
    {
        public ESAPIX.Facade.API.Course Course
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Course"))
                    {
                        return _client.Course;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Course);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Course) != (null))
                        {
                            return new ESAPIX.Facade.API.Course(_client.Course);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    );
                }
                else
                {
                    return default (ESAPIX.Facade.API.Course);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Course = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.PlanSumComponent> PlanSumComponents
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PlanSumComponents"))
                    {
                        foreach (var item in _client.PlanSumComponents)
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
                    XC.Instance.Invoke(() =>
                    {
                        var asEnum = (IEnumerable)_client.PlanSumComponents;
                        if ((asEnum) != null)
                        {
                            enumerator = asEnum.GetEnumerator();
                        }
                    }

                    );
                    if (enumerator == null)
                    {
                        yield break;
                    }

                    while (XC.Instance.GetValue<bool>(sc => enumerator.MoveNext()))
                    {
                        var facade = new ESAPIX.Facade.API.PlanSumComponent();
                        XC.Instance.Invoke(() =>
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
                    _client.PlanSumComponents = value;
            }
        }

        public ESAPIX.Facade.API.StructureSet StructureSet
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("StructureSet"))
                    {
                        return _client.StructureSet;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.StructureSet);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.StructureSet) != (null))
                        {
                            return new ESAPIX.Facade.API.StructureSet(_client.StructureSet);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    );
                }
                else
                {
                    return default (ESAPIX.Facade.API.StructureSet);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.StructureSet = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.PlanSetup> PlanSetups
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PlanSetups"))
                    {
                        foreach (var item in _client.PlanSetups)
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
                    XC.Instance.Invoke(() =>
                    {
                        var asEnum = (IEnumerable)_client.PlanSetups;
                        if ((asEnum) != null)
                        {
                            enumerator = asEnum.GetEnumerator();
                        }
                    }

                    );
                    if (enumerator == null)
                    {
                        yield break;
                    }

                    while (XC.Instance.GetValue<bool>(sc => enumerator.MoveNext()))
                    {
                        var facade = new ESAPIX.Facade.API.PlanSetup();
                        XC.Instance.Invoke(() =>
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
                    _client.PlanSetups = value;
            }
        }

        public VMS.TPS.Common.Model.Types.PlanSumOperation GetPlanSumOperation(ESAPIX.Facade.API.PlanSetup planSetupInPlanSum)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetPlanSumOperation(planSetupInPlanSum._client));
                    if (fromClient.Equals(default (VMS.TPS.Common.Model.Types.PlanSumOperation)))
                    {
                        return default (VMS.TPS.Common.Model.Types.PlanSumOperation);
                    }

                    return (VMS.TPS.Common.Model.Types.PlanSumOperation)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (VMS.TPS.Common.Model.Types.PlanSumOperation)(_client.GetPlanSumOperation(planSetupInPlanSum));
            }
        }

        public System.Double GetPlanWeight(ESAPIX.Facade.API.PlanSetup planSetupInPlanSum)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetPlanWeight(planSetupInPlanSum._client));
                    if (fromClient.Equals(default (System.Double)))
                    {
                        return default (System.Double);
                    }

                    return (System.Double)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Double)(_client.GetPlanWeight(planSetupInPlanSum));
            }
        }

        public PlanSum()
        {
            _client = (new ExpandoObject());
        }

        public PlanSum(dynamic client)
        {
            _client = (client);
        }
    }
}