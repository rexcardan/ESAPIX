using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationSetup : ESAPIX.Facade.API.SerializableObject
    {
        public OptimizationSetup() { }
        public OptimizationSetup(dynamic client) { _client = client; }
        public IEnumerable<ESAPIX.Facade.API.OptimizationObjective> Objectives
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.OptimizationObjective>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.Objectives).Select(s => new ESAPIX.Facade.API.OptimizationObjective(s));
                });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.OptimizationParameter> Parameters
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.OptimizationParameter>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.Parameters).Select(s => new ESAPIX.Facade.API.OptimizationParameter(s));
                });
            }
        }
        public System.Boolean UseJawTracking
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.UseJawTracking; });
            }
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
        public ESAPIX.Facade.API.OptimizationNormalTissueParameter AddAutomaticNormalTissueObjective(System.Double priority)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.OptimizationNormalTissueParameter(local._client.AddAutomaticNormalTissueObjective(priority)); });
            return retVal;

        }
        public ESAPIX.Facade.API.OptimizationIMRTBeamParameter AddBeamSpecificParameter(ESAPIX.Facade.API.Beam beam, System.Double smoothX, System.Double smoothY, System.Boolean fixedJaws)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.OptimizationIMRTBeamParameter(local._client.AddBeamSpecificParameter(beam._client, smoothX, smoothY, fixedJaws)); });
            return retVal;

        }
        public ESAPIX.Facade.API.OptimizationEUDObjective AddEUDObjective(ESAPIX.Facade.API.Structure structure, ESAPIX.Facade.Types.OptimizationObjectiveOperator objectiveOperator, ESAPIX.Facade.Types.DoseValue dose, System.Double parameterA, System.Double priority)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.OptimizationEUDObjective(local._client.AddEUDObjective(structure._client, (ESAPIX.Facade.Types.OptimizationObjectiveOperator)objectiveOperator, dose._client, parameterA, priority)); });
            return retVal;

        }
        public ESAPIX.Facade.API.OptimizationMeanDoseObjective AddMeanDoseObjective(ESAPIX.Facade.API.Structure structure, ESAPIX.Facade.Types.DoseValue dose, System.Double priority)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.OptimizationMeanDoseObjective(local._client.AddMeanDoseObjective(structure._client, dose._client, priority)); });
            return retVal;

        }
        public ESAPIX.Facade.API.OptimizationNormalTissueParameter AddNormalTissueObjective(System.Double priority, System.Double distanceFromTargetBorderInMM, System.Double startDosePercentage, System.Double endDosePercentage, System.Double fallOff)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.OptimizationNormalTissueParameter(local._client.AddNormalTissueObjective(priority, distanceFromTargetBorderInMM, startDosePercentage, endDosePercentage, fallOff)); });
            return retVal;

        }
        public ESAPIX.Facade.API.OptimizationPointObjective AddPointObjective(ESAPIX.Facade.API.Structure structure, ESAPIX.Facade.Types.OptimizationObjectiveOperator objectiveOperator, ESAPIX.Facade.Types.DoseValue dose, System.Double volume, System.Double priority)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.OptimizationPointObjective(local._client.AddPointObjective(structure._client, (ESAPIX.Facade.Types.OptimizationObjectiveOperator)objectiveOperator, dose._client, volume, priority)); });
            return retVal;

        }
        public void RemoveObjective(ESAPIX.Facade.API.OptimizationObjective objective)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.RemoveObjective(objective._client);
            });

        }
        public void RemoveParameter(ESAPIX.Facade.API.OptimizationParameter parameter)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.RemoveParameter(parameter._client);
            });

        }
        public ESAPIX.Facade.API.OptimizationPointCloudParameter AddStructurePointCloudParameter(ESAPIX.Facade.API.Structure structure, System.Double pointResolutionInMM)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.OptimizationPointCloudParameter(local._client.AddStructurePointCloudParameter(structure._client, pointResolutionInMM)); });
            return retVal;

        }
    }
}