using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;

namespace ESAPIX.DVH.Constraints
{
    public class NFractionConstraint : IPriorityConstraint
    {
        public int NumOfFractions { get; set; }

        public string FullName { get { return Name; } }

        public string Name { get { return $"{NumOfFractions} Fractions Required"; } }

        public PriorityType Priority { get; set; }

        public ConstraintResult CanConstrain(PlanningItem pi)
        {
            var message = string.Empty;
            if (pi is PlanSetup)
            {
                if ((pi as PlanSetup).UniqueFractionation.NumberOfFractions == null)
                {
                    message = "No fractionation present!";
                    return new ConstraintResult(this, false, message);
                }
            }
            else
            {
                var canConstrain = true;
                foreach (var ps in ((PlanSum)pi).PlanSetups)
                {
                    canConstrain = canConstrain && ps.UniqueFractionation.NumberOfFractions != null;
                }
                if (!canConstrain)
                {
                    message = "No fractionation present in one or more plans in the sum!";
                    return new ConstraintResult(this, false, message);
                }
            }
            return new ConstraintResult(this, true, message);
        }

        public ConstraintResult Constrain(PlanningItem pi)
        {
            var actualFractions = 0;
            var passed = false;
            if (pi is PlanSetup)
            {
                var ps = pi as PlanSetup;
                if (ps.UniqueFractionation.NumberOfFractions != null)
                {
                    actualFractions = (int)ps.UniqueFractionation.NumberOfFractions;
                    if (actualFractions == NumOfFractions)
                    {
                        passed = true;
                    }
                }
            }
            else if (pi is PlanSum)
            {

                foreach (var ps in ((PlanSum)pi).PlanSetups)
                {
                    actualFractions += (int)ps.UniqueFractionation.NumberOfFractions;
                }
                if (actualFractions == NumOfFractions)
                {
                    passed = true;
                }
            }
            var passedMsg = $"Plan contains exactly {NumOfFractions} fractions";
            var failedMsg = $"Plan has {actualFractions} fractions instead of {NumOfFractions} fractions";
            return new ConstraintResult(this, passed, passed ? passedMsg : failedMsg, actualFractions.ToString());
        }
    }
}
