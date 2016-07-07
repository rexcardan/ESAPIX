using System;
using System.Collections.Generic;
using System.Reflection;
using ESAPIX.Enums;
using ESAPIX.Interfaces;
using ESAPIX.Types;

namespace ESAPIX.Fakes
{
    public class PlanSetup : PlanningItem, IPlanSetup
    {
        public string UID { get; set; }

        public bool IsTreated { get; set; }

        public string CreationUserName { get; set; }

        public string PlanNormalizationMethod { get; set; }

        public VVector PlanNormalizationPoint { get; set; }

        public string ProtocolID { get; set; }

        public string ProtocolPhaseID { get; set; }

        public string TargetVolumeID { get; set; }

        public ICourse Course
        {
             get; set; 
        }

        public IEnumerable<IBeam> Beams
        {
            get; set; 
        }

        public IStructureSet StructureSet
        {
            get; set; 
        }

        public bool IsDoseValid { get; set; }

        public PlanSetupApprovalStatus ApprovalStatus { get; set; }

        public string PlanningApprovalDate { get; set; }

        public string PlanningApprover { get; set; }

        public string TreatmentApprovalDate { get; set; }

        public string TreatmentApprover { get; set; }

        public double PrescribedPercentage { get; set; }

        public DoseValue TotalPrescribedDose { get; set; }

        public IFractionation UniqueFractionation
        {
           get; set; 
        }

        public IReferencePoint PrimaryReferencePoint
        {
            get;
            set; 
        }

        public string ElectronCalculationModel { get; set; }

        public Dictionary<string, string> ElectronCalculationOptions { get; set; }

        public string PhotonCalculationModel { get; set; }

        public Dictionary<string, string> PhotonCalculationOptions { get; set; }

        public string ProtonCalculationModel { get; set; }

        public Dictionary<string, string> ProtonCalculationOptions { get; set; }

        public PatientOrientation TreatmentOrientation { get; set; }
    }
}