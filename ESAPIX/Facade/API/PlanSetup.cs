using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class PlanSetup : PlanningItem
    {
        public PlanSetup()
        {
            _client = new ExpandoObject();
        }

        public PlanSetup(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public PlanSetupApprovalStatus ApprovalStatus
        {
            get
            {
                if (_client is ExpandoObject) return _client.ApprovalStatus;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    return (PlanSetupApprovalStatus) local._client.ApprovalStatus;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ApprovalStatus = value;
            }
        }

        public IEnumerable<Beam> Beams
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.Beams;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new Beam();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                            facade._client = vms;
                    });
                    if (facade._client != null)
                        yield return facade;
                }
            }
        }

        public Course Course
        {
            get
            {
                if (_client is ExpandoObject) return _client.Course;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Course)) return default(Course);
                    return new Course(local._client.Course);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Course = value;
            }
        }

        public string CreationUserName
        {
            get
            {
                if (_client is ExpandoObject) return _client.CreationUserName;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.CreationUserName; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CreationUserName = value;
            }
        }

        public IEnumerable<EstimatedDVH> DVHEstimates
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.DVHEstimates;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new EstimatedDVH();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                            facade._client = vms;
                    });
                    if (facade._client != null)
                        yield return facade;
                }
            }
        }

        public string ElectronCalculationModel
        {
            get
            {
                if (_client is ExpandoObject) return _client.ElectronCalculationModel;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc =>
                {
                    return local._client.ElectronCalculationModel;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ElectronCalculationModel = value;
            }
        }

        public Dictionary<string, string> ElectronCalculationOptions
        {
            get
            {
                if (_client is ExpandoObject) return _client.ElectronCalculationOptions;
                var local = this;
                return X.Instance.CurrentContext.GetValue<Dictionary<string, string>>(sc =>
                {
                    return local._client.ElectronCalculationOptions;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ElectronCalculationOptions = value;
            }
        }

        public bool IsDoseValid
        {
            get
            {
                if (_client is ExpandoObject) return _client.IsDoseValid;
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.IsDoseValid; });
            }
            set
            {
                if (_client is ExpandoObject) _client.IsDoseValid = value;
            }
        }

        public bool IsTreated
        {
            get
            {
                if (_client is ExpandoObject) return _client.IsTreated;
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.IsTreated; });
            }
            set
            {
                if (_client is ExpandoObject) _client.IsTreated = value;
            }
        }

        public OptimizationSetup OptimizationSetup
        {
            get
            {
                if (_client is ExpandoObject) return _client.OptimizationSetup;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.OptimizationSetup)) return default(OptimizationSetup);
                    return new OptimizationSetup(local._client.OptimizationSetup);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.OptimizationSetup = value;
            }
        }

        public string PhotonCalculationModel
        {
            get
            {
                if (_client is ExpandoObject) return _client.PhotonCalculationModel;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(
                    sc => { return local._client.PhotonCalculationModel; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PhotonCalculationModel = value;
            }
        }

        public Dictionary<string, string> PhotonCalculationOptions
        {
            get
            {
                if (_client is ExpandoObject) return _client.PhotonCalculationOptions;
                var local = this;
                return X.Instance.CurrentContext.GetValue<Dictionary<string, string>>(sc =>
                {
                    return local._client.PhotonCalculationOptions;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.PhotonCalculationOptions = value;
            }
        }

        public string PlanIntent
        {
            get
            {
                if (_client is ExpandoObject) return _client.PlanIntent;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.PlanIntent; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanIntent = value;
            }
        }

        public string PlanningApprovalDate
        {
            get
            {
                if (_client is ExpandoObject) return _client.PlanningApprovalDate;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.PlanningApprovalDate; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanningApprovalDate = value;
            }
        }

        public string PlanningApprover
        {
            get
            {
                if (_client is ExpandoObject) return _client.PlanningApprover;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.PlanningApprover; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanningApprover = value;
            }
        }

        public string PlanNormalizationMethod
        {
            get
            {
                if (_client is ExpandoObject) return _client.PlanNormalizationMethod;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc =>
                {
                    return local._client.PlanNormalizationMethod;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanNormalizationMethod = value;
            }
        }

        public VVector PlanNormalizationPoint
        {
            get
            {
                if (_client is ExpandoObject) return _client.PlanNormalizationPoint;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.PlanNormalizationPoint)) return default(VVector);
                    return new VVector(local._client.PlanNormalizationPoint);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanNormalizationPoint = value;
            }
        }

        public PlanType PlanType
        {
            get
            {
                if (_client is ExpandoObject) return _client.PlanType;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc => { return (PlanType) local._client.PlanType; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanType = value;
            }
        }

        public double PrescribedPercentage
        {
            get
            {
                if (_client is ExpandoObject) return _client.PrescribedPercentage;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.PrescribedPercentage; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PrescribedPercentage = value;
            }
        }

        public ReferencePoint PrimaryReferencePoint
        {
            get
            {
                if (_client is ExpandoObject) return _client.PrimaryReferencePoint;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.PrimaryReferencePoint)) return default(ReferencePoint);
                    return new ReferencePoint(local._client.PrimaryReferencePoint);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.PrimaryReferencePoint = value;
            }
        }

        public string ProtocolID
        {
            get
            {
                if (_client is ExpandoObject) return _client.ProtocolID;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.ProtocolID; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ProtocolID = value;
            }
        }

        public string ProtocolPhaseID
        {
            get
            {
                if (_client is ExpandoObject) return _client.ProtocolPhaseID;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.ProtocolPhaseID; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ProtocolPhaseID = value;
            }
        }

        public string ProtonCalculationModel
        {
            get
            {
                if (_client is ExpandoObject) return _client.ProtonCalculationModel;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(
                    sc => { return local._client.ProtonCalculationModel; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ProtonCalculationModel = value;
            }
        }

        public Dictionary<string, string> ProtonCalculationOptions
        {
            get
            {
                if (_client is ExpandoObject) return _client.ProtonCalculationOptions;
                var local = this;
                return X.Instance.CurrentContext.GetValue<Dictionary<string, string>>(sc =>
                {
                    return local._client.ProtonCalculationOptions;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ProtonCalculationOptions = value;
            }
        }

        public Series Series
        {
            get
            {
                if (_client is ExpandoObject) return _client.Series;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Series)) return default(Series);
                    return new Series(local._client.Series);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Series = value;
            }
        }

        public string SeriesUID
        {
            get
            {
                if (_client is ExpandoObject) return _client.SeriesUID;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.SeriesUID; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SeriesUID = value;
            }
        }

        public StructureSet StructureSet
        {
            get
            {
                if (_client is ExpandoObject) return _client.StructureSet;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.StructureSet)) return default(StructureSet);
                    return new StructureSet(local._client.StructureSet);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.StructureSet = value;
            }
        }

        public string TargetVolumeID
        {
            get
            {
                if (_client is ExpandoObject) return _client.TargetVolumeID;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.TargetVolumeID; });
            }
            set
            {
                if (_client is ExpandoObject) _client.TargetVolumeID = value;
            }
        }

        public DoseValue TotalPrescribedDose
        {
            get
            {
                if (_client is ExpandoObject) return _client.TotalPrescribedDose;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.TotalPrescribedDose)) return default(DoseValue);
                    return new DoseValue(local._client.TotalPrescribedDose);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.TotalPrescribedDose = value;
            }
        }

        public string TreatmentApprovalDate
        {
            get
            {
                if (_client is ExpandoObject) return _client.TreatmentApprovalDate;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc =>
                {
                    return local._client.TreatmentApprovalDate;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.TreatmentApprovalDate = value;
            }
        }

        public string TreatmentApprover
        {
            get
            {
                if (_client is ExpandoObject) return _client.TreatmentApprover;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.TreatmentApprover; });
            }
            set
            {
                if (_client is ExpandoObject) _client.TreatmentApprover = value;
            }
        }

        public PatientOrientation TreatmentOrientation
        {
            get
            {
                if (_client is ExpandoObject) return _client.TreatmentOrientation;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    return (PatientOrientation) local._client.TreatmentOrientation;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.TreatmentOrientation = value;
            }
        }

        public string UID
        {
            get
            {
                if (_client is ExpandoObject) return _client.UID;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.UID; });
            }
            set
            {
                if (_client is ExpandoObject) _client.UID = value;
            }
        }

        public Fractionation UniqueFractionation
        {
            get
            {
                if (_client is ExpandoObject) return _client.UniqueFractionation;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.UniqueFractionation)) return default(Fractionation);
                    return new Fractionation(local._client.UniqueFractionation);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.UniqueFractionation = value;
            }
        }

        public PlanSetup VerifiedPlan
        {
            get
            {
                if (_client is ExpandoObject) return _client.VerifiedPlan;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.VerifiedPlan)) return default(PlanSetup);
                    return new PlanSetup(local._client.VerifiedPlan);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.VerifiedPlan = value;
            }
        }

        public string Id
        {
            get
            {
                if (_client is ExpandoObject) return _client.Id;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Id; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Id = value;
            }
        }

        public double PlanNormalizationValue
        {
            get
            {
                if (_client is ExpandoObject) return _client.PlanNormalizationValue;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(
                    sc => { return local._client.PlanNormalizationValue; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanNormalizationValue = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public void ClearCalculationModel(CalculationType calculationType)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.ClearCalculationModel(calculationType); });
        }

        public string GetCalculationModel(CalculationType calculationType)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.GetCalculationModel(calculationType);
            });
            return retVal;
        }

        public bool GetCalculationOption(string calculationModel, string optionName, out string optionValue)
        {
            var optionValue_OUT = default(string);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.GetCalculationOption(calculationModel, optionName, out optionValue_OUT);
            });
            optionValue = optionValue_OUT;
            return retVal;
        }

        public Dictionary<string, string> GetCalculationOptions(string calculationModel)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.GetCalculationOptions(calculationModel);
            });
            return retVal;
        }

        public DoseValue GetDoseAtVolume(Structure structure, double volume, VolumePresentation volumePresentation,
            DoseValuePresentation requestedDosePresentation)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new DoseValue(local._client.GetDoseAtVolume(structure._client, volume, volumePresentation,
                    requestedDosePresentation));
            });
            return retVal;
        }

        public double GetVolumeAtDose(Structure structure, DoseValue dose,
            VolumePresentation requestedVolumePresentation)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.GetVolumeAtDose(structure._client, dose._client, requestedVolumePresentation);
            });
            return retVal;
        }

        public void SetCalculationModel(CalculationType calculationType, string model)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(
                () => { local._client.SetCalculationModel(calculationType, model); });
        }

        public bool SetCalculationOption(string calculationModel, string optionName, string optionValue)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.SetCalculationOption(calculationModel, optionName, optionValue);
            });
            return retVal;
        }
    }
}