using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.DVH.Constraints
{
    /// <summary>
    /// Encapsulates the results from an attempt to constrain a planning item
    /// </summary>
    public class ConstraintResult
    {
        public ConstraintResult(IConstraint constraint, ResultType resultType, string message, string value = "")
        {
            this.Constraint = constraint;
            this.IsSuccess = resultType == ResultType.PASSED;
            this.ResultType = resultType;
            this.IsApplicable = resultType != ResultType.NOT_APPLICABLE
                && ResultType != ResultType.NOT_APPLICABLE_MISSING_STRUCTURE
                 && ResultType != ResultType.NOT_APPLICABLE_MISSING_DOSE;
            this.Message = message;
            this.Value = value;
        }
        public IConstraint Constraint { get; set; }

        /// <summary>
        /// Signifies if constraint passed. 
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Signifies if constraint was applicable to current plan. 
        /// </summary>
        public bool IsApplicable { get; set; }

        /// <summary>
        /// The result value including action level for the constraint
        /// </summary>
        public ResultType ResultType { get; set; }

        /// <summary>
        /// The message indicating why a test failed
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The message indicating why a test failed
        /// </summary>
        public string Value { get; set; }
    }
}
