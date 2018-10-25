using ESAPIX.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var thread = AppComThread.Instance;
            thread.SetContext(() => VMS.TPS.Common.Model.API.Application.CreateApplication());
            thread.Execute(sac =>
            {
                sac.SetPatient("1311142");
                Console.WriteLine(sac.Patient.Name);
                var pat = sac.Patient;
                var first = pat.FirstName;
            });
            var name = thread.Get(sac =>
            {
                var pat = sac.Patient;
                return pat.Name;
            });

            var pat2 = thread.Get(sac =>
            {
                return sac.Patient;
            });

            thread.Execute(() => Console.WriteLine(pat2.Name));
            thread.Dispose();
            Console.Read();
        }
    }
}
