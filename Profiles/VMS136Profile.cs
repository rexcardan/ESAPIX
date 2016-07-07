using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Proxies;

namespace ESAPIX.Profiles
{
    /// <summary>
    /// This profile needs to be called before using the proxy classes in ESAPIX
    /// It adds a mapped relationship between VMS objects and the proxy counterparts.
    /// However, ESAPIX doesn't depend on the VMS dlls so the configure method will 
    /// fail if the project that calls it doesn't reference the VMS dlls.
    /// </summary>
    public class VMS136Profile : Profile
    {
        protected override void Configure()
        {
            var V = "VMS.TPS.Common.Model.API";
            var VT = "VMS.TPS.Common.Model.Types";
            var EX = "ESAPIX";
            var XP = "ESAPIX.Proxies";
            var XE = "ESAPIX.Enums";
            var XT = "ESAPIX.Types";

            //VMS.TPS.Common.Model.API
            CreateMap(Type.GetType($"{V}.User,{V}"), Type.GetType($"{XP}.User,{EX}"));
            CreateMap(Type.GetType($"{V}.Course,{V}"), Type.GetType($"{XP}.Course,{EX}"));
            CreateMap(Type.GetType($"{V}.Patient,{V}"), Type.GetType($"{XP}.Patient,{EX}"));
            CreateMap(Type.GetType($"{V}.PlanSetup,{V}"), Type.GetType($"{XP}.PlanSetup,{EX}"));
            CreateMap(Type.GetType($"{V}.PlanSum,{V}"), Type.GetType($"{XP}.PlanSum,{EX}"));
            CreateMap(Type.GetType($"{V}.Fractionation,{V}"), Type.GetType($"{XP}.Fractionation,{EX}"));
            CreateMap(Type.GetType($"{V}.Beam,{V}"), Type.GetType($"{XP}.Beam,{EX}"));
            CreateMap(Type.GetType($"{V}.ExternalBeam,{V}"), Type.GetType($"{XP}.ExternalBeam,{EX}"));
            CreateMap(Type.GetType($"{V}.Technique,{V}"), Type.GetType($"{XP}.Technique,{EX}"));
            CreateMap(Type.GetType($"{V}.Wedge,{V}"), Type.GetType($"{XP}.Wedge,{EX}"));
            CreateMap(Type.GetType($"{V}.Tray,{V}"), Type.GetType($"{XP}.Tray,{EX}"));
            CreateMap(Type.GetType($"{V}.Block,{V}"), Type.GetType($"{XP}.Block,{EX}"));
            CreateMap(Type.GetType($"{V}.Compensator,{V}"), Type.GetType($"{XP}.Compensator,{EX}"));
            CreateMap(Type.GetType($"{V}.MLC,{V}"), Type.GetType($"{XP}.MLC,{EX}"));
            CreateMap(Type.GetType($"{V}.ControlPointCollection,{V}"), Type.GetType($"{XP}.ControlPointCollection,{EX}"));
            CreateMap(Type.GetType($"{V}.ControlPoint,{V}"), Type.GetType($"{XP}.ControlPoint,{EX}"));
            CreateMap(Type.GetType($"{V}.Bolus,{V}"), Type.GetType($"{XP}.Bolus,{EX}"));
            CreateMap(Type.GetType($"{V}.Applicator,{V}"), Type.GetType($"{XP}.Applicator,{EX}"));
            CreateMap(Type.GetType($"{V}.BeamCalculationLog,{V}"), Type.GetType($"{XP}.BeamCalculationLog,{EX}"));
            CreateMap(Type.GetType($"{V}.FieldReferencePoint,{V}"), Type.GetType($"{XP}.FieldReferencePoint,{EX}"));
            CreateMap(Type.GetType($"{V}.ReferencePoint,{V}"), Type.GetType($"{XP}.ReferencePoint,{EX}"));
            CreateMap(Type.GetType($"{V}.Image,{V}"), Type.GetType($"{XP}.Image,{EX}"));
            CreateMap(Type.GetType($"{V}.StructureSet,{V}"), Type.GetType($"{XP}.StructureSet,{EX}"));
            CreateMap(Type.GetType($"{V}.Structure,{V}"), Type.GetType($"{XP}.Structure,{EX}"));
            CreateMap(Type.GetType($"{V}.DVHData,{V}"), Type.GetType($"{XP}.DVHData,{EX}"));

            //VMS.TPS.Common.Model.Types
            CreateMap(Type.GetType($"{VT}.PatientOrientation,{VT}"), Type.GetType($"{XE}.PatientOrientation,{EX}"));
            CreateMap(Type.GetType($"{VT}.SetupTechnique,{VT}"), Type.GetType($"{XE}.SetupTechnique,{EX}"));
            CreateMap(Type.GetType($"{VT}.GantryDirection,{VT}"), Type.GetType($"{XE}.GantryDirection,{EX}"));
            CreateMap(Type.GetType($"{VT}.MLCPlanType,{VT}"), Type.GetType($"{XE}.MLCPlanType,{EX}"));
            CreateMap(Type.GetType($"{VT}.VRect`1,{VT}"), Type.GetType($"{XT}.VRect`1,{EX}"));
            CreateMap(Type.GetType($"{VT}.MetersetValue,{VT}"), Type.GetType($"{XT}.MetersetValue,{EX}"));
            CreateMap(Type.GetType($"{VT}.DVHPoint,{VT}"), Type.GetType($"{XT}.DVHPoint,{EX}"));
            CreateMap(Type.GetType($"{VT}.VVector,{VT}"), Type.GetType($"{XT}.VVector,{EX}"));
            //Inverse needed
            CreateMap(Type.GetType($"{XT}.VVector,{EX}"), Type.GetType($"{VT}.VVector,{VT}"));
            CreateMap(Type.GetType($"{VT}.DoseValue,{VT}"), Type.GetType($"{XT}.DoseValue,{EX}"));
            CreateMap(Type.GetType($"{VT}.DoseValue+DoseUnit,{VT}"), Type.GetType($"{XE}.DoseUnit,{EX}"));
        }

    }
}
