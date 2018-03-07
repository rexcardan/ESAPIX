#region

using System.Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESAPIX.Facade.API;
using System;
using static VMS.TPS.Common.Model.Types.DoseValue;

#endregion

namespace ESAPIX.Facade.Tests
{
    [TestClass]
    public class ExpandoGetterTests
    {
        //[TestMethod]
        //public void GetClientTest()
        //{
        //    var offline = ESAPIX.OfflineObjects.Samples.GetProstatePlanSetup();
        //    var client = ExpandoGetter.GetClient(offline);
        //    client.Id = "TEST";
        //    Assert.IsNotNull((object) client);
        //    Assert.AreEqual(offline.Id, "TEST");
        //    Assert.IsTrue(client is ExpandoObject);
        //}

        //[TestMethod]
        //public void GetClientSetMethod()
        //{
        //    var offline = ESAPIX.OfflineObjects.Samples.GetProstatePlanSetup();
        //    var client = ExpandoGetter.GetClient(offline);
        //    client.GetDVHCumulativeData = new Func<API.Structure, VMS.TPS.Common.Model.Types.DoseValuePresentation, VMS.TPS.Common.Model.Types.VolumePresentation, double, API.DVHData>((s, dv, vp, bin) =>
        //    {
        //        return new DVHData() { MaxDose = new VMS.TPS.Common.Model.Types.DoseValue(25, DoseUnit.Gy) };
        //    });
        //    var dvh = offline.GetDVHCumulativeData(null, VMS.TPS.Common.Model.Types.DoseValuePresentation.Absolute, VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3, 10);
        //    Assert.AreEqual(dvh.MaxDose.Dose, 25);
        //}
    }
}