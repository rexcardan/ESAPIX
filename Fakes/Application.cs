using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using ESAPIX.Logging;
using ESAPIX.Interfaces;

namespace ESAPIX.Fakes
{
    public class Application : IApplication
    {
        public virtual IUser CurrentUser
        {
            get;
            set; 
        }

        public virtual IPatient OpenPatientById(string id)
        {
            throw new NotImplementedException();
        }

        public void LoadApp(string serialized)
        {
            throw new NotImplementedException();
        }

        public void SaveApp(string serialized)
        {
            throw new NotImplementedException();
        }
    }
}