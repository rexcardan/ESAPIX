using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Beam : ESAPIX.Facade.API.ApiDataObject
    {
        public Beam() { _client = new ExpandoObject(); }
        public Beam(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public ESAPIX.Facade.API.Applicator Applicator
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Applicator; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Applicator>((sc) => { if (DefaultHelper.IsDefault(local._client.Applicator)) { return default(ESAPIX.Facade.API.Applicator); } else { return new ESAPIX.Facade.API.Applicator(local._client.Applicator); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Applicator = value; }
            }
        }
        public System.Double ArcLength
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ArcLength; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.ArcLength; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ArcLength = value; }
            }
        }
        public System.Double AverageSSD
        {
            get
            {
                if (_client is ExpandoObject) { return _client.AverageSSD; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.AverageSSD; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.AverageSSD = value; }
            }
        }
        public System.Int32 BeamNumber
        {
            get
            {
                if (_client is ExpandoObject) { return _client.BeamNumber; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.BeamNumber; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.BeamNumber = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Block> Blocks
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.Blocks;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.Block();
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
        public IEnumerable<ESAPIX.Facade.API.Bolus> Boluses
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.Boluses;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.Bolus();
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
        public IEnumerable<ESAPIX.Facade.API.BeamCalculationLog> CalculationLogs
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.CalculationLogs;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.BeamCalculationLog();
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
        public ESAPIX.Facade.API.Compensator Compensator
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Compensator; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Compensator>((sc) => { if (DefaultHelper.IsDefault(local._client.Compensator)) { return default(ESAPIX.Facade.API.Compensator); } else { return new ESAPIX.Facade.API.Compensator(local._client.Compensator); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Compensator = value; }
            }
        }
        public ESAPIX.Facade.API.ControlPointCollection ControlPoints
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ControlPoints; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.ControlPointCollection>((sc) => { if (DefaultHelper.IsDefault(local._client.ControlPoints)) { return default(ESAPIX.Facade.API.ControlPointCollection); } else { return new ESAPIX.Facade.API.ControlPointCollection(local._client.ControlPoints); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ControlPoints = value; }
            }
        }
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CreationDateTime; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CreationDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CreationDateTime = value; }
            }
        }
        public ESAPIX.Facade.API.BeamDose Dose
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Dose; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.BeamDose>((sc) => { if (DefaultHelper.IsDefault(local._client.Dose)) { return default(ESAPIX.Facade.API.BeamDose); } else { return new ESAPIX.Facade.API.BeamDose(local._client.Dose); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Dose = value; }
            }
        }
        public System.Int32 DoseRate
        {
            get
            {
                if (_client is ExpandoObject) { return _client.DoseRate; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.DoseRate; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.DoseRate = value; }
            }
        }
        public System.Double DosimetricLeafGap
        {
            get
            {
                if (_client is ExpandoObject) { return _client.DosimetricLeafGap; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.DosimetricLeafGap; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.DosimetricLeafGap = value; }
            }
        }
        public System.String EnergyModeDisplayName
        {
            get
            {
                if (_client is ExpandoObject) { return _client.EnergyModeDisplayName; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.EnergyModeDisplayName; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.EnergyModeDisplayName = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.FieldReferencePoint> FieldReferencePoints
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.FieldReferencePoints;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.FieldReferencePoint();
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
        public ESAPIX.Facade.Types.GantryDirection GantryDirection
        {
            get
            {
                if (_client is ExpandoObject) { return _client.GantryDirection; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.GantryDirection>((sc) => { return (ESAPIX.Facade.Types.GantryDirection)local._client.GantryDirection; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.GantryDirection = value; }
            }
        }
        public ESAPIX.Facade.Types.VVector IsocenterPosition
        {
            get
            {
                if (_client is ExpandoObject) { return _client.IsocenterPosition; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.VVector>((sc) => { if (DefaultHelper.IsDefault(local._client.IsocenterPosition)) { return default(ESAPIX.Facade.Types.VVector); } else { return new ESAPIX.Facade.Types.VVector(local._client.IsocenterPosition); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.IsocenterPosition = value; }
            }
        }
        public System.Boolean IsSetupField
        {
            get
            {
                if (_client is ExpandoObject) { return _client.IsSetupField; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsSetupField; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.IsSetupField = value; }
            }
        }
        public System.Double MetersetPerGy
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MetersetPerGy; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MetersetPerGy; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MetersetPerGy = value; }
            }
        }
        public ESAPIX.Facade.API.MLC MLC
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MLC; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.MLC>((sc) => { if (DefaultHelper.IsDefault(local._client.MLC)) { return default(ESAPIX.Facade.API.MLC); } else { return new ESAPIX.Facade.API.MLC(local._client.MLC); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MLC = value; }
            }
        }
        public ESAPIX.Facade.Types.MLCPlanType MLCPlanType
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MLCPlanType; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.MLCPlanType>((sc) => { return (ESAPIX.Facade.Types.MLCPlanType)local._client.MLCPlanType; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MLCPlanType = value; }
            }
        }
        public System.Double MLCTransmissionFactor
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MLCTransmissionFactor; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MLCTransmissionFactor; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MLCTransmissionFactor = value; }
            }
        }
        public System.Double NormalizationFactor
        {
            get
            {
                if (_client is ExpandoObject) { return _client.NormalizationFactor; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.NormalizationFactor; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.NormalizationFactor = value; }
            }
        }
        public System.String NormalizationMethod
        {
            get
            {
                if (_client is ExpandoObject) { return _client.NormalizationMethod; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.NormalizationMethod; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.NormalizationMethod = value; }
            }
        }
        public System.Double PlannedSSD
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PlannedSSD; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.PlannedSSD; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PlannedSSD = value; }
            }
        }
        public ESAPIX.Facade.API.Image ReferenceImage
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ReferenceImage; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Image>((sc) => { if (DefaultHelper.IsDefault(local._client.ReferenceImage)) { return default(ESAPIX.Facade.API.Image); } else { return new ESAPIX.Facade.API.Image(local._client.ReferenceImage); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ReferenceImage = value; }
            }
        }
        public ESAPIX.Facade.Types.SetupTechnique SetupTechnique
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SetupTechnique; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.SetupTechnique>((sc) => { return (ESAPIX.Facade.Types.SetupTechnique)local._client.SetupTechnique; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SetupTechnique = value; }
            }
        }
        public System.Double SSD
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SSD; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SSD; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SSD = value; }
            }
        }
        public System.Double SSDAtStopAngle
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SSDAtStopAngle; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SSDAtStopAngle; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SSDAtStopAngle = value; }
            }
        }
        public ESAPIX.Facade.API.Technique Technique
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Technique; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Technique>((sc) => { if (DefaultHelper.IsDefault(local._client.Technique)) { return default(ESAPIX.Facade.API.Technique); } else { return new ESAPIX.Facade.API.Technique(local._client.Technique); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Technique = value; }
            }
        }
        public System.String ToleranceTableLabel
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ToleranceTableLabel; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ToleranceTableLabel; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ToleranceTableLabel = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Tray> Trays
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.Trays;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.Tray();
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
        public ESAPIX.Facade.API.ExternalBeamTreatmentUnit TreatmentUnit
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TreatmentUnit; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.ExternalBeamTreatmentUnit>((sc) => { if (DefaultHelper.IsDefault(local._client.TreatmentUnit)) { return default(ESAPIX.Facade.API.ExternalBeamTreatmentUnit); } else { return new ESAPIX.Facade.API.ExternalBeamTreatmentUnit(local._client.TreatmentUnit); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TreatmentUnit = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Wedge> Wedges
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.Wedges;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.Wedge();
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
        public System.Double WeightFactor
        {
            get
            {
                if (_client is ExpandoObject) { return _client.WeightFactor; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.WeightFactor; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.WeightFactor = value; }
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
        public ESAPIX.Facade.Types.MetersetValue Meterset
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Meterset; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.MetersetValue>((sc) => { if (DefaultHelper.IsDefault(local._client.Meterset)) { return default(ESAPIX.Facade.Types.MetersetValue); } else { return new ESAPIX.Facade.Types.MetersetValue(local._client.Meterset); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Meterset = value; }
            }
        }
        public ESAPIX.Facade.API.ExternalBeam ExternalBeam
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ExternalBeam; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.ExternalBeam>((sc) => { if (DefaultHelper.IsDefault(local._client.ExternalBeam)) { return default(ESAPIX.Facade.API.ExternalBeam); } else { return new ESAPIX.Facade.API.ExternalBeam(local._client.ExternalBeam); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ExternalBeam = value; }
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
        public void ApplyParameters(ESAPIX.Facade.API.BeamParameters beamParams)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.ApplyParameters(beamParams._client);
            });

        }
        public System.Boolean CanSetOptimalFluence(ESAPIX.Facade.Types.Fluence fluence, out System.String message)
        {
            var message_OUT = default(System.String);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.CanSetOptimalFluence(fluence._client, out message_OUT); });
            message = message_OUT;
            return retVal;

        }
        public ESAPIX.Facade.API.BeamParameters GetEditableParameters()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.BeamParameters(local._client.GetEditableParameters()); });
            return retVal;

        }
        public ESAPIX.Facade.Types.Fluence GetOptimalFluence()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.Types.Fluence(local._client.GetOptimalFluence()); });
            return retVal;

        }
        public ESAPIX.Facade.Types.VVector GetSourceLocation(System.Double gantryAngle)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.Types.VVector(local._client.GetSourceLocation(gantryAngle)); });
            return retVal;

        }
        public void SetOptimalFluence(ESAPIX.Facade.Types.Fluence fluence)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.SetOptimalFluence(fluence._client);
            });

        }
    }
}