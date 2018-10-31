using ESAPIX.Extensions;
using VMS.TPS.Common.Model.API;
using System.Linq;
using VMS.TPS.Common.Model.Types;
using static ESAPIX.Helpers.Strings.MagicStrings;

namespace ESAPIX.Constraints.DVH.Query
{
    /// <summary>
    /// Algorithms http://www.sciencedirect.com/science/article/pii/S0360301605027197
    /// </summary>
    public class TargetStats
    {
        /// <summary>
        /// Calculates the RTOG conformity index as isodose volume irradiated at reference dose (Body contour volume irradiated) 
        /// divided by the target volume. Does not necessarily mean the volumes are coincident!
        /// </summary>
        /// <param name="s">the target structure</param>
        /// <param name="pi">the planning item containing the dose</param>
        /// <param name="referenceDose">the reference isodose (eg. prescription dose)</param>
        /// <returns>RTOG conformity index</returns>
        public static double GetCI_RTOG(Structure s, PlanningItem pi, DoseValue referenceDose)
        {
            var external = pi.GetStructureSet()?.Structures.FirstOrDefault(st => st.DicomType == DICOMType.EXTERNAL);
            if (external == null) { return double.NaN; }
            var prescription_volIsodose = pi.GetVolumeAtDose(external, referenceDose, VolumePresentation.AbsoluteCm3);
            var target_vol = s.Volume;
            return prescription_volIsodose / target_vol;
        }

        /// Calculates the RTOG conformity index as isodose volume irradiated at reference dose (Body contour volume irradiated) 
        /// divided by the target volume. Does not necessarily mean the volumes are coincident!
        /// </summary>
        /// <param name="s">the target structure</param>
        /// <param name="pi">the planning item containing the dose</param>
        /// <param name="referenceDose">the reference isodose (eg. prescription dose)</param>
        /// <returns>RTOG conformity index</returns>
        public static double GetCI_RTOG(ESAPIX.Facade.API.Structure s, ESAPIX.Facade.API.PlanningItem pi, DoseValue referenceDose)
        {
            var external = pi.GetStructureSet()?.Structures.FirstOrDefault(st => st.DicomType == DICOMType.EXTERNAL);
            if (external == null) { return double.NaN; }
            var prescription_volIsodose = pi.GetVolumeAtDose(external, referenceDose, VolumePresentation.AbsoluteCm3);
            var target_vol = s.Volume;
            return prescription_volIsodose / target_vol;
        }


        /// <summary>
        /// Calculates the Paddick conformity index (PMID 11143252) as Paddick CI = (TVPIV)2 / (TV x PIV). 
        /// TVPIV = Target Volume covered by Prescription Isodose Volume
        ///TV = Target Volume
        ///PIV = Prescription Isodose Volume
        /// </summary>
        /// <param name="s">the target structure</param>
        /// <param name="pi">the planning item containing the dose</param>
        /// <param name="referenceDose">the reference isodose (eg. prescription dose)</param>
        /// <returns>RTOG conformity index</returns>
        public static double GetCI_Paddick(Structure s, PlanningItem pi, DoseValue referenceDose)
        {
            var external = pi.GetStructureSet()?.Structures.FirstOrDefault(st => st.DicomType == DICOMType.EXTERNAL);
            if (external == null) { return double.NaN; }
            var prescription_volIsodose = pi.GetVolumeAtDose(external, referenceDose, VolumePresentation.AbsoluteCm3);
            var target_volIsodose = pi.GetVolumeAtDose(s, referenceDose, VolumePresentation.AbsoluteCm3);
            var target_vol = s.Volume;
            return (target_volIsodose * target_volIsodose) / (target_vol * prescription_volIsodose);
        }

        /// Calculates the Paddick conformity index (PMID 11143252) as Paddick CI = (TVPIV)2 / (TV x PIV). 
        /// TVPIV = Target Volume covered by Prescription Isodose Volume
        ///TV = Target Volume
        ///PIV = Prescription Isodose Volume
        /// </summary>
        /// <param name="s">the target structure</param>
        /// <param name="pi">the planning item containing the dose</param>
        /// <param name="referenceDose">the reference isodose (eg. prescription dose)</param>
        /// <returns>RTOG conformity index</returns>
        public static double GetCI_Paddick(ESAPIX.Facade.API.Structure s, ESAPIX.Facade.API.PlanningItem pi, DoseValue referenceDose)
        {
            var external = pi.GetStructureSet()?.Structures.FirstOrDefault(st => st.DicomType == DICOMType.EXTERNAL);
            if (external == null) { return double.NaN; }
            var prescription_volIsodose = pi.GetVolumeAtDose(external, referenceDose, VolumePresentation.AbsoluteCm3);
            var target_volIsodose = pi.GetVolumeAtDose(s, referenceDose, VolumePresentation.AbsoluteCm3);
            var target_vol = s.Volume;
            return (target_volIsodose * target_volIsodose) / (target_vol * prescription_volIsodose);
        }
    }
}
