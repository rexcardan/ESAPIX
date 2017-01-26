using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Interfaces;
using VMS.TPS.Common.Model.API;
using ESAPIX.DVH.Constraints;
using static ESAPIX.DVH.Constraints.ResultType;

namespace ESAPIX.DVH.Constraints
{
    public class OrConstraint : IPriorityConstraint
    {
        public PriorityType Priority { get; set; }
        public IConstraint C1 { get; set; }
        public IConstraint C2 { get; set; }

        public string Name { get { return $"{C1.Name} Or {C2.Name}"; } }
        public string FullName { get { return $"{C1.FullName} Or {C2.FullName}"; } }

        public OrConstraint() { }

        public OrConstraint(IConstraint cst1, IConstraint cst2)
        {
            C1 = cst1;
            C2 = cst2;
        }

        public ConstraintResult CanConstrain(PlanningItem pi)
        {
            var canConstrain = false;
            var message = string.Empty;

            if (C1 == null || C2 == null)
            {
                message = "There are not enough constraints for OR operator!";
                return new ConstraintResult(this, NOT_APPLICABLE, message, null);
            }
            var c1 = C1.CanConstrain(pi);
            var c2 = C2.CanConstrain(pi);
            canConstrain = (c1.IsSuccess && c1.IsSuccess);
            if (!canConstrain)
            {
                message = (c1.IsSuccess && c1.IsSuccess) ? c2.Message : c1.Message;
            }
            return new ConstraintResult(this, canConstrain ? PASSED : NOT_APPLICABLE, message, $"{c1.Value}/{c2.Value}");
        }

        public ConstraintResult Constrain(PlanningItem pi)
        {
            var c1passed = C1.Constrain(pi);
            var c2passed = C2.Constrain(pi);

            var passed = (c1passed.IsSuccess && c1passed.IsSuccess) ||
                (c2passed.IsSuccess && c2passed.IsSuccess);

            var msg = $"{(passed ? "One or both constraints passed" : "Neither constraint passed")} \n{c1passed.Message} \n{c2passed.Message}";
            return new ConstraintResult(this, passed ? PASSED : GetFailedResultType(), msg, $"{c1passed.Value}/{c2passed.Value}");
        }

        public ResultType GetFailedResultType()
        {
            return PriorityConverter.GetFailedResult(Priority);
        }

        public override string ToString()
        {
            return $"{C1.ToString()} [OR] {C2.ToString()}";
        }
    }
}
