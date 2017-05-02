#region

using System;

#endregion

namespace ESAPIX.Facade
{
    public class EnumConverter
    {
        public static Func<VMS.TPS.Common.Model.Types.StructureMarginGeometry, dynamic>
            StructureMarginGeometryConvertFunc = es =>
            {
                throw new Exception(
                    "Facades have not been initialized. Call FacadeInitializer method to initialize.");
            };

        public static Func<VMS.TPS.Common.Model.Types.PatientOrientation, dynamic> PatientOrientationConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<VMS.TPS.Common.Model.Types.SeriesModality, dynamic> SeriesModalityConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<VMS.TPS.Common.Model.Types.DoseValue.DoseUnit, dynamic> DoseUnitConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<VMS.TPS.Common.Model.Types.DoseValuePresentation, dynamic> DoseValuePresentationConvertFunc =
            es =>
            {
                throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
            };

        public static Func<VMS.TPS.Common.Model.Types.VolumePresentation, dynamic> VolumePresentationConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<VMS.TPS.Common.Model.Types.PlanSetupApprovalStatus, dynamic>
            PlanSetupApprovalStatusConvertFunc = es =>
            {
                throw new Exception(
                    "Facades have not been initialized. Call FacadeInitializer method to initialize.");
            };

        public static Func<VMS.TPS.Common.Model.Types.BlockType, dynamic> BlockTypeConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<VMS.TPS.Common.Model.Types.GantryDirection, dynamic> GantryDirectionConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<VMS.TPS.Common.Model.Types.MLCPlanType, dynamic> MLCPlanTypeConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<VMS.TPS.Common.Model.Types.SetupTechnique, dynamic> SetupTechniqueConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<VMS.TPS.Common.Model.Types.DosimeterUnit, dynamic> DosimeterUnitConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<VMS.TPS.Common.Model.Types.DVHEstimateType, dynamic> DVHEstimateTypeConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<VMS.TPS.Common.Model.Types.OptimizationObjectiveOperator, dynamic>
            OptimizationObjectiveOperatorConvertFunc =
                es =>
                {
                    throw new Exception(
                        "Facades have not been initialized. Call FacadeInitializer method to initialize.");
                };

        public static Func<VMS.TPS.Common.Model.Types.PlanType, dynamic> PlanTypeConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<VMS.TPS.Common.Model.Types.CalculationType, dynamic> CalculationTypeConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<VMS.TPS.Common.Model.Types.PlanSumOperation, dynamic> PlanSumOperationConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<VMS.TPS.Common.Model.Types.OptimizationOption, dynamic> OptimizationOptionConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<VMS.TPS.Common.Model.Types.OptimizationIntermediateDoseOption, dynamic>
            OptimizationIntermediateDoseOptionConvertFunc = es =>
            {
                throw new Exception(
                    "Facades have not been initialized. Call FacadeInitializer method to initialize.");
            };

        public static Func<VMS.TPS.Common.Model.Types.OptimizationConvergenceOption, dynamic>
            OptimizationConvergenceOptionConvertFunc =
                es =>
                {
                    throw new Exception(
                        "Facades have not been initialized. Call FacadeInitializer method to initialize.");
                };

        public static dynamic Convert(VMS.TPS.Common.Model.Types.StructureMarginGeometry esapixEnum)
        {
            return StructureMarginGeometryConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.PatientOrientation esapixEnum)
        {
            return PatientOrientationConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.SeriesModality esapixEnum)
        {
            return SeriesModalityConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.DoseValue.DoseUnit esapixEnum)
        {
            return DoseUnitConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.DoseValuePresentation esapixEnum)
        {
            return DoseValuePresentationConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.VolumePresentation esapixEnum)
        {
            return VolumePresentationConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.PlanSetupApprovalStatus esapixEnum)
        {
            return PlanSetupApprovalStatusConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.BlockType esapixEnum)
        {
            return BlockTypeConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.GantryDirection esapixEnum)
        {
            return GantryDirectionConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.MLCPlanType esapixEnum)
        {
            return MLCPlanTypeConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.SetupTechnique esapixEnum)
        {
            return SetupTechniqueConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.DosimeterUnit esapixEnum)
        {
            return DosimeterUnitConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.DVHEstimateType esapixEnum)
        {
            return DVHEstimateTypeConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.OptimizationObjectiveOperator esapixEnum)
        {
            return OptimizationObjectiveOperatorConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.PlanType esapixEnum)
        {
            return PlanTypeConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.CalculationType esapixEnum)
        {
            return CalculationTypeConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.PlanSumOperation esapixEnum)
        {
            return PlanSumOperationConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.OptimizationOption esapixEnum)
        {
            return OptimizationOptionConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.OptimizationIntermediateDoseOption esapixEnum)
        {
            return OptimizationIntermediateDoseOptionConvertFunc(esapixEnum);
        }

        public static dynamic Convert(VMS.TPS.Common.Model.Types.OptimizationConvergenceOption esapixEnum)
        {
            return OptimizationConvergenceOptionConvertFunc(esapixEnum);
        }
    }
}