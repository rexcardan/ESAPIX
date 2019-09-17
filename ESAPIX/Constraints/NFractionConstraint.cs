#region
using VMS.TPS.Common.Model.API;
using ESAPIX.Extensions;
#endregion

namespace ESAPIX.Constraints
{
    public class NFractionConstraint : IPriorityConstraint
    {
        public int NumOfFractions { get; set; }

        public string FullName => Name;

        public string Name => $"{NumOfFractions} Fractions Required";

        public PriorityType Priority { get; set; }

        public ConstraintResult CanConstrain(PlanningItem pi)
        {
            var message = string.Empty;
            if (pi is PlanSetup)
            {
                if ((pi as PlanSetup).NumberOfFractions() == null)
                {
                    message = "No fractionation present!";
                    return new ConstraintResult(this, ResultType.NOT_APPLICABLE, message);
                }
            }
            else
            {
                var canConstrain = true;
                foreach (var ps in ((PlanSum) pi).PlanSetups)
                    canConstrain = canConstrain && ps.NumberOfFractions() != null;
                if (!canConstrain)
                {
                    message = "No fractionation present in one or more plans in the sum!";
                    return new ConstraintResult(this, ResultType.NOT_APPLICABLE, message);
                }
            }
            return new ConstraintResult(this, ResultType.PASSED, message);
        }

        public ConstraintResult Constrain(PlanningItem pi)
        {
            var actualFractions = 0;
            var passed = false;
            if (pi is PlanSetup)
            {
                var ps = pi as PlanSetup;
                if (ps.NumberOfFractions() != null)
                {
                    actualFractions = (int) ps.NumberOfFractions();
                    if (actualFractions == NumOfFractions)
                        passed = true;
                }
            }
            else if (pi is PlanSum)
            {
                foreach (var ps in ((PlanSum) pi).PlanSetups)
                    actualFractions += (int) ps.NumberOfFractions();
                if (actualFractions == NumOfFractions)
                    passed = true;
            }
            var passedMsg = $"Plan contains exactly {NumOfFractions} fractions";
            var failedMsg = $"Plan has {actualFractions} fractions instead of {NumOfFractions} fractions";
            return new ConstraintResult(this, passed ? ResultType.PASSED : GetFailedResultType(),
                passed ? passedMsg : failedMsg, actualFractions.ToString());
        }

        public ResultType GetFailedResultType()
        {
            switch (Priority)
            {
                case PriorityType.PRIORITY_1: return ResultType.ACTION_LEVEL_3;
                case PriorityType.PRIORITY_2: return ResultType.ACTION_LEVEL_2;
                case PriorityType.PRIORITY_3: return ResultType.ACTION_LEVEL_1;
                default: return ResultType.ACTION_LEVEL_1;
            }
        }
    }
}