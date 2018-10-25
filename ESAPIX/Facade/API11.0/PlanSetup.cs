using System;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Common.AppComThread;
using V = VMS.TPS.Common.Model.API;
using Types = VMS.TPS.Common.Model.Types;

namespace ESAPIX.Facade.API
{
    public class PlanSetup : ESAPIX.Facade.API.PlanningItem, System.Xml.Serialization.IXmlSerializable
    {
        public System.String UID
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("UID"))
                    {
                        return _client.UID;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.UID;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.UID = (value);
                }
                else
                {
                }
            }
        }

        public System.Boolean IsTreated
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IsTreated"))
                    {
                        return _client.IsTreated;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.IsTreated;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.IsTreated = (value);
                }
                else
                {
                }
            }
        }

        public System.String CreationUserName
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CreationUserName"))
                    {
                        return _client.CreationUserName;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.CreationUserName;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CreationUserName = (value);
                }
                else
                {
                }
            }
        }

        public System.String PlanNormalizationMethod
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PlanNormalizationMethod"))
                    {
                        return _client.PlanNormalizationMethod;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PlanNormalizationMethod;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PlanNormalizationMethod = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.VVector PlanNormalizationPoint
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PlanNormalizationPoint"))
                    {
                        return _client.PlanNormalizationPoint;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.VVector);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PlanNormalizationPoint;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.VVector);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PlanNormalizationPoint = (value);
                }
                else
                {
                }
            }
        }

        public System.String ProtocolID
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ProtocolID"))
                    {
                        return _client.ProtocolID;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.ProtocolID;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ProtocolID = (value);
                }
                else
                {
                }
            }
        }

        public System.String ProtocolPhaseID
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ProtocolPhaseID"))
                    {
                        return _client.ProtocolPhaseID;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.ProtocolPhaseID;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ProtocolPhaseID = (value);
                }
                else
                {
                }
            }
        }

        public System.String TargetVolumeID
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TargetVolumeID"))
                    {
                        return _client.TargetVolumeID;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.TargetVolumeID;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TargetVolumeID = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Course Course
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Course"))
                    {
                        return _client.Course;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Course);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Course) != (null))
                        {
                            return new ESAPIX.Facade.API.Course(_client.Course);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    );
                }
                else
                {
                    return default (ESAPIX.Facade.API.Course);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Course = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.Beam> Beams
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Beams"))
                    {
                        foreach (var item in _client.Beams)
                        {
                            yield return item;
                        }
                    }
                    else
                    {
                        yield break;
                    }
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.Invoke(() =>
                    {
                        var asEnum = (IEnumerable)_client.Beams;
                        if ((asEnum) != null)
                        {
                            enumerator = asEnum.GetEnumerator();
                        }
                    }

                    );
                    if (enumerator == null)
                    {
                        yield break;
                    }

                    while (XC.Instance.GetValue<bool>(sc => enumerator.MoveNext()))
                    {
                        var facade = new ESAPIX.Facade.API.Beam();
                        XC.Instance.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            if (vms != null)
                            {
                                facade._client = vms;
                            }
                        }

                        );
                        if (facade._client != null)
                        {
                            yield return facade;
                        }
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Beams = value;
            }
        }

        public ESAPIX.Facade.API.StructureSet StructureSet
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("StructureSet"))
                    {
                        return _client.StructureSet;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.StructureSet);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.StructureSet) != (null))
                        {
                            return new ESAPIX.Facade.API.StructureSet(_client.StructureSet);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    );
                }
                else
                {
                    return default (ESAPIX.Facade.API.StructureSet);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.StructureSet = (value);
                }
                else
                {
                }
            }
        }

        public System.Boolean IsDoseValid
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IsDoseValid"))
                    {
                        return _client.IsDoseValid;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.IsDoseValid;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.IsDoseValid = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.PlanSetupApprovalStatus ApprovalStatus
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ApprovalStatus"))
                    {
                        return _client.ApprovalStatus;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.PlanSetupApprovalStatus);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.ApprovalStatus;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.PlanSetupApprovalStatus);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ApprovalStatus = (value);
                }
                else
                {
                }
            }
        }

        public System.String PlanningApprovalDate
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PlanningApprovalDate"))
                    {
                        return _client.PlanningApprovalDate;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PlanningApprovalDate;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PlanningApprovalDate = (value);
                }
                else
                {
                }
            }
        }

        public System.String PlanningApprover
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PlanningApprover"))
                    {
                        return _client.PlanningApprover;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PlanningApprover;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PlanningApprover = (value);
                }
                else
                {
                }
            }
        }

        public System.String TreatmentApprovalDate
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TreatmentApprovalDate"))
                    {
                        return _client.TreatmentApprovalDate;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.TreatmentApprovalDate;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TreatmentApprovalDate = (value);
                }
                else
                {
                }
            }
        }

        public System.String TreatmentApprover
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TreatmentApprover"))
                    {
                        return _client.TreatmentApprover;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.TreatmentApprover;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TreatmentApprover = (value);
                }
                else
                {
                }
            }
        }

        public System.Double PrescribedPercentage
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PrescribedPercentage"))
                    {
                        return _client.PrescribedPercentage;
                    }
                    else
                    {
                        return default (System.Double);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PrescribedPercentage;
                    }

                    );
                }
                else
                {
                    return default (System.Double);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PrescribedPercentage = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.DoseValue TotalPrescribedDose
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TotalPrescribedDose"))
                    {
                        return _client.TotalPrescribedDose;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.DoseValue);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.TotalPrescribedDose;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.DoseValue);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TotalPrescribedDose = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Fractionation UniqueFractionation
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("UniqueFractionation"))
                    {
                        return _client.UniqueFractionation;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Fractionation);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.UniqueFractionation) != (null))
                        {
                            return new ESAPIX.Facade.API.Fractionation(_client.UniqueFractionation);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    );
                }
                else
                {
                    return default (ESAPIX.Facade.API.Fractionation);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.UniqueFractionation = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.ReferencePoint PrimaryReferencePoint
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PrimaryReferencePoint"))
                    {
                        return _client.PrimaryReferencePoint;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.ReferencePoint);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.PrimaryReferencePoint) != (null))
                        {
                            return new ESAPIX.Facade.API.ReferencePoint(_client.PrimaryReferencePoint);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    );
                }
                else
                {
                    return default (ESAPIX.Facade.API.ReferencePoint);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PrimaryReferencePoint = (value);
                }
                else
                {
                }
            }
        }

        public System.String ElectronCalculationModel
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ElectronCalculationModel"))
                    {
                        return _client.ElectronCalculationModel;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.ElectronCalculationModel;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ElectronCalculationModel = (value);
                }
                else
                {
                }
            }
        }

        public System.Collections.Generic.Dictionary<System.String,System.String> ElectronCalculationOptions
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ElectronCalculationOptions"))
                    {
                        return _client.ElectronCalculationOptions;
                    }
                    else
                    {
                        return default (System.Collections.Generic.Dictionary<System.String,System.String>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.ElectronCalculationOptions;
                    }

                    );
                }
                else
                {
                    return default (System.Collections.Generic.Dictionary<System.String,System.String>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ElectronCalculationOptions = (value);
                }
                else
                {
                }
            }
        }

        public System.String PhotonCalculationModel
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PhotonCalculationModel"))
                    {
                        return _client.PhotonCalculationModel;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PhotonCalculationModel;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PhotonCalculationModel = (value);
                }
                else
                {
                }
            }
        }

        public System.Collections.Generic.Dictionary<System.String,System.String> PhotonCalculationOptions
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PhotonCalculationOptions"))
                    {
                        return _client.PhotonCalculationOptions;
                    }
                    else
                    {
                        return default (System.Collections.Generic.Dictionary<System.String,System.String>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PhotonCalculationOptions;
                    }

                    );
                }
                else
                {
                    return default (System.Collections.Generic.Dictionary<System.String,System.String>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PhotonCalculationOptions = (value);
                }
                else
                {
                }
            }
        }

        public System.String ProtonCalculationModel
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ProtonCalculationModel"))
                    {
                        return _client.ProtonCalculationModel;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.ProtonCalculationModel;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ProtonCalculationModel = (value);
                }
                else
                {
                }
            }
        }

        public System.Collections.Generic.Dictionary<System.String,System.String> ProtonCalculationOptions
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ProtonCalculationOptions"))
                    {
                        return _client.ProtonCalculationOptions;
                    }
                    else
                    {
                        return default (System.Collections.Generic.Dictionary<System.String,System.String>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.ProtonCalculationOptions;
                    }

                    );
                }
                else
                {
                    return default (System.Collections.Generic.Dictionary<System.String,System.String>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ProtonCalculationOptions = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.PatientOrientation TreatmentOrientation
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TreatmentOrientation"))
                    {
                        return _client.TreatmentOrientation;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.PatientOrientation);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.TreatmentOrientation;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.PatientOrientation);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TreatmentOrientation = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.DoseValue GetDoseAtVolume(ESAPIX.Facade.API.Structure structure, System.Double volume, VMS.TPS.Common.Model.Types.VolumePresentation volumePresentation, VMS.TPS.Common.Model.Types.DoseValuePresentation requestedDosePresentation)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetDoseAtVolume(structure._client, volume, volumePresentation, requestedDosePresentation));
                    if (fromClient.Equals(default (VMS.TPS.Common.Model.Types.DoseValue)))
                    {
                        return default (VMS.TPS.Common.Model.Types.DoseValue);
                    }

                    return (VMS.TPS.Common.Model.Types.DoseValue)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (VMS.TPS.Common.Model.Types.DoseValue)(_client.GetDoseAtVolume(structure, volume, volumePresentation, requestedDosePresentation));
            }
        }

        public System.Double GetVolumeAtDose(ESAPIX.Facade.API.Structure structure, VMS.TPS.Common.Model.Types.DoseValue dose, VMS.TPS.Common.Model.Types.VolumePresentation requestedVolumePresentation)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetVolumeAtDose(structure._client, dose, requestedVolumePresentation));
                    if (fromClient.Equals(default (System.Double)))
                    {
                        return default (System.Double);
                    }

                    return (System.Double)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Double)(_client.GetVolumeAtDose(structure, dose, requestedVolumePresentation));
            }
        }

        public PlanSetup()
        {
            _client = (new ExpandoObject());
        }

        public PlanSetup(dynamic client)
        {
            _client = (client);
        }
    }
}