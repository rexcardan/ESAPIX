using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Enums;
using ESAPIX.Types;

namespace ESAPIX.Interfaces
{
    public interface IBeam: IApiDataObject
    {
         DateTime? CreationDateTime { get; }

         bool IsSetupField { get; }

         IExternalBeam ExternalBeam { get; }

         string EnergyModeDisplayName { get; }

         int DoseRate { get; }

         ITechnique Technique { get; }

         SetupTechnique SetupTechnique { get; }

         double ArcLength { get; }

         GantryDirection GantryDirection { get; }

         VVector IsocenterPosition { get; }

         IEnumerable<IWedge> Wedges { get; }

         IEnumerable<ITray> Trays { get; }

         IEnumerable<IBlock> Blocks { get; }

         ICompensator Compensator { get; }

         IMLC MLC { get; }

         MLCPlanType MLCPlanType { get; }

         double DosimetricLeafGap { get; }

         double MLCTransmissionFactor { get; }

         IControlPointCollection ControlPoints { get; }

         IEnumerable<IBolus> Boluses { get; }

         IApplicator Applicator { get; }

         IImage ReferenceImage { get; }

         double WeightFactor { get; }

         IEnumerable<IBeamCalculationLog> CalculationLogs { get; }

         MetersetValue Meterset { get; }

         double MetersetPerGy { get; }

         double PlannedSSD { get; }

         double SSD { get; }

         double SSDAtStopAngle { get; }

         IEnumerable<IFieldReferencePoint> FieldReferencePoints { get; }

         double NormalizationFactor { get; }

         string NormalizationMethod { get; }

         double AverageSSD { get; }
    }
}
