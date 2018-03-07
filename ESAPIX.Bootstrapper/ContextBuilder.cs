using ESAPIX.AppKit;
using ESAPIX.Facade;
using System;
using X = ESAPIX.Facade.API;

namespace ESAPIX.Bootstrapper
{
    public class ContextBuilder
    {
        public StandAloneContext GenerateContext(Func<VMS.TPS.Common.Model.API.Application> appFunc)
        {
            Exception e = null;
            if (appFunc == null)
            {
                throw new Exception("Must assign a function to create VMS app. Call SetAppFunction() prior to this.");
            }
            X.Application xApp = null;
            var thread = new AppComThread();
            thread.Invoke(() =>
            {
                var vms = appFunc();
                xApp = new X.Application(vms);
            });

            if (xApp == null)
                throw new Exception("App was not created. Check to make sure the VMS dll references are correct.", e);

            if (ExpandoGetter.GetClient(xApp) == null)
                throw new Exception(
                    "App was not created. Make sure FacadeInitializer.Initialize() in ESAPIX.Bootstrapper is being called before invoking static methods",
                    e);

            var sac = new StandAloneContext(xApp, thread);
            XContext.Instance.CurrentContext = new StandAloneContext(xApp, thread);
            return sac;
        }
    }
}

