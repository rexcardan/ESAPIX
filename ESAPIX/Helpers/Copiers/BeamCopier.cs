#if VMS155
using System;
using System.Collections.Generic;
using System.Linq;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.Helpers.Copiers
{
    public class BeamCopier
    {
        public static void CopyBeamToPlan(Beam beam, ExternalPlanSetup plansetup, VVector isocenter)
        {
            string energyModeDisp = beam.EnergyModeDisplayName;
            Char[] sep = { '-' };
            string energyMode = energyModeDisp.Split(sep).First();
            string pfm = energyModeDisp.Split(sep).Count() > 1 ? energyModeDisp.Split(sep).Last() : null;

            ExternalBeamMachineParameters extParams = new ExternalBeamMachineParameters(beam.TreatmentUnit.Id, energyMode, beam.DoseRate, beam.Technique.Id, pfm);
            List<double> metersetWeights = GetControlPointWeights(beam);
            Beam copyBeam = null;

            if (beam.MLCPlanType == MLCPlanType.VMAT)
            {
                copyBeam = plansetup.AddVMATBeam(extParams, metersetWeights, beam.ControlPoints[0].CollimatorAngle, beam.ControlPoints[0].GantryAngle, beam.ControlPoints[beam.ControlPoints.Count - 1].GantryAngle,
                              beam.GantryDirection, beam.ControlPoints[0].PatientSupportAngle, isocenter);
            }
            else if (beam.MLCPlanType == MLCPlanType.ArcDynamic)
            {
                copyBeam = plansetup.AddConformalArcBeam(extParams, beam.ControlPoints[0].CollimatorAngle, beam.ControlPoints.Count, beam.ControlPoints[0].GantryAngle, beam.ControlPoints[beam.ControlPoints.Count - 1].GantryAngle,
                              beam.GantryDirection, beam.ControlPoints[0].PatientSupportAngle, isocenter);
            }
            else if (beam.MLCPlanType == MLCPlanType.DoseDynamic)
            {
                var cppPairs = metersetWeights.Zip(metersetWeights.Skip(1), (a, b) => new Tuple<double, double>(a, b)).ToList();
                var oddCppPairs = cppPairs.Where((p, i) => i % 2 == 1);

                if (metersetWeights.Count >= 4 && metersetWeights.Count % 2 == 0 && oddCppPairs.All(p => p.Item1 == p.Item2))
                {
                    copyBeam = plansetup.AddMultipleStaticSegmentBeam(extParams, metersetWeights, beam.ControlPoints[0].CollimatorAngle, beam.ControlPoints[0].GantryAngle, beam.ControlPoints[0].PatientSupportAngle, isocenter);
                }
                else
                {
                    copyBeam = plansetup.AddSlidingWindowBeam(extParams, metersetWeights, beam.ControlPoints[0].CollimatorAngle, beam.ControlPoints[0].GantryAngle, beam.ControlPoints[0].PatientSupportAngle, isocenter);
                }
            }
            else
            {
                throw new NotImplementedException("Copying this type of beam not implemented");
            }

            var beamParams = copyBeam.GetEditableParameters();
            CopyJawAndLeafPositions(beam, beamParams);
            beamParams.WeightFactor = beam.WeightFactor;

            copyBeam.ApplyParameters(beamParams);

            copyBeam.Id = beam.Id;
        }

        static List<double> GetControlPointWeights(Beam beam)
        {
            List<double> weights = new List<double>();
            foreach (var cp in beam.ControlPoints)
                weights.Add(cp.MetersetWeight);

            return weights;
        }

        static void CopyJawAndLeafPositions(Beam from, BeamParameters to)
        {
            IEnumerable<ControlPointParameters> cps = to.ControlPoints;
            int ix = 0;
            foreach (var cp in from.ControlPoints)
            {
                cps.ElementAt(ix).JawPositions = cp.JawPositions;
                cps.ElementAt(ix).LeafPositions = cp.LeafPositions;
                ix++;
            }
        }
    }
}
#endif