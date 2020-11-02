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
    public class TradeoffExplorationContext
    {
        internal dynamic _client;

        public System.Boolean HasPlanCollection
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("HasPlanCollection"))
                    {
                        return _client.HasPlanCollection;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.HasPlanCollection;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.HasPlanCollection = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.HasPlanCollection = (value));
                }
            }
        }

        public System.Boolean CanLoadSavedPlanCollection
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CanLoadSavedPlanCollection"))
                    {
                        return _client.CanLoadSavedPlanCollection;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.CanLoadSavedPlanCollection;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CanLoadSavedPlanCollection = (value);
                }
                else
                {
                }
            }
        }

        public System.Boolean CanCreatePlanCollection
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CanCreatePlanCollection"))
                    {
                        return _client.CanCreatePlanCollection;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.CanCreatePlanCollection;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CanCreatePlanCollection = (value);
                }
                else
                {
                }
            }
        }

        public System.Boolean CanUsePlanDoseAsIntermediateDose
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CanUsePlanDoseAsIntermediateDose"))
                    {
                        return _client.CanUsePlanDoseAsIntermediateDose;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.CanUsePlanDoseAsIntermediateDose;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CanUsePlanDoseAsIntermediateDose = (value);
                }
                else
                {
                }
            }
        }

        public System.Collections.Generic.IReadOnlyList<ESAPIX.Facade.API.OptimizationObjective> TradeoffObjectiveCandidates
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TradeoffObjectiveCandidates"))
                    {
                        return _client.TradeoffObjectiveCandidates;
                    }
                    else
                    {
                        return default (System.Collections.Generic.IReadOnlyList<ESAPIX.Facade.API.OptimizationObjective>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.TradeoffObjectiveCandidates;
                    }

                    );
                }
                else
                {
                    return default (System.Collections.Generic.IReadOnlyList<ESAPIX.Facade.API.OptimizationObjective>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TradeoffObjectiveCandidates = (value);
                }
                else
                {
                }
            }
        }

        public System.Collections.Generic.IReadOnlyCollection<ESAPIX.Facade.API.TradeoffObjective> TradeoffObjectives
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TradeoffObjectives"))
                    {
                        return _client.TradeoffObjectives;
                    }
                    else
                    {
                        return default (System.Collections.Generic.IReadOnlyCollection<ESAPIX.Facade.API.TradeoffObjective>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.TradeoffObjectives;
                    }

                    );
                }
                else
                {
                    return default (System.Collections.Generic.IReadOnlyCollection<ESAPIX.Facade.API.TradeoffObjective>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TradeoffObjectives = (value);
                }
                else
                {
                }
            }
        }

        public System.Collections.Generic.IReadOnlyList<ESAPIX.Facade.API.Structure> TradeoffStructureCandidates
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TradeoffStructureCandidates"))
                    {
                        return _client.TradeoffStructureCandidates;
                    }
                    else
                    {
                        return default (System.Collections.Generic.IReadOnlyList<ESAPIX.Facade.API.Structure>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.TradeoffStructureCandidates;
                    }

                    );
                }
                else
                {
                    return default (System.Collections.Generic.IReadOnlyList<ESAPIX.Facade.API.Structure>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TradeoffStructureCandidates = (value);
                }
                else
                {
                }
            }
        }

        public System.Collections.Generic.IReadOnlyList<ESAPIX.Facade.API.Structure> TargetStructures
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TargetStructures"))
                    {
                        return _client.TargetStructures;
                    }
                    else
                    {
                        return default (System.Collections.Generic.IReadOnlyList<ESAPIX.Facade.API.Structure>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.TargetStructures;
                    }

                    );
                }
                else
                {
                    return default (System.Collections.Generic.IReadOnlyList<ESAPIX.Facade.API.Structure>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TargetStructures = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Dose CurrentDose
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CurrentDose"))
                    {
                        return _client.CurrentDose;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Dose);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.CurrentDose) != (null))
                        {
                            return new ESAPIX.Facade.API.Dose(_client.CurrentDose);
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
                    return default (ESAPIX.Facade.API.Dose);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CurrentDose = (value);
                }
                else
                {
                }
            }
        }

        public System.Boolean LoadSavedPlanCollection()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.LoadSavedPlanCollection());
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.LoadSavedPlanCollection());
            }
        }

    

        public System.Double GetObjectiveCost(ESAPIX.Facade.API.TradeoffObjective objective)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetObjectiveCost(objective._client));
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
                return (System.Double)(_client.GetObjectiveCost(objective));
            }
        }

        public System.Double GetObjectiveLowerLimit(ESAPIX.Facade.API.TradeoffObjective objective)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetObjectiveLowerLimit(objective._client));
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
                return (System.Double)(_client.GetObjectiveLowerLimit(objective));
            }
        }

        public System.Double GetObjectiveUpperLimit(ESAPIX.Facade.API.TradeoffObjective objective)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetObjectiveUpperLimit(objective._client));
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
                return (System.Double)(_client.GetObjectiveUpperLimit(objective));
            }
        }

        public System.Double GetObjectiveUpperRestrictor(ESAPIX.Facade.API.TradeoffObjective objective)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetObjectiveUpperRestrictor(objective._client));
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
                return (System.Double)(_client.GetObjectiveUpperRestrictor(objective));
            }
        }

        public void SetObjectiveCost(ESAPIX.Facade.API.TradeoffObjective tradeoffObjective, System.Double cost)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.SetObjectiveCost(tradeoffObjective._client, cost);
                }

                );
            }
            else
            {
                _client.SetObjectiveCost(tradeoffObjective, cost);
            }
        }

        public void SetObjectiveUpperRestrictor(ESAPIX.Facade.API.TradeoffObjective tradeoffObjective, System.Double restrictorValue)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.SetObjectiveUpperRestrictor(tradeoffObjective._client, restrictorValue);
                }

                );
            }
            else
            {
                _client.SetObjectiveUpperRestrictor(tradeoffObjective, restrictorValue);
            }
        }

        public void ResetToBalancedPlan()
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.ResetToBalancedPlan();
                }

                );
            }
            else
            {
                _client.ResetToBalancedPlan();
            }
        }

        public ESAPIX.Facade.API.DVHData GetStructureDvh(ESAPIX.Facade.API.Structure structure)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetStructureDvh(structure._client));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.DVHData(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.DVHData)(_client.GetStructureDvh(structure));
            }
        }

        public System.Boolean AddTargetHomogeneityObjective(ESAPIX.Facade.API.Structure targetStructure)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddTargetHomogeneityObjective(targetStructure._client));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.AddTargetHomogeneityObjective(targetStructure));
            }
        }

        public System.Boolean AddTradeoffObjective(ESAPIX.Facade.API.Structure structure)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddTradeoffObjective(structure._client));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.AddTradeoffObjective(structure));
            }
        }

        public System.Boolean AddTradeoffObjective(ESAPIX.Facade.API.OptimizationObjective objective)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddTradeoffObjective(objective._client));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.AddTradeoffObjective(objective));
            }
        }

        public System.Boolean RemoveTradeoffObjective(ESAPIX.Facade.API.TradeoffObjective tradeoffObjective)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.RemoveTradeoffObjective(tradeoffObjective._client));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.RemoveTradeoffObjective(tradeoffObjective));
            }
        }

        public System.Boolean RemoveTargetHomogeneityObjective(ESAPIX.Facade.API.Structure targetStructure)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.RemoveTargetHomogeneityObjective(targetStructure._client));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.RemoveTargetHomogeneityObjective(targetStructure));
            }
        }

        public System.Boolean RemoveTradeoffObjective(ESAPIX.Facade.API.Structure structure)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.RemoveTradeoffObjective(structure._client));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.RemoveTradeoffObjective(structure));
            }
        }

        public void RemovePlanCollection()
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.RemovePlanCollection();
                }

                );
            }
            else
            {
                _client.RemovePlanCollection();
            }
        }

        public void RemoveAllTradeoffObjectives()
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.RemoveAllTradeoffObjectives();
                }

                );
            }
            else
            {
                _client.RemoveAllTradeoffObjectives();
            }
        }

        public void ApplyTradeoffExplorationResult()
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.ApplyTradeoffExplorationResult();
                }

                );
            }
            else
            {
                _client.ApplyTradeoffExplorationResult();
            }
        }

        public System.Boolean CreateDeliverableVmatPlan(System.Boolean useIntermediateDose)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CreateDeliverableVmatPlan(useIntermediateDose));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.CreateDeliverableVmatPlan(useIntermediateDose));
            }
        }

        public TradeoffExplorationContext()
        {
            _client = (new ExpandoObject());
        }

        public TradeoffExplorationContext(dynamic client)
        {
            _client = (client);
        }
    }
}