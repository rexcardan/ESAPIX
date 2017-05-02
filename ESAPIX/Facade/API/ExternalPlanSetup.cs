#region

using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using X = ESAPIX.Facade.XContext;

#endregion


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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public EvaluationDose DoseAsEvaluationDose
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DoseAsEvaluationDose")
                        ? _client.DoseAsEvaluationDose
                        : default(EvaluationDose);
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
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new CalculationResult(local._client.CalculateDoseWithPresetValues(presetValues));
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
                return new CalculationResult(local._client.CalculateLeafMotions(options));
            });
            return retVal;
        }

        public CalculationResult CalculateLeafMotions(SmartLMCOptions options)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new CalculationResult(local._client.CalculateLeafMotions(options));
            });
            return retVal;
        }

        public CalculationResult CalculateLeafMotions(LMCMSSOptions options)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new CalculationResult(local._client.CalculateLeafMotions(options));
            });
            return retVal;
        }

        public IEnumerable<string> GetModelsForCalculationType(CalculationType calculationType)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.GetModelsForCalculationType(EnumConverter.Convert(calculationType));
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
                return new OptimizerResult(
                    local._client.Optimize(maxIterations, EnumConverter.Convert(optimizationOption)));
            });
            return retVal;
        }

        public OptimizerResult Optimize(int maxIterations, OptimizationOption optimizationOption, string mlcId)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new OptimizerResult(
                    local._client.Optimize(maxIterations, EnumConverter.Convert(optimizationOption), mlcId));
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
                return new OptimizerResult(local._client.Optimize(options));
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
                return new OptimizerResult(local._client.OptimizeVMAT(options));
            });
            return retVal;
        }

        public CalculationResult CalculateDVHEstimates(string modelId, Dictionary<string, DoseValue> targetDoseLevels,
            Dictionary<string, string> structureMatches)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new CalculationResult(
                    local._client.CalculateDVHEstimates(modelId, targetDoseLevels, structureMatches));
            });
            return retVal;
        }

        public void WriteXml(System.Xml.XmlWriter writer)
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
                return new Beam(local._client.AddArcBeam(machineParameters, jawPositions, collimatorAngle,
                    gantryAngle, gantryStop, EnumConverter.Convert(gantryDirection), patientSupportAngle,
                    isocenter));
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
                return new Beam(local._client.AddConformalArcBeam(machineParameters, collimatorAngle,
                    controlPointCount, gantryAngle, gantryStop, EnumConverter.Convert(gantryDirection),
                    patientSupportAngle, isocenter));
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
                return new Beam(local._client.AddMLCArcBeam(machineParameters, leafPositions, jawPositions,
                    collimatorAngle, gantryAngle, gantryStop, EnumConverter.Convert(gantryDirection),
                    patientSupportAngle, isocenter));
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
                return new Beam(local._client.AddMLCBeam(machineParameters, leafPositions, jawPositions,
                    collimatorAngle, gantryAngle, patientSupportAngle, isocenter));
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
                return new Beam(local._client.AddMultipleStaticSegmentBeam(machineParameters, metersetWeights,
                    collimatorAngle, gantryAngle, patientSupportAngle, isocenter));
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
                return new Beam(local._client.AddSlidingWindowBeam(machineParameters, metersetWeights,
                    collimatorAngle, gantryAngle, patientSupportAngle, isocenter));
            });
            return retVal;
        }

        public Beam AddStaticBeam(ExternalBeamMachineParameters machineParameters, VRect<double> jawPositions,
            double collimatorAngle, double gantryAngle, double patientSupportAngle, VVector isocenter)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Beam(local._client.AddStaticBeam(machineParameters, jawPositions, collimatorAngle,
                    gantryAngle, patientSupportAngle, isocenter));
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
                return new Beam(local._client.AddVMATBeam(machineParameters, metersetWeights, collimatorAngle,
                    gantryAngle, gantryStop, EnumConverter.Convert(gantryDirection), patientSupportAngle,
                    isocenter));
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