using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Beam : ESAPIX.Facade.API.ApiDataObject
    {
        public Beam() { }
        public Beam(dynamic client) { _client = client; }
        public ESAPIX.Facade.API.Applicator Applicator
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Applicator(local._client.Applicator);
            }
        }
        public System.Double ArcLength
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.ArcLength; });
            }
        }
        public System.Double AverageSSD
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.AverageSSD; });
            }
        }
        public System.Int32 BeamNumber
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.BeamNumber; });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Block> Blocks
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.Block>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.Blocks).Select(s => new ESAPIX.Facade.API.Block(s));
                });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Bolus> Boluses
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.Bolus>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.Boluses).Select(s => new ESAPIX.Facade.API.Bolus(s));
                });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.BeamCalculationLog> CalculationLogs
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.BeamCalculationLog>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.CalculationLogs).Select(s => new ESAPIX.Facade.API.BeamCalculationLog(s));
                });
            }
        }
        public ESAPIX.Facade.API.Compensator Compensator
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Compensator(local._client.Compensator);
            }
        }
        public ESAPIX.Facade.API.ControlPointCollection ControlPoints
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.ControlPointCollection(local._client.ControlPoints);
            }
        }
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CreationDateTime; });
            }
        }
        public ESAPIX.Facade.API.BeamDose Dose
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.BeamDose(local._client.Dose);
            }
        }
        public System.Int32 DoseRate
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.DoseRate; });
            }
        }
        public System.Double DosimetricLeafGap
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.DosimetricLeafGap; });
            }
        }
        public System.String EnergyModeDisplayName
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.EnergyModeDisplayName; });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.FieldReferencePoint> FieldReferencePoints
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.FieldReferencePoint>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.FieldReferencePoints).Select(s => new ESAPIX.Facade.API.FieldReferencePoint(s));
                });
            }
        }
        public ESAPIX.Facade.Types.GantryDirection GantryDirection
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.GantryDirection)local._client.GantryDirection;
            }
        }
        public ESAPIX.Facade.Types.VVector IsocenterPosition
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.IsocenterPosition);
            }
        }
        public System.Boolean IsSetupField
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsSetupField; });
            }
        }
        public System.Double MetersetPerGy
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MetersetPerGy; });
            }
        }
        public ESAPIX.Facade.API.MLC MLC
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.MLC(local._client.MLC);
            }
        }
        public ESAPIX.Facade.Types.MLCPlanType MLCPlanType
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.MLCPlanType)local._client.MLCPlanType;
            }
        }
        public System.Double MLCTransmissionFactor
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MLCTransmissionFactor; });
            }
        }
        public System.Double NormalizationFactor
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.NormalizationFactor; });
            }
        }
        public System.String NormalizationMethod
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.NormalizationMethod; });
            }
        }
        public System.Double PlannedSSD
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.PlannedSSD; });
            }
        }
        public ESAPIX.Facade.API.Image ReferenceImage
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Image(local._client.ReferenceImage);
            }
        }
        public ESAPIX.Facade.Types.SetupTechnique SetupTechnique
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.SetupTechnique)local._client.SetupTechnique;
            }
        }
        public System.Double SSD
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SSD; });
            }
        }
        public System.Double SSDAtStopAngle
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SSDAtStopAngle; });
            }
        }
        public ESAPIX.Facade.API.Technique Technique
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Technique(local._client.Technique);
            }
        }
        public System.String ToleranceTableLabel
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ToleranceTableLabel; });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Tray> Trays
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.Tray>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.Trays).Select(s => new ESAPIX.Facade.API.Tray(s));
                });
            }
        }
        public ESAPIX.Facade.API.ExternalBeamTreatmentUnit TreatmentUnit
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.ExternalBeamTreatmentUnit(local._client.TreatmentUnit);
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Wedge> Wedges
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.Wedge>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.Wedges).Select(s => new ESAPIX.Facade.API.Wedge(s));
                });
            }
        }
        public System.Double WeightFactor
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.WeightFactor; });
            }
        }
        public System.String Id
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Id; });
            }
        }
        public ESAPIX.Facade.Types.MetersetValue Meterset
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.MetersetValue(local._client.Meterset);
            }
        }
        public ESAPIX.Facade.API.ExternalBeam ExternalBeam
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.ExternalBeam(local._client.ExternalBeam);
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