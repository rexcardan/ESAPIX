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
        public System.String Id
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Id"))
                    {
                        return _client.Id;
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
                        return _client.Id;
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
                    _client.Id = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.Id = (value));
                }
            }
        }

        public System.Double PlanNormalizationValue
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PlanNormalizationValue"))
                    {
                        return _client.PlanNormalizationValue;
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
                        return _client.PlanNormalizationValue;
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
                    _client.PlanNormalizationValue = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.PlanNormalizationValue = (value));
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.PlanUncertainty> PlanUncertainties
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PlanUncertainties"))
                    {
                        foreach (var item in _client.PlanUncertainties)
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
                        var asEnum = (IEnumerable)_client.PlanUncertainties;
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
                        var facade = new ESAPIX.Facade.API.PlanUncertainty();
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
                    _client.PlanUncertainties = value;
            }
        }

        public VMS.TPS.Common.Model.Types.DoseValue DosePerFractionInPrimaryRefPoint
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("DosePerFractionInPrimaryRefPoint"))
                    {
                        return _client.DosePerFractionInPrimaryRefPoint;
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
                        return _client.DosePerFractionInPrimaryRefPoint;
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
                    _client.DosePerFractionInPrimaryRefPoint = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.DoseValue PrescribedDosePerFraction
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PrescribedDosePerFraction"))
                    {
                        return _client.PrescribedDosePerFraction;
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
                        return _client.PrescribedDosePerFraction;
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
                    _client.PrescribedDosePerFraction = (value);
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

        public IEnumerable<ESAPIX.Facade.API.ApplicationScriptLog> ApplicationScriptLogs
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("ApplicationScriptLogs"))
                    {
                        foreach (var item in _client.ApplicationScriptLogs)
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
                        var asEnum = (IEnumerable)_client.ApplicationScriptLogs;
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
                        var facade = new ESAPIX.Facade.API.ApplicationScriptLog();
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
                    _client.ApplicationScriptLogs = value;
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

        public VMS.TPS.Common.Model.Types.DoseValue DosePerFraction
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("DosePerFraction"))
                    {
                        return _client.DosePerFraction;
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
                        return _client.DosePerFraction;
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
                    _client.DosePerFraction = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.EstimatedDVH> DVHEstimates
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("DVHEstimates"))
                    {
                        foreach (var item in _client.DVHEstimates)
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
                        var asEnum = (IEnumerable)_client.DVHEstimates;
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
                        var facade = new ESAPIX.Facade.API.EstimatedDVH();
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
                    _client.DVHEstimates = value;
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

        public System.Nullable<System.Int32> NumberOfFractions
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("NumberOfFractions"))
                    {
                        return _client.NumberOfFractions;
                    }
                    else
                    {
                        return default (System.Nullable<System.Int32>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.NumberOfFractions;
                    }

                    );
                }
                else
                {
                    return default (System.Nullable<System.Int32>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.NumberOfFractions = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.OptimizationSetup OptimizationSetup
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("OptimizationSetup"))
                    {
                        return _client.OptimizationSetup;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.OptimizationSetup);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.OptimizationSetup) != (null))
                        {
                            return new ESAPIX.Facade.API.OptimizationSetup(_client.OptimizationSetup);
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
                    return default (ESAPIX.Facade.API.OptimizationSetup);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.OptimizationSetup = (value);
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

        public System.String PlanIntent
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PlanIntent"))
                    {
                        return _client.PlanIntent;
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
                        return _client.PlanIntent;
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
                    _client.PlanIntent = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.DoseValue PlannedDosePerFraction
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PlannedDosePerFraction"))
                    {
                        return _client.PlannedDosePerFraction;
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
                        return _client.PlannedDosePerFraction;
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
                    _client.PlannedDosePerFraction = (value);
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

        public System.String PlanningApproverDisplayName
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PlanningApproverDisplayName"))
                    {
                        return _client.PlanningApproverDisplayName;
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
                        return _client.PlanningApproverDisplayName;
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
                    _client.PlanningApproverDisplayName = (value);
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

        public VMS.TPS.Common.Model.Types.PlanType PlanType
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PlanType"))
                    {
                        return _client.PlanType;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.PlanType);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PlanType;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.PlanType);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PlanType = (value);
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

        public ESAPIX.Facade.API.Series Series
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Series"))
                    {
                        return _client.Series;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Series);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Series) != (null))
                        {
                            return new ESAPIX.Facade.API.Series(_client.Series);
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
                    return default (ESAPIX.Facade.API.Series);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Series = (value);
                }
                else
                {
                }
            }
        }

        public System.String SeriesUID
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("SeriesUID"))
                    {
                        return _client.SeriesUID;
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
                        return _client.SeriesUID;
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
                    _client.SeriesUID = (value);
                }
                else
                {
                }
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

        public VMS.TPS.Common.Model.Types.DoseValue TotalDose
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TotalDose"))
                    {
                        return _client.TotalDose;
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
                        return _client.TotalDose;
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
                    _client.TotalDose = (value);
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

        public System.String TreatmentApproverDisplayName
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TreatmentApproverDisplayName"))
                    {
                        return _client.TreatmentApproverDisplayName;
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
                        return _client.TreatmentApproverDisplayName;
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
                    _client.TreatmentApproverDisplayName = (value);
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

        public System.Double TreatmentPercentage
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TreatmentPercentage"))
                    {
                        return _client.TreatmentPercentage;
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
                        return _client.TreatmentPercentage;
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
                    _client.TreatmentPercentage = (value);
                }
                else
                {
                }
            }
        }

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

        public ESAPIX.Facade.API.PlanSetup VerifiedPlan
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("VerifiedPlan"))
                    {
                        return _client.VerifiedPlan;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.PlanSetup);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.VerifiedPlan) != (null))
                        {
                            return new ESAPIX.Facade.API.PlanSetup(_client.VerifiedPlan);
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
                    return default (ESAPIX.Facade.API.PlanSetup);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.VerifiedPlan = (value);
                }
                else
                {
                }
            }
        }

        public void ClearCalculationModel(VMS.TPS.Common.Model.Types.CalculationType calculationType)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.ClearCalculationModel(calculationType);
                }

                );
            }
            else
            {
                _client.ClearCalculationModel(calculationType);
            }
        }

        public System.String GetCalculationModel(VMS.TPS.Common.Model.Types.CalculationType calculationType)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetCalculationModel(calculationType));
                    if (fromClient.Equals(default (System.String)))
                    {
                        return default (System.String);
                    }

                    return (System.String)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.String)(_client.GetCalculationModel(calculationType));
            }
        }

        public System.Boolean GetCalculationOption(System.String calculationModel, System.String optionName, out System.String optionValue)
        {
            if ((XC.Instance) != (null))
            {
                var optionValue_OUT = (default (System.String));
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetCalculationOption(calculationModel, optionName, out optionValue_OUT));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                optionValue = (optionValue_OUT);
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.GetCalculationOption(calculationModel, optionName, out optionValue));
            }
        }

        public System.Collections.Generic.Dictionary<System.String,System.String> GetCalculationOptions(System.String calculationModel)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetCalculationOptions(calculationModel));
                    if (fromClient.Equals(default (System.Collections.Generic.Dictionary<System.String,System.String>)))
                    {
                        return default (System.Collections.Generic.Dictionary<System.String,System.String>);
                    }

                    return (System.Collections.Generic.Dictionary<System.String,System.String>)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Collections.Generic.Dictionary<System.String,System.String>)(_client.GetCalculationOptions(calculationModel));
            }
        }

        public void SetCalculationModel(VMS.TPS.Common.Model.Types.CalculationType calculationType, System.String model)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.SetCalculationModel(calculationType, model);
                }

                );
            }
            else
            {
                _client.SetCalculationModel(calculationType, model);
            }
        }

        public System.Boolean SetCalculationOption(System.String calculationModel, System.String optionName, System.String optionValue)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.SetCalculationOption(calculationModel, optionName, optionValue));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.SetCalculationOption(calculationModel, optionName, optionValue));
            }
        }

        public void SetPrescription(System.Int32 numberOfFractions, VMS.TPS.Common.Model.Types.DoseValue dosePerFraction, System.Double treatmentPercentage)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.SetPrescription(numberOfFractions, dosePerFraction, treatmentPercentage);
                }

                );
            }
            else
            {
                _client.SetPrescription(numberOfFractions, dosePerFraction, treatmentPercentage);
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