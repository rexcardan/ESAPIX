#region

using System;

#endregion

namespace ESAPIX.Facade
{
    public class EnumConverter
    {
        public static Func<Types.StructureMarginGeometry, dynamic> StructureMarginGeometryConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.PatientOrientation, dynamic> PatientOrientationConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.SeriesModality, dynamic> SeriesModalityConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.DoseValue.DoseUnit, dynamic> DoseUnitConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.DoseValuePresentation, dynamic> DoseValuePresentationConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.VolumePresentation, dynamic> VolumePresentationConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.PlanSetupApprovalStatus, dynamic> PlanSetupApprovalStatusConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.BlockType, dynamic> BlockTypeConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.GantryDirection, dynamic> GantryDirectionConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.MLCPlanType, dynamic> MLCPlanTypeConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.SetupTechnique, dynamic> SetupTechniqueConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.DosimeterUnit, dynamic> DosimeterUnitConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.DVHEstimateType, dynamic> DVHEstimateTypeConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.OptimizationObjectiveOperator, dynamic> OptimizationObjectiveOperatorConvertFunc =
            es =>
            {
                throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
            };

        public static Func<Types.PlanType, dynamic> PlanTypeConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.CalculationType, dynamic> CalculationTypeConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.PlanSumOperation, dynamic> PlanSumOperationConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.OptimizationOption, dynamic> OptimizationOptionConvertFunc = es =>
        {
            throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
        };

        public static Func<Types.OptimizationIntermediateDoseOption, dynamic>
            OptimizationIntermediateDoseOptionConvertFunc = es =>
            {
                throw new Exception(
                    "Facades have not been initialized. Call FacadeInitializer method to initialize.");
            };

        public static Func<Types.OptimizationConvergenceOption, dynamic> OptimizationConvergenceOptionConvertFunc =
            es =>
            {
                throw new Exception("Facades have not been initialized. Call FacadeInitializer method to initialize.");
            };

        public static dynamic Convert(Types.StructureMarginGeometry esapixEnum)
        {
            return StructureMarginGeometryConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.PatientOrientation esapixEnum)
        {
            return PatientOrientationConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.SeriesModality esapixEnum)
        {
            return SeriesModalityConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.DoseValue.DoseUnit esapixEnum)
        {
            return DoseUnitConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.DoseValuePresentation esapixEnum)
        {
            return DoseValuePresentationConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.VolumePresentation esapixEnum)
        {
            return VolumePresentationConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.PlanSetupApprovalStatus esapixEnum)
        {
            return PlanSetupApprovalStatusConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.BlockType esapixEnum)
        {
            return BlockTypeConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.GantryDirection esapixEnum)
        {
            return GantryDirectionConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.MLCPlanType esapixEnum)
        {
            return MLCPlanTypeConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.SetupTechnique esapixEnum)
        {
            return SetupTechniqueConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.DosimeterUnit esapixEnum)
        {
            return DosimeterUnitConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.DVHEstimateType esapixEnum)
        {
            return DVHEstimateTypeConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.OptimizationObjectiveOperator esapixEnum)
        {
            return OptimizationObjectiveOperatorConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.PlanType esapixEnum)
        {
            return PlanTypeConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.CalculationType esapixEnum)
        {
            return CalculationTypeConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.PlanSumOperation esapixEnum)
        {
            return PlanSumOperationConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.OptimizationOption esapixEnum)
        {
            return OptimizationOptionConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.OptimizationIntermediateDoseOption esapixEnum)
        {
            return OptimizationIntermediateDoseOptionConvertFunc(esapixEnum);
        }

        public static dynamic Convert(Types.OptimizationConvergenceOption esapixEnum)
        {
            return OptimizationConvergenceOptionConvertFunc(esapixEnum);
        }
    }
}