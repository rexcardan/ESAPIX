using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class PlanSetup : ESAPIX.Facade.API.PlanningItem
    {
        public PlanSetup() { }
        public PlanSetup(dynamic client) { _client = client; }
        public ESAPIX.Facade.Types.PlanSetupApprovalStatus ApprovalStatus
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.PlanSetupApprovalStatus)local._client.ApprovalStatus;
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Beam> Beams
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.Beam>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.Beams).Select(s => new ESAPIX.Facade.API.Beam(s));
                });
            }
        }
        public ESAPIX.Facade.API.Course Course
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Course(local._client.Course);
            }
        }
        public System.String CreationUserName
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.CreationUserName; });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.EstimatedDVH> DVHEstimates
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.EstimatedDVH>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.DVHEstimates).Select(s => new ESAPIX.Facade.API.EstimatedDVH(s));
                });
            }
        }
        public System.String ElectronCalculationModel
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ElectronCalculationModel; });
            }
        }
        public System.Collections.Generic.Dictionary<System.String, System.String> ElectronCalculationOptions
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Collections.Generic.Dictionary<System.String, System.String>>((sc) => { return local._client.ElectronCalculationOptions; });
            }
        }
        public System.Boolean IsDoseValid
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsDoseValid; });
            }
        }
        public System.Boolean IsTreated
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsTreated; });
            }
        }
        public ESAPIX.Facade.API.OptimizationSetup OptimizationSetup
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.OptimizationSetup(local._client.OptimizationSetup);
            }
        }
        public System.String PhotonCalculationModel
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PhotonCalculationModel; });
            }
        }
        public System.Collections.Generic.Dictionary<System.String, System.String> PhotonCalculationOptions
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Collections.Generic.Dictionary<System.String, System.String>>((sc) => { return local._client.PhotonCalculationOptions; });
            }
        }
        public System.String PlanIntent
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PlanIntent; });
            }
        }
        public System.String PlanningApprovalDate
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PlanningApprovalDate; });
            }
        }
        public System.String PlanningApprover
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PlanningApprover; });
            }
        }
        public System.String PlanNormalizationMethod
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PlanNormalizationMethod; });
            }
        }
        public ESAPIX.Facade.Types.VVector PlanNormalizationPoint
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.PlanNormalizationPoint);
            }
        }
        public ESAPIX.Facade.Types.PlanType PlanType
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.PlanType)local._client.PlanType;
            }
        }
        public System.Double PrescribedPercentage
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.PrescribedPercentage; });
            }
        }
        public ESAPIX.Facade.API.ReferencePoint PrimaryReferencePoint
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.ReferencePoint(local._client.PrimaryReferencePoint);
            }
        }
        public System.String ProtocolID
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ProtocolID; });
            }
        }
        public System.String ProtocolPhaseID
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ProtocolPhaseID; });
            }
        }
        public System.String ProtonCalculationModel
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ProtonCalculationModel; });
            }
        }
        public System.Collections.Generic.Dictionary<System.String, System.String> ProtonCalculationOptions
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Collections.Generic.Dictionary<System.String, System.String>>((sc) => { return local._client.ProtonCalculationOptions; });
            }
        }
        public ESAPIX.Facade.API.Series Series
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Series(local._client.Series);
            }
        }
        public System.String SeriesUID
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.SeriesUID; });
            }
        }
        public ESAPIX.Facade.API.StructureSet StructureSet
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.StructureSet(local._client.StructureSet);
            }
        }
        public System.String TargetVolumeID
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.TargetVolumeID; });
            }
        }
        public ESAPIX.Facade.Types.DoseValue TotalPrescribedDose
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.DoseValue(local._client.TotalPrescribedDose);
            }
        }
        public System.String TreatmentApprovalDate
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.TreatmentApprovalDate; });
            }
        }
        public System.String TreatmentApprover
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.TreatmentApprover; });
            }
        }
        public ESAPIX.Facade.Types.PatientOrientation TreatmentOrientation
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.PatientOrientation)local._client.TreatmentOrientation;
            }
        }
        public System.String UID
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.UID; });
            }
        }
        public ESAPIX.Facade.API.Fractionation UniqueFractionation
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Fractionation(local._client.UniqueFractionation);
            }
        }
        public ESAPIX.Facade.API.PlanSetup VerifiedPlan
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.PlanSetup(local._client.VerifiedPlan);
            }
        }
        public System.String Id
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Id; });
            }
        }
        public System.Double PlanNormalizationValue
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.PlanNormalizationValue; });
            }
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
        public void ClearCalculationModel(ESAPIX.Facade.Types.CalculationType calculationType)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.ClearCalculationModel((ESAPIX.Facade.Types.CalculationType)calculationType);
            });

        }
        public System.String GetCalculationModel(ESAPIX.Facade.Types.CalculationType calculationType)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetCalculationModel((ESAPIX.Facade.Types.CalculationType)calculationType); });
            return retVal;

        }
        public System.Boolean GetCalculationOption(System.String calculationModel, System.String optionName, out System.String optionValue)
        {
            var optionValue_OUT = default(System.String);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetCalculationOption(calculationModel, optionName, out optionValue_OUT); });
            optionValue = optionValue_OUT;
            return retVal;

        }
        public System.Collections.Generic.Dictionary<System.String, System.String> GetCalculationOptions(System.String calculationModel)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetCalculationOptions(calculationModel); });
            return retVal;

        }
        public ESAPIX.Facade.Types.DoseValue GetDoseAtVolume(ESAPIX.Facade.API.Structure structure, System.Double volume, ESAPIX.Facade.Types.VolumePresentation volumePresentation, ESAPIX.Facade.Types.DoseValuePresentation requestedDosePresentation)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.Types.DoseValue(local._client.GetDoseAtVolume(structure._client, volume, (ESAPIX.Facade.Types.VolumePresentation)volumePresentation, (ESAPIX.Facade.Types.DoseValuePresentation)requestedDosePresentation)); });
            return retVal;

        }
        public System.Double GetVolumeAtDose(ESAPIX.Facade.API.Structure structure, ESAPIX.Facade.Types.DoseValue dose, ESAPIX.Facade.Types.VolumePresentation requestedVolumePresentation)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetVolumeAtDose(structure._client, dose._client, (ESAPIX.Facade.Types.VolumePresentation)requestedVolumePresentation); });
            return retVal;

        }
        public void SetCalculationModel(ESAPIX.Facade.Types.CalculationType calculationType, System.String model)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.SetCalculationModel((ESAPIX.Facade.Types.CalculationType)calculationType, model);
            });

        }
        public System.Boolean SetCalculationOption(System.String calculationModel, System.String optionName, System.String optionValue)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.SetCalculationOption(calculationModel, optionName, optionValue); });
            return retVal;

        }
    }
}