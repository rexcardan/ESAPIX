using System;
using System.Collections.Generic;
using System.Reflection;
using ESAPIX.Interfaces;
using Newtonsoft.Json;

namespace ESAPIX.Proxies
{
    public class Patient : ApiDataObject, IPatient
    {
        public string Id2 { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [JsonIgnore]
        public IEnumerable<ICourse> Courses
        {
            get
            {
                var name = MethodBase.GetCurrentMethod().Name.Substring(4);
                return WrapEnumerable<Course>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IEnumerable<IStructureSet> StructureSets
        {
            get
            {
                return WrapEnumerable<StructureSet>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }
    }
}