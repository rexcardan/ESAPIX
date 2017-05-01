using ESAPIX.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.Types;
using V = VMS.TPS.Common.Model.API;
using X = ESAPIX.Facade.API;
using T = VMS.TPS.Common.Model.Types;

namespace ESAPIX.Bootstrapper
{
    public class FacadeInitializer
    {
        public static void Initialize()
        {
            //DO STATIC METHOD MAPS
            StaticHelper.CreateApplicationFunc = new Func<string, string, dynamic>((user, pw) =>
            {
                return V.Application.CreateApplication(user, pw);
            });

            StaticHelper.DoseValue_UndefinedDoseFunc = new Func<dynamic>(() => DoseValue.UndefinedDose());
            StaticHelper.SerializableObject_ClearSerializationHistoryAction = new Action(() => V.SerializableObject.ClearSerializationHistory());
            StaticHelper.VVector_DistanceFunc = new Func<dynamic, dynamic, double>((v1, v2) => VVector.Distance(v1, v2));


            VMSConstructor.ConstructScriptContextFunc0 = new Func<System.Object, System.Object, System.String, dynamic>((context, user, appName) =>
            {
                return new VMS.TPS.Common.Model.API.ScriptContext(context, user, appName);
            });
            VMSConstructor.ConstructVVectorFunc0 = new Func<System.Double, System.Double, System.Double, dynamic>((xi, yi, zi) =>
            {
                return new VMS.TPS.Common.Model.Types.VVector(xi, yi, zi);
            });
            VMSConstructor.ConstructAxisAlignedMarginsFunc0 = new Func<dynamic, System.Double, System.Double, System.Double, System.Double, System.Double, System.Double, dynamic>((geometry, x1, y1, z1, x2, y2, z2) =>
            {
                return new VMS.TPS.Common.Model.Types.AxisAlignedMargins((VMS.TPS.Common.Model.Types.StructureMarginGeometry)geometry, x1, y1, z1, x2, y2, z2);
            });
            VMSConstructor.ConstructStructureCodeInfoFunc0 = new Func<System.String, System.String, dynamic>((codingScheme, code) =>
            {
                return new VMS.TPS.Common.Model.Types.StructureCodeInfo(codingScheme, code);
            });
            VMSConstructor.ConstructSegmentProfileFunc0 = new Func<dynamic, dynamic, System.Collections.BitArray, dynamic>((origin, step, data) =>
            {
                return new VMS.TPS.Common.Model.Types.SegmentProfile(origin._client, step._client, data);
            });
            VMSConstructor.ConstructSegmentProfilePointFunc0 = new Func<dynamic, System.Boolean, dynamic>((position, value) =>
            {
                return new VMS.TPS.Common.Model.Types.SegmentProfilePoint(position._client, value);
            });
            VMSConstructor.ConstructDoseValueFunc0 = new Func<System.Double, System.String, dynamic>((value, unitName) =>
            {
                return new VMS.TPS.Common.Model.Types.DoseValue(value, unitName);
            });
            VMSConstructor.ConstructDoseValueFunc1 = new Func<System.Double, dynamic, dynamic>((value, unit) =>
            {
                return new VMS.TPS.Common.Model.Types.DoseValue(value, (VMS.TPS.Common.Model.Types.DoseValue.DoseUnit)unit);
            });
            VMSConstructor.ConstructProfilePointFunc0 = new Func<dynamic, System.Double, dynamic>((position, value) =>
            {
                return new VMS.TPS.Common.Model.Types.ProfilePoint(position._client, value);
            });
            VMSConstructor.ConstructDoseProfileFunc0 = new Func<dynamic, dynamic, System.Double[], dynamic, dynamic>((origin, step, data, unit) =>
            {
                return new VMS.TPS.Common.Model.Types.DoseProfile(origin._client, step._client, data, (VMS.TPS.Common.Model.Types.DoseValue.DoseUnit)unit);
            });
            VMSConstructor.ConstructDVHPointFunc0 = new Func<dynamic, System.Double, System.String, dynamic>((dose, volume, volumeUnit) =>
            {
                return new VMS.TPS.Common.Model.Types.DVHPoint(dose._client, volume, volumeUnit);
            });
            VMSConstructor.ConstructVRectFunc0 = new Func<dynamic, dynamic, dynamic, dynamic, dynamic>((x1, y1, x2, y2) =>
            {
                return new VMS.TPS.Common.Model.Types.VRect<double>(x1, y1, x2, y2);
            });
            VMSConstructor.ConstructMetersetValueFunc0 = new Func<System.Double, dynamic, dynamic>((value, unit) =>
            {
                return new VMS.TPS.Common.Model.Types.MetersetValue(value, (VMS.TPS.Common.Model.Types.DosimeterUnit)unit);
            });
            VMSConstructor.ConstructFluenceFunc0 = new Func<System.Single[,], System.Double, System.Double, dynamic>((fluenceMatrix, xOrigin, yOrigin) =>
            {
                return new VMS.TPS.Common.Model.Types.Fluence(fluenceMatrix, xOrigin, yOrigin);
            });
            VMSConstructor.ConstructFluenceFunc1 = new Func<System.Single[,], System.Double, System.Double, System.String, dynamic>((fluenceMatrix, xOrigin, yOrigin, mlcId) =>
            {
                return new VMS.TPS.Common.Model.Types.Fluence(fluenceMatrix, xOrigin, yOrigin, mlcId);
            });
            VMSConstructor.ConstructImageProfileFunc0 = new Func<dynamic, dynamic, System.Double[], System.String, dynamic>((origin, step, data, unit) =>
            {
                return new VMS.TPS.Common.Model.Types.ImageProfile(origin._client, step._client, data, unit);
            });
            VMSConstructor.ConstructLMCVOptionsFunc0 = new Func<System.Boolean, dynamic>((fixedJaws) =>
            {
                return new VMS.TPS.Common.Model.Types.LMCVOptions(fixedJaws);
            });
            VMSConstructor.ConstructSmartLMCOptionsFunc0 = new Func<System.Boolean, System.Boolean, dynamic>((fixedFieldBorders, jawTracking) =>
            {
                return new VMS.TPS.Common.Model.Types.SmartLMCOptions(fixedFieldBorders, jawTracking);
            });
            VMSConstructor.ConstructLMCMSSOptionsFunc0 = new Func<System.Int32, dynamic>((numberOfIterations) =>
            {
                return new VMS.TPS.Common.Model.Types.LMCMSSOptions(numberOfIterations);
            });
            VMSConstructor.ConstructOptimizationOptionsIMRTFunc0 = new Func<System.Int32, dynamic, System.Int32, dynamic, System.String, dynamic>((maxIterations, initialState, numberOfStepsBeforeIntermediateDose, convergenceOption, mlcId) =>
            {
                return new VMS.TPS.Common.Model.Types.OptimizationOptionsIMRT(maxIterations, (VMS.TPS.Common.Model.Types.OptimizationOption)initialState, numberOfStepsBeforeIntermediateDose, (VMS.TPS.Common.Model.Types.OptimizationConvergenceOption)convergenceOption, mlcId);
            });
            VMSConstructor.ConstructOptimizationOptionsIMRTFunc1 = new Func<System.Int32, dynamic, dynamic, dynamic, System.String, dynamic>((maxIterations, initialState, convergenceOption, intermediateDoseOption, mlcId) =>
            {
                return new VMS.TPS.Common.Model.Types.OptimizationOptionsIMRT(maxIterations, (VMS.TPS.Common.Model.Types.OptimizationOption)initialState, (VMS.TPS.Common.Model.Types.OptimizationConvergenceOption)convergenceOption, (VMS.TPS.Common.Model.Types.OptimizationIntermediateDoseOption)intermediateDoseOption, mlcId);
            });
            VMSConstructor.ConstructOptimizationOptionsIMRTFunc2 = new Func<System.Int32, dynamic, dynamic, System.String, dynamic>((maxIterations, initialState, convergenceOption, mlcId) =>
            {
                return new VMS.TPS.Common.Model.Types.OptimizationOptionsIMRT(maxIterations, (VMS.TPS.Common.Model.Types.OptimizationOption)initialState, (VMS.TPS.Common.Model.Types.OptimizationConvergenceOption)convergenceOption, mlcId);
            });
            VMSConstructor.ConstructOptimizationOptionsVMATFunc0 = new Func<dynamic, System.String, dynamic>((startOption, mlcId) =>
            {
                return new VMS.TPS.Common.Model.Types.OptimizationOptionsVMAT((VMS.TPS.Common.Model.Types.OptimizationOption)startOption, mlcId);
            });
            VMSConstructor.ConstructOptimizationOptionsVMATFunc1 = new Func<dynamic, System.String, dynamic>((intermediateDoseOption, mlcId) =>
            {
                return new VMS.TPS.Common.Model.Types.OptimizationOptionsVMAT((VMS.TPS.Common.Model.Types.OptimizationIntermediateDoseOption)intermediateDoseOption, mlcId);
            });
            VMSConstructor.ConstructOptimizationOptionsVMATFunc2 = new Func<System.Int32, System.String, dynamic>((numberOfCycles, mlcId) =>
            {
                return new VMS.TPS.Common.Model.Types.OptimizationOptionsVMAT(numberOfCycles, mlcId);
            });
            VMSConstructor.ConstructOptimizationOptionsVMATFunc3 = new Func<dynamic, dynamic, System.Int32, System.String, dynamic>((startOption, intermediateDoseOption, numberOfCycles, mlcId) =>
            {
                return new VMS.TPS.Common.Model.Types.OptimizationOptionsVMAT((VMS.TPS.Common.Model.Types.OptimizationOption)startOption, (VMS.TPS.Common.Model.Types.OptimizationIntermediateDoseOption)intermediateDoseOption, numberOfCycles, mlcId);
            });
            VMSConstructor.ConstructOptimizationOptionsVMATFunc4 = new Func<dynamic, dynamic>((options) =>
            {
                return new VMS.TPS.Common.Model.Types.OptimizationOptionsVMAT(options._client);
            });
            VMSConstructor.ConstructExternalBeamMachineParametersFunc0 = new Func<System.String, System.String, System.Int32, System.String, System.String, dynamic>((machineId, energyModeId, doseRate, techniqueId, primaryFluenceModeId) =>
            {
                return new VMS.TPS.Common.Model.Types.ExternalBeamMachineParameters(machineId, energyModeId, doseRate, techniqueId, primaryFluenceModeId);
            });

            #region ENUM CONVERSION
            EnumConverter.StructureMarginGeometryConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.StructureMarginGeometry)es; };
            EnumConverter.PatientOrientationConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.PatientOrientation)es; };
            EnumConverter.SeriesModalityConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.SeriesModality)es; };
            EnumConverter.DoseUnitConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.DoseValue.DoseUnit)es; };
            EnumConverter.DoseValuePresentationConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.DoseValuePresentation)es; };
            EnumConverter.VolumePresentationConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.VolumePresentation)es; };
            EnumConverter.PlanSetupApprovalStatusConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.PlanSetupApprovalStatus)es; };
            EnumConverter.BlockTypeConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.BlockType)es; };
            EnumConverter.GantryDirectionConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.GantryDirection)es; };
            EnumConverter.MLCPlanTypeConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.MLCPlanType)es; };
            EnumConverter.SetupTechniqueConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.SetupTechnique)es; };
            EnumConverter.DosimeterUnitConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.DosimeterUnit)es; };
            EnumConverter.DVHEstimateTypeConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.DVHEstimateType)es; };
            EnumConverter.OptimizationObjectiveOperatorConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.OptimizationObjectiveOperator)es; };
            EnumConverter.PlanTypeConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.PlanType)es; };
            EnumConverter.CalculationTypeConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.CalculationType)es; };
            EnumConverter.PlanSumOperationConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.PlanSumOperation)es; };
            EnumConverter.OptimizationOptionConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.OptimizationOption)es; };
            EnumConverter.OptimizationIntermediateDoseOptionConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.OptimizationIntermediateDoseOption)es; };
            EnumConverter.OptimizationConvergenceOptionConvertFunc = (es) => { return (VMS.TPS.Common.Model.Types.OptimizationConvergenceOption)es; };
            #endregion

        }
    }
}
