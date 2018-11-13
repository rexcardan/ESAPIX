using ESAPIX.Constraints;
using ESAPIX.Constraints.DVH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;
using static VMS.TPS.Common.Model.Types.PrescriptionModifier;

namespace ESAPIX.Extensions
{
    public static class ProtocolPhasePrescriptionExtensions
    {
        public static DoseStructureConstraint ToConstraint(this ProtocolPhasePrescription rx)
        {
            switch (rx.PrescModifier)
            {
                case PrescriptionModifierAtLeast:
                    return new MinDoseAtVolConstraint()
                    {
                        ConstraintDose = rx.TargetTotalDose,
                        StructureName = rx.StructureId,
                        Volume = rx.PrescParameter,
                        VolumeType = VMS.TPS.Common.Model.Types.VolumePresentation.Relative
                    };

                case PrescriptionModifierAtMost:
                    return new MaxDoseAtVolConstraint()
                    {
                        ConstraintDose = rx.TargetTotalDose,
                        StructureName = rx.StructureId,
                        Volume = rx.PrescParameter,
                        VolumeType = VMS.TPS.Common.Model.Types.VolumePresentation.Relative
                    };

                case PrescriptionModifierMaxDoseAtMost:
                    return new MaxDoseConstraint()
                    {
                        ConstraintDose = rx.TargetTotalDose,
                        StructureName = rx.StructureId,
                    };

                case PrescriptionModifierMinDoseAtLeast:
                    return new MinDoseConstraint()
                    {
                        ConstraintDose = rx.TargetTotalDose,
                        StructureName = rx.StructureId,
                    };

                case PrescriptionModifierMeanDoseAtLeast:
                    return new MinMeanDoseConstraint()
                    {
                        ConstraintDose = rx.TargetTotalDose,
                        StructureName = rx.StructureId
                    };

                case PrescriptionModifierMeanDoseAtMost:
                    return new MaxMeanDoseConstraint()
                    {
                        ConstraintDose = rx.TargetTotalDose,
                        StructureName = rx.StructureId
                    };
            }
            return null;
        }
    }
}
