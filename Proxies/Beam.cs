using System;
using System.Collections.Generic;
using System.Reflection;
using ESAPIX.Enums;
using ESAPIX.Interfaces;
using ESAPIX.Types;
using ESAPIX.Proxies;


namespace ESAPIX.Proxies
{
    public class Beam : ApiDataObject, IBeam
    {
        public DateTime? CreationDateTime { get; set; }
        public bool IsSetupField { get; set; }

        public IExternalBeam ExternalBeam
        {
            get
            {
                return Wrap<ExternalBeam>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public string EnergyModeDisplayName { get; set; }
        public int DoseRate { get; set; }
        public ITechnique Technique
        {
            get
            {
                return Wrap<Technique>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public SetupTechnique SetupTechnique { get; set; }

        public double ArcLength { get; set; }
        public GantryDirection GantryDirection { get; set; }

        public VVector IsocenterPosition { get; set; }

        public IEnumerable<IWedge> Wedges
        {
            get
            {
                return WrapEnumerable<Wedge>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IEnumerable<ITray> Trays
        {
            get
            {
                return WrapEnumerable<Tray>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IEnumerable<IBlock> Blocks
        {
            get
            {
                return WrapEnumerable<Block>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public ICompensator Compensator
        {
            get
            {
                return Wrap<Compensator>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IMLC MLC
        {
            get
            {
                return Wrap<MLC>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public MLCPlanType MLCPlanType { get; set; }
        public double DosimetricLeafGap { get; set; }

        public double MLCTransmissionFactor { get; set; }

        public IControlPointCollection ControlPoints
        {
            get
            {
                return Wrap<ControlPointCollection>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }
        public IEnumerable<IBolus> Boluses
        {
            get
            {
                return WrapEnumerable<Bolus>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IApplicator Applicator
        {
            get
            {
                return Wrap<Applicator>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IImage ReferenceImage
        {
            get
            {
                return Wrap<Image>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public double WeightFactor { get; set; }

        public IEnumerable<IBeamCalculationLog> CalculationLogs
        {
            get
            {
                return WrapEnumerable<BeamCalculationLog>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public MetersetValue Meterset { get; set; }

        public double MetersetPerGy { get; set; }
        public double PlannedSSD { get; set; }

        public double SSD { get; set; }

        public double SSDAtStopAngle { get; set; }

        public IEnumerable<IFieldReferencePoint> FieldReferencePoints
        {
            get
            {
                return WrapEnumerable<FieldReferencePoint>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }
        public double NormalizationFactor { get; set; }

        public string NormalizationMethod { get; set; }

        public double AverageSSD { get; set; }
    }
}