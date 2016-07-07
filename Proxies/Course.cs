using System;
using System.Collections.Generic;
using System.Reflection;
using ESAPIX.Interfaces;


namespace ESAPIX.Proxies
{
    public class Course : ApiDataObject, ICourse
    {
        public string CompletedByUserName { get; set; }

        public DateTime? CompletedDateTime { get; set; }

        public IEnumerable<IPlanSetup> PlanSetups
        {
            get
            {
                return WrapEnumerable<PlanSetup>(MethodBase.GetCurrentMethod().Name.Substring(4)); 
            }
        }

        public IEnumerable<IPlanSum> PlanSums
        {
            get
            {
                return WrapEnumerable<PlanSum>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public DateTime? StartDateTime { get; set; }
    }
}