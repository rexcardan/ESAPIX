using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Facade.Types;

namespace ESAPIX.Facade
{

    public sealed class VMSConstructor
    {
        private static object syncRoot = new Object();
        private static volatile VMSConstructor instance;

        internal dynamic ConstructLMCVOptions(bool fixedJaws)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructLineProfile(VVector origin, VVector step, double[] data)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructDoseProfile(VVector origin, VVector step, double[] data, DoseValue.DoseUnit unit)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructSegmentProfilePoint(VVector position, bool value)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructFluence(float[,] fluenceMatrix, double xOrigin, double yOrigin, string mlcId)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructSmartLMCOptions(bool fixedFieldBorders, bool jawTracking)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructVRect<T>(T x1, T y1, T x2, T y2)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructOptimizationOptionsIMRT(int maxIterations, OptimizationOption initialState, OptimizationConvergenceOption convergenceOption, OptimizationIntermediateDoseOption intermediateDoseOption, string mlcId)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructLMCMSSOptions(int numberOfIterations)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructSegmentProfile(VVector origin, VVector step, BitArray data)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructImageProfile(VVector origin, VVector step, double[] data, string unit)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructOptimizationOptionsIMRT(int maxIterations, OptimizationOption initialState, int numberOfStepsBeforeIntermediateDose, OptimizationConvergenceOption convergenceOption, string mlcId)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructOptimizationOptionsVMAT(OptimizationOption startOption, string mlcId)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructFluence(float[,] fluenceMatrix, double xOrigin, double yOrigin)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructOptimizationOptionsVMAT(OptimizationIntermediateDoseOption intermediateDoseOption, string mlcId)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructOptimizationOptionsIMRT(int maxIterations, OptimizationOption initialState, OptimizationConvergenceOption convergenceOption, string mlcId)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructProfilePoint(VVector position, double value)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructOptimizationOptionsVMAT(OptimizationOption startOption, OptimizationIntermediateDoseOption intermediateDoseOption, int numberOfCycles, string mlcId)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructOptimizationOptionsVMAT(int numberOfCycles, string mlcId)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructExternalBeamMachineParameters(string machineId, string energyModeId, int doseRate, string techniqueId, string primaryFluenceModeId)
        {
            throw new NotImplementedException();
        }


        internal dynamic ConstructStructureCodeInfo(string codingScheme, string code)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructMetersetValue(double value, DosimeterUnit unit)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructOptimizationOptionsVMAT(OptimizationOptionsVMAT options)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructAxisAlignedMargins(StructureMarginGeometry geometry, double x1, double y1, double z1, double x2, double y2, double z2)
        {
            throw new NotImplementedException();
        }

        public dynamic ConstructScriptContext(System.Object context, System.Object user, System.String appName)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructDVHPoint(DoseValue dose, double volume, string volumeUnit)
        {
            throw new NotImplementedException();
        }

        internal dynamic ConstructVVector(params object[] input)
        {
            throw new NotImplementedException();
        }

        public dynamic ConstructDoseValue(double value, DoseValue.DoseUnit unit)
        {
            throw new NotImplementedException();
        }

        public dynamic ConstructDoseValue(double value, string unitName)
        {
            throw new NotImplementedException();
        }

        private VMSConstructor() { }

        public static VMSConstructor Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new VMSConstructor();
                    }
                }

                return instance;
            }
        }
    }
}
