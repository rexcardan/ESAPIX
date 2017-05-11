using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ESAPIX.Facade.API;
using ESAPIX.Facade.Serialization;
using ESAPIX.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ESAPIX.OfflineObjects;

namespace ESAPIX_TESTS.Helpers
{
    [TestClass]
    public class OfflineObjectsTests
    {
        [TestMethod]
        public void TestCanGetPlan()
        {
            var plan = Samples.GetProstatePlanSetup();
            var beams = plan.Beams.Count();
            Assert.AreEqual(beams, 7);
        }

    }
}
