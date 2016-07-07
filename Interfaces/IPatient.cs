using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIX.Interfaces
{
    public interface IPatient :IApiDataObject
    {
         string Id2 { get; }
         string FirstName { get;  }
         string MiddleName { get;  }
         string LastName { get;  }
         DateTime? DateOfBirth { get;  }

         IEnumerable<ICourse> Courses { get; }

         IEnumerable<IStructureSet> StructureSets { get;}
    }
}
