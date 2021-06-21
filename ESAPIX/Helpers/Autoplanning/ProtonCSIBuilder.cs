using ESAPIX.Common;
using ESAPIX.Extensions;
using System;
using System.Windows.Media;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using static ESAPIX.Helpers.Strings.MagicStrings;

namespace ESAPIX.Helpers.Autoplanning
{
    /// <summary>
    /// Structure building techinique for auto gradients using robust optimization from
    /// Cancers (Basel). 2018 Jan 3;10(1):7. doi: 10.3390/cancers10010007.
    /// </summary>
    public class ProtonCSIBuilder
    {
        public static string CTV_BRAIN { get; set; } = "_ctv brain";
        public static string CTV_UPP { get; set; } = "_ctv upp";
        public static string CTV_LOW { get; set; } = "_ctv low";
        public static string OTV_BRAIN { get; set; } = "_otv brain";
        public static string OTV_UPP { get; set; } = "_otv upp";
        public static string OTV_LOW { get; set; } = "_otv low";

        /// <summary>
        /// How much the CTV should overlap in the DICOM Z direction
        /// </summary>
        public static int FieldOverlapmm { get; set; } = 60;

        /// <summary>
        /// The longest field size to allow in BEV Y direction (DICOM Z)
        /// </summary>
        public static int MaxFieldSizeYmm { get; set; } = 350;

        public static void CreateStructures(StructureSet ss)
        {
            var ui = new ConsoleUI();
            //Required Structures - Need CTV which encompasses brain and cord
            if (ss.Find("CTV") == null) { ui.WriteError("No CTV exists"); return; }
            //Required Structures - Need Brain separately contoured
            if (ss.Find("Brain") == null) { ui.WriteError("No Brain exists"); return; }

            //Control structures
            ss.CreateOrResetStructure(CTV_LOW, DICOMType.CONTROL);
            ss.CreateOrResetStructure(CTV_UPP, DICOMType.CONTROL);
            ss.CreateOrResetStructure(CTV_BRAIN, DICOMType.CONTROL);
            ss.CreateOrResetStructure(OTV_LOW, DICOMType.CONTROL);
            ss.CreateOrResetStructure(OTV_UPP, DICOMType.CONTROL);
            ss.CreateOrResetStructure(OTV_BRAIN, DICOMType.CONTROL);

            //Get bounding Zs-physician drawn CTV, brain
            var minZCTV = ss.Find("CTV").MeshGeometry.Bounds.Z;
            var minZBrain = ss.Find("Brain").MeshGeometry.Bounds.Z - 10; // add 1cm toward spine
            var maxZBrain = ss.Find("Brain").MeshGeometry.Bounds.Z + ss.Find("Brain").MeshGeometry.Bounds.SizeZ;

            //Determine how many spine fields are needed
            var totalSpineLength = (minZBrain) - minZCTV;
            var nSpineFieldsRequired = (int)Math.Ceiling((totalSpineLength) / MaxFieldSizeYmm);
            var spinePartLength = totalSpineLength / nSpineFieldsRequired;

            //Create control CTVs
            ui.Write("Creating CTV Brain...");
            ss.Find(CTV_BRAIN).CopyStructureInBounds(ss.Find("CTV"), ss.Image, (minZBrain - FieldOverlapmm, maxZBrain));
            if (nSpineFieldsRequired == 1)
            {
                ui.Write("Creating CTV Upper...");
                ss.Find(CTV_UPP).CopyStructureInBounds(ss.Find("CTV"), ss.Image, (minZBrain - spinePartLength, minZBrain));
            }
            else if (nSpineFieldsRequired > 1)
            {
                ui.Write("Creating CTV Upper...");
                ss.Find(CTV_UPP).CopyStructureInBounds(ss.Find("CTV"), ss.Image, (minZBrain - spinePartLength - FieldOverlapmm / 2, minZBrain));
                ui.Write("Creating CTV Lower...");
                ss.Find(CTV_LOW).CopyStructureInBounds(ss.Find("CTV"), ss.Image, (minZCTV, minZBrain - spinePartLength + FieldOverlapmm / 2));
            }

            //Expand to OTV (spine fields only - 4mm circumferential and 1cm longitudinally)
            var sMargin = new AxisAlignedMargins(StructureMarginGeometry.Outer, 4, 4, 10, 4, 4, 10);
            ui.Write("Building OTVs...");
            ss.Find(OTV_UPP).SegmentVolume = ss.Find(CTV_UPP).AsymmetricMargin(sMargin);
            if (nSpineFieldsRequired > 1)
            {
                ss.Find(OTV_LOW).SegmentVolume = ss.Find(CTV_LOW).AsymmetricMargin(sMargin);
            }

            //We don't want to do margin on the brain structure...just the part of the brain CTV containing the cord/brainstem
            ss.Find(OTV_BRAIN).SegmentVolume = ss.Find(CTV_BRAIN).SegmentVolume
                .Sub(ss.Find("Brain").SegmentVolume.Margin(3))//CTV-Brain
                .AsymmetricMargin(sMargin)//4mm/1cm
                .Or(ss.Find(CTV_BRAIN).SegmentVolume.Margin(3)); //combine margined cord with non-margin brain

            //Clean up - remove unneccesary spine targets if not required
            if (nSpineFieldsRequired == 1)
            {
                ss.RemoveStructure(ss.Find(CTV_LOW));
                ss.RemoveStructure(ss.Find(OTV_LOW));
            }
            //Set colors for easier visibility
            ss.Find(OTV_BRAIN).Color = Colors.Blue;
            ss.Find(OTV_UPP).Color = Colors.Yellow;
            ss.Find(OTV_LOW).Color = Colors.Red;
        }

        public static void AddOptimizationGoals(IonPlanSetup ion)
        {
            ion.AddObjective("CTV", "D100%[cGy] >= 3600", 200);
            ion.AddObjective("CTV", "Max[cGy] < 3780", 250);
            ion.AddObjective(OTV_BRAIN, "D100%[cGy] >= 3600", 200);
            ion.AddObjective(OTV_BRAIN, "Max[cGy] < 3780", 250);
            ion.AddObjective(OTV_UPP, "D100%[cGy] >= 3600", 200);
            ion.AddObjective(OTV_UPP, "Max[cGy] < 3780", 250);
            ion.AddObjective(OTV_LOW, "D100%[cGy] >= 3600", 200);
            ion.AddObjective(OTV_LOW, "Max[cGy] < 3780", 250);
            ion.AddObjective("Larynx", "Mean[cGy] < 1000", 80);
            ion.AddObjective("Lens_L", "Max[cGy] < 1000", 50);
            ion.AddObjective("Lens_R", "Max[cGy] < 1000", 50);
            ion.AddObjective("Eye_R", "Max[cGy] < 3000", 60);
            ion.AddObjective("Eye_R", "Mean[cGy] < 1700", 60);
            ion.AddObjective("Eye_L", "Max[cGy] < 3000", 60);
            ion.AddObjective("Eye_L", "Mean[cGy] < 1700", 60);
            ion.AddObjective("Cochlea_L", "Mean[cGy] < 3150", 80);
            ion.AddObjective("Cochlea_R", "Mean[cGy] < 3150", 80);
            ion.AddObjective("Pharynx", "Mean[cGy] < 1600", 60);
        }

        public static void AddBeams(IonPlanSetup ion, VMS.TPS.Common.Model.Types.ProtonBeamMachineParameters mParams, string snoutID, string rsId)
        {
            var ss = ion.StructureSet;
            var f1 = (IonBeam)ion.AddModulatedScanningBeam(mParams, snoutID, 42, 120, 0, ss.Find(CTV_BRAIN).CenterPoint);
            var ibp = f1.GetEditableParameters();
            ibp.TargetStructure = ss.Find(OTV_BRAIN);
            ibp.PreSelectedRangeShifter1Id = rsId;
            f1.ApplyParameters(ibp);
            f1.DistalTargetMargin = 10;
            f1.ProximalTargetMargin = 8;
            f1.LateralMargins = new VRect<double>(7, 7, 7, 7);

            var f2 = (IonBeam)ion.AddModulatedScanningBeam(mParams, snoutID, 42, 240, 0, ss.Find(OTV_BRAIN).GetMidpoint());
            ibp = f2.GetEditableParameters();
            ibp.PreSelectedRangeShifter1Id = rsId;
            ibp.TargetStructure = ss.Find(OTV_BRAIN);
            f2.ApplyParameters(ibp);
            f2.DistalTargetMargin = 10;
            f2.ProximalTargetMargin = 8;
            f1.LateralMargins = new VRect<double>(7, 7, 7, 7);

            var f3 = (IonBeam)ion.AddModulatedScanningBeam(mParams, snoutID, 42, 180.1, 0, ss.Find(OTV_UPP).GetMidpoint());
            ibp = f3.GetEditableParameters();
            ibp.PreSelectedRangeShifter1Id = rsId;
            ibp.TargetStructure = ss.Find(OTV_UPP);
            f3.ApplyParameters(ibp);
            f3.DistalTargetMargin = 10;
            f3.ProximalTargetMargin = 8;
            f1.LateralMargins = new VRect<double>(7, 0, 7, 0);

            if (ss.Find(CTV_LOW) != null)
            {
                var f4 = (IonBeam)ion.AddModulatedScanningBeam(mParams, snoutID, 42, 180.1, 0, ss.Find(OTV_LOW).GetMidpoint());
                ibp = f4.GetEditableParameters();
                ibp.PreSelectedRangeShifter1Id = rsId;
                ibp.TargetStructure = ss.Find(OTV_LOW);
                f4.ApplyParameters(ibp);
                f4.DistalTargetMargin = 10;
                f4.ProximalTargetMargin = 8;
                f1.LateralMargins = new VRect<double>(7, 0, 7, 0);
            }
        }
    }
}
