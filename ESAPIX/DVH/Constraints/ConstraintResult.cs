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
        public ConstraintResult(IConstraint constraint, bool? isConstraintMet, string message, string value = "")
        {
            this.Constraint = constraint;
            this.IsSuccess = isConstraintMet;
            this.Message = message;
            this.Value = value;
        }
        public IConstraint Constraint { get; set; }

        /// <summary>
        /// Signifies if constraint passed. A null value means the test was not applicable or could not be performed.
        /// </summary>
        public bool? IsSuccess { get; set; }

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
