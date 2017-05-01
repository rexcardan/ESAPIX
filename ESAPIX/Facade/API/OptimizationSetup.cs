#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class OptimizationSetup : SerializableObject
    {
        public OptimizationSetup()
        {
            _client = new ExpandoObject();
        }

        public OptimizationSetup(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public IEnumerable<OptimizationObjective> Objectives
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Objectives"))
                        foreach (var item in _client.Objectives) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.Objectives;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new OptimizationObjective();
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
                if (_client is ExpandoObject) _client.Objectives = value;
            }
        }

        public IEnumerable<OptimizationParameter> Parameters
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Parameters"))
                        foreach (var item in _client.Parameters) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.Parameters;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new OptimizationParameter();
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
                if (_client is ExpandoObject) _client.Parameters = value;
            }
        }

        public bool UseJawTracking
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("UseJawTracking")
                        ? _client.UseJawTracking
                        : default(bool);
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.UseJawTracking; });
            }
            set
            {
                if (_client is ExpandoObject) _client.UseJawTracking = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public OptimizationNormalTissueParameter AddAutomaticNormalTissueObjective(double priority)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizationNormalTissueParameter(
                    local._client.AddAutomaticNormalTissueObjective(priority));
            });
            return retVal;
        }

        public OptimizationIMRTBeamParameter AddBeamSpecificParameter(Beam beam, double smoothX, double smoothY,
            bool fixedJaws)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizationIMRTBeamParameter(
                    local._client.AddBeamSpecificParameter(beam._client, smoothX, smoothY, fixedJaws));
            });
            return retVal;
        }

        public OptimizationEUDObjective AddEUDObjective(Structure structure,
            Types.OptimizationObjectiveOperator objectiveOperator, Types.DoseValue dose, double parameterA,
            double priority)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizationEUDObjective(local._client.AddEUDObjective(structure._client,
                    EnumConverter.Convert(objectiveOperator), dose._client, parameterA, priority));
            });
            return retVal;
        }

        public OptimizationMeanDoseObjective AddMeanDoseObjective(Structure structure, Types.DoseValue dose,
            double priority)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizationMeanDoseObjective(
                    local._client.AddMeanDoseObjective(structure._client, dose._client, priority));
            });
            return retVal;
        }

        public OptimizationNormalTissueParameter AddNormalTissueObjective(double priority,
            double distanceFromTargetBorderInMM, double startDosePercentage, double endDosePercentage, double fallOff)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizationNormalTissueParameter(local._client.AddNormalTissueObjective(priority,
                    distanceFromTargetBorderInMM, startDosePercentage, endDosePercentage, fallOff));
            });
            return retVal;
        }

        public OptimizationPointObjective AddPointObjective(Structure structure,
            Types.OptimizationObjectiveOperator objectiveOperator, Types.DoseValue dose, double volume, double priority)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizationPointObjective(local._client.AddPointObjective(structure._client,
                    EnumConverter.Convert(objectiveOperator), dose._client, volume, priority));
            });
            return retVal;
        }

        public void RemoveObjective(OptimizationObjective objective)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.RemoveObjective(objective._client); });
        }

        public void RemoveParameter(OptimizationParameter parameter)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.RemoveParameter(parameter._client); });
        }

        public OptimizationPointCloudParameter AddStructurePointCloudParameter(Structure structure,
            double pointResolutionInMM)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizationPointCloudParameter(
                    local._client.AddStructurePointCloudParameter(structure._client, pointResolutionInMM));
            });
            return retVal;
        }
    }
}