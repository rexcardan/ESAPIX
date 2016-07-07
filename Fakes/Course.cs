using System;
using System.Collections.Generic;
using ESAPIX.Interfaces;


namespace ESAPIX.Fakes
{
    public class Course : ApiDataObject, ICourse
    {
        public string CompletedByUserName { get; set; }

        public DateTime? CompletedDateTime { get; set; }

        public IEnumerable<IPlanSetup> PlanSetups
        {
            get;
            set; 
        }

        public IEnumerable<IPlanSum> PlanSums
        {
            get;
            set; 
        }

        public DateTime? StartDateTime { get; set; }
    }
}