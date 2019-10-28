#region

using System;
using System.Collections.Generic;
using System.Linq;
using VMS.TPS.Common.Model.API;

#endregion

namespace ESAPIX.Constraints
{
    public abstract class AbstractPlanQualityConstraint : IConstraint
    {
        public delegate void StatusUpdateHandler(double progress, string status);

        /// <summary>
        /// Optional parameter to set the "value" returned of a particular constraint. Can be
        /// used for reporting
        /// </summary>
        public virtual string Value { get; protected set; }
        public abstract string Name { get; }

        public virtual string FullName
        {
            get { return Name; }
        }

        public abstract ConstraintResult CanConstrain(PlanningItem pi);

        public abstract ConstraintResult Constrain(PlanningItem pi);

        public event StatusUpdateHandler StatusChanged;

        public void OnStatusChanged(double progress, string status)
        {
            StatusChanged?.Invoke(progress, status);
        }

        /// <summary>
        /// A custom class of custom settings appropriate for the constraint implemented. Use ValidateSettings or
        /// data annotations to ensure setting strings are correct
        /// </summary>
        public object ConstraintSettings { get; set; }

        /// <summary>
        /// A optional method to validate the settings values to make sure they are appropriate.
        /// This will be called when settings are changed. 
        /// </summary>
        /// <returns>Returns a dictionary of keys matching the settings keys with validation
        /// results for each key</returns>
        public virtual List<ValidationResult> ValidateSettings()
        {
            return new List<ValidationResult>();
        }
    }
}