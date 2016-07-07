using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Enums;
using ESAPIX.Types;

namespace ESAPIX.Interfaces
{
    public interface IPlanSetup : IPlanningItem
    {
        string UID { get; }

        bool IsTreated { get; }

        string CreationUserName { get; }

        string PlanNormalizationMethod { get; }

        VVector PlanNormalizationPoint { get; }

        string ProtocolID { get; }

        string ProtocolPhaseID { get; }

        string TargetVolumeID { get; }

        ICourse Course { get; }

        IEnumerable<IBeam> Beams { get; }

        IStructureSet StructureSet { get; }
        bool IsDoseValid { get; }

        PlanSetupApprovalStatus ApprovalStatus { get; }

        string PlanningApprovalDate { get; }

        string PlanningApprover { get; }

        string TreatmentApprovalDate { get; }

        string TreatmentApprover { get; }

        double PrescribedPercentage { get; }

        DoseValue TotalPrescribedDose { get; }

        IFractionation UniqueFractionation { get; }

        IReferencePoint PrimaryReferencePoint { get; }

        string ElectronCalculationModel { get; }

        Dictionary<string, string> ElectronCalculationOptions { get; }

        string PhotonCalculationModel { get; }

        Dictionary<string, string> PhotonCalculationOptions { get; }

        string ProtonCalculationModel { get; }

        Dictionary<string, string> ProtonCalculationOptions { get; }

        PatientOrientation TreatmentOrientation { get; }
    }
}
