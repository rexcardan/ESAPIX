#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using X = ESAPIX.Facade.XContext;

#endregion


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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public PlanSetupApprovalStatus ApprovalStatus
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ApprovalStatus")
                        ? _client.ApprovalStatus
                        : default(PlanSetupApprovalStatus);
                var local = this;
                return X.Instance.CurrentContext.GetValue<PlanSetupApprovalStatus>(sc =>
                {
                    return local._client.ApprovalStatus;
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
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Beams"))
                        foreach (var item in _client.Beams) yield return item;
                    else yield break;
                }
                else
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
            set
            {
                if (_client is ExpandoObject) _client.Beams = value;
            }
        }

        public Course Course
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Course") ? _client.Course : default(Course);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CreationUserName")
                        ? _client.CreationUserName
                        : default(string);
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
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("DVHEstimates"))
                        foreach (var item in _client.DVHEstimates) yield return item;
                    else yield break;
                }
                else
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
            set
            {
                if (_client is ExpandoObject) _client.DVHEstimates = value;
            }
        }

        public string ElectronCalculationModel
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ElectronCalculationModel")
                        ? _client.ElectronCalculationModel
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ElectronCalculationOptions")
                        ? _client.ElectronCalculationOptions
                        : default(Dictionary<string, string>);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("IsDoseValid") ? _client.IsDoseValid : default(bool);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("IsTreated") ? _client.IsTreated : default(bool);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("OptimizationSetup")
                        ? _client.OptimizationSetup
                        : default(OptimizationSetup);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PhotonCalculationModel")
                        ? _client.PhotonCalculationModel
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PhotonCalculationOptions")
                        ? _client.PhotonCalculationOptions
                        : default(Dictionary<string, string>);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PlanIntent") ? _client.PlanIntent : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PlanningApprovalDate")
                        ? _client.PlanningApprovalDate
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PlanningApprover")
                        ? _client.PlanningApprover
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PlanNormalizationMethod")
                        ? _client.PlanNormalizationMethod
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PlanNormalizationPoint")
                        ? _client.PlanNormalizationPoint
                        : default(VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue<VVector>(sc =>
                {
                    return local._client.PlanNormalizationPoint;
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PlanType") ? _client.PlanType : default(PlanType);
                var local = this;
                return X.Instance.CurrentContext.GetValue<PlanType>(sc => { return local._client.PlanType; });
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PrescribedPercentage")
                        ? _client.PrescribedPercentage
                        : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PrimaryReferencePoint")
                        ? _client.PrimaryReferencePoint
                        : default(ReferencePoint);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ProtocolID") ? _client.ProtocolID : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ProtocolPhaseID")
                        ? _client.ProtocolPhaseID
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ProtonCalculationModel")
                        ? _client.ProtonCalculationModel
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ProtonCalculationOptions")
                        ? _client.ProtonCalculationOptions
                        : default(Dictionary<string, string>);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Series") ? _client.Series : default(Series);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("SeriesUID") ? _client.SeriesUID : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("StructureSet")
                        ? _client.StructureSet
                        : default(StructureSet);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("TargetVolumeID")
                        ? _client.TargetVolumeID
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("TotalPrescribedDose")
                        ? _client.TotalPrescribedDose
                        : default(DoseValue);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DoseValue>(
                    sc => { return local._client.TotalPrescribedDose; });
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("TreatmentApprovalDate")
                        ? _client.TreatmentApprovalDate
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("TreatmentApprover")
                        ? _client.TreatmentApprover
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("TreatmentOrientation")
                        ? _client.TreatmentOrientation
                        : default(PatientOrientation);
                var local = this;
                return X.Instance.CurrentContext.GetValue<PatientOrientation>(sc =>
                {
                    return local._client.TreatmentOrientation;
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("UID") ? _client.UID : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("UniqueFractionation")
                        ? _client.UniqueFractionation
                        : default(Fractionation);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("VerifiedPlan")
                        ? _client.VerifiedPlan
                        : default(PlanSetup);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Id") ? _client.Id : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PlanNormalizationValue")
                        ? _client.PlanNormalizationValue
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(
                    sc => { return local._client.PlanNormalizationValue; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanNormalizationValue = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public void ClearCalculationModel(CalculationType calculationType)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.ClearCalculationModel(EnumConverter.Convert(calculationType));
            });
        }

        public string GetCalculationModel(CalculationType calculationType)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.GetCalculationModel(EnumConverter.Convert(calculationType));
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
                return local._client.GetDoseAtVolume(structure._client, volume,
                    EnumConverter.Convert(volumePresentation), EnumConverter.Convert(requestedDosePresentation));
            });
            return retVal;
        }

        public double GetVolumeAtDose(Structure structure, DoseValue dose,
            VolumePresentation requestedVolumePresentation)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.GetVolumeAtDose(structure._client, dose,
                    EnumConverter.Convert(requestedVolumePresentation));
            });
            return retVal;
        }

        public void SetCalculationModel(CalculationType calculationType, string model)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.SetCalculationModel(EnumConverter.Convert(calculationType), model);
            });
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