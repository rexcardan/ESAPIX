#region

using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class ExternalPlanSetup : PlanSetup, System.Xml.Serialization.IXmlSerializable
    {
        public ExternalPlanSetup()
        {
            _client = new ExpandoObject();
        }

        public ExternalPlanSetup(dynamic client)
        {
            _client = client;
        }

        public EvaluationDose DoseAsEvaluationDose
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("DoseAsEvaluationDose"))
                        return _client.DoseAsEvaluationDose;
                    else
                        return default(EvaluationDose);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.DoseAsEvaluationDose != null)
                                return new EvaluationDose(_client.DoseAsEvaluationDose);
                            return null;
                        }
                    );
                return default(EvaluationDose);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.DoseAsEvaluationDose = value;
            }
        }

        public CalculationResult CalculateDoseWithPresetValues(List<KeyValuePair<string, MetersetValue>> presetValues)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new CalculationResult(_client.CalculateDoseWithPresetValues(presetValues));
                    }
                );
                return vmsResult;
            }
            return _client.CalculateDoseWithPresetValues(presetValues);
        }

        public CalculationResult CalculateDose()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new CalculationResult(_client.CalculateDose()); }
                );
                return vmsResult;
            }
            return _client.CalculateDose();
        }

        public CalculationResult CalculateLeafMotionsAndDose()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new CalculationResult(_client.CalculateLeafMotionsAndDose());
                    }
                );
                return vmsResult;
            }
            return _client.CalculateLeafMotionsAndDose();
        }

        public CalculationResult CalculateLeafMotions()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new CalculationResult(_client.CalculateLeafMotions());
                    }
                );
                return vmsResult;
            }
            return _client.CalculateLeafMotions();
        }

        public CalculationResult CalculateLeafMotions(LMCVOptions options)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new CalculationResult(_client.CalculateLeafMotions(options));
                    }
                );
                return vmsResult;
            }
            return _client.CalculateLeafMotions(options);
        }

        public CalculationResult CalculateLeafMotions(SmartLMCOptions options)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new CalculationResult(_client.CalculateLeafMotions(options));
                    }
                );
                return vmsResult;
            }
            return _client.CalculateLeafMotions(options);
        }

        public CalculationResult CalculateLeafMotions(LMCMSSOptions options)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new CalculationResult(_client.CalculateLeafMotions(options));
                    }
                );
                return vmsResult;
            }
            return _client.CalculateLeafMotions(options);
        }

        public IEnumerable<string> GetModelsForCalculationType(CalculationType calculationType)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.GetModelsForCalculationType(calculationType);
                    }
                );
                return vmsResult;
            }
            return (IEnumerable<string>) _client.GetModelsForCalculationType(calculationType);
        }

        public OptimizerResult Optimize(int maxIterations)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new OptimizerResult(_client.Optimize(maxIterations));
                    }
                );
                return vmsResult;
            }
            return _client.Optimize(maxIterations);
        }

        public OptimizerResult Optimize(int maxIterations, OptimizationOption optimizationOption)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new OptimizerResult(_client.Optimize(maxIterations, optimizationOption));
                    }
                );
                return vmsResult;
            }
            return _client.Optimize(maxIterations, optimizationOption);
        }

        public OptimizerResult Optimize(int maxIterations, OptimizationOption optimizationOption, string mlcId)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new OptimizerResult(_client.Optimize(maxIterations, optimizationOption, mlcId));
                    }
                );
                return vmsResult;
            }
            return _client.Optimize(maxIterations, optimizationOption, mlcId);
        }

        public OptimizerResult Optimize()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new OptimizerResult(_client.Optimize()); }
                );
                return vmsResult;
            }
            return _client.Optimize();
        }

        public OptimizerResult Optimize(OptimizationOptionsIMRT options)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new OptimizerResult(_client.Optimize(options)); }
                );
                return vmsResult;
            }
            return _client.Optimize(options);
        }

        public OptimizerResult OptimizeVMAT(string mlcId)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new OptimizerResult(_client.OptimizeVMAT(mlcId)); }
                );
                return vmsResult;
            }
            return _client.OptimizeVMAT(mlcId);
        }

        public OptimizerResult OptimizeVMAT()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new OptimizerResult(_client.OptimizeVMAT()); }
                );
                return vmsResult;
            }
            return _client.OptimizeVMAT();
        }

        public OptimizerResult OptimizeVMAT(OptimizationOptionsVMAT options)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new OptimizerResult(_client.OptimizeVMAT(options)); }
                );
                return vmsResult;
            }
            return _client.OptimizeVMAT(options);
        }

        public CalculationResult CalculateDVHEstimates(string modelId, Dictionary<string, DoseValue> targetDoseLevels,
            Dictionary<string, string> structureMatches)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new CalculationResult(
                            _client.CalculateDVHEstimates(modelId, targetDoseLevels, structureMatches));
                    }
                );
                return vmsResult;
            }
            return _client.CalculateDVHEstimates(modelId, targetDoseLevels, structureMatches);
        }

        public Beam AddArcBeam(ExternalBeamMachineParameters machineParameters, VRect<double> jawPositions,
            double collimatorAngle, double gantryAngle, double gantryStop, GantryDirection gantryDirection,
            double patientSupportAngle, VVector isocenter)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new Beam(_client.AddArcBeam(machineParameters, jawPositions, collimatorAngle,
                            gantryAngle, gantryStop, gantryDirection, patientSupportAngle, isocenter));
                    }
                );
                return vmsResult;
            }
            return _client.AddArcBeam(machineParameters, jawPositions, collimatorAngle, gantryAngle, gantryStop,
                gantryDirection, patientSupportAngle, isocenter);
        }

        public Beam AddConformalArcBeam(ExternalBeamMachineParameters machineParameters, double collimatorAngle,
            int controlPointCount, double gantryAngle, double gantryStop, GantryDirection gantryDirection,
            double patientSupportAngle, VVector isocenter)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new Beam(_client.AddConformalArcBeam(machineParameters, collimatorAngle,
                            controlPointCount, gantryAngle, gantryStop, gantryDirection, patientSupportAngle,
                            isocenter));
                    }
                );
                return vmsResult;
            }
            return _client.AddConformalArcBeam(machineParameters, collimatorAngle, controlPointCount, gantryAngle,
                gantryStop, gantryDirection, patientSupportAngle, isocenter);
        }

        public Beam AddMLCArcBeam(ExternalBeamMachineParameters machineParameters, float[,] leafPositions,
            VRect<double> jawPositions, double collimatorAngle, double gantryAngle, double gantryStop,
            GantryDirection gantryDirection, double patientSupportAngle, VVector isocenter)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new Beam(_client.AddMLCArcBeam(machineParameters, leafPositions, jawPositions,
                            collimatorAngle, gantryAngle, gantryStop, gantryDirection, patientSupportAngle, isocenter));
                    }
                );
                return vmsResult;
            }
            return _client.AddMLCArcBeam(machineParameters, leafPositions, jawPositions, collimatorAngle, gantryAngle,
                gantryStop, gantryDirection, patientSupportAngle, isocenter);
        }

        public Beam AddMLCBeam(ExternalBeamMachineParameters machineParameters, float[,] leafPositions,
            VRect<double> jawPositions, double collimatorAngle, double gantryAngle, double patientSupportAngle,
            VVector isocenter)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new Beam(_client.AddMLCBeam(machineParameters, leafPositions, jawPositions,
                            collimatorAngle, gantryAngle, patientSupportAngle, isocenter));
                    }
                );
                return vmsResult;
            }
            return _client.AddMLCBeam(machineParameters, leafPositions, jawPositions, collimatorAngle, gantryAngle,
                patientSupportAngle, isocenter);
        }

        public Beam AddMultipleStaticSegmentBeam(ExternalBeamMachineParameters machineParameters,
            IEnumerable<double> metersetWeights, double collimatorAngle, double gantryAngle, double patientSupportAngle,
            VVector isocenter)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new Beam(_client.AddMultipleStaticSegmentBeam(machineParameters, metersetWeights,
                            collimatorAngle, gantryAngle, patientSupportAngle, isocenter));
                    }
                );
                return vmsResult;
            }
            return _client.AddMultipleStaticSegmentBeam(machineParameters, metersetWeights, collimatorAngle,
                gantryAngle, patientSupportAngle, isocenter);
        }

        public Beam AddSlidingWindowBeam(ExternalBeamMachineParameters machineParameters,
            IEnumerable<double> metersetWeights, double collimatorAngle, double gantryAngle, double patientSupportAngle,
            VVector isocenter)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new Beam(_client.AddSlidingWindowBeam(machineParameters, metersetWeights,
                            collimatorAngle, gantryAngle, patientSupportAngle, isocenter));
                    }
                );
                return vmsResult;
            }
            return _client.AddSlidingWindowBeam(machineParameters, metersetWeights, collimatorAngle, gantryAngle,
                patientSupportAngle, isocenter);
        }

        public Beam AddStaticBeam(ExternalBeamMachineParameters machineParameters, VRect<double> jawPositions,
            double collimatorAngle, double gantryAngle, double patientSupportAngle, VVector isocenter)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new Beam(_client.AddStaticBeam(machineParameters, jawPositions, collimatorAngle,
                            gantryAngle, patientSupportAngle, isocenter));
                    }
                );
                return vmsResult;
            }
            return _client.AddStaticBeam(machineParameters, jawPositions, collimatorAngle, gantryAngle,
                patientSupportAngle, isocenter);
        }

        public Beam AddVMATBeam(ExternalBeamMachineParameters machineParameters, IEnumerable<double> metersetWeights,
            double collimatorAngle, double gantryAngle, double gantryStop, GantryDirection gantryDirection,
            double patientSupportAngle, VVector isocenter)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new Beam(_client.AddVMATBeam(machineParameters, metersetWeights, collimatorAngle,
                            gantryAngle, gantryStop, gantryDirection, patientSupportAngle, isocenter));
                    }
                );
                return vmsResult;
            }
            return _client.AddVMATBeam(machineParameters, metersetWeights, collimatorAngle, gantryAngle, gantryStop,
                gantryDirection, patientSupportAngle, isocenter);
        }

        public EvaluationDose CreateEvaluationDose()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new EvaluationDose(_client.CreateEvaluationDose()); }
                );
                return vmsResult;
            }
            return _client.CreateEvaluationDose();
        }

        public void RemoveBeam(Beam beam)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.RemoveBeam(beam._client); }
                );
            else
                _client.RemoveBeam(beam);
        }
    }
}