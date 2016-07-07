using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Interfaces
{
    public interface IApplication 
    {
        IUser CurrentUser { get; }

        IPatient OpenPatientById(string id);
    }
}
