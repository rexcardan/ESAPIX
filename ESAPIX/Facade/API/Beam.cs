#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Beam : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Beam()
        {
            _client = new ExpandoObject();
        }

        public Beam(dynamic client)
        {
            _client = client;
        }

        public Applicator Applicator
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Applicator"))
                        return _client.Applicator;
                    else
                        return default(Applicator);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Applicator != null)
                                return new Applicator(_client.Applicator);
                            return null;
                        }
                    );
                return default(Applicator);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Applicator = value;
            }
        }

        public double ArcLength
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ArcLength"))
                        return _client.ArcLength;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ArcLength; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ArcLength = value;
            }
        }

        public double AverageSSD
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("AverageSSD"))
                        return _client.AverageSSD;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.AverageSSD; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.AverageSSD = value;
            }
        }

        public int BeamNumber
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("BeamNumber"))
                        return _client.BeamNumber;
                    else
                        return default(int);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.BeamNumber; }
                    );
                return default(int);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.BeamNumber = value;
            }
        }

        public IEnumerable<Block> Blocks
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Blocks"))
                        foreach (var item in _client.Blocks)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Blocks;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Block();
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
                    _client.Blocks = value;
            }
        }

        public IEnumerable<Bolus> Boluses
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Boluses"))
                        foreach (var item in _client.Boluses)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Boluses;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Bolus();
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
                    _client.Boluses = value;
            }
        }

        public IEnumerable<BeamCalculationLog> CalculationLogs
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("CalculationLogs"))
                        foreach (var item in _client.CalculationLogs)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.CalculationLogs;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new BeamCalculationLog();
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
                    _client.CalculationLogs = value;
            }
        }

        public Compensator Compensator
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Compensator"))
                        return _client.Compensator;
                    else
                        return default(Compensator);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Compensator != null)
                                return new Compensator(_client.Compensator);
                            return null;
                        }
                    );
                return default(Compensator);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Compensator = value;
            }
        }

        public ControlPointCollection ControlPoints
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ControlPoints"))
                        return _client.ControlPoints;
                    else
                        return default(ControlPointCollection);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.ControlPoints != null)
                                return new ControlPointCollection(_client.ControlPoints);
                            return null;
                        }
                    );
                return default(ControlPointCollection);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ControlPoints = value;
            }
        }

        public DateTime? CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CreationDateTime"))
                        return _client.CreationDateTime;
                    else
                        return default(DateTime?);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CreationDateTime; }
                    );
                return default(DateTime?);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CreationDateTime = value;
            }
        }

        public BeamDose Dose
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Dose"))
                        return _client.Dose;
                    else
                        return default(BeamDose);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Dose != null)
                                return new BeamDose(_client.Dose);
                            return null;
                        }
                    );
                return default(BeamDose);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Dose = value;
            }
        }

        public int DoseRate
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("DoseRate"))
                        return _client.DoseRate;
                    else
                        return default(int);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.DoseRate; }
                    );
                return default(int);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.DoseRate = value;
            }
        }

        public double DosimetricLeafGap
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("DosimetricLeafGap"))
                        return _client.DosimetricLeafGap;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.DosimetricLeafGap; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.DosimetricLeafGap = value;
            }
        }

        public string EnergyModeDisplayName
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("EnergyModeDisplayName"))
                        return _client.EnergyModeDisplayName;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.EnergyModeDisplayName; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.EnergyModeDisplayName = value;
            }
        }

        public IEnumerable<FieldReferencePoint> FieldReferencePoints
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("FieldReferencePoints"))
                        foreach (var item in _client.FieldReferencePoints)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.FieldReferencePoints;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new FieldReferencePoint();
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
                    _client.FieldReferencePoints = value;
            }
        }

        public GantryDirection GantryDirection
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("GantryDirection"))
                        return _client.GantryDirection;
                    else
                        return default(GantryDirection);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.GantryDirection; }
                    );
                return default(GantryDirection);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.GantryDirection = value;
            }
        }

        public VVector IsocenterPosition
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("IsocenterPosition"))
                        return _client.IsocenterPosition;
                    else
                        return default(VVector);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.IsocenterPosition; }
                    );
                return default(VVector);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.IsocenterPosition = value;
            }
        }

        public bool IsSetupField
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("IsSetupField"))
                        return _client.IsSetupField;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.IsSetupField; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.IsSetupField = value;
            }
        }

        public double MetersetPerGy
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MetersetPerGy"))
                        return _client.MetersetPerGy;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MetersetPerGy; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MetersetPerGy = value;
            }
        }

        public MLC MLC
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MLC"))
                        return _client.MLC;
                    else
                        return default(MLC);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.MLC != null)
                                return new MLC(_client.MLC);
                            return null;
                        }
                    );
                return default(MLC);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MLC = value;
            }
        }

        public MLCPlanType MLCPlanType
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MLCPlanType"))
                        return _client.MLCPlanType;
                    else
                        return default(MLCPlanType);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MLCPlanType; }
                    );
                return default(MLCPlanType);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MLCPlanType = value;
            }
        }

        public double MLCTransmissionFactor
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MLCTransmissionFactor"))
                        return _client.MLCTransmissionFactor;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MLCTransmissionFactor; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MLCTransmissionFactor = value;
            }
        }

        public double NormalizationFactor
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("NormalizationFactor"))
                        return _client.NormalizationFactor;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.NormalizationFactor; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.NormalizationFactor = value;
            }
        }

        public string NormalizationMethod
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("NormalizationMethod"))
                        return _client.NormalizationMethod;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.NormalizationMethod; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.NormalizationMethod = value;
            }
        }

        public double PlannedSSD
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PlannedSSD"))
                        return _client.PlannedSSD;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PlannedSSD; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PlannedSSD = value;
            }
        }

        public Image ReferenceImage
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ReferenceImage"))
                        return _client.ReferenceImage;
                    else
                        return default(Image);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.ReferenceImage != null)
                                return new Image(_client.ReferenceImage);
                            return null;
                        }
                    );
                return default(Image);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ReferenceImage = value;
            }
        }

        public SetupTechnique SetupTechnique
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SetupTechnique"))
                        return _client.SetupTechnique;
                    else
                        return default(SetupTechnique);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.SetupTechnique; }
                    );
                return default(SetupTechnique);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SetupTechnique = value;
            }
        }

        public double SSD
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SSD"))
                        return _client.SSD;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.SSD; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SSD = value;
            }
        }

        public double SSDAtStopAngle
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SSDAtStopAngle"))
                        return _client.SSDAtStopAngle;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.SSDAtStopAngle; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SSDAtStopAngle = value;
            }
        }

        public Technique Technique
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Technique"))
                        return _client.Technique;
                    else
                        return default(Technique);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Technique != null)
                                return new Technique(_client.Technique);
                            return null;
                        }
                    );
                return default(Technique);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Technique = value;
            }
        }

        public string ToleranceTableLabel
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ToleranceTableLabel"))
                        return _client.ToleranceTableLabel;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ToleranceTableLabel; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ToleranceTableLabel = value;
            }
        }

        public IEnumerable<Tray> Trays
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Trays"))
                        foreach (var item in _client.Trays)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Trays;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Tray();
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
                    _client.Trays = value;
            }
        }

        public ExternalBeamTreatmentUnit TreatmentUnit
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TreatmentUnit"))
                        return _client.TreatmentUnit;
                    else
                        return default(ExternalBeamTreatmentUnit);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.TreatmentUnit != null)
                                return new ExternalBeamTreatmentUnit(_client.TreatmentUnit);
                            return null;
                        }
                    );
                return default(ExternalBeamTreatmentUnit);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.TreatmentUnit = value;
            }
        }

        public IEnumerable<Wedge> Wedges
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Wedges"))
                        foreach (var item in _client.Wedges)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Wedges;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Wedge();
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
                    _client.Wedges = value;
            }
        }

        public double WeightFactor
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("WeightFactor"))
                        return _client.WeightFactor;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.WeightFactor; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.WeightFactor = value;
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

        public MetersetValue Meterset
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Meterset"))
                        return _client.Meterset;
                    else
                        return default(MetersetValue);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Meterset; }
                    );
                return default(MetersetValue);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Meterset = value;
            }
        }

        public ExternalBeam ExternalBeam
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ExternalBeam"))
                        return _client.ExternalBeam;
                    else
                        return default(ExternalBeam);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.ExternalBeam != null)
                                return new ExternalBeam(_client.ExternalBeam);
                            return null;
                        }
                    );
                return default(ExternalBeam);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ExternalBeam = value;
            }
        }

        public void ApplyParameters(BeamParameters beamParams)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.ApplyParameters(beamParams._client); }
                );
            else
                _client.ApplyParameters(beamParams);
        }

        public bool CanSetOptimalFluence(Fluence fluence, out string message)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var message_OUT = default(string);
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.CanSetOptimalFluence(fluence, out message_OUT);
                    }
                );
                message = message_OUT;
                return vmsResult;
            }
            return (bool) _client.CanSetOptimalFluence(fluence, out message);
        }

        public BeamParameters GetEditableParameters()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new BeamParameters(_client.GetEditableParameters());
                    }
                );
                return vmsResult;
            }
            return _client.GetEditableParameters();
        }

        public Fluence GetOptimalFluence()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc => { return _client.GetOptimalFluence(); }
                );
                return vmsResult;
            }
            return (Fluence) _client.GetOptimalFluence();
        }

        public VVector GetSourceLocation(double gantryAngle)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.GetSourceLocation(gantryAngle); }
                );
                return vmsResult;
            }
            return (VVector) _client.GetSourceLocation(gantryAngle);
        }

        public void SetOptimalFluence(Fluence fluence)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.SetOptimalFluence(fluence); }
                );
            else
                _client.SetOptimalFluence(fluence);
        }
    }
}