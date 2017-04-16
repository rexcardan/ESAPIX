using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Facade.Types;

namespace ESAPIX.Facade

{
    /// <summary>
    /// This class is responsible for creating VMS types without knowing anything about VMS classes (not dependent)
    /// </summary>
    public class VMSConstructor
    {
        public static Func<System.Object, System.Object, System.String, dynamic> ConstructScriptContextFunc0 = null;
        internal static dynamic ConstructScriptContext(System.Object context, System.Object user, System.String appName)
        {
            if (VMSConstructor.ConstructScriptContextFunc0 == null) { throw new NullReferenceException("The function ConstructScriptContextFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructScriptContextFunc0(context, user, appName);
            });
        }
        public static Func<System.Double, System.Double, System.Double, dynamic> ConstructVVectorFunc0 = null;
        internal static dynamic ConstructVVector(System.Double xi, System.Double yi, System.Double zi)
        {
            if (VMSConstructor.ConstructVVectorFunc0 == null) { throw new NullReferenceException("The function ConstructVVectorFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructVVectorFunc0(xi, yi, zi);
            });
        }
        public static Func<dynamic, System.Double, System.Double, System.Double, System.Double, System.Double, System.Double, dynamic> ConstructAxisAlignedMarginsFunc0 = null;
        internal static dynamic ConstructAxisAlignedMargins(ESAPIX.Facade.Types.StructureMarginGeometry geometry, System.Double x1, System.Double y1, System.Double z1, System.Double x2, System.Double y2, System.Double z2)
        {
            if (VMSConstructor.ConstructAxisAlignedMarginsFunc0 == null) { throw new NullReferenceException("The function ConstructAxisAlignedMarginsFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructAxisAlignedMarginsFunc0(geometry, x1, y1, z1, x2, y2, z2);
            });
        }
        public static Func<System.String, System.String, dynamic> ConstructStructureCodeInfoFunc0 = null;
        internal static dynamic ConstructStructureCodeInfo(System.String codingScheme, System.String code)
        {
            if (VMSConstructor.ConstructStructureCodeInfoFunc0 == null) { throw new NullReferenceException("The function ConstructStructureCodeInfoFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructStructureCodeInfoFunc0(codingScheme, code);
            });
        }
        public static Func<dynamic, dynamic, System.Collections.BitArray, dynamic> ConstructSegmentProfileFunc0 = null;
        internal static dynamic ConstructSegmentProfile(ESAPIX.Facade.Types.VVector origin, ESAPIX.Facade.Types.VVector step, System.Collections.BitArray data)
        {
            if (VMSConstructor.ConstructSegmentProfileFunc0 == null) { throw new NullReferenceException("The function ConstructSegmentProfileFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructSegmentProfileFunc0(origin._client, step._client, data);
            });
        }
        public static Func<dynamic, System.Boolean, dynamic> ConstructSegmentProfilePointFunc0 = null;
        internal static dynamic ConstructSegmentProfilePoint(ESAPIX.Facade.Types.VVector position, System.Boolean value)
        {
            if (VMSConstructor.ConstructSegmentProfilePointFunc0 == null) { throw new NullReferenceException("The function ConstructSegmentProfilePointFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructSegmentProfilePointFunc0(position._client, value);
            });
        }
        public static Func<System.Double, System.String, dynamic> ConstructDoseValueFunc0 = null;
        internal static dynamic ConstructDoseValue(System.Double value, System.String unitName)
        {
            if (VMSConstructor.ConstructDoseValueFunc0 == null) { throw new NullReferenceException("The function ConstructDoseValueFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructDoseValueFunc0(value, unitName);
            });
        }
        public static Func<System.Double, dynamic, dynamic> ConstructDoseValueFunc1 = null;
        internal static dynamic ConstructDoseValue(System.Double value, ESAPIX.Facade.Types.DoseValue.DoseUnit unit)
        {
            if (VMSConstructor.ConstructDoseValueFunc1 == null) { throw new NullReferenceException("The function ConstructDoseValueFunc1 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructDoseValueFunc1(value, unit);
            });
        }
        public static Func<dynamic, dynamic, System.Double[], dynamic> ConstructLineProfileFunc0 = null;
        internal static dynamic ConstructLineProfile(ESAPIX.Facade.Types.VVector origin, ESAPIX.Facade.Types.VVector step, System.Double[] data)
        {
            if (VMSConstructor.ConstructLineProfileFunc0 == null) { throw new NullReferenceException("The function ConstructLineProfileFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructLineProfileFunc0(origin._client, step._client, data);
            });
        }
        public static Func<dynamic, System.Double, dynamic> ConstructProfilePointFunc0 = null;
        internal static dynamic ConstructProfilePoint(ESAPIX.Facade.Types.VVector position, System.Double value)
        {
            if (VMSConstructor.ConstructProfilePointFunc0 == null) { throw new NullReferenceException("The function ConstructProfilePointFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructProfilePointFunc0(position._client, value);
            });
        }
        public static Func<dynamic, dynamic, System.Double[], dynamic, dynamic> ConstructDoseProfileFunc0 = null;
        internal static dynamic ConstructDoseProfile(ESAPIX.Facade.Types.VVector origin, ESAPIX.Facade.Types.VVector step, System.Double[] data, ESAPIX.Facade.Types.DoseValue.DoseUnit unit)
        {
            if (VMSConstructor.ConstructDoseProfileFunc0 == null) { throw new NullReferenceException("The function ConstructDoseProfileFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructDoseProfileFunc0(origin._client, step._client, data, unit);
            });
        }
        public static Func<dynamic, System.Double, System.String, dynamic> ConstructDVHPointFunc0 = null;
        internal static dynamic ConstructDVHPoint(ESAPIX.Facade.Types.DoseValue dose, System.Double volume, System.String volumeUnit)
        {
            if (VMSConstructor.ConstructDVHPointFunc0 == null) { throw new NullReferenceException("The function ConstructDVHPointFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructDVHPointFunc0(dose._client, volume, volumeUnit);
            });
        }
        public static Func<dynamic, dynamic, dynamic, dynamic, dynamic> ConstructVRectFunc0 = null;
        internal static dynamic ConstructVRect<T>(T x1, T y1, T x2, T y2)
        {
            if (VMSConstructor.ConstructVRectFunc0 == null) { throw new NullReferenceException("The function ConstructVRectFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructVRectFunc0(x1, y1, x2, y2);
            });
        }
        public static Func<System.Double, dynamic, dynamic> ConstructMetersetValueFunc0 = null;
        internal static dynamic ConstructMetersetValue(System.Double value, ESAPIX.Facade.Types.DosimeterUnit unit)
        {
            if (VMSConstructor.ConstructMetersetValueFunc0 == null) { throw new NullReferenceException("The function ConstructMetersetValueFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructMetersetValueFunc0(value, unit);
            });
        }
        public static Func<System.Single[,], System.Double, System.Double, dynamic> ConstructFluenceFunc0 = null;
        internal static dynamic ConstructFluence(System.Single[,] fluenceMatrix, System.Double xOrigin, System.Double yOrigin)
        {
            if (VMSConstructor.ConstructFluenceFunc0 == null) { throw new NullReferenceException("The function ConstructFluenceFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructFluenceFunc0(fluenceMatrix, xOrigin, yOrigin);
            });
        }
        public static Func<System.Single[,], System.Double, System.Double, System.String, dynamic> ConstructFluenceFunc1 = null;
        internal static dynamic ConstructFluence(System.Single[,] fluenceMatrix, System.Double xOrigin, System.Double yOrigin, System.String mlcId)
        {
            if (VMSConstructor.ConstructFluenceFunc1 == null) { throw new NullReferenceException("The function ConstructFluenceFunc1 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructFluenceFunc1(fluenceMatrix, xOrigin, yOrigin, mlcId);
            });
        }
        public static Func<dynamic, dynamic, System.Double[], System.String, dynamic> ConstructImageProfileFunc0 = null;
        internal static dynamic ConstructImageProfile(ESAPIX.Facade.Types.VVector origin, ESAPIX.Facade.Types.VVector step, System.Double[] data, System.String unit)
        {
            if (VMSConstructor.ConstructImageProfileFunc0 == null) { throw new NullReferenceException("The function ConstructImageProfileFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructImageProfileFunc0(origin._client, step._client, data, unit);
            });
        }
        public static Func<System.Boolean, dynamic> ConstructLMCVOptionsFunc0 = null;
        internal static dynamic ConstructLMCVOptions(System.Boolean fixedJaws)
        {
            if (VMSConstructor.ConstructLMCVOptionsFunc0 == null) { throw new NullReferenceException("The function ConstructLMCVOptionsFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructLMCVOptionsFunc0(fixedJaws);
            });
        }
        public static Func<System.Boolean, System.Boolean, dynamic> ConstructSmartLMCOptionsFunc0 = null;
        internal static dynamic ConstructSmartLMCOptions(System.Boolean fixedFieldBorders, System.Boolean jawTracking)
        {
            if (VMSConstructor.ConstructSmartLMCOptionsFunc0 == null) { throw new NullReferenceException("The function ConstructSmartLMCOptionsFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructSmartLMCOptionsFunc0(fixedFieldBorders, jawTracking);
            });
        }
        public static Func<System.Int32, dynamic> ConstructLMCMSSOptionsFunc0 = null;
        internal static dynamic ConstructLMCMSSOptions(System.Int32 numberOfIterations)
        {
            if (VMSConstructor.ConstructLMCMSSOptionsFunc0 == null) { throw new NullReferenceException("The function ConstructLMCMSSOptionsFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructLMCMSSOptionsFunc0(numberOfIterations);
            });
        }
        public static Func<System.Int32, dynamic, System.Int32, dynamic, System.String, dynamic> ConstructOptimizationOptionsIMRTFunc0 = null;
        internal static dynamic ConstructOptimizationOptionsIMRT(System.Int32 maxIterations, ESAPIX.Facade.Types.OptimizationOption initialState, System.Int32 numberOfStepsBeforeIntermediateDose, ESAPIX.Facade.Types.OptimizationConvergenceOption convergenceOption, System.String mlcId)
        {
            if (VMSConstructor.ConstructOptimizationOptionsIMRTFunc0 == null) { throw new NullReferenceException("The function ConstructOptimizationOptionsIMRTFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructOptimizationOptionsIMRTFunc0(maxIterations, initialState, numberOfStepsBeforeIntermediateDose, convergenceOption, mlcId);
            });
        }
        public static Func<System.Int32, dynamic, dynamic, dynamic, System.String, dynamic> ConstructOptimizationOptionsIMRTFunc1 = null;
        internal static dynamic ConstructOptimizationOptionsIMRT(System.Int32 maxIterations, ESAPIX.Facade.Types.OptimizationOption initialState, ESAPIX.Facade.Types.OptimizationConvergenceOption convergenceOption, ESAPIX.Facade.Types.OptimizationIntermediateDoseOption intermediateDoseOption, System.String mlcId)
        {
            if (VMSConstructor.ConstructOptimizationOptionsIMRTFunc1 == null) { throw new NullReferenceException("The function ConstructOptimizationOptionsIMRTFunc1 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructOptimizationOptionsIMRTFunc1(maxIterations, initialState, convergenceOption, intermediateDoseOption, mlcId);
            });
        }
        public static Func<System.Int32, dynamic, dynamic, System.String, dynamic> ConstructOptimizationOptionsIMRTFunc2 = null;
        internal static dynamic ConstructOptimizationOptionsIMRT(System.Int32 maxIterations, ESAPIX.Facade.Types.OptimizationOption initialState, ESAPIX.Facade.Types.OptimizationConvergenceOption convergenceOption, System.String mlcId)
        {
            if (VMSConstructor.ConstructOptimizationOptionsIMRTFunc2 == null) { throw new NullReferenceException("The function ConstructOptimizationOptionsIMRTFunc2 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructOptimizationOptionsIMRTFunc2(maxIterations, initialState, convergenceOption, mlcId);
            });
        }
        public static Func<dynamic, System.String, dynamic> ConstructOptimizationOptionsVMATFunc0 = null;
        internal static dynamic ConstructOptimizationOptionsVMAT(ESAPIX.Facade.Types.OptimizationOption startOption, System.String mlcId)
        {
            if (VMSConstructor.ConstructOptimizationOptionsVMATFunc0 == null) { throw new NullReferenceException("The function ConstructOptimizationOptionsVMATFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructOptimizationOptionsVMATFunc0(startOption, mlcId);
            });
        }
        public static Func<dynamic, System.String, dynamic> ConstructOptimizationOptionsVMATFunc1 = null;
        internal static dynamic ConstructOptimizationOptionsVMAT(ESAPIX.Facade.Types.OptimizationIntermediateDoseOption intermediateDoseOption, System.String mlcId)
        {
            if (VMSConstructor.ConstructOptimizationOptionsVMATFunc1 == null) { throw new NullReferenceException("The function ConstructOptimizationOptionsVMATFunc1 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructOptimizationOptionsVMATFunc1(intermediateDoseOption, mlcId);
            });
        }
        public static Func<System.Int32, System.String, dynamic> ConstructOptimizationOptionsVMATFunc2 = null;
        internal static dynamic ConstructOptimizationOptionsVMAT(System.Int32 numberOfCycles, System.String mlcId)
        {
            if (VMSConstructor.ConstructOptimizationOptionsVMATFunc2 == null) { throw new NullReferenceException("The function ConstructOptimizationOptionsVMATFunc2 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructOptimizationOptionsVMATFunc2(numberOfCycles, mlcId);
            });
        }
        public static Func<dynamic, dynamic, System.Int32, System.String, dynamic> ConstructOptimizationOptionsVMATFunc3 = null;
        internal static dynamic ConstructOptimizationOptionsVMAT(ESAPIX.Facade.Types.OptimizationOption startOption, ESAPIX.Facade.Types.OptimizationIntermediateDoseOption intermediateDoseOption, System.Int32 numberOfCycles, System.String mlcId)
        {
            if (VMSConstructor.ConstructOptimizationOptionsVMATFunc3 == null) { throw new NullReferenceException("The function ConstructOptimizationOptionsVMATFunc3 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructOptimizationOptionsVMATFunc3(startOption, intermediateDoseOption, numberOfCycles, mlcId);
            });
        }
        public static Func<dynamic, dynamic> ConstructOptimizationOptionsVMATFunc4 = null;
        internal static dynamic ConstructOptimizationOptionsVMAT(ESAPIX.Facade.Types.OptimizationOptionsVMAT options)
        {
            if (VMSConstructor.ConstructOptimizationOptionsVMATFunc4 == null) { throw new NullReferenceException("The function ConstructOptimizationOptionsVMATFunc4 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructOptimizationOptionsVMATFunc4(options._client);
            });
        }
        public static Func<System.String, System.String, System.Int32, System.String, System.String, dynamic> ConstructExternalBeamMachineParametersFunc0 = null;
        internal static dynamic ConstructExternalBeamMachineParameters(System.String machineId, System.String energyModeId, System.Int32 doseRate, System.String techniqueId, System.String primaryFluenceModeId)
        {
            if (VMSConstructor.ConstructExternalBeamMachineParametersFunc0 == null) { throw new NullReferenceException("The function ConstructExternalBeamMachineParametersFunc0 has not been initialized. Try calling FacadeInitializer.Initialize() in ESAPIX.VMS before calling this method."); }
            return XContext.Instance.CurrentContext.GetValue(sc =>
            {
                return VMSConstructor.ConstructExternalBeamMachineParametersFunc0(machineId, energyModeId, doseRate, techniqueId, primaryFluenceModeId);
            });
        }
    }
}