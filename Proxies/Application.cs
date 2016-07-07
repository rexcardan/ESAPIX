using System;
using System.Reflection;
using ESAPIX.Interfaces;
using System.Diagnostics;
using ESAPIX.Profiles;
using System.Threading.Tasks;

namespace ESAPIX.Proxies
{
    public class Application : VMSProxy, IApplication
    {
        public static Application CreateApplication(string username, string password)
        {
            //Configure automapper
            AutoMapper.Mapper.Initialize((cfg) =>
            {
                cfg.AddProfile<VMS136Profile>();
            });

            //Spin up VMS thread and create underlying application
            var vmsThread = new VmsComThread();
            var type = Type.GetType("VMS.TPS.Common.Model.API.Application, VMS.TPS.Common.Model.API");
            dynamic app = null;

            vmsThread.Invoke(() =>
            {
                app = type.GetMethod("CreateApplication").Invoke(null, new object[] { username, password });
            });

            //Emit proxy container
            var proxy = new Application() { VmsObject = app, VmsThread = vmsThread };
            return proxy;
        }

        public static async Task<Application> CreateApplicationAsync(string username, string password)
        {
            return await Task.Run(() => CreateApplication(username, password));
        }

        public IUser CurrentUser
        {
            get
            {
                return Wrap<User>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IPatient OpenPatientById(string id)
        {
            return InvokeAndWrap<Patient>(MethodBase.GetCurrentMethod().Name, id);
        }

        public void Dispose()
        {
            try
            {
                Invoke(MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
            IsDisposed = true;
        }

        public bool IsDisposed { get; private set; }

    }
}