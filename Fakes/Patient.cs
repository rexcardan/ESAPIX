using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Interfaces;

namespace ESAPIX.Fakes
{
    public class Patient : IPatient
    {
        public string Id { get; set; }

        public string Id2 { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public IEnumerable<ICourse> Courses { get; set; }

        public IEnumerable<IStructureSet> StructureSets { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public string HistoryUserName { get; set; }

        public DateTime HistoryDateTime { get; set; }
    }
}
