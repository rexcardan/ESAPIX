using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.Extensions
{
    public static class BeamExtensions
    {
        /// <summary>
        /// Aligns beam isocenter to within the nearest mm to structure midpoint (not "weighted" center).
        /// </summary>
        /// <param name="beam">beam in which isocenter will be set</param>
        /// <param name="str">the structure in which the center will be used</param>
        public static void AlignToStructureMidpoint(this Beam beam, Structure str)
        {
            var beamParams = beam.GetEditableParameters();
            var midpoint = str.GetMidpoint();
            var rounded = new VVector(Math.Round(midpoint.x), Math.Round(midpoint.y), Math.Round(midpoint.z));
            beamParams.Isocenter = rounded;
            beam.ApplyParameters(beamParams);
        }

        /// <summary>
        /// Aligns beam isocenter to within the nearest mm to structure midpoint (not "weighted" center).
        /// </summary>
        /// <param name="beam">beam in which isocenter will be set</param>
        /// <param name="str">the structure in which the center will be used</param>
        public static void AlignToStructureMidpoint(this IonBeam beam, Structure str)
        {
            var beamParams = beam.GetEditableParameters();
            var midpoint = str.GetMidpoint();
            var rounded = new VVector(Math.Round(midpoint.x), Math.Round(midpoint.y), Math.Round(midpoint.z));
            beamParams.Isocenter = rounded;
            beam.ApplyParameters(beamParams);
        }

        /// <summary>
        /// Aligns beam isocenter to within the nearest mm.
        /// </summary>
        /// <param name="beam">beam in which isocenter will be set</param>
        /// <param name="str">the structure in which the center will be used</param>
        public static void AlignToStructureCenter(this Beam beam, Structure str)
        {
            var beamParams = beam.GetEditableParameters();
            var rounded = new VVector(Math.Round(str.CenterPoint.x), Math.Round(str.CenterPoint.x), Math.Round(str.CenterPoint.x));
            beamParams.Isocenter = rounded;
            beam.ApplyParameters(beamParams);
        }

        /// <summary>
        /// Aligns beam isocenter to within the nearest mm.
        /// </summary>
        /// <param name="beam">beam in which isocenter will be set</param>
        /// <param name="str">the structure in which the center will be used</param>
        public static void AlignToStructureCenter(this IonBeam beam, Structure str)
        {
            var beamParams = beam.GetEditableParameters();
            var rounded = new VVector(Math.Round(str.CenterPoint.x), Math.Round(str.CenterPoint.x), Math.Round(str.CenterPoint.x));
            beamParams.Isocenter = rounded;
            beam.ApplyParameters(beamParams);
        }
    }
}
