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
    public class ExternalPlanSetup : ESAPIX.Facade.API.PlanSetup, System.Xml.Serialization.IXmlSerializable
    {
        public ESAPIX.Facade.API.EvaluationDose DoseAsEvaluationDose
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("DoseAsEvaluationDose"))
                    {
                        return _client.DoseAsEvaluationDose;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.EvaluationDose);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.DoseAsEvaluationDose) != (null))
                        {
                            return new ESAPIX.Facade.API.EvaluationDose(_client.DoseAsEvaluationDose);
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
                    return default (ESAPIX.Facade.API.EvaluationDose);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.DoseAsEvaluationDose = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.CalculationResult CalculateDoseWithPresetValues(System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<System.String,VMS.TPS.Common.Model.Types.MetersetValue>> presetValues)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CalculateDoseWithPresetValues(presetValues));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.CalculationResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.CalculationResult)(_client.CalculateDoseWithPresetValues(presetValues));
            }
        }

        public ESAPIX.Facade.API.CalculationResult CalculateDose()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CalculateDose());
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.CalculationResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.CalculationResult)(_client.CalculateDose());
            }
        }

        public ESAPIX.Facade.API.CalculationResult CalculateLeafMotionsAndDose()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CalculateLeafMotionsAndDose());
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.CalculationResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.CalculationResult)(_client.CalculateLeafMotionsAndDose());
            }
        }

        public ESAPIX.Facade.API.CalculationResult CalculateLeafMotions()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CalculateLeafMotions());
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.CalculationResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.CalculationResult)(_client.CalculateLeafMotions());
            }
        }

        public ESAPIX.Facade.API.CalculationResult CalculateLeafMotions(VMS.TPS.Common.Model.Types.LMCVOptions options)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CalculateLeafMotions(options));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.CalculationResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.CalculationResult)(_client.CalculateLeafMotions(options));
            }
        }

        public ESAPIX.Facade.API.CalculationResult CalculateLeafMotions(VMS.TPS.Common.Model.Types.SmartLMCOptions options)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CalculateLeafMotions(options));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.CalculationResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.CalculationResult)(_client.CalculateLeafMotions(options));
            }
        }

        public ESAPIX.Facade.API.CalculationResult CalculateLeafMotions(VMS.TPS.Common.Model.Types.LMCMSSOptions options)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CalculateLeafMotions(options));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.CalculationResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.CalculationResult)(_client.CalculateLeafMotions(options));
            }
        }

        public System.Collections.Generic.IEnumerable<System.String> GetModelsForCalculationType(VMS.TPS.Common.Model.Types.CalculationType calculationType)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetModelsForCalculationType(calculationType));
                    if (fromClient.Equals(default (System.Collections.Generic.IEnumerable<System.String>)))
                    {
                        return default (System.Collections.Generic.IEnumerable<System.String>);
                    }

                    return (System.Collections.Generic.IEnumerable<System.String>)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Collections.Generic.IEnumerable<System.String>)(_client.GetModelsForCalculationType(calculationType));
            }
        }

        public ESAPIX.Facade.API.OptimizerResult Optimize(System.Int32 maxIterations)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Optimize(maxIterations));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.OptimizerResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.OptimizerResult)(_client.Optimize(maxIterations));
            }
        }

        public ESAPIX.Facade.API.OptimizerResult Optimize(System.Int32 maxIterations, VMS.TPS.Common.Model.Types.OptimizationOption optimizationOption)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Optimize(maxIterations, optimizationOption));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.OptimizerResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.OptimizerResult)(_client.Optimize(maxIterations, optimizationOption));
            }
        }

        public ESAPIX.Facade.API.OptimizerResult Optimize(System.Int32 maxIterations, VMS.TPS.Common.Model.Types.OptimizationOption optimizationOption, System.String mlcId)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Optimize(maxIterations, optimizationOption, mlcId));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.OptimizerResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.OptimizerResult)(_client.Optimize(maxIterations, optimizationOption, mlcId));
            }
        }

        public ESAPIX.Facade.API.OptimizerResult Optimize()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Optimize());
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.OptimizerResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.OptimizerResult)(_client.Optimize());
            }
        }

        public ESAPIX.Facade.API.OptimizerResult Optimize(VMS.TPS.Common.Model.Types.OptimizationOptionsIMRT options)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Optimize(options));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.OptimizerResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.OptimizerResult)(_client.Optimize(options));
            }
        }

        public ESAPIX.Facade.API.OptimizerResult OptimizeVMAT(System.String mlcId)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.OptimizeVMAT(mlcId));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.OptimizerResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.OptimizerResult)(_client.OptimizeVMAT(mlcId));
            }
        }

        public ESAPIX.Facade.API.OptimizerResult OptimizeVMAT()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.OptimizeVMAT());
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.OptimizerResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.OptimizerResult)(_client.OptimizeVMAT());
            }
        }

        public ESAPIX.Facade.API.OptimizerResult OptimizeVMAT(VMS.TPS.Common.Model.Types.OptimizationOptionsVMAT options)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.OptimizeVMAT(options));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.OptimizerResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.OptimizerResult)(_client.OptimizeVMAT(options));
            }
        }

        public ESAPIX.Facade.API.CalculationResult CalculateDVHEstimates(System.String modelId, System.Collections.Generic.Dictionary<System.String,VMS.TPS.Common.Model.Types.DoseValue> targetDoseLevels, System.Collections.Generic.Dictionary<System.String,System.String> structureMatches)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CalculateDVHEstimates(modelId, targetDoseLevels, structureMatches));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.CalculationResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.CalculationResult)(_client.CalculateDVHEstimates(modelId, targetDoseLevels, structureMatches));
            }
        }

        public ESAPIX.Facade.API.Beam AddArcBeam(VMS.TPS.Common.Model.Types.ExternalBeamMachineParameters machineParameters, VMS.TPS.Common.Model.Types.VRect<System.Double> jawPositions, System.Double collimatorAngle, System.Double gantryAngle, System.Double gantryStop, VMS.TPS.Common.Model.Types.GantryDirection gantryDirection, System.Double patientSupportAngle, VMS.TPS.Common.Model.Types.VVector isocenter)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddArcBeam(machineParameters, jawPositions, collimatorAngle, gantryAngle, gantryStop, gantryDirection, patientSupportAngle, isocenter));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.Beam(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.Beam)(_client.AddArcBeam(machineParameters, jawPositions, collimatorAngle, gantryAngle, gantryStop, gantryDirection, patientSupportAngle, isocenter));
            }
        }

        public ESAPIX.Facade.API.Beam AddConformalArcBeam(VMS.TPS.Common.Model.Types.ExternalBeamMachineParameters machineParameters, System.Double collimatorAngle, System.Int32 controlPointCount, System.Double gantryAngle, System.Double gantryStop, VMS.TPS.Common.Model.Types.GantryDirection gantryDirection, System.Double patientSupportAngle, VMS.TPS.Common.Model.Types.VVector isocenter)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddConformalArcBeam(machineParameters, collimatorAngle, controlPointCount, gantryAngle, gantryStop, gantryDirection, patientSupportAngle, isocenter));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.Beam(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.Beam)(_client.AddConformalArcBeam(machineParameters, collimatorAngle, controlPointCount, gantryAngle, gantryStop, gantryDirection, patientSupportAngle, isocenter));
            }
        }

        public ESAPIX.Facade.API.Beam AddMLCArcBeam(VMS.TPS.Common.Model.Types.ExternalBeamMachineParameters machineParameters, System.Single[,] leafPositions, VMS.TPS.Common.Model.Types.VRect<System.Double> jawPositions, System.Double collimatorAngle, System.Double gantryAngle, System.Double gantryStop, VMS.TPS.Common.Model.Types.GantryDirection gantryDirection, System.Double patientSupportAngle, VMS.TPS.Common.Model.Types.VVector isocenter)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddMLCArcBeam(machineParameters, leafPositions, jawPositions, collimatorAngle, gantryAngle, gantryStop, gantryDirection, patientSupportAngle, isocenter));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.Beam(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.Beam)(_client.AddMLCArcBeam(machineParameters, leafPositions, jawPositions, collimatorAngle, gantryAngle, gantryStop, gantryDirection, patientSupportAngle, isocenter));
            }
        }

        public ESAPIX.Facade.API.Beam AddMLCBeam(VMS.TPS.Common.Model.Types.ExternalBeamMachineParameters machineParameters, System.Single[,] leafPositions, VMS.TPS.Common.Model.Types.VRect<System.Double> jawPositions, System.Double collimatorAngle, System.Double gantryAngle, System.Double patientSupportAngle, VMS.TPS.Common.Model.Types.VVector isocenter)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddMLCBeam(machineParameters, leafPositions, jawPositions, collimatorAngle, gantryAngle, patientSupportAngle, isocenter));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.Beam(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.Beam)(_client.AddMLCBeam(machineParameters, leafPositions, jawPositions, collimatorAngle, gantryAngle, patientSupportAngle, isocenter));
            }
        }

        public ESAPIX.Facade.API.Beam AddMultipleStaticSegmentBeam(VMS.TPS.Common.Model.Types.ExternalBeamMachineParameters machineParameters, System.Collections.Generic.IEnumerable<System.Double> metersetWeights, System.Double collimatorAngle, System.Double gantryAngle, System.Double patientSupportAngle, VMS.TPS.Common.Model.Types.VVector isocenter)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddMultipleStaticSegmentBeam(machineParameters, metersetWeights, collimatorAngle, gantryAngle, patientSupportAngle, isocenter));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.Beam(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.Beam)(_client.AddMultipleStaticSegmentBeam(machineParameters, metersetWeights, collimatorAngle, gantryAngle, patientSupportAngle, isocenter));
            }
        }

        public ESAPIX.Facade.API.Beam AddSlidingWindowBeam(VMS.TPS.Common.Model.Types.ExternalBeamMachineParameters machineParameters, System.Collections.Generic.IEnumerable<System.Double> metersetWeights, System.Double collimatorAngle, System.Double gantryAngle, System.Double patientSupportAngle, VMS.TPS.Common.Model.Types.VVector isocenter)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddSlidingWindowBeam(machineParameters, metersetWeights, collimatorAngle, gantryAngle, patientSupportAngle, isocenter));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.Beam(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.Beam)(_client.AddSlidingWindowBeam(machineParameters, metersetWeights, collimatorAngle, gantryAngle, patientSupportAngle, isocenter));
            }
        }

        public ESAPIX.Facade.API.Beam AddStaticBeam(VMS.TPS.Common.Model.Types.ExternalBeamMachineParameters machineParameters, VMS.TPS.Common.Model.Types.VRect<System.Double> jawPositions, System.Double collimatorAngle, System.Double gantryAngle, System.Double patientSupportAngle, VMS.TPS.Common.Model.Types.VVector isocenter)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddStaticBeam(machineParameters, jawPositions, collimatorAngle, gantryAngle, patientSupportAngle, isocenter));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.Beam(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.Beam)(_client.AddStaticBeam(machineParameters, jawPositions, collimatorAngle, gantryAngle, patientSupportAngle, isocenter));
            }
        }

        public ESAPIX.Facade.API.Beam AddVMATBeam(VMS.TPS.Common.Model.Types.ExternalBeamMachineParameters machineParameters, System.Collections.Generic.IEnumerable<System.Double> metersetWeights, System.Double collimatorAngle, System.Double gantryAngle, System.Double gantryStop, VMS.TPS.Common.Model.Types.GantryDirection gantryDirection, System.Double patientSupportAngle, VMS.TPS.Common.Model.Types.VVector isocenter)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddVMATBeam(machineParameters, metersetWeights, collimatorAngle, gantryAngle, gantryStop, gantryDirection, patientSupportAngle, isocenter));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.Beam(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.Beam)(_client.AddVMATBeam(machineParameters, metersetWeights, collimatorAngle, gantryAngle, gantryStop, gantryDirection, patientSupportAngle, isocenter));
            }
        }

        public ESAPIX.Facade.API.EvaluationDose CreateEvaluationDose()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CreateEvaluationDose());
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.EvaluationDose(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.EvaluationDose)(_client.CreateEvaluationDose());
            }
        }

        public void RemoveBeam(ESAPIX.Facade.API.Beam beam)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.RemoveBeam(beam._client);
                }

                );
            }
            else
            {
                _client.RemoveBeam(beam);
            }
        }

        public ExternalPlanSetup()
        {
            _client = (new ExpandoObject());
        }

        public ExternalPlanSetup(dynamic client)
        {
            _client = (client);
        }
    }
}