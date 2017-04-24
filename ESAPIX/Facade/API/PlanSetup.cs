using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class PlanSetup : ESAPIX.Facade.API.PlanningItem
    {
        public PlanSetup() { _client = new ExpandoObject(); }
        public PlanSetup(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public ESAPIX.Facade.Types.PlanSetupApprovalStatus ApprovalStatus
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ApprovalStatus; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.PlanSetupApprovalStatus>((sc) => { return (ESAPIX.Facade.Types.PlanSetupApprovalStatus)local._client.ApprovalStatus; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ApprovalStatus = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Beam> Beams
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.Beams;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.Beam();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
            }
        }
        public ESAPIX.Facade.API.Course Course
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Course; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Course>((sc) => { return new ESAPIX.Facade.API.Course(local._client.Course); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Course = value; }
            }
        }
        public System.String CreationUserName
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CreationUserName; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.CreationUserName; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CreationUserName = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.EstimatedDVH> DVHEstimates
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.DVHEstimates;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.EstimatedDVH();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
            }
        }
        public System.String ElectronCalculationModel
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ElectronCalculationModel; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ElectronCalculationModel; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ElectronCalculationModel = value; }
            }
        }
        public System.Collections.Generic.Dictionary<System.String, System.String> ElectronCalculationOptions
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ElectronCalculationOptions; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Collections.Generic.Dictionary<System.String, System.String>>((sc) => { return local._client.ElectronCalculationOptions; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ElectronCalculationOptions = value; }
            }
        }
        public System.Boolean IsDoseValid
        {
            get
            {
                if (_client is ExpandoObject) { return _client.IsDoseValid; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsDoseValid; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.IsDoseValid = value; }
            }
        }
        public System.Boolean IsTreated
        {
            get
            {
                if (_client is ExpandoObject) { return _client.IsTreated; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsTreated; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.IsTreated = value; }
            }
        }
        public ESAPIX.Facade.API.OptimizationSetup OptimizationSetup
        {
            get
            {
                if (_client is ExpandoObject) { return _client.OptimizationSetup; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.OptimizationSetup>((sc) => { return new ESAPIX.Facade.API.OptimizationSetup(local._client.OptimizationSetup); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.OptimizationSetup = value; }
            }
        }
        public System.String PhotonCalculationModel
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PhotonCalculationModel; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PhotonCalculationModel; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PhotonCalculationModel = value; }
            }
        }
        public System.Collections.Generic.Dictionary<System.String, System.String> PhotonCalculationOptions
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PhotonCalculationOptions; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Collections.Generic.Dictionary<System.String, System.String>>((sc) => { return local._client.PhotonCalculationOptions; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PhotonCalculationOptions = value; }
            }
        }
        public System.String PlanIntent
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PlanIntent; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PlanIntent; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PlanIntent = value; }
            }
        }
        public System.String PlanningApprovalDate
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PlanningApprovalDate; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PlanningApprovalDate; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PlanningApprovalDate = value; }
            }
        }
        public System.String PlanningApprover
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PlanningApprover; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PlanningApprover; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PlanningApprover = value; }
            }
        }
        public System.String PlanNormalizationMethod
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PlanNormalizationMethod; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PlanNormalizationMethod; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PlanNormalizationMethod = value; }
            }
        }
        public ESAPIX.Facade.Types.VVector PlanNormalizationPoint
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PlanNormalizationPoint; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.VVector>((sc) => { return new ESAPIX.Facade.Types.VVector(local._client.PlanNormalizationPoint); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PlanNormalizationPoint = value; }
            }
        }
        public ESAPIX.Facade.Types.PlanType PlanType
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PlanType; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.PlanType>((sc) => { return (ESAPIX.Facade.Types.PlanType)local._client.PlanType; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PlanType = value; }
            }
        }
        public System.Double PrescribedPercentage
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PrescribedPercentage; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.PrescribedPercentage; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PrescribedPercentage = value; }
            }
        }
        public ESAPIX.Facade.API.ReferencePoint PrimaryReferencePoint
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PrimaryReferencePoint; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.ReferencePoint>((sc) => { return new ESAPIX.Facade.API.ReferencePoint(local._client.PrimaryReferencePoint); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PrimaryReferencePoint = value; }
            }
        }
        public System.String ProtocolID
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ProtocolID; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ProtocolID; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ProtocolID = value; }
            }
        }
        public System.String ProtocolPhaseID
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ProtocolPhaseID; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ProtocolPhaseID; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ProtocolPhaseID = value; }
            }
        }
        public System.String ProtonCalculationModel
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ProtonCalculationModel; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ProtonCalculationModel; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ProtonCalculationModel = value; }
            }
        }
        public System.Collections.Generic.Dictionary<System.String, System.String> ProtonCalculationOptions
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ProtonCalculationOptions; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Collections.Generic.Dictionary<System.String, System.String>>((sc) => { return local._client.ProtonCalculationOptions; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ProtonCalculationOptions = value; }
            }
        }
        public ESAPIX.Facade.API.Series Series
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Series; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Series>((sc) => { return new ESAPIX.Facade.API.Series(local._client.Series); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Series = value; }
            }
        }
        public System.String SeriesUID
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SeriesUID; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.SeriesUID; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SeriesUID = value; }
            }
        }
        public ESAPIX.Facade.API.StructureSet StructureSet
        {
            get
            {
                if (_client is ExpandoObject) { return _client.StructureSet; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.StructureSet>((sc) => { return new ESAPIX.Facade.API.StructureSet(local._client.StructureSet); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.StructureSet = value; }
            }
        }
        public System.String TargetVolumeID
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TargetVolumeID; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.TargetVolumeID; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TargetVolumeID = value; }
            }
        }
        public ESAPIX.Facade.Types.DoseValue TotalPrescribedDose
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TotalPrescribedDose; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValue>((sc) => { return new ESAPIX.Facade.Types.DoseValue(local._client.TotalPrescribedDose); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TotalPrescribedDose = value; }
            }
        }
        public System.String TreatmentApprovalDate
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TreatmentApprovalDate; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.TreatmentApprovalDate; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TreatmentApprovalDate = value; }
            }
        }
        public System.String TreatmentApprover
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TreatmentApprover; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.TreatmentApprover; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TreatmentApprover = value; }
            }
        }
        public ESAPIX.Facade.Types.PatientOrientation TreatmentOrientation
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TreatmentOrientation; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.PatientOrientation>((sc) => { return (ESAPIX.Facade.Types.PatientOrientation)local._client.TreatmentOrientation; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TreatmentOrientation = value; }
            }
        }
        public System.String UID
        {
            get
            {
                if (_client is ExpandoObject) { return _client.UID; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.UID; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.UID = value; }
            }
        }
        public ESAPIX.Facade.API.Fractionation UniqueFractionation
        {
            get
            {
                if (_client is ExpandoObject) { return _client.UniqueFractionation; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Fractionation>((sc) => { return new ESAPIX.Facade.API.Fractionation(local._client.UniqueFractionation); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.UniqueFractionation = value; }
            }
        }
        public ESAPIX.Facade.API.PlanSetup VerifiedPlan
        {
            get
            {
                if (_client is ExpandoObject) { return _client.VerifiedPlan; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.PlanSetup>((sc) => { return new ESAPIX.Facade.API.PlanSetup(local._client.VerifiedPlan); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.VerifiedPlan = value; }
            }
        }
        public System.String Id
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Id; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Id; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Id = value; }
            }
        }
        public System.Double PlanNormalizationValue
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PlanNormalizationValue; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.PlanNormalizationValue; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PlanNormalizationValue = value; }
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