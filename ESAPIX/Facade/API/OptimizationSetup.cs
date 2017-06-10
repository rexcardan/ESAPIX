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
    public class OptimizationSetup : SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public OptimizationSetup()
        {
            _client = new ExpandoObject();
        }

        public OptimizationSetup(dynamic client)
        {
            _client = client;
        }

        public IEnumerable<OptimizationObjective> Objectives
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Objectives"))
                        foreach (var item in _client.Objectives)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Objectives;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new OptimizationObjective();
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
                    _client.Objectives = value;
            }
        }

        public IEnumerable<OptimizationParameter> Parameters
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Parameters"))
                        foreach (var item in _client.Parameters)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Parameters;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new OptimizationParameter();
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
                    _client.Parameters = value;
            }
        }

        public bool UseJawTracking
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("UseJawTracking"))
                        return _client.UseJawTracking;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.UseJawTracking; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.UseJawTracking = value;
            }
        }

        public OptimizationNormalTissueParameter AddAutomaticNormalTissueObjective(double priority)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new OptimizationNormalTissueParameter(
                            _client.AddAutomaticNormalTissueObjective(priority));
                    }
                );
                return vmsResult;
            }
            return _client.AddAutomaticNormalTissueObjective(priority);
        }

        public OptimizationIMRTBeamParameter AddBeamSpecificParameter(Beam beam, double smoothX, double smoothY,
            bool fixedJaws)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new OptimizationIMRTBeamParameter(_client.AddBeamSpecificParameter(beam._client, smoothX,
                            smoothY, fixedJaws));
                    }
                );
                return vmsResult;
            }
            return _client.AddBeamSpecificParameter(beam, smoothX, smoothY, fixedJaws);
        }

        public OptimizationEUDObjective AddEUDObjective(Structure structure,
            OptimizationObjectiveOperator objectiveOperator, DoseValue dose, double parameterA, double priority)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new OptimizationEUDObjective(_client.AddEUDObjective(structure._client,
                            objectiveOperator, dose, parameterA, priority));
                    }
                );
                return vmsResult;
            }
            return _client.AddEUDObjective(structure, objectiveOperator, dose, parameterA, priority);
        }

        public OptimizationMeanDoseObjective AddMeanDoseObjective(Structure structure, DoseValue dose, double priority)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new OptimizationMeanDoseObjective(
                            _client.AddMeanDoseObjective(structure._client, dose, priority));
                    }
                );
                return vmsResult;
            }
            return _client.AddMeanDoseObjective(structure, dose, priority);
        }

        public OptimizationNormalTissueParameter AddNormalTissueObjective(double priority,
            double distanceFromTargetBorderInMM, double startDosePercentage, double endDosePercentage, double fallOff)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new OptimizationNormalTissueParameter(_client.AddNormalTissueObjective(priority,
                            distanceFromTargetBorderInMM, startDosePercentage, endDosePercentage, fallOff));
                    }
                );
                return vmsResult;
            }
            return _client.AddNormalTissueObjective(priority, distanceFromTargetBorderInMM, startDosePercentage,
                endDosePercentage, fallOff);
        }

        public OptimizationPointObjective AddPointObjective(Structure structure,
            OptimizationObjectiveOperator objectiveOperator, DoseValue dose, double volume, double priority)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new OptimizationPointObjective(_client.AddPointObjective(structure._client,
                            objectiveOperator, dose, volume, priority));
                    }
                );
                return vmsResult;
            }
            return _client.AddPointObjective(structure, objectiveOperator, dose, volume, priority);
        }

        public void RemoveObjective(OptimizationObjective objective)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.RemoveObjective(objective._client); }
                );
            else
                _client.RemoveObjective(objective);
        }

        public void RemoveParameter(OptimizationParameter parameter)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.RemoveParameter(parameter._client); }
                );
            else
                _client.RemoveParameter(parameter);
        }

        public OptimizationPointCloudParameter AddStructurePointCloudParameter(Structure structure,
            double pointResolutionInMM)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new OptimizationPointCloudParameter(
                            _client.AddStructurePointCloudParameter(structure._client, pointResolutionInMM));
                    }
                );
                return vmsResult;
            }
            return _client.AddStructurePointCloudParameter(structure, pointResolutionInMM);
        }
    }
}