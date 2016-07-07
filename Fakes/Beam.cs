using System;
using System.Collections.Generic;
using System.Reflection;
using ESAPIX.Enums;
using ESAPIX.Interfaces;
using ESAPIX.Types;

namespace ESAPIX.Fakes
{
    public class Beam : ApiDataObject, IBeam
    {
        public DateTime? CreationDateTime { get; set; }
        public bool IsSetupField { get; set; }

        public IExternalBeam ExternalBeam
        {
            get;
            set; 
        }

        public string EnergyModeDisplayName { get; set; }
        public int DoseRate { get; set; }
        public ITechnique Technique
        {
            get;
            set; 
        }

        public SetupTechnique SetupTechnique { get; set; }

        public double ArcLength { get; set; }
        public GantryDirection GantryDirection { get; set; }

        public VVector IsocenterPosition { get; set; }

        public IEnumerable<IWedge> Wedges
        {
            get;
            set; 
        }

        public IEnumerable<ITray> Trays
        {
            get;
            set; 
        }

        public IEnumerable<IBlock> Blocks
        {
            get;
            set; 
        }

        public ICompensator Compensator
        {
            get;
            set; 
        }

        public IMLC MLC
        {
            get;
            set; 
        }

        public MLCPlanType MLCPlanType { get; set; }
        public double DosimetricLeafGap { get; set; }

        public double MLCTransmissionFactor { get; set; }

        public IControlPointCollection ControlPoints
        {
            get;
            set; 
        }
        public IEnumerable<IBolus> Boluses
        {
            get;
            set; 
        }

        public IApplicator Applicator
        {
            get;
            set; 
        }

        public IImage ReferenceImage
        {
            get;
            set; 
        }

        public double WeightFactor { get; set; }

        public IEnumerable<IBeamCalculationLog> CalculationLogs
        {
            get;
            set; 
        }

        public MetersetValue Meterset { get; set; }

        public double MetersetPerGy { get; set; }
        public double PlannedSSD { get; set; }

        public double SSD { get; set; }

        public double SSDAtStopAngle { get; set; }

        public IEnumerable<IFieldReferencePoint> FieldReferencePoints { get; set; }
        public double NormalizationFactor { get; set; }

        public string NormalizationMethod { get; set; }

        public double AverageSSD { get; set; }
    }
}