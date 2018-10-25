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
    public class OptimizationSetup : ESAPIX.Facade.API.SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.Boolean UseJawTracking
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("UseJawTracking"))
                    {
                        return _client.UseJawTracking;
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
                        return _client.UseJawTracking;
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
                    _client.UseJawTracking = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.UseJawTracking = (value));
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.OptimizationObjective> Objectives
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Objectives"))
                    {
                        foreach (var item in _client.Objectives)
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
                        var asEnum = (IEnumerable)_client.Objectives;
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
                        var facade = new ESAPIX.Facade.API.OptimizationObjective();
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
                    _client.Objectives = value;
            }
        }

        public IEnumerable<ESAPIX.Facade.API.OptimizationParameter> Parameters
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Parameters"))
                    {
                        foreach (var item in _client.Parameters)
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
                        var asEnum = (IEnumerable)_client.Parameters;
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
                        var facade = new ESAPIX.Facade.API.OptimizationParameter();
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
                    _client.Parameters = value;
            }
        }

        public ESAPIX.Facade.API.OptimizationPointCloudParameter AddStructurePointCloudParameter(ESAPIX.Facade.API.Structure structure, System.Double pointResolutionInMM)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddStructurePointCloudParameter(structure._client, pointResolutionInMM));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.OptimizationPointCloudParameter(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.OptimizationPointCloudParameter)(_client.AddStructurePointCloudParameter(structure, pointResolutionInMM));
            }
        }

        public ESAPIX.Facade.API.OptimizationNormalTissueParameter AddAutomaticNormalTissueObjective(System.Double priority)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddAutomaticNormalTissueObjective(priority));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.OptimizationNormalTissueParameter(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.OptimizationNormalTissueParameter)(_client.AddAutomaticNormalTissueObjective(priority));
            }
        }

        public ESAPIX.Facade.API.OptimizationIMRTBeamParameter AddBeamSpecificParameter(ESAPIX.Facade.API.Beam beam, System.Double smoothX, System.Double smoothY, System.Boolean fixedJaws)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddBeamSpecificParameter(beam._client, smoothX, smoothY, fixedJaws));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.OptimizationIMRTBeamParameter(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.OptimizationIMRTBeamParameter)(_client.AddBeamSpecificParameter(beam, smoothX, smoothY, fixedJaws));
            }
        }

        public ESAPIX.Facade.API.OptimizationEUDObjective AddEUDObjective(ESAPIX.Facade.API.Structure structure, VMS.TPS.Common.Model.Types.OptimizationObjectiveOperator objectiveOperator, VMS.TPS.Common.Model.Types.DoseValue dose, System.Double parameterA, System.Double priority)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddEUDObjective(structure._client, objectiveOperator, dose, parameterA, priority));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.OptimizationEUDObjective(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.OptimizationEUDObjective)(_client.AddEUDObjective(structure, objectiveOperator, dose, parameterA, priority));
            }
        }

        public ESAPIX.Facade.API.OptimizationMeanDoseObjective AddMeanDoseObjective(ESAPIX.Facade.API.Structure structure, VMS.TPS.Common.Model.Types.DoseValue dose, System.Double priority)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddMeanDoseObjective(structure._client, dose, priority));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.OptimizationMeanDoseObjective(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.OptimizationMeanDoseObjective)(_client.AddMeanDoseObjective(structure, dose, priority));
            }
        }

        public ESAPIX.Facade.API.OptimizationNormalTissueParameter AddNormalTissueObjective(System.Double priority, System.Double distanceFromTargetBorderInMM, System.Double startDosePercentage, System.Double endDosePercentage, System.Double fallOff)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddNormalTissueObjective(priority, distanceFromTargetBorderInMM, startDosePercentage, endDosePercentage, fallOff));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.OptimizationNormalTissueParameter(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.OptimizationNormalTissueParameter)(_client.AddNormalTissueObjective(priority, distanceFromTargetBorderInMM, startDosePercentage, endDosePercentage, fallOff));
            }
        }

        public ESAPIX.Facade.API.OptimizationPointObjective AddPointObjective(ESAPIX.Facade.API.Structure structure, VMS.TPS.Common.Model.Types.OptimizationObjectiveOperator objectiveOperator, VMS.TPS.Common.Model.Types.DoseValue dose, System.Double volume, System.Double priority)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddPointObjective(structure._client, objectiveOperator, dose, volume, priority));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.OptimizationPointObjective(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.OptimizationPointObjective)(_client.AddPointObjective(structure, objectiveOperator, dose, volume, priority));
            }
        }

        public void RemoveObjective(ESAPIX.Facade.API.OptimizationObjective objective)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.RemoveObjective(objective._client);
                }

                );
            }
            else
            {
                _client.RemoveObjective(objective);
            }
        }

        public void RemoveParameter(ESAPIX.Facade.API.OptimizationParameter parameter)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.RemoveParameter(parameter._client);
                }

                );
            }
            else
            {
                _client.RemoveParameter(parameter);
            }
        }

        public OptimizationSetup()
        {
            _client = (new ExpandoObject());
        }

        public OptimizationSetup(dynamic client)
        {
            _client = (client);
        }
    }
}