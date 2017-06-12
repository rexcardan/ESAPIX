#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class PlanSetup : PlanningItem, System.Xml.Serialization.IXmlSerializable
    {
        public PlanSetup()
        {
            _client = new ExpandoObject();
        }

        public PlanSetup(dynamic client)
        {
            _client = client;
        }

        public PlanSetupApprovalStatus ApprovalStatus
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ApprovalStatus"))
                        return _client.ApprovalStatus;
                    else
                        return default(PlanSetupApprovalStatus);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ApprovalStatus; }
                    );
                return default(PlanSetupApprovalStatus);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ApprovalStatus = value;
            }
        }

        public IEnumerable<Beam> Beams
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Beams"))
                        foreach (var item in _client.Beams)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Beams;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Beam();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Beams = value;
            }
        }

        public Course Course
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Course"))
                        return _client.Course;
                    else
                        return default(Course);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Course != null)
                                return new Course(_client.Course);
                            return null;
                        }
                    );
                return default(Course);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Course = value;
            }
        }

        public string CreationUserName
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CreationUserName"))
                        return _client.CreationUserName;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CreationUserName; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CreationUserName = value;
            }
        }

        public IEnumerable<EstimatedDVH> DVHEstimates
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("DVHEstimates"))
                        foreach (var item in _client.DVHEstimates)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.DVHEstimates;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new EstimatedDVH();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.DVHEstimates = value;
            }
        }

        public string ElectronCalculationModel
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ElectronCalculationModel"))
                        return _client.ElectronCalculationModel;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ElectronCalculationModel; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ElectronCalculationModel = value;
            }
        }

        public Dictionary<string, string> ElectronCalculationOptions
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ElectronCalculationOptions"))
                        return _client.ElectronCalculationOptions;
                    else
                        return default(Dictionary<string, string>);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ElectronCalculationOptions; }
                    );
                return default(Dictionary<string, string>);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ElectronCalculationOptions = value;
            }
        }

        public bool IsDoseValid
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("IsDoseValid"))
                        return _client.IsDoseValid;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.IsDoseValid; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.IsDoseValid = value;
            }
        }

        public bool IsTreated
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("IsTreated"))
                        return _client.IsTreated;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.IsTreated; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.IsTreated = value;
            }
        }

        public OptimizationSetup OptimizationSetup
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("OptimizationSetup"))
                        return _client.OptimizationSetup;
                    else
                        return default(OptimizationSetup);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.OptimizationSetup != null)
                                return new OptimizationSetup(_client.OptimizationSetup);
                            return null;
                        }
                    );
                return default(OptimizationSetup);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.OptimizationSetup = value;
            }
        }

        public string PhotonCalculationModel
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PhotonCalculationModel"))
                        return _client.PhotonCalculationModel;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PhotonCalculationModel; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PhotonCalculationModel = value;
            }
        }

        public Dictionary<string, string> PhotonCalculationOptions
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PhotonCalculationOptions"))
                        return _client.PhotonCalculationOptions;
                    else
                        return default(Dictionary<string, string>);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PhotonCalculationOptions; }
                    );
                return default(Dictionary<string, string>);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PhotonCalculationOptions = value;
            }
        }

        public string PlanIntent
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PlanIntent"))
                        return _client.PlanIntent;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PlanIntent; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PlanIntent = value;
            }
        }

        public string PlanningApprovalDate
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PlanningApprovalDate"))
                        return _client.PlanningApprovalDate;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PlanningApprovalDate; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PlanningApprovalDate = value;
            }
        }

        public string PlanningApprover
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PlanningApprover"))
                        return _client.PlanningApprover;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PlanningApprover; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PlanningApprover = value;
            }
        }

        public string PlanNormalizationMethod
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PlanNormalizationMethod"))
                        return _client.PlanNormalizationMethod;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PlanNormalizationMethod; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PlanNormalizationMethod = value;
            }
        }

        public VVector PlanNormalizationPoint
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PlanNormalizationPoint"))
                        return _client.PlanNormalizationPoint;
                    else
                        return default(VVector);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PlanNormalizationPoint; }
                    );
                return default(VVector);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PlanNormalizationPoint = value;
            }
        }

        public PlanType PlanType
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PlanType"))
                        return _client.PlanType;
                    else
                        return default(PlanType);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PlanType; }
                    );
                return default(PlanType);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PlanType = value;
            }
        }

        public double PrescribedPercentage
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PrescribedPercentage"))
                        return _client.PrescribedPercentage;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PrescribedPercentage; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PrescribedPercentage = value;
            }
        }

        public ReferencePoint PrimaryReferencePoint
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PrimaryReferencePoint"))
                        return _client.PrimaryReferencePoint;
                    else
                        return default(ReferencePoint);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.PrimaryReferencePoint != null)
                                return new ReferencePoint(_client.PrimaryReferencePoint);
                            return null;
                        }
                    );
                return default(ReferencePoint);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PrimaryReferencePoint = value;
            }
        }

        public string ProtocolID
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ProtocolID"))
                        return _client.ProtocolID;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ProtocolID; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ProtocolID = value;
            }
        }

        public string ProtocolPhaseID
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ProtocolPhaseID"))
                        return _client.ProtocolPhaseID;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ProtocolPhaseID; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ProtocolPhaseID = value;
            }
        }

        public string ProtonCalculationModel
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ProtonCalculationModel"))
                        return _client.ProtonCalculationModel;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ProtonCalculationModel; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ProtonCalculationModel = value;
            }
        }

        public Dictionary<string, string> ProtonCalculationOptions
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ProtonCalculationOptions"))
                        return _client.ProtonCalculationOptions;
                    else
                        return default(Dictionary<string, string>);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ProtonCalculationOptions; }
                    );
                return default(Dictionary<string, string>);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ProtonCalculationOptions = value;
            }
        }

        public Series Series
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Series"))
                        return _client.Series;
                    else
                        return default(Series);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Series != null)
                                return new Series(_client.Series);
                            return null;
                        }
                    );
                return default(Series);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Series = value;
            }
        }

        public string SeriesUID
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SeriesUID"))
                        return _client.SeriesUID;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.SeriesUID; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SeriesUID = value;
            }
        }

        public StructureSet StructureSet
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("StructureSet"))
                        return _client.StructureSet;
                    else
                        return default(StructureSet);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.StructureSet != null)
                                return new StructureSet(_client.StructureSet);
                            return null;
                        }
                    );
                return default(StructureSet);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.StructureSet = value;
            }
        }

        public string TargetVolumeID
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TargetVolumeID"))
                        return _client.TargetVolumeID;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.TargetVolumeID; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.TargetVolumeID = value;
            }
        }

        public DoseValue TotalPrescribedDose
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TotalPrescribedDose"))
                        return _client.TotalPrescribedDose;
                    else
                        return default(DoseValue);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.TotalPrescribedDose; }
                    );
                return default(DoseValue);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.TotalPrescribedDose = value;
            }
        }

        public string TreatmentApprovalDate
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TreatmentApprovalDate"))
                        return _client.TreatmentApprovalDate;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.TreatmentApprovalDate; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.TreatmentApprovalDate = value;
            }
        }

        public string TreatmentApprover
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TreatmentApprover"))
                        return _client.TreatmentApprover;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.TreatmentApprover; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.TreatmentApprover = value;
            }
        }

        public PatientOrientation TreatmentOrientation
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TreatmentOrientation"))
                        return _client.TreatmentOrientation;
                    else
                        return default(PatientOrientation);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.TreatmentOrientation; }
                    );
                return default(PatientOrientation);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.TreatmentOrientation = value;
            }
        }

        public string UID
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("UID"))
                        return _client.UID;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.UID; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.UID = value;
            }
        }

        public Fractionation UniqueFractionation
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("UniqueFractionation"))
                        return _client.UniqueFractionation;
                    else
                        return default(Fractionation);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.UniqueFractionation != null)
                                return new Fractionation(_client.UniqueFractionation);
                            return null;
                        }
                    );
                return default(Fractionation);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.UniqueFractionation = value;
            }
        }

        public PlanSetup VerifiedPlan
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("VerifiedPlan"))
                        return _client.VerifiedPlan;
                    else
                        return default(PlanSetup);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.VerifiedPlan != null)
                                return new PlanSetup(_client.VerifiedPlan);
                            return null;
                        }
                    );
                return default(PlanSetup);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.VerifiedPlan = value;
            }
        }

        public string Id
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Id"))
                        return _client.Id;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Id; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Id = value;
            }
        }

        public double PlanNormalizationValue
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PlanNormalizationValue"))
                        return _client.PlanNormalizationValue;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PlanNormalizationValue; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PlanNormalizationValue = value;
            }
        }

        public void ClearCalculationModel(CalculationType calculationType)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.ClearCalculationModel(calculationType); }
                );
            else
                _client.ClearCalculationModel(calculationType);
        }

        public string GetCalculationModel(CalculationType calculationType)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.GetCalculationModel(calculationType); }
                );
                return vmsResult;
            }
            return (string) _client.GetCalculationModel(calculationType);
        }

        public bool GetCalculationOption(string calculationModel, string optionName, out string optionValue)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var optionValue_OUT = default(string);
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.GetCalculationOption(calculationModel, optionName, out optionValue_OUT);
                    }
                );
                optionValue = optionValue_OUT;
                return vmsResult;
            }
            return (bool) _client.GetCalculationOption(calculationModel, optionName, out optionValue);
        }

        public Dictionary<string, string> GetCalculationOptions(string calculationModel)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.GetCalculationOptions(calculationModel); }
                );
                return vmsResult;
            }
            return (Dictionary<string, string>) _client.GetCalculationOptions(calculationModel);
        }

        public DoseValue GetDoseAtVolume(Structure structure, double volume, VolumePresentation volumePresentation,
            DoseValuePresentation requestedDosePresentation)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.GetDoseAtVolume(structure._client, volume, volumePresentation,
                            requestedDosePresentation);
                    }
                );
                return vmsResult;
            }
            return (DoseValue) _client.GetDoseAtVolume(structure, volume, volumePresentation,
                requestedDosePresentation);
        }

        public double GetVolumeAtDose(Structure structure, DoseValue dose,
            VolumePresentation requestedVolumePresentation)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.GetVolumeAtDose(structure._client, dose, requestedVolumePresentation);
                    }
                );
                return vmsResult;
            }
            return (double) _client.GetVolumeAtDose(structure, dose, requestedVolumePresentation);
        }

        public void SetCalculationModel(CalculationType calculationType, string model)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.SetCalculationModel(calculationType, model); }
                );
            else
                _client.SetCalculationModel(calculationType, model);
        }

        public bool SetCalculationOption(string calculationModel, string optionName, string optionValue)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.SetCalculationOption(calculationModel, optionName, optionValue);
                    }
                );
                return vmsResult;
            }
            return (bool) _client.SetCalculationOption(calculationModel, optionName, optionValue);
        }
    }
}