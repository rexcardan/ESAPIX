#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Beam : ApiDataObject
    {
        public Beam()
        {
            _client = new ExpandoObject();
        }

        public Beam(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public Applicator Applicator
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Applicator")
                        ? _client.Applicator
                        : default(Applicator);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Applicator)) return default(Applicator);
                    return new Applicator(local._client.Applicator);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Applicator = value;
            }
        }

        public double ArcLength
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ArcLength") ? _client.ArcLength : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.ArcLength; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ArcLength = value;
            }
        }

        public double AverageSSD
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("AverageSSD") ? _client.AverageSSD : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.AverageSSD; });
            }
            set
            {
                if (_client is ExpandoObject) _client.AverageSSD = value;
            }
        }

        public int BeamNumber
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("BeamNumber") ? _client.BeamNumber : default(int);
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.BeamNumber; });
            }
            set
            {
                if (_client is ExpandoObject) _client.BeamNumber = value;
            }
        }

        public IEnumerable<Block> Blocks
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Blocks"))
                        foreach (var item in _client.Blocks) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.Blocks;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Block();
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
                if (_client is ExpandoObject) _client.Blocks = value;
            }
        }

        public IEnumerable<Bolus> Boluses
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Boluses"))
                        foreach (var item in _client.Boluses) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.Boluses;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Bolus();
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
                if (_client is ExpandoObject) _client.Boluses = value;
            }
        }

        public IEnumerable<BeamCalculationLog> CalculationLogs
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("CalculationLogs"))
                        foreach (var item in _client.CalculationLogs) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.CalculationLogs;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new BeamCalculationLog();
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
                if (_client is ExpandoObject) _client.CalculationLogs = value;
            }
        }

        public Compensator Compensator
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Compensator")
                        ? _client.Compensator
                        : default(Compensator);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Compensator)) return default(Compensator);
                    return new Compensator(local._client.Compensator);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Compensator = value;
            }
        }

        public ControlPointCollection ControlPoints
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ControlPoints")
                        ? _client.ControlPoints
                        : default(ControlPointCollection);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.ControlPoints)) return default(ControlPointCollection);
                    return new ControlPointCollection(local._client.ControlPoints);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ControlPoints = value;
            }
        }

        public DateTime? CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CreationDateTime")
                        ? _client.CreationDateTime
                        : default(DateTime?);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime?>(sc => { return local._client.CreationDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CreationDateTime = value;
            }
        }

        public BeamDose Dose
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Dose") ? _client.Dose : default(BeamDose);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Dose)) return default(BeamDose);
                    return new BeamDose(local._client.Dose);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Dose = value;
            }
        }

        public int DoseRate
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DoseRate") ? _client.DoseRate : default(int);
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.DoseRate; });
            }
            set
            {
                if (_client is ExpandoObject) _client.DoseRate = value;
            }
        }

        public double DosimetricLeafGap
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DosimetricLeafGap")
                        ? _client.DosimetricLeafGap
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.DosimetricLeafGap; });
            }
            set
            {
                if (_client is ExpandoObject) _client.DosimetricLeafGap = value;
            }
        }

        public string EnergyModeDisplayName
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("EnergyModeDisplayName")
                        ? _client.EnergyModeDisplayName
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc =>
                {
                    return local._client.EnergyModeDisplayName;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.EnergyModeDisplayName = value;
            }
        }

        public IEnumerable<FieldReferencePoint> FieldReferencePoints
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("FieldReferencePoints"))
                        foreach (var item in _client.FieldReferencePoints) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.FieldReferencePoints;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new FieldReferencePoint();
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
                if (_client is ExpandoObject) _client.FieldReferencePoints = value;
            }
        }

        public Types.GantryDirection GantryDirection
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("GantryDirection")
                        ? _client.GantryDirection
                        : default(Types.GantryDirection);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    return (Types.GantryDirection) local._client.GantryDirection;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.GantryDirection = value;
            }
        }

        public Types.VVector IsocenterPosition
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("IsocenterPosition")
                        ? _client.IsocenterPosition
                        : default(Types.VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.IsocenterPosition)) return default(Types.VVector);
                    return new Types.VVector(local._client.IsocenterPosition);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.IsocenterPosition = value;
            }
        }

        public bool IsSetupField
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("IsSetupField")
                        ? _client.IsSetupField
                        : default(bool);
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.IsSetupField; });
            }
            set
            {
                if (_client is ExpandoObject) _client.IsSetupField = value;
            }
        }

        public double MetersetPerGy
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MetersetPerGy")
                        ? _client.MetersetPerGy
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.MetersetPerGy; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MetersetPerGy = value;
            }
        }

        public MLC MLC
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MLC") ? _client.MLC : default(MLC);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.MLC)) return default(MLC);
                    return new MLC(local._client.MLC);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.MLC = value;
            }
        }

        public Types.MLCPlanType MLCPlanType
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MLCPlanType")
                        ? _client.MLCPlanType
                        : default(Types.MLCPlanType);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    return (Types.MLCPlanType) local._client.MLCPlanType;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.MLCPlanType = value;
            }
        }

        public double MLCTransmissionFactor
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MLCTransmissionFactor")
                        ? _client.MLCTransmissionFactor
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc =>
                {
                    return local._client.MLCTransmissionFactor;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.MLCTransmissionFactor = value;
            }
        }

        public double NormalizationFactor
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("NormalizationFactor")
                        ? _client.NormalizationFactor
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.NormalizationFactor; });
            }
            set
            {
                if (_client is ExpandoObject) _client.NormalizationFactor = value;
            }
        }

        public string NormalizationMethod
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("NormalizationMethod")
                        ? _client.NormalizationMethod
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.NormalizationMethod; });
            }
            set
            {
                if (_client is ExpandoObject) _client.NormalizationMethod = value;
            }
        }

        public double PlannedSSD
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PlannedSSD") ? _client.PlannedSSD : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.PlannedSSD; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlannedSSD = value;
            }
        }

        public Image ReferenceImage
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ReferenceImage")
                        ? _client.ReferenceImage
                        : default(Image);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.ReferenceImage)) return default(Image);
                    return new Image(local._client.ReferenceImage);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ReferenceImage = value;
            }
        }

        public Types.SetupTechnique SetupTechnique
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("SetupTechnique")
                        ? _client.SetupTechnique
                        : default(Types.SetupTechnique);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    return (Types.SetupTechnique) local._client.SetupTechnique;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.SetupTechnique = value;
            }
        }

        public double SSD
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("SSD") ? _client.SSD : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.SSD; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SSD = value;
            }
        }

        public double SSDAtStopAngle
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("SSDAtStopAngle")
                        ? _client.SSDAtStopAngle
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.SSDAtStopAngle; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SSDAtStopAngle = value;
            }
        }

        public Technique Technique
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Technique") ? _client.Technique : default(Technique);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Technique)) return default(Technique);
                    return new Technique(local._client.Technique);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Technique = value;
            }
        }

        public string ToleranceTableLabel
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ToleranceTableLabel")
                        ? _client.ToleranceTableLabel
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.ToleranceTableLabel; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ToleranceTableLabel = value;
            }
        }

        public IEnumerable<Tray> Trays
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Trays"))
                        foreach (var item in _client.Trays) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.Trays;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Tray();
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
                if (_client is ExpandoObject) _client.Trays = value;
            }
        }

        public ExternalBeamTreatmentUnit TreatmentUnit
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("TreatmentUnit")
                        ? _client.TreatmentUnit
                        : default(ExternalBeamTreatmentUnit);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.TreatmentUnit)) return default(ExternalBeamTreatmentUnit);
                    return new ExternalBeamTreatmentUnit(local._client.TreatmentUnit);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.TreatmentUnit = value;
            }
        }

        public IEnumerable<Wedge> Wedges
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Wedges"))
                        foreach (var item in _client.Wedges) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.Wedges;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Wedge();
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
                if (_client is ExpandoObject) _client.Wedges = value;
            }
        }

        public double WeightFactor
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("WeightFactor")
                        ? _client.WeightFactor
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.WeightFactor; });
            }
            set
            {
                if (_client is ExpandoObject) _client.WeightFactor = value;
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

        public Types.MetersetValue Meterset
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Meterset")
                        ? _client.Meterset
                        : default(Types.MetersetValue);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Meterset)) return default(Types.MetersetValue);
                    return new Types.MetersetValue(local._client.Meterset);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Meterset = value;
            }
        }

        public ExternalBeam ExternalBeam
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ExternalBeam")
                        ? _client.ExternalBeam
                        : default(ExternalBeam);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.ExternalBeam)) return default(ExternalBeam);
                    return new ExternalBeam(local._client.ExternalBeam);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ExternalBeam = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public void ApplyParameters(BeamParameters beamParams)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.ApplyParameters(beamParams._client); });
        }

        public bool CanSetOptimalFluence(Types.Fluence fluence, out string message)
        {
            var message_OUT = default(string);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.CanSetOptimalFluence(fluence._client, out message_OUT);
            });
            message = message_OUT;
            return retVal;
        }

        public BeamParameters GetEditableParameters()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new BeamParameters(local._client.GetEditableParameters());
            });
            return retVal;
        }

        public Types.Fluence GetOptimalFluence()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Types.Fluence(local._client.GetOptimalFluence());
            });
            return retVal;
        }

        public Types.VVector GetSourceLocation(double gantryAngle)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Types.VVector(local._client.GetSourceLocation(gantryAngle));
            });
            return retVal;
        }

        public void SetOptimalFluence(Types.Fluence fluence)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.SetOptimalFluence(fluence._client); });
        }
    }
}