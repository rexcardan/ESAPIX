using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Exceptions
{
    public class PatientNotFoundException : Exception
    {
        static string msg = "Could not find a patient with id {0} in the database";

        public PatientNotFoundException(string id) : base(string.Format(msg,id)) { }

        public override string Message
        {
            get
            {
                return msg;
            }
        }
    }
}
