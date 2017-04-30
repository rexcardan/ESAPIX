using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

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

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public IEnumerable<OptimizationObjective> Objectives
        {
            get
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

        public IEnumerable<OptimizationParameter> Parameters
        {
            get
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

        public bool UseJawTracking
        {
            get
            {
                if (_client is ExpandoObject) return _client.UseJawTracking;
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.UseJawTracking; });
            }
            set
            {
                if (_client is ExpandoObject) _client.UseJawTracking = value;
            }
        }

        public void WriteXml(XmlWriter writer)
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
            OptimizationObjectiveOperator objectiveOperator, DoseValue dose, double parameterA, double priority)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizationEUDObjective(local._client.AddEUDObjective(structure._client,
                    objectiveOperator, dose._client, parameterA, priority));
            });
            return retVal;
        }

        public OptimizationMeanDoseObjective AddMeanDoseObjective(Structure structure, DoseValue dose, double priority)
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
            OptimizationObjectiveOperator objectiveOperator, DoseValue dose, double volume, double priority)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizationPointObjective(local._client.AddPointObjective(structure._client,
                    objectiveOperator, dose._client, volume, priority));
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