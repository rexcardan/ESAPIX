#region

using ESAPIX.Facade;
using V = VMS.TPS.Common.Model.API;
using X = ESAPIX.Facade.API;
using T = VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Bootstrapper
{
    public class FacadeInitializer
    {
        public static void Initialize()
        {
            //DO STATIC METHOD MAPS
            StaticHelper.CreateApplicationFunc = (user, pw) => { return V.Application.CreateApplication(user, pw); };

            StaticHelper.DoseValue_UndefinedDoseFunc = () => T.DoseValue.UndefinedDose();
            StaticHelper.SerializableObject_ClearSerializationHistoryAction =
                () => V.SerializableObject.ClearSerializationHistory();
            StaticHelper.VVector_DistanceFunc = (v1, v2) => T.VVector.Distance(v1, v2);


            VMSConstructor.ConstructScriptContextFunc0 = (context, user, appName) =>
            {
                return new VMS.TPS.Common.Model.API.ScriptContext(context, user, appName);
            };
            VMSConstructor.ConstructVVectorFunc0 = (xi, yi, zi) => { return new T.VVector(xi, yi, zi); };
            VMSConstructor.ConstructAxisAlignedMarginsFunc0 = (geometry, x1, y1, z1, x2, y2, z2) =>
            {
                return new T.AxisAlignedMargins((T.StructureMarginGeometry) geometry, x1, y1, z1, x2, y2, z2);
            };
            VMSConstructor.ConstructStructureCodeInfoFunc0 = (codingScheme, code) =>
            {
                return new T.StructureCodeInfo(codingScheme, code);
            };
            VMSConstructor.ConstructSegmentProfileFunc0 = (origin, step, data) =>
            {
                return new T.SegmentProfile(origin, step, data);
            };
            VMSConstructor.ConstructSegmentProfilePointFunc0 = (position, value) =>
            {
                return new T.SegmentProfilePoint(position, value);
            };
            VMSConstructor.ConstructDoseValueFunc0 = (value, unitName) => { return new T.DoseValue(value, unitName); };
            VMSConstructor.ConstructDoseValueFunc1 = (value, unit) =>
            {
                return new T.DoseValue(value, (T.DoseValue.DoseUnit) unit);
            };
            VMSConstructor.ConstructProfilePointFunc0 = (position, value) =>
            {
                return new T.ProfilePoint(position, value);
            };
            VMSConstructor.ConstructDoseProfileFunc0 = (origin, step, data, unit) =>
            {
                return new T.DoseProfile(origin, step, data, (T.DoseValue.DoseUnit) unit);
            };
            VMSConstructor.ConstructDVHPointFunc0 = (dose, volume, volumeUnit) =>
            {
                return new T.DVHPoint(dose, volume, volumeUnit);
            };
            VMSConstructor.ConstructVRectFunc0 = (x1, y1, x2, y2) => { return new T.VRect<double>(x1, y1, x2, y2); };
            VMSConstructor.ConstructMetersetValueFunc0 = (value, unit) =>
            {
                return new T.MetersetValue(value, (T.DosimeterUnit) unit);
            };
            VMSConstructor.ConstructFluenceFunc0 = (fluenceMatrix, xOrigin, yOrigin) =>
            {
                return new T.Fluence(fluenceMatrix, xOrigin, yOrigin);
            };
            VMSConstructor.ConstructFluenceFunc1 = (fluenceMatrix, xOrigin, yOrigin, mlcId) =>
            {
                return new T.Fluence(fluenceMatrix, xOrigin, yOrigin, mlcId);
            };
            VMSConstructor.ConstructImageProfileFunc0 = (origin, step, data, unit) =>
            {
                return new T.ImageProfile(origin, step, data, unit);
            };
            VMSConstructor.ConstructLMCVOptionsFunc0 = fixedJaws => { return new T.LMCVOptions(fixedJaws); };
            VMSConstructor.ConstructSmartLMCOptionsFunc0 = (fixedFieldBorders, jawTracking) =>
            {
                return new T.SmartLMCOptions(fixedFieldBorders, jawTracking);
            };
            VMSConstructor.ConstructLMCMSSOptionsFunc0 = numberOfIterations =>
            {
                return new T.LMCMSSOptions(numberOfIterations);
            };
            VMSConstructor.ConstructOptimizationOptionsIMRTFunc0 =
                (maxIterations, initialState, numberOfStepsBeforeIntermediateDose, convergenceOption, mlcId) =>
                {
                    return new T.OptimizationOptionsIMRT(maxIterations, (T.OptimizationOption) initialState,
                        numberOfStepsBeforeIntermediateDose, (T.OptimizationConvergenceOption) convergenceOption,
                        mlcId);
                };
            VMSConstructor.ConstructOptimizationOptionsIMRTFunc1 =
                (maxIterations, initialState, convergenceOption, intermediateDoseOption, mlcId) =>
                {
                    return new T.OptimizationOptionsIMRT(maxIterations, (T.OptimizationOption) initialState,
                        (T.OptimizationConvergenceOption) convergenceOption,
                        (T.OptimizationIntermediateDoseOption) intermediateDoseOption, mlcId);
                };
            VMSConstructor.ConstructOptimizationOptionsIMRTFunc2 =
                (maxIterations, initialState, convergenceOption, mlcId) =>
                {
                    return new T.OptimizationOptionsIMRT(maxIterations, (T.OptimizationOption) initialState,
                        (T.OptimizationConvergenceOption) convergenceOption, mlcId);
                };
            VMSConstructor.ConstructOptimizationOptionsVMATFunc0 = (startOption, mlcId) =>
            {
                return new T.OptimizationOptionsVMAT((T.OptimizationOption) startOption, mlcId);
            };
            VMSConstructor.ConstructOptimizationOptionsVMATFunc1 = (intermediateDoseOption, mlcId) =>
            {
                return new T.OptimizationOptionsVMAT((T.OptimizationIntermediateDoseOption) intermediateDoseOption,
                    mlcId);
            };
            VMSConstructor.ConstructOptimizationOptionsVMATFunc2 = (numberOfCycles, mlcId) =>
            {
                return new T.OptimizationOptionsVMAT(numberOfCycles, mlcId);
            };
            VMSConstructor.ConstructOptimizationOptionsVMATFunc3 =
                (startOption, intermediateDoseOption, numberOfCycles, mlcId) =>
                {
                    return new T.OptimizationOptionsVMAT((T.OptimizationOption) startOption,
                        (T.OptimizationIntermediateDoseOption) intermediateDoseOption, numberOfCycles, mlcId);
                };
            VMSConstructor.ConstructOptimizationOptionsVMATFunc4 = options =>
            {
                return new T.OptimizationOptionsVMAT(options);
            };
            VMSConstructor.ConstructExternalBeamMachineParametersFunc0 =
                (machineId, energyModeId, doseRate, techniqueId, primaryFluenceModeId) =>
                {
                    return new T.ExternalBeamMachineParameters(machineId, energyModeId, doseRate, techniqueId,
                        primaryFluenceModeId);
                };
        }
    }
}