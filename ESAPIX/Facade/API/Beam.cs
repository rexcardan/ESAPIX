using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

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

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public Applicator Applicator
        {
            get
            {
                if (_client is ExpandoObject) return _client.Applicator;
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
                if (_client is ExpandoObject) return _client.ArcLength;
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
                if (_client is ExpandoObject) return _client.AverageSSD;
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
                if (_client is ExpandoObject) return _client.BeamNumber;
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

        public IEnumerable<Bolus> Boluses
        {
            get
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

        public IEnumerable<BeamCalculationLog> CalculationLogs
        {
            get
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

        public Compensator Compensator
        {
            get
            {
                if (_client is ExpandoObject) return _client.Compensator;
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
                if (_client is ExpandoObject) return _client.ControlPoints;
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
                if (_client is ExpandoObject) return _client.CreationDateTime;
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
                if (_client is ExpandoObject) return _client.Dose;
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
                if (_client is ExpandoObject) return _client.DoseRate;
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
                if (_client is ExpandoObject) return _client.DosimetricLeafGap;
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
                if (_client is ExpandoObject) return _client.EnergyModeDisplayName;
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

        public GantryDirection GantryDirection
        {
            get
            {
                if (_client is ExpandoObject) return _client.GantryDirection;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    return (GantryDirection) local._client.GantryDirection;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.GantryDirection = value;
            }
        }

        public VVector IsocenterPosition
        {
            get
            {
                if (_client is ExpandoObject) return _client.IsocenterPosition;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.IsocenterPosition)) return default(VVector);
                    return new VVector(local._client.IsocenterPosition);
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
                if (_client is ExpandoObject) return _client.IsSetupField;
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
                if (_client is ExpandoObject) return _client.MetersetPerGy;
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
                if (_client is ExpandoObject) return _client.MLC;
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

        public MLCPlanType MLCPlanType
        {
            get
            {
                if (_client is ExpandoObject) return _client.MLCPlanType;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc => { return (MLCPlanType) local._client.MLCPlanType; });
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
                if (_client is ExpandoObject) return _client.MLCTransmissionFactor;
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
                if (_client is ExpandoObject) return _client.NormalizationFactor;
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
                if (_client is ExpandoObject) return _client.NormalizationMethod;
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
                if (_client is ExpandoObject) return _client.PlannedSSD;
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
                if (_client is ExpandoObject) return _client.ReferenceImage;
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

        public SetupTechnique SetupTechnique
        {
            get
            {
                if (_client is ExpandoObject) return _client.SetupTechnique;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    return (SetupTechnique) local._client.SetupTechnique;
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
                if (_client is ExpandoObject) return _client.SSD;
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
                if (_client is ExpandoObject) return _client.SSDAtStopAngle;
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
                if (_client is ExpandoObject) return _client.Technique;
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
                if (_client is ExpandoObject) return _client.ToleranceTableLabel;
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

        public ExternalBeamTreatmentUnit TreatmentUnit
        {
            get
            {
                if (_client is ExpandoObject) return _client.TreatmentUnit;
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

        public double WeightFactor
        {
            get
            {
                if (_client is ExpandoObject) return _client.WeightFactor;
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
                if (_client is ExpandoObject) return _client.Id;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Id; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Id = value;
            }
        }

        public MetersetValue Meterset
        {
            get
            {
                if (_client is ExpandoObject) return _client.Meterset;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Meterset)) return default(MetersetValue);
                    return new MetersetValue(local._client.Meterset);
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
                if (_client is ExpandoObject) return _client.ExternalBeam;
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

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public void ApplyParameters(BeamParameters beamParams)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.ApplyParameters(beamParams._client); });
        }

        public bool CanSetOptimalFluence(Fluence fluence, out string message)
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

        public Fluence GetOptimalFluence()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Fluence(local._client.GetOptimalFluence());
            });
            return retVal;
        }

        public VVector GetSourceLocation(double gantryAngle)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new VVector(local._client.GetSourceLocation(gantryAngle));
            });
            return retVal;
        }

        public void SetOptimalFluence(Fluence fluence)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.SetOptimalFluence(fluence._client); });
        }
    }
}