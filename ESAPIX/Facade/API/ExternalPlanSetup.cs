using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class ExternalPlanSetup : ESAPIX.Facade.API.PlanSetup
    {
        public ExternalPlanSetup() { }
        public ExternalPlanSetup(dynamic client) { _client = client; }
        public ESAPIX.Facade.API.EvaluationDose DoseAsEvaluationDose
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.EvaluationDose(local._client.DoseAsEvaluationDose);
            }
        }
        public ESAPIX.Facade.API.CalculationResult CalculateDoseWithPresetValues(System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<System.String, ESAPIX.Facade.Types.MetersetValue>> presetValues)
        {
            var conv = new List<KeyValuePair<string, dynamic>>();
            foreach (var val in presetValues)
            {
                conv.Add(new KeyValuePair<string, dynamic>(val.Key, val.Value._client));
            }
            var local = this; var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.CalculationResult(local._client.CalculateDoseWithPresetValues(conv)); });
            return retVal;
        }
        public ESAPIX.Facade.API.CalculationResult CalculateDose()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.CalculationResult(local._client.CalculateDose()); });
            return retVal;

        }
        public ESAPIX.Facade.API.CalculationResult CalculateLeafMotionsAndDose()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.CalculationResult(local._client.CalculateLeafMotionsAndDose()); });
            return retVal;

        }
        public ESAPIX.Facade.API.CalculationResult CalculateLeafMotions()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.CalculationResult(local._client.CalculateLeafMotions()); });
            return retVal;

        }
        public ESAPIX.Facade.API.CalculationResult CalculateLeafMotions(ESAPIX.Facade.Types.LMCVOptions options)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.CalculationResult(local._client.CalculateLeafMotions(options._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.CalculationResult CalculateLeafMotions(ESAPIX.Facade.Types.SmartLMCOptions options)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.CalculationResult(local._client.CalculateLeafMotions(options._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.CalculationResult CalculateLeafMotions(ESAPIX.Facade.Types.LMCMSSOptions options)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.CalculationResult(local._client.CalculateLeafMotions(options._client)); });
            return retVal;

        }
        public System.Collections.Generic.IEnumerable<System.String> GetModelsForCalculationType(ESAPIX.Facade.Types.CalculationType calculationType)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetModelsForCalculationType((ESAPIX.Facade.Types.CalculationType)calculationType); });
            return retVal;

        }
        public ESAPIX.Facade.API.OptimizerResult Optimize(System.Int32 maxIterations)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.OptimizerResult(local._client.Optimize(maxIterations)); });
            return retVal;

        }
        public ESAPIX.Facade.API.OptimizerResult Optimize(System.Int32 maxIterations, ESAPIX.Facade.Types.OptimizationOption optimizationOption)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.OptimizerResult(local._client.Optimize(maxIterations, (ESAPIX.Facade.Types.OptimizationOption)optimizationOption)); });
            return retVal;

        }
        public ESAPIX.Facade.API.OptimizerResult Optimize(System.Int32 maxIterations, ESAPIX.Facade.Types.OptimizationOption optimizationOption, System.String mlcId)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.OptimizerResult(local._client.Optimize(maxIterations, (ESAPIX.Facade.Types.OptimizationOption)optimizationOption, mlcId)); });
            return retVal;

        }
        public ESAPIX.Facade.API.OptimizerResult Optimize()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.OptimizerResult(local._client.Optimize()); });
            return retVal;

        }
        public ESAPIX.Facade.API.OptimizerResult Optimize(ESAPIX.Facade.Types.OptimizationOptionsIMRT options)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.OptimizerResult(local._client.Optimize(options._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.OptimizerResult OptimizeVMAT(System.String mlcId)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.OptimizerResult(local._client.OptimizeVMAT(mlcId)); });
            return retVal;

        }
        public ESAPIX.Facade.API.OptimizerResult OptimizeVMAT()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.OptimizerResult(local._client.OptimizeVMAT()); });
            return retVal;

        }
        public ESAPIX.Facade.API.OptimizerResult OptimizeVMAT(ESAPIX.Facade.Types.OptimizationOptionsVMAT options)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.OptimizerResult(local._client.OptimizeVMAT(options._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.CalculationResult CalculateDVHEstimates(System.String modelId, System.Collections.Generic.Dictionary<System.String, ESAPIX.Facade.Types.DoseValue> targetDoseLevels, System.Collections.Generic.Dictionary<System.String, System.String> structureMatches)
        {
            var conv = new Dictionary<String, dynamic>();
            foreach (var entry in targetDoseLevels)
            {
                conv.Add(entry.Key, entry.Value._client);
            }
            var local = this;
            return X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.CalculationResult(_client.CalculateDVHEstimates(modelId, conv, structureMatches)); });
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
        public ESAPIX.Facade.API.Beam AddArcBeam(ESAPIX.Facade.Types.ExternalBeamMachineParameters machineParameters, ESAPIX.Facade.Types.VRect<System.Double> jawPositions, System.Double collimatorAngle, System.Double gantryAngle, System.Double gantryStop, ESAPIX.Facade.Types.GantryDirection gantryDirection, System.Double patientSupportAngle, ESAPIX.Facade.Types.VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.Beam(local._client.AddArcBeam(machineParameters._client, jawPositions._client, collimatorAngle, gantryAngle, gantryStop, (ESAPIX.Facade.Types.GantryDirection)gantryDirection, patientSupportAngle, isocenter._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.Beam AddConformalArcBeam(ESAPIX.Facade.Types.ExternalBeamMachineParameters machineParameters, System.Double collimatorAngle, System.Int32 controlPointCount, System.Double gantryAngle, System.Double gantryStop, ESAPIX.Facade.Types.GantryDirection gantryDirection, System.Double patientSupportAngle, ESAPIX.Facade.Types.VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.Beam(local._client.AddConformalArcBeam(machineParameters._client, collimatorAngle, controlPointCount, gantryAngle, gantryStop, (ESAPIX.Facade.Types.GantryDirection)gantryDirection, patientSupportAngle, isocenter._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.Beam AddMLCArcBeam(ESAPIX.Facade.Types.ExternalBeamMachineParameters machineParameters, System.Single[,] leafPositions, ESAPIX.Facade.Types.VRect<System.Double> jawPositions, System.Double collimatorAngle, System.Double gantryAngle, System.Double gantryStop, ESAPIX.Facade.Types.GantryDirection gantryDirection, System.Double patientSupportAngle, ESAPIX.Facade.Types.VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.Beam(local._client.AddMLCArcBeam(machineParameters._client, leafPositions, jawPositions._client, collimatorAngle, gantryAngle, gantryStop, (ESAPIX.Facade.Types.GantryDirection)gantryDirection, patientSupportAngle, isocenter._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.Beam AddMLCBeam(ESAPIX.Facade.Types.ExternalBeamMachineParameters machineParameters, System.Single[,] leafPositions, ESAPIX.Facade.Types.VRect<System.Double> jawPositions, System.Double collimatorAngle, System.Double gantryAngle, System.Double patientSupportAngle, ESAPIX.Facade.Types.VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.Beam(local._client.AddMLCBeam(machineParameters._client, leafPositions, jawPositions._client, collimatorAngle, gantryAngle, patientSupportAngle, isocenter._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.Beam AddMultipleStaticSegmentBeam(ESAPIX.Facade.Types.ExternalBeamMachineParameters machineParameters, System.Collections.Generic.IEnumerable<System.Double> metersetWeights, System.Double collimatorAngle, System.Double gantryAngle, System.Double patientSupportAngle, ESAPIX.Facade.Types.VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.Beam(local._client.AddMultipleStaticSegmentBeam(machineParameters._client, metersetWeights, collimatorAngle, gantryAngle, patientSupportAngle, isocenter._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.Beam AddSlidingWindowBeam(ESAPIX.Facade.Types.ExternalBeamMachineParameters machineParameters, System.Collections.Generic.IEnumerable<System.Double> metersetWeights, System.Double collimatorAngle, System.Double gantryAngle, System.Double patientSupportAngle, ESAPIX.Facade.Types.VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.Beam(local._client.AddSlidingWindowBeam(machineParameters._client, metersetWeights, collimatorAngle, gantryAngle, patientSupportAngle, isocenter._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.Beam AddStaticBeam(ESAPIX.Facade.Types.ExternalBeamMachineParameters machineParameters, ESAPIX.Facade.Types.VRect<System.Double> jawPositions, System.Double collimatorAngle, System.Double gantryAngle, System.Double patientSupportAngle, ESAPIX.Facade.Types.VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.Beam(local._client.AddStaticBeam(machineParameters._client, jawPositions._client, collimatorAngle, gantryAngle, patientSupportAngle, isocenter._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.Beam AddVMATBeam(ESAPIX.Facade.Types.ExternalBeamMachineParameters machineParameters, System.Collections.Generic.IEnumerable<System.Double> metersetWeights, System.Double collimatorAngle, System.Double gantryAngle, System.Double gantryStop, ESAPIX.Facade.Types.GantryDirection gantryDirection, System.Double patientSupportAngle, ESAPIX.Facade.Types.VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.Beam(local._client.AddVMATBeam(machineParameters._client, metersetWeights, collimatorAngle, gantryAngle, gantryStop, (ESAPIX.Facade.Types.GantryDirection)gantryDirection, patientSupportAngle, isocenter._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.EvaluationDose CreateEvaluationDose()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.EvaluationDose(local._client.CreateEvaluationDose()); });
            return retVal;

        }
        public void RemoveBeam(ESAPIX.Facade.API.Beam beam)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.RemoveBeam(beam._client);
            });

        }
    }
}