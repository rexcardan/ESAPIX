using System.Collections.Generic;
using System.Dynamic;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class ExternalPlanSetup : PlanSetup
    {
        public ExternalPlanSetup()
        {
            _client = new ExpandoObject();
        }

        public ExternalPlanSetup(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public EvaluationDose DoseAsEvaluationDose
        {
            get
            {
                if (_client is ExpandoObject) return _client.DoseAsEvaluationDose;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.DoseAsEvaluationDose)) return default(EvaluationDose);
                    return new EvaluationDose(local._client.DoseAsEvaluationDose);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.DoseAsEvaluationDose = value;
            }
        }

        public CalculationResult CalculateDoseWithPresetValues(List<KeyValuePair<string, MetersetValue>> presetValues)
        {
            var conv = new List<KeyValuePair<string, dynamic>>();
            foreach (var val in presetValues)
                conv.Add(new KeyValuePair<string, dynamic>(val.Key, val.Value._client));
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new CalculationResult(local._client.CalculateDoseWithPresetValues(conv));
            });
            return retVal;
        }

        public CalculationResult CalculateDose()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new CalculationResult(local._client.CalculateDose());
            });
            return retVal;
        }

        public CalculationResult CalculateLeafMotionsAndDose()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new CalculationResult(local._client.CalculateLeafMotionsAndDose());
            });
            return retVal;
        }

        public CalculationResult CalculateLeafMotions()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new CalculationResult(local._client.CalculateLeafMotions());
            });
            return retVal;
        }

        public CalculationResult CalculateLeafMotions(LMCVOptions options)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new CalculationResult(local._client.CalculateLeafMotions(options._client));
            });
            return retVal;
        }

        public CalculationResult CalculateLeafMotions(SmartLMCOptions options)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new CalculationResult(local._client.CalculateLeafMotions(options._client));
            });
            return retVal;
        }

        public CalculationResult CalculateLeafMotions(LMCMSSOptions options)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new CalculationResult(local._client.CalculateLeafMotions(options._client));
            });
            return retVal;
        }

        public IEnumerable<string> GetModelsForCalculationType(CalculationType calculationType)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.GetModelsForCalculationType(calculationType);
            });
            return retVal;
        }

        public OptimizerResult Optimize(int maxIterations)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizerResult(local._client.Optimize(maxIterations));
            });
            return retVal;
        }

        public OptimizerResult Optimize(int maxIterations, OptimizationOption optimizationOption)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizerResult(local._client.Optimize(maxIterations, optimizationOption));
            });
            return retVal;
        }

        public OptimizerResult Optimize(int maxIterations, OptimizationOption optimizationOption, string mlcId)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizerResult(local._client.Optimize(maxIterations, optimizationOption, mlcId));
            });
            return retVal;
        }

        public OptimizerResult Optimize()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizerResult(local._client.Optimize());
            });
            return retVal;
        }

        public OptimizerResult Optimize(OptimizationOptionsIMRT options)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizerResult(local._client.Optimize(options._client));
            });
            return retVal;
        }

        public OptimizerResult OptimizeVMAT(string mlcId)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizerResult(local._client.OptimizeVMAT(mlcId));
            });
            return retVal;
        }

        public OptimizerResult OptimizeVMAT()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizerResult(local._client.OptimizeVMAT());
            });
            return retVal;
        }

        public OptimizerResult OptimizeVMAT(OptimizationOptionsVMAT options)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizerResult(local._client.OptimizeVMAT(options._client));
            });
            return retVal;
        }

        public CalculationResult CalculateDVHEstimates(string modelId, Dictionary<string, DoseValue> targetDoseLevels,
            Dictionary<string, string> structureMatches)
        {
            var conv = new Dictionary<string, dynamic>();
            foreach (var entry in targetDoseLevels)
                conv.Add(entry.Key, entry.Value._client);
            var local = this;
            return X.Instance.CurrentContext.GetValue(sc =>
            {
                return new CalculationResult(_client.CalculateDVHEstimates(modelId, conv, structureMatches));
            });
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public Beam AddArcBeam(ExternalBeamMachineParameters machineParameters, VRect<double> jawPositions,
            double collimatorAngle, double gantryAngle, double gantryStop, GantryDirection gantryDirection,
            double patientSupportAngle, VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Beam(local._client.AddArcBeam(machineParameters._client, jawPositions._client,
                    collimatorAngle, gantryAngle, gantryStop, gantryDirection, patientSupportAngle,
                    isocenter._client));
            });
            return retVal;
        }

        public Beam AddConformalArcBeam(ExternalBeamMachineParameters machineParameters, double collimatorAngle,
            int controlPointCount, double gantryAngle, double gantryStop, GantryDirection gantryDirection,
            double patientSupportAngle, VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Beam(local._client.AddConformalArcBeam(machineParameters._client, collimatorAngle,
                    controlPointCount, gantryAngle, gantryStop, gantryDirection, patientSupportAngle,
                    isocenter._client));
            });
            return retVal;
        }

        public Beam AddMLCArcBeam(ExternalBeamMachineParameters machineParameters, float[,] leafPositions,
            VRect<double> jawPositions, double collimatorAngle, double gantryAngle, double gantryStop,
            GantryDirection gantryDirection, double patientSupportAngle, VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Beam(local._client.AddMLCArcBeam(machineParameters._client, leafPositions,
                    jawPositions._client, collimatorAngle, gantryAngle, gantryStop, gantryDirection,
                    patientSupportAngle, isocenter._client));
            });
            return retVal;
        }

        public Beam AddMLCBeam(ExternalBeamMachineParameters machineParameters, float[,] leafPositions,
            VRect<double> jawPositions, double collimatorAngle, double gantryAngle, double patientSupportAngle,
            VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Beam(local._client.AddMLCBeam(machineParameters._client, leafPositions,
                    jawPositions._client, collimatorAngle, gantryAngle, patientSupportAngle, isocenter._client));
            });
            return retVal;
        }

        public Beam AddMultipleStaticSegmentBeam(ExternalBeamMachineParameters machineParameters,
            IEnumerable<double> metersetWeights, double collimatorAngle, double gantryAngle, double patientSupportAngle,
            VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Beam(local._client.AddMultipleStaticSegmentBeam(machineParameters._client,
                    metersetWeights, collimatorAngle, gantryAngle, patientSupportAngle, isocenter._client));
            });
            return retVal;
        }

        public Beam AddSlidingWindowBeam(ExternalBeamMachineParameters machineParameters,
            IEnumerable<double> metersetWeights, double collimatorAngle, double gantryAngle, double patientSupportAngle,
            VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Beam(local._client.AddSlidingWindowBeam(machineParameters._client, metersetWeights,
                    collimatorAngle, gantryAngle, patientSupportAngle, isocenter._client));
            });
            return retVal;
        }

        public Beam AddStaticBeam(ExternalBeamMachineParameters machineParameters, VRect<double> jawPositions,
            double collimatorAngle, double gantryAngle, double patientSupportAngle, VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Beam(local._client.AddStaticBeam(machineParameters._client, jawPositions._client,
                    collimatorAngle, gantryAngle, patientSupportAngle, isocenter._client));
            });
            return retVal;
        }

        public Beam AddVMATBeam(ExternalBeamMachineParameters machineParameters, IEnumerable<double> metersetWeights,
            double collimatorAngle, double gantryAngle, double gantryStop, GantryDirection gantryDirection,
            double patientSupportAngle, VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Beam(local._client.AddVMATBeam(machineParameters._client, metersetWeights,
                    collimatorAngle, gantryAngle, gantryStop, gantryDirection, patientSupportAngle,
                    isocenter._client));
            });
            return retVal;
        }

        public EvaluationDose CreateEvaluationDose()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new EvaluationDose(local._client.CreateEvaluationDose());
            });
            return retVal;
        }

        public void RemoveBeam(Beam beam)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.RemoveBeam(beam._client); });
        }
    }
}